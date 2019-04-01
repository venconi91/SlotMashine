namespace SlotMashine
{
  using System;

  public class ConsoleInputHandler : IInputHandler
  {
    public string ReadLine()
    {
      string input = Console.ReadLine();
      return input;
    }
  }
}
