using HeyDapper.WebUI.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyDapper.WebUI.Pages.Company
{
    public class UpsertModel : PageModel
    {
        private readonly ICompanyRepository _repository;

        [BindProperty]
        public Models.Company CompanyObj { get; set; }
        public UpsertModel(ICompanyRepository companyRepository)
        {
            _repository = companyRepository;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                CompanyObj = new();


                return Page();
            }
            else
            {
                if (id.HasValue)
                {
                   CompanyObj = _repository.Find(id.Value);


                    if (CompanyObj == null)
                    {
                        return NotFound("/NotFound/Index");
                    }
                    return Page();
                }
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }


            if (CompanyObj != null)
            {

                if (CompanyObj.CompanyId == 0)
                {
                    //Create new record
                    _repository.Add(CompanyObj);
                    TempData["Add"] = "Record was added successfully!";
                    return RedirectToPage("list");
                }
                else
                {
                    //Update existing record
                    var obj = _repository.Find(CompanyObj.CompanyId);

                    if (obj == null)
                    {
                        return NotFound("/NotFound/Index");
                    }

                    CompanyObj = _repository.Update(CompanyObj);
                    TempData["Updated"] = "Record updated successfully!";
                    return RedirectToPage("list");
                }

            }

            return Page();
        }
    }
}
