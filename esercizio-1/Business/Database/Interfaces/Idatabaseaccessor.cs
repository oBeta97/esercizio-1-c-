using System.Data;

public interface Idatabaseaccessor
{
    public DataSet ExecuteSelectQuery(FormattableString query);

    public int ExecuteModifyQuery (FormattableString query);
}