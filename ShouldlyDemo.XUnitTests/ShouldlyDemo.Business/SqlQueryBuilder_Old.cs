namespace ShouldlyDemo.Business;

public class SqlQueryBuilder_Old
{
    public string BuildQuery(string columns, string table, string where)
    {
        if (string.IsNullOrEmpty(columns)) columns = "*";

        if (string.IsNullOrEmpty(table))
            throw new Exception("No table selected");

        if (!string.IsNullOrEmpty(where)) where = $"WHERE {where}";

        string query = $"Select {columns} {table} {where}";

        return query;
    }
}
