using System.Threading;
using System.Threading.Tasks;

namespace Gems.Diamond.CQRS.Abstractions.Queries
{
	/// <summary>
	/// Interface for async queries
	/// </summary>
	/// <typeparam name="TQuery">Query type</typeparam>
	/// <typeparam name="TResult">Query result type</typeparam>
	public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
	{
		/// <summary>
		/// Method for query execution
		/// </summary>
		/// <param name="query">Information needed for query execution</param>
		/// <returns>Query result</returns>
		Task<TResult> Handle(TQuery query);

		/// <summary>
		/// Method for query execution
		/// </summary>
		/// <param name="query">Information needed for query execution</param>
		/// <param name="cancellationToken">Cancellation token</param>
		/// <returns>Query result</returns>
		Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
	}

	/*На этот интерфейс нужно переделать все асинхронные запросы*/
	//////////////////////////////////////////////////////////////
	///// <summary>
	///// Interface for async queries
	///// </summary>
	///// <typeparam name="TQuery">Query type</typeparam>
	///// <typeparam name="TResult">Query result type</typeparam>
	//public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IAsyncQuery<TResult>
	//{
	//	/// <summary>
	//	/// Method for query execution
	//	/// </summary>
	//	/// <param name="query">Information needed for query execution</param>
	//	/// <returns>Query result</returns>
	//	Task<TResult> HandleAsync(TQuery query,CancellationToken cancellationToken);
	//}
}
