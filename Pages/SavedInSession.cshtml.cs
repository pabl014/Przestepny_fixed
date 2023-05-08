using Przestepny_fixed.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Przestepny_fixed.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public Sesja Sesja_ { get; set; } = new Sesja();
        public void OnGet()
        {
            var Dane = HttpContext.Session.GetString("Dane"); // pobieranie danych z sesji
            if (Dane != null)
            {
                Sesja_ = JsonConvert.DeserializeObject<Sesja>(Dane);
                HttpContext.Session.SetString("Dane", JsonConvert.SerializeObject(Sesja_)); // zapis do sesji
            }
        }
    }
}
