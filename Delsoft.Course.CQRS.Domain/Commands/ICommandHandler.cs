using Delsoft.Course.CQRS.Model.Commands;

namespace Delsoft.Course.CQRS.Domain.Commands
{
    public interface ICommandHandler<TCommand> where TCommand: ICommand
    {
        void Handle(TCommand command);
    }
}