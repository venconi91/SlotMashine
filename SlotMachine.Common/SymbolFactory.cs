using System;

namespace SlotMachine.Common
{
  public class SymbolFactory
  {
    public Symbol GenerateSymbol(SlotMachineSymbolsSettings symbolSetting)
    {
      switch (symbolSetting.Sign)
      {
        case "A":
          return new AppleSymbol(symbolSetting.Name, symbolSetting.Sign, symbolSetting.Coefficient, symbolSetting.ProbabilityForAppearingInPercentige);
        case "B":
          return new BananaSymbol(symbolSetting.Name, symbolSetting.Sign, symbolSetting.Coefficient, symbolSetting.ProbabilityForAppearingInPercentige);
        case "P":
          return new PineppleSymbol(symbolSetting.Name, symbolSetting.Sign, symbolSetting.Coefficient, symbolSetting.ProbabilityForAppearingInPercentige);
        case "*":
          return new WildcardSymbol(symbolSetting.Name, symbolSetting.Sign, symbolSetting.Coefficient, symbolSetting.ProbabilityForAppearingInPercentige);
        default:
          throw new ArgumentException("symbol not supported");
      }
    }
  }
}
