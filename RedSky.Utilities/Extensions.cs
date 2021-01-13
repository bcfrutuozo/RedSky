using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace RedSky.Utilities
{
    /// <summary>
    ///     Constains methods to help object manipulation.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        ///     Creates an object based on the information inside the generic data reader.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="objReader">The data reader object which contains the data</param>
        /// <returns>Strongly typed object</returns>
        public static T CreateObject<T>(this IDataReader objReader)
            where T : new()
        {
            var obj = default(T);

            using (objReader)
            {
                while (objReader.Read())
                    obj = (T) Activator.CreateInstance(typeof(T), objReader);
                return obj;
            }
        }

        /// <summary>
        ///     Creates an object list based on the information inside the generic data reader.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="objReader">The data reader object which contains the data</param>
        /// <returns>Strongly typed object list</returns>
        public static IList<T> CreateObjectList<T>(this IDataReader objReader)
            where T : new()
        {
            IList<T> objList = new List<T>();

            using (objReader)
            {
                while (objReader.Read())
                    objList.Add((T) Activator.CreateInstance(typeof(T), objReader));
                return objList;
            }
        }

        /// <summary>
        ///     Creates an object list based on the information inside the generic data reader.
        /// </summary>
        /// <param name="objReader">The data reader object which contains the data</param>
        /// <returns>Strongly typed object list</returns>
        public static IEnumerable<dynamic> CreateDynamicObjectList(this IDataReader objReader)
        {
            using (objReader)
            {
                var columnNames = Enumerable.Range(0, objReader.FieldCount).Select(objReader.GetName).ToList();
                foreach (IDataRecord record in objReader as IEnumerable)
                {
                    var readerEntry = new ExpandoObject() as IDictionary<string, object>;
                    foreach (var name in columnNames)
                        readerEntry[name] = record[name];

                    yield return readerEntry;
                }
            }
        }

        /// <summary>
        ///     Gets the value of a certain column within the data reader.
        /// </summary>
        /// <typeparam name="T">Generic data type</typeparam>
        /// <param name="objRow">The data reader object which will invoke the method</param>
        /// <param name="columnName">Column name</param>
        /// <returns>Desired property from the chosen column</returns>
        public static T RetrieveValueFromColumn<T>(this IDataReader objRow, string columnName)
        {
            if (!DataReaderHasColumn(objRow, columnName) || objRow[columnName] == DBNull.Value && typeof(T).IsValueType)
                return default;

            // Get the converter type for the object
            var tcConverter = TypeDescriptor.GetConverter(typeof(T));

            // Returns the column data to the typed object property
            return
                (T)
                tcConverter.ConvertFrom(null, CultureInfo.CurrentCulture,
                    Convert.ToString(objRow[columnName], CultureInfo.CurrentCulture));
        }

        /// <summary>
        ///     Checks if the following datareader has a certain column.
        /// </summary>
        /// <param name="objReader">Datareader to be verified</param>
        /// <param name="columnName">Column name to search</param>
        /// <returns>True if the datareader has the column, otherwise false</returns>
        public static bool DataReaderHasColumn(IDataRecord objReader, string columnName)
        {
            for (var i = 0; i < objReader.FieldCount; i++)
                if (objReader.GetName(i).Equals(columnName))
                    return true;
            return false;
        }

        public static bool ValidateMSSQLConnection(this SqlConnection conn)
        {
            bool valid;

            try
            {
                conn.Open();
                conn.Close();
                valid = true;
            }
            catch
            {
                valid = false;
            }
            finally
            {
                conn.Dispose();
            }

            return valid;
        }
    }
}