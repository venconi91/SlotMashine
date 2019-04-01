using System.Collections.Generic;

namespace SlotMachine.Common
{
  public class SlotMachineSettings
  {
    public int Rows { get; set; }
    public int Cols { get; set; }
    public IList<SlotMachineSymbolsSettings> SlotMachineSymbolsSettings { get; set; }
  }
}
