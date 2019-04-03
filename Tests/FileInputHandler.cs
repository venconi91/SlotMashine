namespace Tests
{
  using SlotMachine.Common;
  using System.IO;

  public class FileInputHandler : IInputHandler
  {
    public static readonly string InputFilePath = "./input.txt";
    private string[] allInputLines = File.ReadAllLines(InputFilePath);
    private int currentLine = 0;

    public string ReadLine()
    {
        string line = allInputLines[currentLine];
        currentLine += 1;
        return line;
    }
  }
}
