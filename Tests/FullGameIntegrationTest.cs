namespace Tests
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using SlotMachine.Common;
  using System.IO;
  using Xunit;

  public class FullGameIntegrationTest
  {
    public static IConfigurationRoot Configuration { get; set; }

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

      //services.AddTransient<IInputHandler, ConsoleInputHandler>();
      //services.AddTransient<IOutputHandler, ConsoleOutputHandler>();
      services.AddTransient<ISymbolGenerator, SymbolGenerator>();

      ServiceProviderHolder.ServiceProvider = services.BuildServiceProvider();
    }
    [Fact]
    public void Test1()
    {
      Assert.True(true);
    }
  }
}
