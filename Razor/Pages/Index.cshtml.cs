using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Text.Json;
using RestSharp;
using Razor.Models;

namespace Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id = 0)
        {
            string Baseurl = "http://192.168.1.228:32774/conta";

            try
            {
                var client = new RestClient("https://localhost:32774/");
                var request = id == 0 ? new RestRequest("conta") : new RestRequest($"conta/{id}");
                var response = client.ExecuteGet(request);

                List<Conta> contas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Conta>>(response.Content);

                if (id == 0)
                {
                    TempData["contas"] = contas;
                }
                else
                {
                    TempData["contasOne"] = contas;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void OnPostDelete(int id)
        {
            try
            {
                var client = new RestClient("https://localhost:32774/");
                var request = new RestRequest($"conta/{id}");
                var response = client.Delete(request);

                OnGet();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void OnPostPut(int id)
        {

        }

    }
}