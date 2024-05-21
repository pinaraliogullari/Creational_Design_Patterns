
// 1) Classtan new operatörü ile nesne üretilmesini engellemek için constructorını private yaptım.
// 2) Artık New operatörü ile nesne üretilemeyecek ancak ilk instance ı talep edebilmek için static bir referans npktası alınır.
// 3)Instance talep edilirken kullanılacak olan member tanımlanır. Bu member bir metot veya property olabilir. Example classının nesne üretim sorumluluğu bu member tarafından üstlenilmiş olur.

Example ex = Example.GetInstance;
Example ex1 = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance; //sonucunda tek bir nesne oluşur diğer nesne taleplerinde ilk üretilen kullanılır.


#region 1. yöntem

class Example
{
	private Example()
	{
		Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
	}
	private static Example _example; //tekil instance ı tutacak referans
	public static Example GetInstance
	{
		get
		{
			if (_example == null)
				_example = new Example();
			return _example;
		}
	}
}
#endregion

#region 2. Yöntem
class Example2
{
	private Example2()
	{
		Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
	}

	static Example2()
	{
		_example2 = new Example2();
	}
	private static Example2 _example2; //tekil instance ı tutacak referans
	public static Example2 GetInstance
	{
		get { return _example2; } //bu yöntemde null kontrolü yapmıyoruz. eğer nesne yoksa direkt olarak static constructorda üretiliyor.
	}
}
#endregion


