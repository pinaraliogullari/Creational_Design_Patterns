namespace Singleton_Design_Pattern_AspNetCore_Pratic.Services
{
	public class DatabaseService
	{
        //*****************singleton pattern part***************************
        private DatabaseService()
        {
            Console.WriteLine($"{nameof(DatabaseService)} is created");
        }

        private static DatabaseService _databaseService;
        public static DatabaseService GetInstance
        {
            get
            {
                if (_databaseService==null)
                    _databaseService = new DatabaseService();
                return _databaseService;
            }
        }

        //*******************************************************************
        //database operations

        public int Count { get; set; }
        public bool Connection()
        {
            Console.WriteLine("Bağlantı sağlandı");
            Count++;
            return true;
        }

        public bool Disconnect()
        {
            Console.WriteLine("Bağlantı koparıldı");
            return true;
        }

    }
}
