namespace SlotMachine.Common
{
  public interface IOutputHandler
  {
    void WriteLine(string text);
    void WriteLine();
    void Write(string text);
  }
}
