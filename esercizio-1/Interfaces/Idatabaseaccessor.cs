using System.Data;

public interface Idatabaseaccessor
{
    public DataSet Query(string query);
}