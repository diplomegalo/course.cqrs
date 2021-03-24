using System;
using System.Text.Json;
using Delsoft.Course.CQRS.Model.Commands;

namespace Delsoft.Course.CQRS.Domain.Commands.Decorators
{
    public class Logging<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;

        public Logging(ICommandHandler<TCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Handle(TCommand command)
        {
            var cmdString = JsonSerializer.Serialize(command);
            Console.WriteLine(cmdString);
            _commandHandler.Handle(command);
        }
    }
}