using OpenTokService.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace OpenTokService.Services
{
    public class HttpClientService : IHttpClientService
    {
        public HttpClient client { get; set; }
        public HttpClientService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["API_URI"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient GetClient()
        {
            return client;
        }
    }
}