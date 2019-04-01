namespace SlotMashine
{
  using System.Collections.Generic;

  public interface ISlotMachine
  {
    IEnumerable<IEnumerable<Symbol>> Spin(decimal stakeAmount);
  }
}
