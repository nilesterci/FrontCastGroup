using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Models;
using RestSharp;

namespace Razor.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Conta Conta { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var client = new RestClient("https://localhost:32774/");
                var request = new RestRequest("conta");
                request.AddBody(new
                {
                    name = Conta.Name,
                    description = Conta.Description
                });
                var response = client.ExecutePost(request);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
