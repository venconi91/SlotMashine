﻿using System.Collections.Generic;

namespace SlotMashine
{
  public class UserHandler : IUserHandler
  {
    private IPlayer currentPlayer;
    private IInputHandler inputHandler;
    private IOutputHandler outputHandler;

    private const string DepositRequestQuestionText = "Please deposit money you would like to play with:";
    private const string DepositAmountInvalidText = "Please enter valid deposit amount:";
    private const string StakeRequestText = "Enter stake amount";
    private const string StakeAmountInvalidText = "Enter enter valid stake amount";

    public UserHandler(IPlayer player, IInputHandler inputHandler, IOutputHandler outputHandler)
    {
      this.currentPlayer = player;
      this.inputHandler = inputHandler;
      this.outputHandler = outputHandler;
    }

    public decimal RequestDepositAmount()
    {
      outputHandler.WriteLine(DepositRequestQuestionText);

      bool isInputDepositValid = false;
      decimal depositAmount = 0;
      while (!isInputDepositValid)
      {
        string input = inputHandler.ReadLine();
        decimal parsedValue = 0;
        if (IsValid(input, out parsedValue))
        {
          isInputDepositValid = true;
          decimal.TryParse(input, out depositAmount);
        }
        else
        {
          outputHandler.WriteLine(DepositAmountInvalidText);
        }
      }

      currentPlayer.Balance = depositAmount;

      return depositAmount;
    }

    private bool IsValid(string strToCheck, out decimal parsedValue)
    {
      bool canParse = decimal.TryParse(strToCheck, out parsedValue);
      return canParse;
    }

    public decimal RequestStakeAmount()
    {
      outputHandler.WriteLine(StakeRequestText);
      bool isStakeAmountValid = false;
      decimal depositAmount = 0;
      while (!isStakeAmountValid)
      {
        string input = inputHandler.ReadLine();
        decimal parsedValue = 0;
        if (IsValid(input, out parsedValue) && currentPlayer.Balance >= parsedValue)
        {
          isStakeAmountValid = true;
          decimal.TryParse(input, out depositAmount);
        }
        else
        {
          outputHandler.WriteLine(StakeAmountInvalidText);
        }
      }

      return depositAmount;
    }

    public void ShowSymbols(IEnumerable<IEnumerable<Symbol>> symbols)
    {
      foreach (var row in symbols)
      {
        outputHandler.WriteLine("");
        foreach (var symbol in row)
        {
          outputHandler.Write(symbol.Sign);
        }
      }
      outputHandler.WriteLine("");
    }

    public void ShowWinning(decimal profit)
    {
      outputHandler.WriteLine($"You have won: {profit}");
      outputHandler.WriteLine($"Current balance is: {currentPlayer.Balance}");
    }

    public void ShowLoss()
    {
      outputHandler.WriteLine($"You have lost this spin");
      outputHandler.WriteLine($"Current balance is: {currentPlayer.Balance}");
    }
  }
}
