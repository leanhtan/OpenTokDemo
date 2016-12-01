using Newtonsoft.Json;
using OpenTokService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenTokApp.Controllers
{
    public class MainController : Controller
    {
        static HttpClient client = new HttpClient();

        public MainController()
        {
            if (client == null)
            {
                client.BaseAddress = new Uri("http://webapidev.nightingales.com.sg:8007/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        async Task<SessionModel> GetProductAsync(string path)
        {
            SessionModel sessionModel = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                sessionModel = JsonConvert.DeserializeObject<SessionModel>(data);
            }
            return sessionModel;
        }

        // GET: Main
        public async Task<ActionResult> Index()
        {
            var session = await GetProductAsync("http://webapidev.nightingales.com.sg:8007/api/OpenTok/Session");
            return View(session);
        }
    }
}