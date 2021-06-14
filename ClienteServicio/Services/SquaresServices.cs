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
    public partial class SquaresServices
    {
        private String url = "https://sleepy-spire-92662.herokuapp.com/api/square";
        private HttpClient client;

        public SquaresServices(HttpClient client)
        {
            this.client = client;
        }

        public async Task<dynamic> ListSquares()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                String responseBody = await response.Content.ReadAsStringAsync();
                List<Square> list = JsonConvert.DeserializeObject<List<Square>>(responseBody);
                return list;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }

        public async Task<dynamic> CreateSquares(Cuadrado cuadrado)
        {
            try
            {

                var content =JsonConvert.SerializeObject(cuadrado);
                HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, httpContent);
                String responseBody = await response.Content.ReadAsStringAsync();
                Square persistedObj = JsonConvert.DeserializeObject<Square>(responseBody);
                return persistedObj;
            }
            catch(HttpRequestException e)
            {
                return e.Message;
            }
        }

    }
}
