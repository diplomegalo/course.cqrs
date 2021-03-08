using System;
using Delsoft.Course.CQRS.Model.Commands;

namespace Delsoft.Course.CQRS.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler =_serviceProvider.GetService(typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType()));
            ((ICommandHandler<TCommand>)handler).Handle(command);
        }
    }
}