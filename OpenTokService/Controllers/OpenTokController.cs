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

        [Route("DeleteAll")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult DeleteAll()
        {
            var archiveList = _openTokService.GetOpenTok().ListArchives();
            foreach (var archive in archiveList)
            {
                if (archive.Status == ArchiveStatus.AVAILABLE)
                {
                    Delete(new ArchiveViewModel { ArchiveId = archive.Id.ToString() });
                }
            }
            return Ok();
        }

        [Route("StopAll")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult StopAll()
        {
            try
            {
                var archiveList = _openTokService.GetOpenTok().ListArchives();
                foreach (var archive in archiveList)
                {
                    if (archive.Status == ArchiveStatus.STARTED || archive.Status == ArchiveStatus.PAUSED)
                    {
                        Stop(new ArchiveViewModel { ArchiveId = archive.Id.ToString() });
                    }
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
