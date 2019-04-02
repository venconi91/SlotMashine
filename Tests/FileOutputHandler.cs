namespace Tests
{
    using System.IO;
    using SlotMachine.Common;
    public class FileOutputHandler : IOutputHandler
    {
        private string InputFileName = "output.txt";
        private StreamWriter streamWriter;

        public FileOutputHandler()
        {
            streamWriter = new StreamWriter($"./{InputFileName}");
        }
      
        public void Write(string text)
        {
            streamWriter.Write(text);
        }

        public void WriteLine(string text)
        {
            streamWriter.WriteLine(text);
        }
    }
}
