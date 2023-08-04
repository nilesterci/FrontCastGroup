using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Models;
using RestSharp;

namespace Razor.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Conta Conta { get; set; }
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

        public async Task<IActionResult> OnPost(int id)
        {
            try
            {
                var client = new RestClient("https://localhost:32774/");
                var request = new RestRequest($"conta/{id}");
                request.AddBody(new
                {
                    name = Conta.Name,
                    description = Conta.Description
                });
                var response = client.ExecutePut(request);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
