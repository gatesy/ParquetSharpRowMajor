# ParquetSharpRowMajor design

Parquet is stored in a column major format.
We regularly deal with systems that take tuples of data, such as the values of a load of signals.
When running these systems offline, we inject data from or output data to a data frame, usually a Parquet file.
This means that we don't want to see column major data, just row major data.

## What sort of API could we have?
* One where we provide a struct type for our values and populate it for each row.

## And the implmementation to serve this API?
* Back this by an efficent reading of columns that can be tweaked between reading the whole row group and read the next n bytes.
* Special features for time series data, such as checking its valid (time doesn't go backwards) and de-multiplexing time series data from multiple sources.

