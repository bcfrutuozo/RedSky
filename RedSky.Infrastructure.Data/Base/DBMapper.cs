using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RedSky.Domain.Entities;

namespace RedSky.Infrastructure.Data.Base
{
    public class DBMapper : DAccess
    {
        public DBMapper(ConexaoBanco connString)
            : base(connString.ConnectionString)
        {
        }

        public DataTable Query(string query, DateTime dataInicial, DateTime dataFinal)
        {
            List<IDbDataParameter> lstParameters = null;

            if (query.Contains("@DATAINICIAL") && query.Contains("@DATAFINAL"))
                lstParameters = new List<IDbDataParameter>
                {
                    new SqlParameter("@DATAINICIAL", dataInicial),
                    new SqlParameter("@DATAFINAL", dataFinal)
                };
            else if (query.Contains(@"DATAINICIAL") && !query.Contains("DATAFINAL"))
                lstParameters = new List<IDbDataParameter>
                {
                    new SqlParameter("@DATAINICIAL", dataInicial)
                };
            else if (!query.Contains(@"DATAINICIAL") && query.Contains("DATAFINAL"))
                lstParameters = new List<IDbDataParameter>
                {
                    new SqlParameter("@DATAFINAL", dataFinal)
                };

            var dt = new DataTable();
            dt.Load(ExecuteReader(query, lstParameters));
            return dt;
        }
    }
}