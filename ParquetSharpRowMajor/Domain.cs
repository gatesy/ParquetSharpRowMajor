using System.Reflection;

namespace ParquetSharpRowMajor.Domain
{
    public class ColumnSetter
    {
        public MethodInfo Setter;
        public string ColumnName;
    }
}