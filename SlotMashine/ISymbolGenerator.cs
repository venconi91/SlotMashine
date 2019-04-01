namespace SlotMashine
{
  using System.Collections.Generic;

  public interface ISymbolGenerator
  {
    ISymbolGenerator SetAvailableSymbols(IEnumerable<Symbol> symbols);

    IEnumerable<IEnumerable<Symbol>> Generate(int rows, int cols);
  }
}
