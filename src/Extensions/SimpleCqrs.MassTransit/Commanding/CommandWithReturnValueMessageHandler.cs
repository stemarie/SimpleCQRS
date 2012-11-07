using MassTransit;
using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit.Commanding
{
    public class CommandWithReturnValueMessageHandler
    {
        private readonly ICommandBus _commandBus;
        private readonly IServiceBus _bus;

        public CommandWithReturnValueMessageHandler(ICommandBus commandBus, IServiceBus bus)
        {
            _commandBus = commandBus;
            _bus = bus;
        }

        public void Handle(CommandWithReturnValueMessage message)
        {
            var value = _commandBus.Execute(message.Command);
            _bus.Publish(value, );
        }
    }
}