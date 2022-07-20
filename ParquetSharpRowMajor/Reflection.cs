using System;
using System.Collections.Generic;
using ParquetSharpRowMajor.Domain;

namespace ParquetSharpRowMajor
{
    public static class Reflection
    {
        public static IEnumerable<ColumnSetter> InspectType(Type type)
        {
            // Get the setters for the properties on the given type, along with the expected column name.
            foreach (var property in type.GetProperties())
            {
                if (property.CanWrite)
                {
                    var setter = property.SetMethod;

                    yield return new ColumnSetter() { ColumnName = property.Name, Setter = property.SetMethod };
                }
                else
                {
                    // Warn that we came across a property we can't set?
                }
            }
        }
    }
}