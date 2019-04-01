namespace SlotMashine
{
  using System;

  public class ConsoleOutputHandler : IOutputHandler
  {
    public void Write(string text)
    {
      Console.Write(text);
    }

    public void WriteLine(string text)
    {
      Console.WriteLine(text);
    }
  }
}
