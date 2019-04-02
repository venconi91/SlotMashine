namespace Tests
{
  using SlotMachine.Common;
  using System.IO;

  public class FileInputHandler : IInputHandler
  {
    private string InputFileName = "input.txt";
    private StreamReader streamReader;

    public FileInputHandler()
    {
      streamReader = new StreamReader($"./{InputFileName}");
    }

    public string ReadLine()
    {
        string line = streamReader.ReadLine();
        System.Console.WriteLine(line);
        return line;
    }
  }
}
