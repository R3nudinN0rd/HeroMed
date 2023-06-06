using ServiceReference1;
using System.Net;
using System.ServiceModel;

namespace HeroMed_API.Helpers 
{ 
    public class ReportDownloader
    {
        const string SSRSUsername = "SSRS_Service";
        const string SSRSPassword = "admin";
        const string SSRSReportExecutionUrl = "http://DESKTOP-2SOS0I4/ReportServer/ReportExecution2005.asmx?wsdl";
        const string SSRSFolderPath = "Reports";

        public async static Task<byte[]> GenerateSSRSReport(string ReportName, Guid? patientIdValue)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.MaxReceivedMessageSize = 1485760; //10MB limit
            binding.TextEncoding = System.Text.Encoding.UTF8;
            binding.TransferMode = TransferMode.StreamedResponse;
            //Create the execution service SOAP Client
            var rsExec = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(SSRSReportExecutionUrl));
            //Setup access credentials.
            var clientCredentials = new NetworkCredential(SSRSUsername, SSRSPassword, "DESKTOP-2SOS0I4");

            if (rsExec.ClientCredentials != null) 
            { 
                rsExec.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                NetworkCredential credentials = new NetworkCredential(SSRSUsername, SSRSPassword);
                rsExec.ClientCredentials.Windows.ClientCredential = credentials;
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
            return null;
        }
    }
}
