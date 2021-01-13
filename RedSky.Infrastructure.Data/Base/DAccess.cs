using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RedSky.Utilities;

namespace RedSky.Infrastructure.Data.Base
{
    public class DAccess
    {
        private readonly IDbConnection _dbConnection;

        private readonly Provider _dbProvider;

        private IDbCommand _dbCommand;

        private IDbTransaction _dbTransaction;

        protected DAccess(ConnectionStringSettings connString)
        {
            switch (connString.ProviderName)
            {
                case "System.Data.SqlClient":
                    _dbConnection = new SqlConnection(connString.ConnectionString);
                    _dbProvider = Provider.SqlClient;
                    break;
            }
        }

        private void Connect()
        {
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        private void Disconnect()
        {
            if (_dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();
        }

        private void AssignConnection()
        {
            if (_dbTransaction == null)
            {
                _dbCommand.Connection = _dbConnection;
            }
            else
            {
                _dbCommand.Transaction = _dbTransaction;
                _dbCommand.Connection = _dbTransaction.Connection;
            }

            Connect();
        }

        public bool TestConnection()
        {
            bool state;

            try
            {
                Connect();
                state = true;
            }
            catch
            {
                state = false;
            }
            finally
            {
                Disconnect();
            }

            return state;
        }

        public void BeginTransaction()
        {
            if (_dbConnection.State != ConnectionState.Open)
                Connect();

            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_dbTransaction != null)
                _dbTransaction.Commit();

            Disconnect();
            _dbTransaction = null;
        }

        public void RollbackTransaction()
        {
            if (_dbTransaction != null)
                _dbTransaction.Rollback();

            Disconnect();
            _dbTransaction = null;
        }

        private void InsertParameters(IDbCommand statement, IEnumerable<IDbDataParameter> lstParameters)
        {
            if (lstParameters == null)
                return;

            statement.Parameters.Clear();

            foreach (var objParameter in lstParameters)
                switch (_dbProvider)
                {
                    default:
                    case Provider.SqlClient:
                        statement.Parameters.Add(new SqlParameter(objParameter.ParameterName, objParameter.Value));
                        break;
                }
        }

        private void CreateCommand(CommandType type, string statement, IEnumerable<IDbDataParameter> lstParameters)
        {
            switch (_dbProvider)
            {
                default:
                case Provider.SqlClient:
                    _dbCommand = new SqlCommand(statement);
                    break;
            }

            _dbCommand.CommandTimeout = 0;
            _dbCommand.CommandType = type;

            InsertParameters(_dbCommand, lstParameters);
            AssignConnection();
        }

        protected IDataReader ExecuteReader(string statement, IEnumerable<IDbDataParameter> lstParameters = null,
            CommandType type = CommandType.Text)
        {
            CreateCommand(type, statement, lstParameters);
            var dtReader = _dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            _dbCommand.Dispose();
            return dtReader;
        }

        protected int ExecuteNonQuery(string statement, IEnumerable<IDbDataParameter> lstParameters,
            CommandType type = CommandType.Text)
        {
            CreateCommand(type, statement, lstParameters);
            var affectedRows = _dbCommand.ExecuteNonQuery();
            _dbCommand.Dispose();
            return affectedRows;
        }

        protected object ExecuteScalar(string statement, IEnumerable<IDbDataParameter> lstParameters = null,
            CommandType type = CommandType.Text)
        {
            CreateCommand(type, statement, lstParameters);
            var data = _dbCommand.ExecuteScalar();
            _dbCommand.Dispose();
            return data;
        }
    }
}