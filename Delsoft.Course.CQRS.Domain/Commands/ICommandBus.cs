using Delsoft.Course.CQRS.Model.Commands;

namespace Delsoft.Course.CQRS.Domain.Commands
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand: ICommand;
    }
}