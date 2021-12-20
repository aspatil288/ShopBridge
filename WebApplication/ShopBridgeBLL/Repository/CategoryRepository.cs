using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Utility;
using Utility.AESCrypto;
using Utility.DBFactory;

namespace ShopBridgeBLL.Repository
{
    public class CategoryRepository 
    {
        private DBProvider _context = new DBProvider();
        private DBController _db = new DBController();
        private DecryptValueUtility _decryptValueUtility = new DecryptValueUtility();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public int CreateCategory(string xmlData, string userId)
        {
            return _context.ExecuteNonQuery(SPConstant.USP_CRUD_CATEGORY, CommandType.StoredProcedure, CreateParameterList("cr", 0, xmlData, userId));
        }
        public int DeleteCategory(int categoryId, string userId)
        {
            return _context.ExecuteNonQuery(SPConstant.USP_CRUD_CATEGORY, CommandType.StoredProcedure, CreateParameterList("dl", categoryId, "", userId));
        }
        public DataTable GetAllCategories()
        {
            return _context.ExecuteDataTable(SPConstant.USP_CRUD_CATEGORY, CommandType.StoredProcedure, CreateParameterList("dl", 0, "", ""));
        }
        public List<DbParameter> CreateParameterList(string flag, int categoryId, string xmlData, string userId)
        {
            try
            {
                List<DbParameter> parameters = new List<DbParameter>()
                {
                    _db.CreateParameter("ip_flag", flag, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_category_id", categoryId, DbType.Int32, ParameterDirection.Input),
                    _db.CreateParameter("ip_xml", xmlData, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_userid", _decryptValueUtility.GetDecryptValue(userId), DbType.Int32, ParameterDirection.Input)
                };
                return parameters;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
