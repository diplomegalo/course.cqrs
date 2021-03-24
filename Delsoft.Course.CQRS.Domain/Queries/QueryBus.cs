using System;
using Delsoft.Course.CQRS.Dtos.Queries;

namespace Delsoft.Course.CQRS.Domain.Queries
{
    public class QueryBus : IQueryBus
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            var type = typeof(IQueryHandler<,>);
            var handlerType = type.MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(handlerType);
            return handler.Handle((dynamic)query);
        }
    }
}