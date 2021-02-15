using System;

namespace GenericInheritance
{
  class BaseClass<T>
  {
    public virtual void MyMethod(T param) => Console.WriteLine($"Inside Base class: {param}");
  }

  class DerivedClass<T> : BaseClass<T>
  {
    public override void MyMethod(T param) => Console.WriteLine($"Inside Derived class: {param}");
  }
  class Program
  {
    static void Main(string[] args)
    {
      BaseClass<int> baseObj1 = new BaseClass<int>();
      baseObj1.MyMethod(25);

      BaseClass<float> baseObj2 = new DerivedClass<float>();
      baseObj2.MyMethod(30.05f);

      DerivedClass<string> derivedObj2 = new DerivedClass<string>();
      derivedObj2.MyMethod("35");

      DerivedClass<bool> derivedObj3 = new DerivedClass<bool>();
      (derivedObj3 as BaseClass<bool>)?.MyMethod(true);      
    }
  }
}
