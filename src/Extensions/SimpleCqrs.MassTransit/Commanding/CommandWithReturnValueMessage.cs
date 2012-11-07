using System;
using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit.Commanding
{
    [Serializable]
    public class CommandWithReturnValueMessage
    {
        public ICommand Command { get; set; }
    }
}