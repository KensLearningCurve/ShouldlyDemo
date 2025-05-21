namespace ShouldlyDemo.Business;

public class SqlQueryBuilder
{
    private string _select;
    private string _from;
    private string _where;

    public SqlQueryBuilder Select(string columns)
    {
        if (string.IsNullOrEmpty(columns)) columns = "*";

        _select = $"SELECT {columns}";
        return this;
    }

    public SqlQueryBuilder From(string table)
    {
        _from = $"FROM {table}";
        return this;
    }

    public SqlQueryBuilder Where(string condition)
    {
        _where = $"WHERE {condition}";
        return this;
    }

    public string Build()
    {
        return $"{_select} {_from} {_where};";
    }
}
