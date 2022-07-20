using System;
using NUnit.Framework;
using ParquetSharp;

namespace ParquetSharpRowMajor.Test
{
    [TestFixture]
    public class ReaderBuilderTests
    {
        [Test]
        public void Test()
        {
            using var parquetReader = new ParquetFileReader("data/test01.parquet");
            var rowMajorReader = new RowMajorReader<Row>(parquetReader);
            
            //Console.Out.WriteLine($"Total rows: {rowMajorReader.RowCount}");
            
            
            //var timestampProv = rowMajorReader.GetColumnProv<DateTime>("timestamp");
            //var countProv = rowMajorReader.GetColumnProv<int>("count");
            //var valueProv = rowMajorReader.GetColumnProv<double>("value");

            //rowMajorReader.NextRow();
            
        }
    }

    public struct Row
    {
        public DateTime Timestamp;
    }
}