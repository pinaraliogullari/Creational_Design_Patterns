



//GarantiBank garantiBank = new("asd", "123");
//garantiBank.ConnectGaranti();


//VakifBank vakifBank = new(new() { UserCode = "gncy", Mail = "gncy@gencayyildiz.com" }, "123");
//bool result = vakifBank.ValidateCredential();
//if (result)
//{
//    //...
//}

//HalkBank halkBank = new("gncy");
//halkBank.Password = "123";

BankCreator bankCreator = new();
GarantiBank? garanti = bankCreator.Create(BankType.Garanti) as GarantiBank;
VakifBank? vakifBank= bankCreator.Create(BankType.VakifBank) as VakifBank;
HalkBank? halkBank=bankCreator.Create(BankType.Halkbank) as HalkBank;

//singleton design pattern kullandıktan sonra 2. taleplerde de ilk oluşturulan nesne kullanılmış oldu.
GarantiBank? garanti2 = bankCreator.Create(BankType.Garanti) as GarantiBank;
VakifBank? vakifBank2 = bankCreator.Create(BankType.VakifBank) as VakifBank;
HalkBank? halkBank2 = bankCreator.Create(BankType.Halkbank) as HalkBank;




//Factory method design pattern kullanmaya karar vermeden önce ; bizim üzerinde çalıştığımız birden fazla nesne bir nesne grubu olarak tek kategoride tanımlanabiliyor mu diye kontrol etmeliyiz. 
#region Abstract Product
interface IBank
{
	//bu interface in amacı;patterna bu interface i implemente eden sınıfların tek bir kategoride tanımlanabilir olduğunu söylemek.
	//Yani bu interfacei implemente etmeye classların nesneleri yardımcı sınıf tarafından üretilemez.
}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
	string _userCode, _password;
	private GarantiBank(string userCode, string password)
	{
		Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
		_userCode = userCode;
		_password = password;
	}
	private static GarantiBank _garantiBank;

	static GarantiBank() => _garantiBank = new("asd","123");
	public static GarantiBank GetInstance=> _garantiBank;
	
	public void ConnectGaranti()
		=> Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
	public void SendMoney(int amount)
		=> Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
	string _userCode, _password;
	private HalkBank(string userCode)
	{
		Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
		_userCode = userCode;
	}
	private static HalkBank _halkBank;
	static HalkBank() => _halkBank = new("xyz");
	public static HalkBank GetInstance=> _halkBank;
	public  string Password { set => _password = value; }

	public void Send(int amount, string accountNumber)
		=> Console.WriteLine($"{amount} money sent.");
}

class CredentialVakifBank
{
	public string UserCode { get; set; }
	public string Mail { get; set; }
}
class VakifBank : IBank
{
	string _userCode, _email, _password;
	public bool isAuthentcation { get; set; }
	private VakifBank(CredentialVakifBank credential, string password)
	{
		Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
		_userCode = credential.UserCode;
		_email = credential.Mail;
		_password = password;
	}

	private static VakifBank _vakifBank;
	static VakifBank() => _vakifBank = new(new() { Mail = "aliogullari@gmail.com", UserCode = "pnr" }, "123");
	public static VakifBank GetInstance=> _vakifBank;
	public void ValidateCredential()
	{
		if (true) //validating
			isAuthentcation = true;
	}

	public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
		=> Console.WriteLine($"{amount} money sent.");
}
#endregion

#region Abstract Factory
interface IBankFactory
{
	IBank CreateInstance();
}
#endregion

#region Concrete Factories
class GarantiFactory : IBankFactory
{
    private GarantiFactory() { }
	static GarantiFactory()=>_garantiFactory=new();
	private static GarantiFactory _garantiFactory;
	public static GarantiFactory GetInstance => _garantiFactory;
    public IBank CreateInstance()
	{
		GarantiBank garanti = GarantiBank.GetInstance;
		garanti.ConnectGaranti();
		return garanti;
	}
}

class HalkBankFactory : IBankFactory
{
    public HalkBankFactory() { }
	static HalkBankFactory() => _halkBankFactory = new();
	private static HalkBankFactory _halkBankFactory;
	public static HalkBankFactory GetInstance => _halkBankFactory;
    public IBank CreateInstance()
	{
		HalkBank halkBank = HalkBank.GetInstance;
		halkBank.Password = "123456";
		return halkBank;
	}
}

class VakifBankFactory : IBankFactory
{
	private VakifBankFactory() { }
	static VakifBankFactory() => _vakifBankFactory = new();
	private static VakifBankFactory _vakifBankFactory;
	public static VakifBankFactory GetInstance => _vakifBankFactory;
	
	public IBank CreateInstance()
	{
		VakifBank vakifBank = VakifBank.GetInstance;
		vakifBank.ValidateCredential();
		return vakifBank;
	}
}
#endregion

#region Creator
enum BankType
{
	Garanti,Halkbank,VakifBank
}
class BankCreator
{
	public IBank Create(BankType bankType)
	{
		IBankFactory _bankFactory = bankType switch
		{
			BankType.VakifBank => VakifBankFactory.GetInstance,
			BankType.Halkbank => HalkBankFactory.GetInstance,
			BankType.Garanti=>GarantiFactory.GetInstance
		};
		return _bankFactory.CreateInstance();
	}
}
#endregion