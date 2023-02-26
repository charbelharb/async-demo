namespace SomeExternalLibrary;

public class Example : IExample
{
    public void DoStuff(int input)
    {
        Console.WriteLine($"Hello From Example.DoStuff, input is {input}");
        for (var i = 0; i < input; i++)
        {
            Console.WriteLine($"DoStuff: We are at iteration {i}");
            Thread.Sleep(i*1000);
        }
    }

    public async Task DoStuffAsync(int input, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Hello From Example.DoStuffAsync");
        await Task.Run(() =>
        {
            for (var i = 0; i < input; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Operation Cancelled");
                    break;
                }
                Console.WriteLine($"DoStuffAsync: We are at iteration {i}");
                Thread.Sleep(i*1000);
            }
        }, cancellationToken).ConfigureAwait(false);
    }

    public int DoStuffAndReturnSomething(int input)
    {
        Console.WriteLine($"Hello From Example.DoStuffAndReturnSomething, input is {input}");
        for (var i = 0; i < input; i++)
        {
            Console.WriteLine($"DoStuffAndReturnSomething: We are at iteration {i}");
            Thread.Sleep(i*1000);
        }
        return input;
    }

    public async Task<int> DoStuffAndReturnSomethingAsync(int input,
        CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            int i;
            for (i = 0; i < input; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Operation Cancelled");
                    break;
                }
                Console.WriteLine($"We are at iteration {i}");
                Thread.Sleep(i*1000);
            }
            return i;
        }, cancellationToken).ConfigureAwait(false);
    }

    public int BlockExample(int input)
    {
        Thread.Sleep(input * 1000);
        return input;
    }

    public async Task<int> BlockExampleAsync(int input, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            Thread.Sleep(input);
            return input;
        }, cancellationToken);
    }
}