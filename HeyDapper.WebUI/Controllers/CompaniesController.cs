using HeyDapper.WebUI.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HeyDapper.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _repository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            _repository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repository.Get()
                                .Select(x => new
                                {
                                    id = x.CompanyId,
                                    name = x.Name,
                                    address = x.Address,
                                    city = x.City,
                                    state = x.State,
                                    postCode = x.PostalCode
                                }).OrderBy(x => x.name)
                                .ToList();

            return Json(new { data = list });
        }

        [HttpDelete(template:"{id}")]
        public IActionResult Delete(int id)
        {
            var findCompany = _repository.Find(id);

            if(findCompany != null)
            {
                _repository.Remove(findCompany);
                return Json(new { success = true, message = "Delete successful!"});
            }
            else
            {
                return Json(new { success = false, message = "Error in deleting record." });
            }
        }
    }
}
