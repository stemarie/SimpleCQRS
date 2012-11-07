using System;
using MassTransit;
using MassTransit.BusConfigurators;
using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit
{
    public class ConfigSimpleCqrs
    {
        private readonly ISimpleCqrsRuntime _runtime;
        public IServiceLocator ServiceLocator { get; private set; }

        public ConfigSimpleCqrs(ISimpleCqrsRuntime runtime)
        {
            _runtime = runtime;
        }

        public void Configure(Action<ServiceBusConfigurator> config)
        {
            var bus = ServiceBusFactory.New(config);

            _runtime.Start();

            ServiceLocator = _runtime.ServiceLocator;
            ServiceLocator.Register(bus);
            ServiceLocator.Register(_runtime);
        }

        public ConfigSimpleCqrs UseMTCommandBus()
        {
            var config = new ConfigCommandBus(_runtime);
            var commandBus = config.Configure(this);

            ServiceLocator.Register<ICommandBus>(commandBus);

            return this;
        }
    }
}
