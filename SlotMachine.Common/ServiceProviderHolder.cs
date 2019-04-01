using Microsoft.Extensions.DependencyInjection;

namespace SlotMachine.Common
{
  public static class ServiceProviderHolder
  {
    public static ServiceProvider ServiceProvider { get; set; }
  }
}
