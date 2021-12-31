using System.Threading;
using System.Threading.Tasks;

namespace Gems.Diamond.CQRS.Abstractions.Queries
{
	/// <summary>
	/// Queries dispatcher interface
	/// </summary>
	public interface IQueryDispatcher
	{
		/// <summary>
		/// Method for queries execution
		/// </summary>
		/// <typeparam name="TResult">Query result type</typeparam>
		/// <param name="query">Information needed for queries execution</param>
		/// <returns>Query result</returns>
		TResult Execute<TResult>(IQuery<TResult> query);

		/// <summary>
		/// Method for asynchronous queries execution
		/// </summary>
		/// <typeparam name="TResult">Query result type</typeparam>
		/// <param name="query">Information needed for commands execution</param>
		Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);

		Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
	}
}
