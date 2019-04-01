namespace SlotMachine.Common
{
  using Microsoft.Extensions.Options;
  using System.Collections.Generic;

  public class Reel : IReel
  {
    private readonly int rows;
    private readonly int cols;
    private IEnumerable<Symbol> availableSymbols;
    private ISymbolGenerator symbolGenerator;
    private SymbolFactory symbolFactory = new SymbolFactory();

    public Reel(ISymbolGenerator symbolGenerator, IOptions<SlotMachineSettings> settings)
    {
      this.symbolGenerator = symbolGenerator;
      rows = settings.Value.Rows;
      cols = settings.Value.Cols;
      InitializeAvailableSymbols(settings.Value.SlotMachineSymbolsSettings);
    }

    public List<List<Symbol>> CurrentSymbols { get; set; }

    private void InitializeAvailableSymbols(IList<SlotMachineSymbolsSettings> symbolSettings)
    {
      var availableSymbols = new List<Symbol>();
      foreach (var symbolSetting in symbolSettings)
      {
        availableSymbols.Add(symbolFactory.GenerateSymbol(symbolSetting));
      }
      this.availableSymbols = availableSymbols;
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
