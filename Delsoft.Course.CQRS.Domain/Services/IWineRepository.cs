using Delsoft.Course.CQRS.Model.Aggregates;

namespace Delsoft.Course.CQRS.Domain.Services
{
    public interface IWineRepository
    {
        void Create(Wine wine);
    }
}