
//1) Ortak arayüz sınıfını oluşturuyor ve concrete Productlara bu arayüzü implemente ediyoruz.
//2) Nesnelerin üretimini üstlenecek yardımcı sınıfı oluşturuyoruz. (Creator)

while (true)
{
	for (int i = 0; i < 100; i++)
	{
		try
		{
			//burada factory design pattern ile nesneyi ihtiyaç olduğu noktada üretmek yerine yalnızca istedik.
			A? a=ProductCreator.GetInstance(ProductType.A) as A;
			a.Run();

			B? b= ProductCreator.GetInstance(ProductType.B) as B;
			b.Run();
		}
		catch (Exception ex)
		{

			throw;
		}
	}	
}


#region Abstract Product


interface IProduct
{
	void Run();
}
#endregion


#region Concrete Products
class A : IProduct
{
    public A()
    {
        Console.WriteLine($"{nameof(A)} is created.");
    }
    public void Run()
	{
		throw new NotImplementedException();
	}
}

class B : IProduct
{
    public B()
    {
		Console.WriteLine($"{nameof(A)} is created.");
	}
    public void Run()
	{
		throw new NotImplementedException();
	}
}

class C : IProduct
{
    public C()
    {
		Console.WriteLine($"{nameof(A)} is created.");
	}
    public void Run()
	{
		throw new NotImplementedException();
	}
}

#endregion

#region Abstract Factory- Factory Method Design Pattern
interface IFactory
{
  IProduct CreateProduct();
}
#endregion

#region Concrete Factory-Factory Method Design Pattern
class AFactory : IFactory
{
	public IProduct CreateProduct()
	{
		A a = new A();
		return a;
	}
}
class BFactory : IFactory
{
	public IProduct CreateProduct()
	{
		B b = new B();
		return b;
	}
}
class CFactory : IFactory
{
	public IProduct CreateProduct()
	{
		C c = new C();
		return c;
	}
}
#endregion
#region ProductCreator

enum ProductType
{
	A,B,C
}
class ProductCreator
{
	//creator sınıfı kendisinden talep edilen nesneyi döndürecek bir metota ihtiyaç duyuyor. 
	//Metodun dönüş tipi tüm nesneleri karşılayacak bir tip olmak zorunda olduğundan; IProduct
	//Metoda parametre olarak enum veriyoruz.
	//Metoda yukarıdan kolayca erişebilmek için static yaptım. Zorunlu değil

	public static IProduct GetInstance(ProductType productType)
	{
		IProduct _product = null;
		switch (productType)
		{
			case ProductType.A:
				_product = new A();
				//....
				break;
			case ProductType.B:
				_product = new B();
				//....
				break;
			case ProductType.C:
				_product = new C();
				//....
				break;
		
		}
		return _product;
		#region Factory MEthod Design Pattern
		//IFactory _factory = productType switch
		//{
		//	ProductType.A => new AFactory(),
		//	ProductType.B => new BFactory(),
		//	ProductType.C => new CFactory(),
		//};
		//return _factory.CreateProduct();
		#endregion

	}
}
#endregion