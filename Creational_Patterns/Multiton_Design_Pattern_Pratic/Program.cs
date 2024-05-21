
// Private constructor
// oluşacak sınırlı sayıdaki instance ı depolamak üzere static bir koleksiyon
// Kullanıcının nesne talebinde bulunacağı member. Bu member singletonda property veya metot olabiliyordu ancak multiton design patternda mutlaka metot olmalı. Çünkü geriye dönülecek instanceın hangi instance olduğu metot içine verilecek key parametresi ile belirlenecek.

var msSql = Database.GetInstance("MSSQL");
var oracle = Database.GetInstance("Oracle");
var mongoDB = Database.GetInstance("MongoDB");

//aşağıdaki nesneler zaten var olduklarından dolayı oluşmayacaktır.
var msSql2 = Database.GetInstance("MSSQL");
var oracle2 = Database.GetInstance("Oracle");
var mongoDB2 = Database.GetInstance("MongoDB");
class Database
{
    private Database()
    {
        Console.WriteLine($"{nameof(Database)} instance is created");
    }


    //private static Database _database;
    private static Dictionary<string,Database> _databases=new();

    public static Database GetInstance(string key)
    {
        if (!_databases.ContainsKey(key))
            _databases[key]=new Database();
        return _databases[key];
    }
    
}