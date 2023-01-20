using System.Collections.Concurrent;

class MyClass
{
    ConcurrentQueue<int> conQueue= new ConcurrentQueue<int>();
    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    public static ConcurrentQueue<int> statConQueue= new ConcurrentQueue<int>();
    public static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        foreach(var num in myClass.list)
        {
            myClass.conQueue.Enqueue(num);
        }
        myClass.Enumerate();
        try
        {
            Task.WaitAll(t1,t2);
        }
        catch (AggregateException e)
        {
            Console.WriteLine(e.Flatten().Message);
        }
       
    }

    private void Enumerate()
    {
        Console.WriteLine("Enumerating the Queue:\nRight now the elements are:");
        foreach (var item in this.conQueue)
        {
            Console.WriteLine(item);
        }
    }
    public static Task t1 = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 100; i++) 
        {
            statConQueue.Enqueue(i);
            Console.WriteLine("Enqueued "+i);
            Thread.Sleep(100);
            if(i%10==0)
            {
                Thread.Sleep(300);
            }
        }
    });

    public static Task t2 = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(8000);
        foreach (var item in statConQueue)
        {
            Console.WriteLine("Task-2: " + item);
            Thread.Sleep(100);
        }
    });
}