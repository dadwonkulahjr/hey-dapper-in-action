using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyDapper.WebUI.Pages.Company
{
    public class ListModel : PageModel
    {

        [TempData]
        public string Add { get; set; }
        [TempData]
        public string Updated { get; set; }
        public void OnGet()
        {
        }
    }
}
