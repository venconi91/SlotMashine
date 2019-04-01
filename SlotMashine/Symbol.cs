namespace SlotMashine
{
  public abstract class Symbol
  {
    public static string wildCardSymbol = "*";

    public Symbol(string name, string sign, decimal coefficient, int probabilityForAppearingInPercentage)
    {
      Name = name;
      Sign = sign;
      Coefficient = coefficient;
      ProbabilityForAppearingInPercentige = probabilityForAppearingInPercentage;
    }

    public string Name { get; }

    public string Sign { get; }

    public decimal Coefficient { get; }

    public int ProbabilityForAppearingInPercentige { get; }
  }
}
