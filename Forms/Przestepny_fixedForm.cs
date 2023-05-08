using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Przestepny_fixed.Forms
{
	public class Przestepny_fixedForm
	{
		public int? Rok { get; set; }
		public string Imie { get; set; }

		public string czy_przestepny()
		{
			if ( (Rok % 4 == 0 && Rok % 100 != 0) || (Rok % 400 == 0 )) 
			{
				return "przestepny";
			}
			else
			{
				return "nieprzestepny";
			}
		}	
	}
} 
