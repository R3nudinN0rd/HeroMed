using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System;
using System.IO;
using HeroMed_API.Helpers;
namespace HeroMed_API.Controllers.Reporting
{
    [ApiController]
    [Route("/api/Reporting")]
    [EnableCors("AllowOrigins")]
    public class ReportingController:ControllerBase
    {

        [HttpGet]
        public ActionResult DownloadReportAsPDF(string reportName, Guid? patientId )
        {
            return Ok(ReportDownloader.GenerateSSRSReport(reportName, patientId).Result);
        }


    }
}
