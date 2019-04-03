namespace Tests
{
  using System.IO;
  using SlotMachine.Common;

  public class FileOutputHandler : IOutputHandler
  {
    public static readonly string OutputFilePath = "./output.txt";

    public FileOutputHandler()
    {
      using (File.Create(OutputFilePath))
      { }

    }

    public void Write(string text)
    {
      using (StreamWriter streamWriter = new StreamWriter(OutputFilePath, true))
      {
        streamWriter.Write(text);
      }
    }

    public void WriteLine(string text)
    {
      using (StreamWriter streamWriter = new StreamWriter(OutputFilePath, true))
      {
        streamWriter.WriteLine(text);
      }

    }

    public void WriteLine()
    {
      using (StreamWriter streamWriter = new StreamWriter(OutputFilePath, true))
      {
        streamWriter.WriteLine();
      }
    }
  }
}
