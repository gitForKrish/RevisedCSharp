using System;

namespace EventHandling
{
  class Sender
  {
    private int myInt;
    public int MyInt
    {
      get { return myInt; }
      set
      {
        myInt = value;
        OnMyIntChanged();
      }
    }
    public event EventHandler MyIntChanged; // EventHandler is system inbuilt delegate
    public void OnMyIntChanged()
    {
      if (MyIntChanged != null)
        MyIntChanged(this, EventArgs.Empty);
    }
    public void GetNotificationItself(object obj, EventArgs args) => Console.WriteLine($"From Sender: MyInt has changed its value to  {MyInt}.");
  }

  class Receiver
  {
    public void GetNotificationFromSender(object obj, EventArgs args)
    {
      var sender = obj as Sender;
      Console.WriteLine($"From Receiver: MyInt has changed its value to {sender.MyInt}");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Sender sender = new Sender();
      Receiver receiver = new Receiver();

      sender.MyIntChanged += sender.GetNotificationItself;
      sender.MyIntChanged += receiver.GetNotificationFromSender;

      sender.MyInt = 10;
      sender.MyInt = 20;

      sender.MyIntChanged -= receiver.GetNotificationFromSender;
      sender.MyInt = 30;
    }
  }
}
