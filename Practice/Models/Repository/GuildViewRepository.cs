using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Practice.Models.Repository
{

    public interface IGuildViewer
    {
        SearchResult GetSqlResult(string sql);
    }

    public class GuildViewRepository : IGuildViewer
    {
        public SearchResult GetSqlResult(string sql)
        {
            using (var con = new GuildDBContext().Database.Connection)
            {
                var dbData = EachReader(con, sql);

                var result = new SearchResult { Result = new List<Tuple<string, List<object>>>(), SumDic = new Dictionary<int, decimal>() };

                var intCols = new List<int>();
                var decimalCols = new List<int>();

                foreach (var item in dbData)
                {
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        if (item.FieldCount > result.Result.Count)
                        {

                            if (item.GetFieldType(i) == typeof(int)) { intCols.Add(i); }
                            else if (item.GetFieldType(i) == typeof(decimal)) { decimalCols.Add(i); }

                            result.Result.Add(Tuple.Create(item.GetName(i), new List<object> { item[i] }));
                        }
                        else
                        {
                            result.Result[i].Item2.Add(item[i]);
                        }

                    }
                }

                foreach (var item in intCols)
                {
                    result.SumDic[item] = result.Result[item].Item2.OfType<int>().Sum();
                }
                foreach (var item in decimalCols)
                {
                    result.SumDic[item] = result.Result[item].Item2.OfType<decimal>().Sum();
                }

                return result;
            }
        }

        static IEnumerable<IDataRecord> EachReader(IDbConnection connection, string query)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                if (connection.State != ConnectionState.Open) connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (!reader.IsClosed && reader.Read()) yield return reader;
                }
            }
        }
    }
}