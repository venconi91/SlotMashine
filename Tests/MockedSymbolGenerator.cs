namespace Tests
{
    using SlotMachine.Common;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MockedSymbolGenerator : ISymbolGenerator
    {
        private IList<Symbol> availableSymbols;
        public IEnumerable<IEnumerable<Symbol>> Generate(int rows, int cols)
        {
            List<List<Symbol>> generatedSymbols = new List<List<Symbol>>();
            for (int i = 0; i < rows; i++)
            {
                List<Symbol> innerList = new List<Symbol>();
                for (int j = 0; j < cols; j++)
                {
                    innerList.Add(availableSymbols[0]);
                }

                generatedSymbols.Add(innerList);
            }
            return generatedSymbols;
        }

        public ISymbolGenerator SetAvailableSymbols(IEnumerable<Symbol> symbols)
        {
            this.availableSymbols = symbols.ToList();
            return this;
        }
    }
}
