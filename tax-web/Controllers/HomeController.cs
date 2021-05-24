using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using tax_web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
 
namespace tax_web.Controllers
{
    public class HomeController : Controller
    {
        private string apiBase = @"https://localhost:5001/api";
        public async Task<ActionResult<TaxCalculation>> Index()
        {
            List<TaxCalculation> calculationList = new List<TaxCalculation>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBase + "/taxcalculations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    calculationList = JsonConvert.DeserializeObject<List<TaxCalculation>>(apiResponse);
                }
            }
            return View(calculationList);
        }

        public ViewResult NewTaxCalculation() => View();
        [HttpPost]
        public async Task<IActionResult> NewTaxCalculation(TaxCalculation taxCalculation)
        {
            TaxCalculation returnTaxCalculation = new TaxCalculation();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(taxCalculation), Encoding.UTF8, "application/json");
 
                using (var response = await httpClient.PostAsync(apiBase + "/taxcalculations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnTaxCalculation = JsonConvert.DeserializeObject<TaxCalculation>(apiResponse);
                }
            }
            return View(returnTaxCalculation);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}