namespace SlotMachine.Console
{
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using SlotMachine.Common;
  using System.IO;

  class Program
  {
    public static IConfigurationRoot Configuration { get; set; }

    static void Main(string[] args)
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

      services.AddTransient<IInputHandler, ConsoleInputHandler>();
      services.AddTransient<IOutputHandler, ConsoleOutputHandler>();
      services.AddTransient<ISymbolGenerator, SymbolGenerator>();

      ServiceProviderHolder.ServiceProvider = services.BuildServiceProvider();
    }
  }
}
