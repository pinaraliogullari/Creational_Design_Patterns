
//asenkron süreçlerde bir sınıf her ne kadar singleton olarak tasarlanmış olsa da o sınıftan birden fazla nesne üretilebilme imkanı var. Çünkü asenkron süreçlerde bir GetInstance ın sonucu dönmeden diğer GetInstance lar devreye girebilir. Yani bir t zamanında bir getInstance henüz nesne üretme aşamasına gelmeden diğer GetInstance da o aşamaya gelebilir. Yani eş zamanlı gidildiği için birden fazla GetInstance example ın null olduğu aşamaya denk gelmiş olabilir.
//Böyle bir durumda GetInstance propertysi veya metodunun asenkrın süreçte olup olmadığı kontrol edilir. Önlem olarak lock işlemi yapılır. Lock yani kitleme sayesinde ;GetInstance propertysi kaç tane asenkron metot tarafından çağırılırsa çağrılsın, ilk çağıran için property kitlenir ve nesne üretilir, diğerleri de artık bu nesneyi kullanır. Yani artık asenkron süreçte üretilen birden fazla nesne durumu söz konusu olmayacaktır. veya direkt ilk nesne static constructor ile üretilirse bu sorun hiç yaşanmamış olur. Bu sebeple öngöremediğimiz asenkron yapılanma sorunlarına karşı 2. yöntemi(Static const) kullanamak daha sağlıklı olacaktır.

var t1 = Task.Run(() =>
{
    Example ex = Example.GetInstance;
});
var t2 = Task.Run(() =>
{
	Example ex = Example.GetInstance;
});

await Task.WhenAll(t1, t2);
var t3 = Task.Run(() =>
{
	Example ex = Example.GetInstance;
});
var t4 = Task.Run(() =>
{
	Example ex = Example.GetInstance;
});
await Task.WhenAll(t3, t4);

/*********************FOR STATIC CONST EXAMPLE******************************/
var t5 = Task.Run(() =>
{
	Example2 ex = Example2.GetInstance;
});
var t6 = Task.Run(() =>
{
	Example2 ex = Example2.GetInstance;
});

await Task.WhenAll(t5, t6);
var t7 = Task.Run(() =>
{
	Example2 ex = Example2.GetInstance;
});
var t8 = Task.Run(() =>
{
	Example2 ex = Example2.GetInstance;
});
await Task.WhenAll(t7, t8);

/*********************FOR STATIC CONST EXAMPLE******************************/


#region Null control
class Example
{
	private Example()
	{
		Console.WriteLine($"{nameof(Example)} is created");
	}

	private static Example _example;
	private static object _obj = new object();

	public static Example GetInstance
	{
		get
		{
			lock (_obj)
			{
				if (_example == null)
					_example = new Example();
			}

			return _example;
		}
	}


}
#endregion


#region Static Const ile

class Example2
{
	private Example2()
	{
		Console.WriteLine($"{nameof(Example)} is created");
	}
	static Example2()
	{
		_example2 = new Example2();
	}

	private static Example2 _example2;

	public static Example2 GetInstance
	{
		get { return _example2; }
	}
}
#endregion





