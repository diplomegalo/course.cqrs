using System;
using Delsoft.Course.CQRS.Dtos.Queries;

namespace Delsoft.Course.CQRS.Domain.Queries
{
    public interface IQueryBus
    {
        TResult Dispatch<TResult>(IQuery<TResult> query);
    }
}