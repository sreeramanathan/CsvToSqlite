using CsvHelper;
using System.IO;

namespace CDSImporter
{
	class CDSImporter
	{
		public static void Main (string[] args)
		{
			var csv = new CsvReader (File.OpenText (args [0]));
			csv.Read ();
			var sqliteTable = new SqliteTable(Path.GetFileNameWithoutExtension(args [0]), csv.FieldHeaders);
			do {
				sqliteTable.InsertData(csv.CurrentRecord);
			} while (csv.Read ());
		}
	}
}
