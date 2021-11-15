using Dapper;
using HeyDapper.WebUI.Models;
using HeyDapper.WebUI.Services.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HeyDapper.WebUI.Services.Repository
{
    public class DapperRepository : ICompanyRepository
    {
        private readonly IDbConnection _dbConnection;
        public DapperRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            var sql = "INSERT INTO Companies(Name, Address, City, State, PostalCode) Values(@Name, @Address, @City, @State, @PostalCode) SELECT Cast(SCOPE_IDENTITY() as int)";

            var id = _dbConnection.Query<int>(sql, company).FirstOrDefault();
            company.CompanyId = id;
            return company;
        }
        public Company Find(int id)
        {
            var sqlCommand = "SELECT * FROM Companies Where CompanyId = @CompanyId";
            return _dbConnection.Query<Company>(sqlCommand, new { @companyId = id }).FirstOrDefault();
        }
        public IEnumerable<Company> Get()
        {
            var sqlCommand = "SELECT * FROM Companies";
            return _dbConnection.Query<Company>(sqlCommand).ToList();
        }
        public Company Remove(Company company)
        {
            var sql = "DELETE FROM Companies Where CompanyId = @CompanyId";
            _dbConnection.Execute(sql, new { company.CompanyId });
            return company;
        }
        public Company Remove(int id)
        {
            return Remove(id);
        }
        public Company Update(Company company)
        {
            var sql = "Update Companies SET Name = @Name, Address = @Address, City = @City, State = @State, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";


            _dbConnection.Execute(sql, company);
            return company;
        }
    }
}
