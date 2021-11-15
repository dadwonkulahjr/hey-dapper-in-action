using HeyDapper.WebUI.Models;
using System.Collections.Generic;

namespace HeyDapper.WebUI.Services.Repository.IRepository
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> Get();
        Company Add(Company company);
        Company Update(Company company);
        Company Remove(Company company);
        Company Remove(int id);
        Company Find(int id);
    }
}
