
using System.Collections.Concurrent;
//Singleton pattern ile beraber.
//ObjectPool nesnesine global ve tekil olarak erişebilmek için singleton pattern ekledim.


ObjectPool<X> pools =  ObjectPool<X>.GetInstance;
var x1 = pools.Get(() => new X()); 
pools.Return(x1);

var x2 = pools.Get(() => new X());
pools.Return(x2);

Console.WriteLine();



class ObjectPool<T> where T : class
{
	readonly ConcurrentBag<T> _instances; 
	private ObjectPool()
		=>_instances = new();

	private static ObjectPool<T> _objectPool;
	static ObjectPool()
		=> _objectPool = new ObjectPool<T>();

	public static ObjectPool<T> GetInstance { get=> _objectPool; }
	public T Get(Func<T>? objectGenerator = null)
	{
	
		return _instances.TryTake(out T instance) ? instance : objectGenerator();
	}
	public void Return(T instance)
	{
		
		_instances.Add(instance);

	}
}
class X
{
	public int Count { get; set; }
	public void Write()
		=> Console.WriteLine(Count);
	public X()
		=> Console.WriteLine("X üretim maliyeti...");

	~X()
		=> Console.WriteLine("X imha maliyeti...");
}
