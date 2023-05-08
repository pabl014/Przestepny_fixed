using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Przestepny_fixed.Forms;

namespace Przestepny_fixed.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Przestepny_fixedForm FizzBuzz { get; set; }
		public Sesja Sesja { get; set; } = new Sesja();
        public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
        public IActionResult OnPost()
		{
			if(FizzBuzz != null)
			{
				var Dane = HttpContext.Session.GetString("Dane"); // pobieranie danych z sesji
				if (Dane != null)
				{
					Sesja = JsonConvert.DeserializeObject<Sesja>(Dane);
				}
				ViewData["Rok_przestepny_info"] = FizzBuzz.czy_przestepny();
				Sesja.Lista_przestepnych.Add(FizzBuzz);
				HttpContext.Session.SetString("Dane", JsonConvert.SerializeObject(Sesja)); // zapis do sesji
			}



			return Page();
        }

    }
}