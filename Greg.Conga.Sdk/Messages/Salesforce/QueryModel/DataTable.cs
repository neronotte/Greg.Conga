using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
    public class DataTable : IReadOnlyList<DataRow>
	{
		public static DataTable From(QueryExpression query, IReadOnlyCollection<JObject> recordList, Action<string> log = null)
		{
			if (log == null) log = s => { };


			log("Analyzing columns structure");
			var extractors = query.Select.Select(x => new ColumnDataExtractor(x)).ToList();

			var i = 0;
			var result = new DataTable(query.Select);
			foreach (var record in recordList)
			{
				log($"Extracting data from record {++i} of {recordList.Count}");

				var item = new DataRow();
				foreach (var extractor in extractors)
				{
					item[extractor.ColumnName] = extractor.ExtractFrom(record);
				}
				result.rows.Add(item);
			}

			return result;
		}


		private readonly List<DataRow> rows = new List<DataRow>();

		private DataTable(IReadOnlyList<string> columns)
		{
			this.Columns = columns ?? throw new ArgumentNullException(nameof(columns));
		}

		public IReadOnlyList<string> Columns { get; }


		public object this[int rowIndex, string columnName]
		{
			get
			{
				if (rowIndex < 0 || rowIndex >= rows.Count)
					throw new ArgumentOutOfRangeException(nameof(rowIndex), $"{nameof(rowIndex)} should be between 0 and {rows.Count}");

				if (!Columns.Contains(columnName))
					throw new ArgumentOutOfRangeException(nameof(rowIndex), $"column <{columnName}> not present in the list");

				var row = rows[rowIndex];
				if (!row.TryGetValue(columnName, out var value)) return null;
				return value;
			}
		}


		public DataRow this[int rowIndex] => this.rows[rowIndex];


		public bool TryGet<T>(int rowIndex, string columnName, out T fieldValue)
		{
			fieldValue = default;

			if (rowIndex < 0 || rowIndex >= rows.Count)
				return false;

			if (!Columns.Contains(columnName))
				return false;

			var row = rows[rowIndex];
			if (!row.TryGetValue(columnName, out var value))
				return false;

			if (!(value is T typedValue))
				return false;

			fieldValue = typedValue;
			return true;
		}



		public int Count => this.rows.Count;


		public void AddData(DataTable table)
		{
			if (table == null)
				throw new ArgumentNullException(nameof(table));

			if (table.Columns.Count != this.Columns.Count)
				throw new ArgumentException("Table column count doesn't match", nameof(table));

			for (int i = 0; i < this.Columns.Count; i++)
			{
				if (table.Columns[i] != this.Columns[i])
					throw new ArgumentException($"Table column {i} doesn't match", nameof(table));
			}

			foreach (var row in table.rows)
			{
				this.rows.Add(row);
			}
		}

		public IEnumerator<DataRow> GetEnumerator()
		{
			return this.rows.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
