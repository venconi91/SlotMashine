namespace SlotMashine
{
  using System.Collections.Generic;

  public class Reel : IReel
  {
    private readonly int rows;
    private readonly int cols;
    private IEnumerable<Symbol> availableSymbols;
    private ISymbolGenerator symbolGenerator;

    public Reel(ISymbolGenerator symbolGenerator)
    {
      this.rows = 4;
      this.cols = 3;
      this.symbolGenerator = symbolGenerator;
      InitializeAvailableSymbols();
    }

    public List<List<Symbol>> CurrentSymbols { get; set; }

    private void InitializeAvailableSymbols()
    {
      Symbol appleSymbol = new AppleSymbol("Apple", "A", 0.4m, 45);
      Symbol bananaSymbol = new BananaSymbol("Banana", "B", 0.6m, 35);
      Symbol pineappleSymbol = new PineppleSymbol("Pineapple", "P", 0.8m, 15);
      Symbol wildcardSymbol = new WildcardSymbol("Wildcard", "*", 0, 5);
      this.availableSymbols = new List<Symbol>() { appleSymbol, bananaSymbol, pineappleSymbol, wildcardSymbol };
    }

    public IEnumerable<IEnumerable<Symbol>> Spin()
    {
      IEnumerable<IEnumerable<Symbol>> generatedSymbols = symbolGenerator
        .SetAvailableSymbols(availableSymbols)
        .Generate(rows, cols);

      return generatedSymbols;
    }
  }
}
