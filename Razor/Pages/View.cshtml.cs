using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Models;
using RestSharp;

namespace Razor.Pages
{
    public class ViewModel : PageModel
    {
        public void OnGet(int id = 0)
        {
            try
            {
                var client = new RestClient("https://localhost:32774/");
                var request = new RestRequest($"conta/{id}");
                var response = client.ExecuteGet(request);

                Conta contas = Newtonsoft.Json.JsonConvert.DeserializeObject<Conta>(response.Content);

                TempData["contasOne"] = contas;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
