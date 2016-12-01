using System.Web.Http;
using System.Web.Http.Results;
using OpenTokService.Models;
using OpenTokService.Interfaces;
using OpenTokSDK;
using System;

namespace OpenTokService.Controllers
{
    [RoutePrefix("api/OpenTok")]
    public class OpenTokController : ApiController
    {
        private readonly IOpenTokService _openTokService;
        public OpenTokController(IOpenTokService openTokService)
        {
            _openTokService = openTokService;
        }

        [Route("Session")]
        [HttpGet]
        [AllowAnonymous]
        public SessionModel Session()
        {
            return _openTokService.GetSessionInfo();
        }

        [Route("Start")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Start(SessionViewModel model)
        {
            Archive archive = _openTokService.GetOpenTok().StartArchive(model.SessionId);
            return Ok();
        }

        [Route("Stop")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Stop(ArchiveViewModel model)
        {
            Archive archive = _openTokService.GetOpenTok().StopArchive(model.ArchiveId);
            return Ok();
        }

        [Route("View")]
        [HttpPost]
        [AllowAnonymous]
        public string View(ArchiveViewModel model)
        {
            Archive archive = _openTokService.GetOpenTok().GetArchive(model.ArchiveId);
            return archive.Url;
        }

        [Route("Delete")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Delete(ArchiveViewModel model)
        {
            _openTokService.GetOpenTok().DeleteArchive(model.ArchiveId);
            return Ok();
        }
    }
}
