using Delsoft.Course.CQRS.Domain.Services;
using Delsoft.Course.CQRS.Model.Aggregates;
using Delsoft.Course.CQRS.Model.Commands;

namespace Delsoft.Course.CQRS.Domain.Commands.Handlers
{
    public class RegisterWineHandler : ICommandHandler<RegisterWine>
    {
        private readonly IWineRepository _wineRepository;

        public RegisterWineHandler(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public void Handle(RegisterWine command)
        {
            var wine = Wine.Create(command.Name, command.Millesime, command.Appellation);
            _wineRepository.Create(wine);
        }
    }
}