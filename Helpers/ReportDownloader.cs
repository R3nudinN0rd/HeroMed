using ServiceReference1;
using System.Net;
using System.ServiceModel;

namespace HeroMed_API.Helpers
{
    public class ReportDownloader
    {
        const string SSRSUsername = "HeroMedSSRS";
        const string SSRSPassword = "admin";
        const string SSRSReportExecutionUrl = "http://EN1311605/ReportServer/ReportExecution2010.asmx?wsdl";
        const string SSRSFolderPath = "Reports";

        public async static Task<byte[]> GenerateSSRSReport(string ReportName, Guid? patientIdValue)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            binding.MaxReceivedMessageSize = 10485760; //10MB limit

            //Create the execution service SOAP Client
            var rsExec = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(SSRSReportExecutionUrl));
            //Setup access credentials.
            var clientCredentials = new NetworkCredential(SSRSUsername, SSRSPassword, ".");

            if (rsExec.ClientCredentials != null)
            {
                rsExec.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                rsExec.ClientCredentials.Windows.ClientCredential = clientCredentials;
                if (patientIdValue != null)
                {
                    ParameterValue[] parameters = new ParameterValue[1];
                    parameters[0] = new ParameterValue();
                    parameters[0].Name = "patientId";
                    parameters[0].Value = patientIdValue.ToString();

                    await rsExec.SetExecutionParametersAsync(null, null, parameters, "en-us");
                }
                else
                {
                    await rsExec.SetExecutionParametersAsync(null, null, null, "en-us");
                }
            }

            //This handles the problem of "Missing session identifier"
            rsExec.Endpoint.EndpointBehaviors.Add(new ReportingServicesEndpointBehavior());

            await rsExec.LoadReportAsync(null, "/" + SSRSFolderPath + "/" + ReportName, null);

            //run the report
            const string deviceInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
            var response = await rsExec.RenderAsync(new RenderRequest(null, null, "PDF", deviceInfo));

            //spit out the result
            var byteResults = response.Result;

            return byteResults;
        }
    }
}
