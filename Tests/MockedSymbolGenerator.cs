namespace Tests
{
  using SlotMachine.Common;
  using System.Collections.Generic;
  using System.Linq;
  using System;

  public class MockedSymbolGenerator : ISymbolGenerator
  {
    private IList<Symbol> availableSymbols;
    private Dictionary<string, Symbol> symbolBySign = new Dictionary<string, Symbol>();

    public int GenerateMethodTimesCalled { get; set; } = 0;

    public IEnumerable<IEnumerable<Symbol>> Generate(int rows, int cols)
    {
      List<List<string>> currentSpinSigns = null;
      if (GenerateMethodTimesCalled == 0)
      {
        currentSpinSigns = MockedSpinSymbolsSigns.MockedSymbolsFirstSpin;
      }
      else if (GenerateMethodTimesCalled == 1)
      {
        currentSpinSigns = MockedSpinSymbolsSigns.MockedSymbolsSecondSpin;
      }
      else if (GenerateMethodTimesCalled == 2)
      {
        currentSpinSigns = MockedSpinSymbolsSigns.MockedSymbolsThirdSpin;
      }
      else
      {
        throw new InvalidOperationException("Player should be lost already");
      }

      List<List<Symbol>> generatedSymbols = new List<List<Symbol>>();
      foreach (var rowSigns in currentSpinSigns)
      {
        List<Symbol> innerList = new List<Symbol>();
        foreach (var colSign in rowSigns)
        {
          Symbol currentSymbol = null;
          if (!symbolBySign.TryGetValue(colSign, out currentSymbol))
          {
            throw new InvalidOperationException("Mocked data should be present in configuration");
          }

          innerList.Add(currentSymbol);
        }
        generatedSymbols.Add(innerList);
      }

      GenerateMethodTimesCalled += 1;
      return generatedSymbols;
    }

    public ISymbolGenerator SetAvailableSymbols(IEnumerable<Symbol> symbols)
    {
      this.availableSymbols = symbols.ToList();
      foreach (var symbol in symbols)
      {
        if (!symbolBySign.ContainsKey(symbol.Sign))
        {
          symbolBySign.Add(symbol.Sign, symbol);
        }
      }
      
      return this;
    }
  }
}
