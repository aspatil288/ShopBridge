
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Utility;
using Utility.DBFactory;

namespace ShopBridgeBLL.Repository
{
    public class UserRepository 
    {
        private DBProvider _context = new DBProvider();
        private DBController _db = new DBController();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public int AuthenticateUser(string userName, string password)
        {
            try
            {
                List<DbParameter> parameters = new List<DbParameter>()
                {
                    _db.CreateParameter("ip_username", userName, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_password", password, DbType.String, ParameterDirection.Input)
                };
                return Convert.ToInt32(_context.ExecuteScalar(SPConstant.USP_AUTHENTICATE_USER, CommandType.StoredProcedure, parameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
