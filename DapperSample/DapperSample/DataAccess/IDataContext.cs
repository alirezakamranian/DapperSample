using System.Data;

namespace DapperSample.DataAccess
{
    public interface IDataContext
    {
        public IDbConnection Db { get; set; }
    }
}
