//Database msSQL = new();
//msSQL.Connection = new();
//msSQL.Connection.ConnectionString = "...";
//msSQL.Command = new();

//var result=msSQL.Connection.Connect();
//if (result && msSQL.Connection.State==ConnectionState.Open)
//{
//	msSQL.Command.Execute("Select * from ...");
//}
//msSQL.Connection.Disconnect();


DatabaseCreator creator = new();
Database database=creator.Create(new OracleDatabaseFactory());
enum DatabaseType
{
	Oracle,
	MsSql,
	MySql,
	PostgreSql
}
enum ConnectionState
{
	Open, Close
}
class Database
{
    public Database()  {  }
    public Database(DatabaseType type, Connection connection, Command command)
	{
		Type = type;
		Connection = connection;
		Command = command;
	}

	public DatabaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }

}

//Abstract Product
abstract class AbstractConnection
{
	public abstract string ConnectionString { get; set; }
	public abstract ConnectionState State { get; set; }
	public abstract bool Connect();
	public abstract bool Disconnect();
}

//Abstract Product
abstract class AbstractCommand
{
	public abstract void Execute(string query);
}

//Concrete Product
class Connection:AbstractConnection
{
	string _connectionString;
	public Connection() { }
	public Connection(string connectionString)
		=>_connectionString = connectionString;
	public override string ConnectionString { get => _connectionString; set => _connectionString = value; }

    public override ConnectionState State { get; set; }
	public override bool Connect()
	{
		//.....işlemler yürütülüyor..
		State = ConnectionState.Open;
		return true;
	}

	public override bool Disconnect()
	{
		//....işlemler yürütülüyor...
		State = ConnectionState.Close;
		return true;
	}
	
}

//Concrete Product
class Command :AbstractCommand
{
	public override void Execute(string query)
	{
		//executing...
	}
}

//Abstract Factory
abstract class DataBaseFactory
{
	public abstract AbstractConnection CreateConnection();
	public abstract AbstractCommand CreateCommand();
}

//Concrete Factory

class MsSqlDatabaseFactory : DataBaseFactory
{
	public override AbstractCommand CreateCommand()
	{
		Command cmd = new Command();
		return cmd;
	}

	public override AbstractConnection CreateConnection()
	{
		Connection conn = new Connection();
		conn.ConnectionString = "MSSQL coennection string";
		return conn;
	}
}

class OracleDatabaseFactory : DataBaseFactory
{
	public override AbstractCommand CreateCommand()
	{
		Command cmd = new Command();
		return cmd;
	}

	public override AbstractConnection CreateConnection()
	{
		Connection conn = new Connection();
		conn.ConnectionString = "Oracle coennection string";
		return conn;
	}
}
class MySqlDatabaseFactory : DataBaseFactory
{
	public override AbstractCommand CreateCommand()
	{
		Command cmd = new Command();
		return cmd;
	}

	public override AbstractConnection CreateConnection()
	{
		Connection conn = new Connection();
		conn.ConnectionString = "MySQL coennection string";
		return conn;
	}
}
class PostgreSqlDatabaseFactory : DataBaseFactory
{
	public override AbstractCommand CreateCommand()
	{
		Command cmd = new Command();
		return cmd;
	}

	public override AbstractConnection CreateConnection()
	{
		Connection conn = new Connection();
		conn.ConnectionString = "PostgreSql coennection string";
		return conn;
	}
}

//Creator

class DatabaseCreator
{
	AbstractConnection _connection;
	AbstractCommand _command;

	public  Database Create(DataBaseFactory databaseFactory)
	{
		_connection=databaseFactory.CreateConnection();
		_command=databaseFactory.CreateCommand();
		return new()
		{
			Command = _command,
			Connection = _connection,
			@Type = (DatabaseType)Enum.Parse(typeof(Database), databaseFactory.GetType().Name.Replace("DatabaseFactory", ""))
		};
		
	}
}