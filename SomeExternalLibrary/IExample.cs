namespace SomeExternalLibrary;

public interface IExample
{
    /// <summary>
    /// Do some stuff synchronously
    /// </summary>
    /// <param name="input">Data model</param>
    void DoStuff(int input);

    /// <summary>
    /// Do some stuff asynchronously
    /// </summary>
    /// <param name="input">Data model</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DoStuffAsync(int input, CancellationToken cancellationToken = default);

    /// <summary>
    /// Do some stuff synchronously and return something
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    int DoStuffAndReturnSomething(int input);

    /// <summary>
    /// Do some stuff asynchronously and return something
    /// </summary>
    /// <param name="input">Data model</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> DoStuffAndReturnSomethingAsync(int input, CancellationToken cancellationToken = default);

    /// <summary>
    /// Block Example
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    int BlockExample(int input);

    /// <summary>
    /// Block Example Async
    /// </summary>
    /// <param name="input"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> BlockExampleAsync(int input, CancellationToken cancellationToken = default);

    /// <summary>
    /// Demonstrate multiple tasks
    /// </summary>
    /// <param name="input"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> MultipleTasksAsync(int input, CancellationToken cancellationToken = default);
}