using System;
using MassTransit.BusConfigurators;

namespace SimpleCqrs.MassTransit
{
    public static class ConfigureSimpleCqrs
    {
        public static ConfigSimpleCqrs SimpleCqrs(this Action<ServiceBusConfigurator> configure, ISimpleCqrsRuntime runtime)
        {
            var configSimpleCqrs = new ConfigSimpleCqrs(runtime);
            configSimpleCqrs.Configure(configure);
            return configSimpleCqrs;
        }
    }
}