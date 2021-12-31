using System;
using System.Threading;
using System.Threading.Tasks;
using Gems.Diamond.CQRS.Abstractions.Queries;

namespace Gems.Diamond.CQRS.Implementations.Queries
{
	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly IServiceProvider _provider;

		
		public QueryDispatcher(IServiceProvider provider)
		{
			_provider = provider;
		}


		public TResult Execute<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			dynamic handler = _provider.GetService(handlerType);
			return handler.Handle((dynamic)query);
		}

		public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
		{
			var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			dynamic handler = _provider.GetService(handlerType);
			return handler.Handle((dynamic)query);
		}

		public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
		{
			var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			dynamic handler = _provider.GetService(handlerType);
			return handler.Handle((dynamic)query, cancellationToken);
		}
	}
}
