using System.Linq;
using ParquetSharp;
using ParquetSharp.Schema;

namespace ParquetSharpRowMajor
{
    public static class Schema
    {
        public static void GetInfo(SchemaDescriptor schema, string columnName)
        {
            var (node, index) = schema.GroupNode.Fields
                .Select((node, i) => (node, i))
                .First(node => node.node.Name == columnName);

            if (node is PrimitiveNode)
            {
                node as Pr
            }
        }
    }
}