using System;
using System.Data.SQLite;

namespace CDSImporter
{
	public class SqliteTable
	{
		private string[] columns;

		private SQLiteConnection dbConnection;

		public SqliteTable (string name, string[] columns)
		{
			this.columns = columns;
			SQLiteConnection.CreateFile (String.Format ("{0}.sqlite", name));
			dbConnection = new SQLiteConnection (String.Format ("Data Source={0}.sqlite;Version=3;", name));
		}

		public bool Create ()
		{
			dbConnection.Open ();
			string sql = String.Format ("create table dataset ({0})", allColumns ());
			new SQLiteCommand (sql, dbConnection).ExecuteNonQuery ();
			dbConnection.Close ();
			return true;
		}

		public bool InsertData (string[] data)
		{
			dbConnection.Open ();
			string sql = String.Format ("insert into dataset ({0}) values ({1})", allColumns (), String.Join (",", data));
			new SQLiteCommand (sql, dbConnection).ExecuteNonQuery ();
			dbConnection.Close ();
			return true;
		}

		string allColumns ()
		{
			return String.Join (" TEXT,", this.columns);
		}
	}
}

