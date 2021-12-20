using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Utility;
using Utility.AESCrypto;
using Utility.DBFactory;

namespace ShopBridgeBLL.Repository
{
    public class InventoryRepository 
    {
        private DBProvider _context = new DBProvider();
        private DBController _db = new DBController();
        private DecryptValueUtility _decryptValueUtility = new DecryptValueUtility();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public int AddProduct(string xmlData, string imageXml, string userId)
        {
            return _context.ExecuteNonQuery(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("cr", 0, 0, xmlData, imageXml, userId));
        }
        public int UpdateProduct(int inventoryId, string xmlData, string imageXml, string userId)
        {
            return _context.ExecuteNonQuery(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("up", inventoryId, 0, xmlData, imageXml, userId));
        }
        public int DeleteProduct(int inventoryId,string userId)
        {
            return _context.ExecuteNonQuery(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("dl", inventoryId, 0, "", "", userId));
        }
        public DataTable GetProductById(int inventoryId)
        {
            return _context.ExecuteDataTable(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("gibi", inventoryId, 0, "", "", ""));
        }
        public DataTable GetProductByCategory(int categoryId)
        {
            return _context.ExecuteDataTable(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("gibc", 0, categoryId, "", "", ""));
        }
        public DataTable GetAllItems()
        {
            return _context.ExecuteDataTable(SPConstant.USP_CRUD_INVENTORY, CommandType.StoredProcedure, CreateParameterList("gai", 0, 0, "", "", ""));
        }
        public List<DbParameter> CreateParameterList(string flag , int inventoryId, int categoryId, string xmlData, string imageXml, string userId)
        {
            try
            {
                List<DbParameter> parameters = new List<DbParameter>()
                {
                    _db.CreateParameter("ip_flag", flag, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_inventory_id", inventoryId, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_category_id", categoryId, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_xml", xmlData, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_map_image_xml", imageXml, DbType.String, ParameterDirection.Input),
                    _db.CreateParameter("ip_userid", _decryptValueUtility.GetDecryptValue(userId), DbType.String, ParameterDirection.Input)
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
