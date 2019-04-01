namespace SlotMachine.Common
{
  using System.Collections.Generic;

  public class SlotGame : IGame
  {
    private bool isFinished = false;
    private IPlayer currentPlayer;
    private IUserHandler userHandler;
    private ISlotMachine slotMachine;

    public SlotGame(IPlayer player, IUserHandler userHandler, ISlotMachine slotMachine)
    {
      this.currentPlayer = player;
      this.userHandler = userHandler;
      this.slotMachine = slotMachine;
    }

    public void Start()
    {
      userHandler.RequestDepositAmount();
      while (!isFinished)
      {
        decimal stakeAmount = userHandler.RequestStakeAmount();
        currentPlayer.Balance -= stakeAmount;

        IEnumerable<IEnumerable<Symbol>> generatedSymbols = slotMachine.Spin(stakeAmount);
        userHandler.ShowSymbols(generatedSymbols);
        decimal spinProfit = CalculateProfit(generatedSymbols, stakeAmount);
        
        if (spinProfit > 0)
        {
          currentPlayer.Balance += spinProfit;
          userHandler.ShowWinning(spinProfit);
        }
        else
        {
          userHandler.ShowLoss();
        }

        if (currentPlayer.Balance == 0)
        {
          isFinished = true;
        }
      }
    }

    private decimal CalculateProfit(IEnumerable<IEnumerable<Symbol>> symbols, decimal stakeAmount)
    {
      Symbol symbolForComparison = null;
      decimal finalCoefficientsSum = 0;

      foreach (var row in symbols)
      {
        symbolForComparison = null;
        decimal coefficientsSum = 0;
        foreach (Symbol symbol in row)
        {
          if (symbol.Sign == Symbol.wildCardSymbol)
          {
            coefficientsSum += symbol.Coefficient;
          }
          else if (symbolForComparison == null)
          {
            symbolForComparison = symbol;
            coefficientsSum += symbol.Coefficient;
          }
          else if (symbol.Sign == symbolForComparison.Sign)
          {
            coefficientsSum += symbol.Coefficient;
          }
          else if (symbol.Sign != symbolForComparison.Sign)
          {
            coefficientsSum = 0;
            break;
          }
        }
        finalCoefficientsSum += coefficientsSum;
      }

      decimal profit = finalCoefficientsSum * stakeAmount;
      return profit;
    }
  }
}
