using Delsoft.Course.CQRS.Dtos.Queries;

namespace Delsoft.Course.CQRS.Domain.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}