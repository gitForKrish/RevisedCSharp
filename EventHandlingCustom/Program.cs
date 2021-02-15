using System;
using static System.Console;

namespace EventHandlingCustom
{
  // User defined delegate for handling event
  public delegate void MyIntChangedEventHandler(object obj, EventArgs eventArgs);

  class Sender
  {
    public event MyIntChangedEventHandler MyIntChanged;

    private int myInt;
    public int MyInt
    {
      get
      {
        return myInt;
      }
      set
      {
        myInt = value;
        OnMyIntChanged();
      }
    }
    protected virtual void OnMyIntChanged() // One of the best practice to make this method as protected virtual
    {
      if (MyIntChanged != null)
        MyIntChanged(this, EventArgs.Empty);
    }
  }

  class Receiver1
  {
    public void GetNotificationFromSender(object obj, EventArgs eventArgs)
      => WriteLine($"From Receiver 1: Value change notification is received... New Value = {(obj as Sender)?.MyInt}");
  }
  class Receiver2
  {
    public void GetNotificationFromSender(object obj, EventArgs eventArgs)
      => WriteLine($"From Receiver 2: Value change notification is received... New Value = {(obj as Sender)?.MyInt}");
  }

  class Program
  {
    static void Main(string[] args)
    {
      Sender sender = new Sender();
      Receiver1 receiver1 = new Receiver1();
      Receiver2 receiver2 = new Receiver2();

      // Subcribing to an event of value change
      sender.MyIntChanged += receiver1.GetNotificationFromSender;
      sender.MyIntChanged += receiver2.GetNotificationFromSender;

      sender.MyInt = 10; // This will trigger the event 

      // Removing subscription from Receiver 1
      sender.MyIntChanged -= receiver1.GetNotificationFromSender;

      sender.MyInt = 20; // This will again trigger the event 

      // Removing all the subscription
      sender.MyIntChanged -= receiver2.GetNotificationFromSender;

      sender.MyInt = 30; // This will again trigger the event but no receiver are available 
    }
  }
}
