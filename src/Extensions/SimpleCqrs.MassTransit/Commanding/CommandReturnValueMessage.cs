using System;
using SimpleCqrs.Commanding;

namespace SimpleCqrs.MassTransit.Commanding
{
    [Serializable]
    public class CommandReturnValueMessage
    {
        public ICommand Command { get; set; }
    }
}