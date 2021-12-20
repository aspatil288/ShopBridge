using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.DBFactory
{
    public class DBController
    {
        public DbParameter CreateParameter(string name, object value, DbType dbType,ParameterDirection parameterDirection)
        {
            MySqlParameter param = null;
            try
            {
                param = new MySqlParameter();
                param.Value = value;
                param.ParameterName = name;
                param.DbType = dbType;
                param.Direction = parameterDirection;
                return param;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
