using Newtonsoft.Json;
using OpenTokService.Interfaces;
using OpenTokService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenTokService.Controllers
{
    public class OpenTokAppController : Controller
    {
        readonly IHttpClientService _httpClientService;
        readonly IOpenTokService _openTokService;
        public OpenTokAppController(IHttpClientService httpClientService, IOpenTokService openTokService)
        {
            _httpClientService = httpClientService;
            _openTokService = openTokService;
        }

        async Task<SessionModel> GetProductAsync(string path)
        {
            SessionModel sessionModel = null;
            HttpResponseMessage response = await _httpClientService.GetClient().GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                sessionModel = JsonConvert.DeserializeObject<SessionModel>(data);
            }
            return sessionModel;
        }

        // GET: OpenTokApp
        public ActionResult Index()
        {
            var session = _openTokService.GetSessionInfo();
            return View(session);
        }

        public ActionResult Old()
        {
            var session = _openTokService.GetSessionInfo();
            return View(session);
        }
    }
}