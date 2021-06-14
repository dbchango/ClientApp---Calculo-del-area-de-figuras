using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ClienteServicio.Models;

namespace ClienteServicio.Services
{
    public partial class TrianglesServices
    {
        private String url = "https://triangles182.herokuapp.com/api/triangle/";
        private HttpClient client;

        public TrianglesServices(HttpClient client)
        {
            this.client = client;
        }

        public async Task<dynamic> ListTriangles()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync(url + "list");
                response.EnsureSuccessStatusCode();
                String responseBody = await response.Content.ReadAsStringAsync();
                List<Triangle> list = JsonConvert.DeserializeObject<List<Triangle>>(responseBody);
                return list;
            }catch(HttpRequestException e)
            {
                return e.Message;
            }
        }

        public async Task<dynamic> CreateTriangle(Triangle triangle)
        {
            try
            {
                var content = JsonConvert.SerializeObject(triangle);
                HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url + "save", httpContent);
                String responseBody = await response.Content.ReadAsStringAsync();
                Triangle persistedObj = JsonConvert.DeserializeObject<Triangle>(responseBody);
                return persistedObj;
            }
            catch(HttpRequestException e)
            {
                return e.Message;
            }
        }

    }
}
