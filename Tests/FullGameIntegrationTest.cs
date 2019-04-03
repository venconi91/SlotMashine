namespace Tests
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using SlotMachine.Common;
  using System.IO;
  using Xunit;
  using System.Linq;

  public class FullGameIntegrationTest
  {
    public static IConfigurationRoot Configuration { get; set; }
    
    private const int ExpectedLostSpinsCountOfPlayer = 2;

    public FullGameIntegrationTest()
    {
      ConfigureApplication();
      IGame slotGame = ServiceProviderHolder.ServiceProvider.GetService<IGame>();
      slotGame.Start();
    }

    static void ConfigureApplication()
    {
      var services = new ServiceCollection();

      var builder = new ConfigurationBuilder()
          .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
          .AddJsonFile("appsettings.json", optional: true);

      Configuration = builder.Build();

      services.Configure<SlotMachineSettings>(Configuration.GetSection("SlotMachineSettings"));

      services.AddTransient<IGame, SlotGame>();
      services.AddSingleton<IPlayer, Player>();
      services.AddTransient<IUserHandler, UserHandler>();
      services.AddTransient<ISlotMachine, SlotMachine>();
      services.AddTransient<IReel, Reel>();

      services.AddTransient<IInputHandler, FileInputHandler>();
      services.AddTransient<IOutputHandler, FileOutputHandler>();
      services.AddTransient<ISymbolGenerator, MockedSymbolGenerator>();

      ServiceProviderHolder.ServiceProvider = services.BuildServiceProvider();
    }
    [Fact]
    public void FinalBalanceOfPlayerShouldBeZero()
    {
      string[] allOutputLines = File.ReadAllLines(FileOutputHandler.OutputFilePath);
      string lastLine = allOutputLines[allOutputLines.Length - 1];
      Assert.Equal(string.Format(UserHandler.CurrentBalanceFormatMessage, 0.0m), lastLine); 
    }

    [Fact]
    public void PlayerLostSpinsShouldBeTwo()
    {
      string[] allOutputLines = File.ReadAllLines(FileOutputHandler.OutputFilePath);
      int actualLostSpinsCount = allOutputLines.Count(l => l == UserHandler.LostSpinMessage);
      Assert.Equal(ExpectedLostSpinsCountOfPlayer, actualLostSpinsCount);
    }
  }
}
