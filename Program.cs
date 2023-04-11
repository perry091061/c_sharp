// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static ConcurrentStack<Action> taskStack = new ConcurrentStack<Action>();

    static void Main(string[] args)
    {
        // Add some tasks to the task stack
        taskStack.Push(() => Console.WriteLine("Task 1"));
        taskStack.Push(() => Console.WriteLine("Task 2"));
        taskStack.Push(() => Console.WriteLine("Task 3"));

        // Execute tasks using Task.ContinueWith()
        Action lastTask = null;
        while (!taskStack.IsEmpty)
        {
            Action task;
            if (taskStack.TryPop(out task))
            {
                Task.Run(() => task()).ContinueWith(previousTask => lastTask = previousTask.Result);
            }
            else
            {
                break;
            }
        }

        // Wait for the last task to complete
        lastTask?.Invoke();
    }
}

 

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static ConcurrentStack<int> stack = new ConcurrentStack<int>();

    static async Task ProcessStackAsync()
    {
        while (true)
        {
            if (stack.TryPop(out int item))
            {
                await ProcessItemAsync(item);
            }
            else
            {
                await Task.Delay(100); // Wait for new items
            }
        }
    }

    static async Task ProcessItemAsync(int item)
    {
        Console.WriteLine($"Processing item {item}...");
        await Task.Delay(1000); // Simulate work
        Console.WriteLine($"Item {item} processed.");
    }

    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }

        Task.Run(() => ProcessStackAsync()).Wait(); // Wait for the loop to complete
    }
}
