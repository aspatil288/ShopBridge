using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Utility.DBFactory
{
    public class DBProvider
    {
        private MySqlConnection _dbConnection = null;
        private MySqlCommand _dbCommand = null;
        private MySqlDataAdapter _dbDataAdapter = null;
        private static XMLUtility _GetXML = new XMLUtility();
        private static CommonUtility _Common = new CommonUtility();

        public void CreateDbConnection()
        {
            string constrng = "";
             constrng = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            _dbConnection = new MySqlConnection(constrng);
        }
        public void CreateDbCommand(String sqlQuery, CommandType commandType, IList<DbParameter> parameters, int commandTimeout = 0)
        {
            _dbCommand = new MySqlCommand();
            _dbCommand.CommandType = commandType;
            _dbCommand.CommandText = sqlQuery;
            _dbCommand.CommandTimeout = commandTimeout;
            _dbCommand.Connection = _dbConnection;
            if (parameters != null)
            {
                _dbCommand.Parameters.AddRange(parameters.AsEnumerable().ToArray());
            }
        }

        public DataSet ExecuteDataSet(String sqlQuery, CommandType commandType, IList<DbParameter> parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                CreateDbConnection();
                using (_dbConnection)
                {
                    using (_dbCommand)
                    {
                        // Create the adapter
                        _dbConnection.Open();
                        CreateDbCommand(sqlQuery, commandType, parameters, 0);
                        using (_dbCommand)
                        {
                            // Create the adapter
                            _dbDataAdapter = new MySqlDataAdapter();
                            using (_dbDataAdapter)
                            {
                                _dbDataAdapter.SelectCommand = _dbCommand;
                                _dbDataAdapter.Fill(ds);
                            }
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex) // Changed
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public DataTable ExecuteDataTable(String sqlQuery, CommandType commandType, IList<DbParameter> parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                CreateDbConnection();

                using (_dbConnection)
                {
                    _dbConnection.Open();
                    CreateDbCommand(sqlQuery, commandType, parameters, 0);
                    using (_dbCommand)
                    {
                        // Create the adapter
                        _dbDataAdapter = new MySqlDataAdapter();
                        using (_dbDataAdapter)
                        {
                            _dbDataAdapter.SelectCommand = _dbCommand;
                            _dbDataAdapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex) // Changed
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public object ExecuteScalar(String sqlQuery, CommandType commandType, IList<DbParameter> parameters)
        {
            try
            {
                CreateDbConnection();
                using (_dbConnection)
                {
                    _dbConnection.Open();
                    CreateDbCommand(sqlQuery, commandType, parameters, 0);
                    using (_dbCommand)
                    {
                        object value = _dbCommand.ExecuteScalar();
                        return value;
                    }
                }
            }
            catch (Exception ex)  // Changed
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public DateTime ExecuteScalarDateTime(String sqlQuery, CommandType commandType, IList<DbParameter> parameters)
        {
            try
            {
                CreateDbConnection();

                using (_dbConnection)
                {
                    _dbConnection.Open();
                    CreateDbCommand(sqlQuery, commandType, parameters, 0);
                    using (_dbCommand)
                    {
                        object value = _dbCommand.ExecuteScalar();
                        return Convert.ToDateTime(value);
                    }
                }
            }
            catch (Exception ex)  // Changed
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public int ExecuteNonQuery(string sqlQuery, CommandType commandType, IList<DbParameter> parameters)
        {
            try
            {
                int rowsAffected = 0;
                CreateDbConnection();

                using (_dbConnection)
                {
                    _dbConnection.Open();
                    CreateDbCommand(sqlQuery, commandType, parameters, 0);
                    using (_dbCommand)
                    {
                        rowsAffected = _dbCommand.ExecuteNonQuery();
                    }
                }
                return rowsAffected;
            }
            catch (Exception ex)//changed
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }

        public static DbParameter CreateParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            DbParameter param = null;
            try
            {
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
            finally
            {
                param = null;
            }
        }


    }
}
