namespace Tests
{
  using System.Collections.Generic;

  public class MockedSpinSymbolsSigns
  {
    public static List<List<string>> MockedSymbolsFirstSpin = new List<List<string>>() {
      new List<string>() { "*", "P", "*"}, // 0.8
      new List<string>() { "A", "A", "A"}, // 1.2
      new List<string>() { "P", "P", "P"}, // 2.4
      new List<string>() { "B", "B", "B"} // 1.8
    };

    public static List<List<string>> MockedSymbolsSecondSpin = new List<List<string>>() {
      new List<string>() { "A", "B", "P"},
      new List<string>() { "*", "A", "B"},
      new List<string>() { "A", "A", "P"},
      new List<string>() { "A", "A", "P"}
    };

    public static List<List<string>> MockedSymbolsThirdSpin = new List<List<string>>() {
      new List<string>() { "A", "B", "P"},
      new List<string>() { "P", "B", "B"},
      new List<string>() { "A", "B", "*"},
      new List<string>() { "P", "P", "A"}
    };
  }
}
