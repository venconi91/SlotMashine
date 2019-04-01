namespace SlotMashine
{
  using System.Collections.Generic;

  public interface IUserHandler
  {
    decimal RequestDepositAmount();
    decimal RequestStakeAmount();
    void ShowSymbols(IEnumerable<IEnumerable<Symbol>> symbols);
    void ShowWinning(decimal profit);
    void ShowLoss();
  }
}
