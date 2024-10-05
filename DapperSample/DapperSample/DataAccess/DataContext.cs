using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.SqlClient;

namespace DapperSample.DataAccess
{
    public class DataContext : IDataContext
    {
        public IDbConnection Db { get; set; } = new SqlConnection(
            "Server = localhost; Database=DapperSample ;User Id = SA; Password=12230500o90P;TrustServerCertificate=True");
    }
}
