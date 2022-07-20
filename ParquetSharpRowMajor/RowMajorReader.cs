using System;
using System.Collections.Generic;
using System.Linq;
using ParquetSharp;
using ParquetSharp.Schema;

namespace ParquetSharpRowMajor
{
    public class RowMajorReader
    {
        public static bool TryReadRowGroup(
            ParquetFileReader parquetFileReader,
            int rowGroup, 
            out RowGroupReader rowGroupReader)
        {
            if (parquetFileReader.FileMetaData.NumRowGroups >= rowGroup)
            {
                rowGroupReader = null;
                return false;
            }

            rowGroupReader = parquetFileReader.RowGroup(rowGroup);
            return true;
        }
    }
    
    public class RowMajorReader<T> : RowMajorReader where T : new()
    {
        private readonly ParquetFileReader _parquetFileReader;
        private int _currentRowGroupIndex = -1;
        private RowGroupReader _currentRowGroup = null;
        private Dictionary<int, Action<T>> _setters;
        

        public RowMajorReader(ParquetFileReader parquetFileReader)
        {
            _parquetFileReader = parquetFileReader;
        }

        private bool TryReadNextRow()
        {
            if (_currentRowGroupIndex == -1)
            {
                ++_currentRowGroupIndex;
                TryReadRowGroup(_parquetFileReader, _currentRowGroupIndex, out _currentRowGroup);
            }

            if (_currentRowGroup == null)
            {
                return false;
            }
            
            
        }
        
        public T NextRow()
        {
            // Make a new T
            var row = new T();

            // Call all the MethodInfos that correspond to T's setters on it.
            
        }

        private static void GetColumns(SchemaDescriptor schema)
        {
            
            // For each field in the type we're mapping to, look for a column that we can use.
            foreach (var property in typeof(T).GetProperties())
            {
                var candidateColumns = schema.GroupNode.Fields.Select((node, i) => (node, i)).Where(nodeAndIndex => nodeAndIndex.node.Name == property.Name);

                if (candidateColumns.Count() > 1)
                {
                    throw new Exception("More than one candidate column");
                }
                
                else if (candidateColumns.Count() == 0)
                {
                    throw new Exception("Column not found");
                }
                else
                {
                    property.SetMethod
                }
            }
            
            
            var rootFields = schema.GroupNode.Fields;

            for (int i = 0; i < rootFields.Length; ++i)
            {
                var node = rootFields[i];
                if (node is PrimitiveNode)
                {
                    
                }
            }
        }
        
    }
}