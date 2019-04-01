namespace SlotMachine.Common
{
  using System.Collections.Generic;

  public class SlotMachine : ISlotMachine
  {
    private IReel reel;

    public SlotMachine(IReel reel)
    {
      this.reel = reel;
    }

    public IEnumerable<IEnumerable<Symbol>> Spin(decimal stakeAmount)
    {
      IEnumerable<IEnumerable<Symbol>> symbols = reel.Spin();

      return symbols;
    }
  }
}
