using System;
using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit.Commanding
{
    [Serializable]
    public class CommandMessage
    {
        public ICommand Command { get; set; }
    }
}