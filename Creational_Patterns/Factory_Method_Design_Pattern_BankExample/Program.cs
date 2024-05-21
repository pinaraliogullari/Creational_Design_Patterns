



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
	public GarantiBank(string userCode, string password)
	{
		Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
		_userCode = userCode;
		_password = password;
	}

	public void ConnectGaranti()
		=> Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
	public void SendMoney(int amount)
		=> Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
	string _userCode, _password;
	public HalkBank(string userCode)
	{
		Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
		_userCode = userCode;
	}

	public string Password { set => _password = value; }

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
	public VakifBank(CredentialVakifBank credential, string password)
	{
		Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
		_userCode = credential.UserCode;
		_email = credential.Mail;
		_password = password;
	}
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
	public IBank CreateInstance()
	{
		GarantiBank garanti = new("asd", "123");
		garanti.ConnectGaranti();
		return garanti;
	}
}

class HalkBankFactory : IBankFactory
{
	public IBank CreateInstance()
	{
		HalkBank halkBank = new("xyz");
		halkBank.Password = "123456";
		return halkBank;
	}
}

class VakifBankFactory : IBankFactory
{
	public IBank CreateInstance()
	{
		VakifBank vakifBank = new(new() { Mail = "aliogullari@gmail.com", UserCode = "pnr" }, "123");
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
			BankType.VakifBank => new VakifBankFactory(),
			BankType.Halkbank => new HalkBankFactory(),
			BankType.Garanti=>new GarantiFactory()
		};
		return _bankFactory.CreateInstance();
	}
}
#endregion