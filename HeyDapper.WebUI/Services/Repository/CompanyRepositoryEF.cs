using HeyDapper.WebUI.Data;
using HeyDapper.WebUI.Models;
using HeyDapper.WebUI.Services.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace HeyDapper.WebUI.Services.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepositoryEF(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public Company Add(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.CompanyId == id);
        }

        public IEnumerable<Company> Get()
        {
            return _context.Companies.ToList();
        }

        public Company Remove(Company company)
        {
            return Remove(company.CompanyId);
        }

        public Company Remove(int id)
        {
            var find = _context.Companies.FirstOrDefault(x => x.CompanyId == id);
            if (find != null)
            {
                _context.Companies.Remove(find);
                _context.SaveChanges();
                return find;
            }

            return null;
        }

        public Company Update(Company company)
        {
            var findCompany = _context.Companies.FirstOrDefault(x => x.CompanyId == company.CompanyId);

            if (findCompany != null)
            {
                findCompany.Name = company.Name;
                findCompany.Address = company.Address;
                findCompany.City = company.City;
                findCompany.PostalCode = company.PostalCode;
                findCompany.State = company.State;
                _context.SaveChanges();
            }
           

            return company;
        }
    }
}
