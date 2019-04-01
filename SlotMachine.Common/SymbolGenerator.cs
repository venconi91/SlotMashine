namespace SlotMachine.Common
{
  using System;
  using System.Collections.Generic;

  public class SymbolGenerator : ISymbolGenerator
  {
    private readonly Random random = new Random();
    private IEnumerable<Symbol> availableSymbols;
    private IList<Symbol> probabilityArrayIndexes = new List<Symbol>(100);

    public ISymbolGenerator SetAvailableSymbols(IEnumerable<Symbol> symbols)
    {
      this.availableSymbols = symbols;
      foreach (var symbol in symbols)
      {
        for (int i = 0; i < symbol.ProbabilityForAppearingInPercentige; i++)
        {
          probabilityArrayIndexes.Add(symbol);
        }
      }

      return this;
    }

    public IEnumerable<IEnumerable<Symbol>> Generate(int rows, int cols)
    {
      List<List<Symbol>> generatedSymbols = new List<List<Symbol>>();
      for (int i = 0; i < rows; i++)
      {
        List<Symbol> innerList = new List<Symbol>();
        for (int j = 0; j < cols; j++)
        {
          int index = random.Next(0, 100);
          innerList.Add(probabilityArrayIndexes[index]);
        }

        generatedSymbols.Add(innerList);
      }

      return generatedSymbols;
    }
  }
}
