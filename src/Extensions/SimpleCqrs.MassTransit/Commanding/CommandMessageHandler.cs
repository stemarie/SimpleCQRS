using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit.Commanding
{
    public class CommandMessageHandler
    {
        private readonly ICommandBus _commandBus;

        public CommandMessageHandler(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void Handle(CommandMessage message)
        {
            _commandBus.Send(message.Command);
        }
    }
}