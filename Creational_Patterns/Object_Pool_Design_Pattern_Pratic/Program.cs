
using System.Collections.Concurrent;
// Öbcelikle tüm sınıflardan nesneleri havuzuna alabilecek kabiliyete sahip bir generic bir class oluşturmalıyız.
//Daha sonra bu classın içine istediğimiz nesneyi verebilecek bir metot, verdiğimiz nesneyi havuza ekleyecek bir metot ve bir de bu havuzu temsil eden bir koleksiyon eklemeliyiz.


ObjectPool<X> pools= new ObjectPool<X>();
var x1=pools.Get(() => new X()); //havuzda x1 nesnesi varsa getir. yoksa get fonskiyonunun iindeki expressiona verilip üretilecek.
//....
pools.Return(x1);// işimiz bittikten sonra x1 i havuza bırakıyoruz.

var x2= pools.Get(() => new X());
pools.Return(x2);

Console.WriteLine();


//tasarladığımız class
class ObjectPool<T> where T : class
{
    readonly ConcurrentBag<T> _instances; //pool
    public ObjectPool()
    {
		_instances = new();
    }
    public T Get(Func<T>? objectGenerator=null)
    {
        //havuzdan generic parametrede bildirilen türdeki nesneyi geri döndürmek.
        return _instances.TryTake(out T instance)? instance:objectGenerator();
    }
    public void Return (T instance)
    {
        //havuzdan ödünç alınan nesneyi geri iade etmek.
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
