using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.Configurators;
using SimpleCqrs.Commanding;
using SimpleCqrs.MassTransit.Commanding;

namespace SimpleCqrs.MassTransit
{
    public class ConfigSimpleCqrs
    {
        private readonly ISimpleCqrsRuntime _runtime;

        public ConfigSimpleCqrs(ISimpleCqrsRuntime runtime)
        {
            _runtime = runtime;
        }

        public IServiceLocator ServiceLocator { get; private set; }

        public void Configure(ServiceBusConfigurator url)
        {
            var bus = ServiceBusFactory.New(
                sbc =>
                {
                    sbc.ReceiveFrom(url);
                    sbc.Subscribe(
                        subs =>
                            {
                                subs.Handler<CommandMessage>(
                                    msg =>
                                    new CommandMessageHandler(
                                        _runtime.ServiceLocator.Resolve<ICommandBus>()
                                        ).Handle(msg));
                                subs.Handler<CommandWithReturnValueMessage>(
                                    msg =>
                                    new CommandWithReturnValueMessageHandler(
                                        _runtime.ServiceLocator.Resolve<ICommandBus>(),
                                        _runtime.ServiceLocator.Resolve<IServiceBus>()
                                        ).Handle(msg));
                            });
                });

            _runtime.Start();

            ServiceLocator = _runtime.ServiceLocator;
            ServiceLocator.Register(() => bus);
        }
    }
}