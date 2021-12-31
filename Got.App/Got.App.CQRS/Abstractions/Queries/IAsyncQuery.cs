using System.Threading.Tasks;

namespace Gems.Diamond.CQRS.Abstractions.Queries
{
	/// <summary>
	/// Interface for async queries context marking
	/// </summary>
	public interface IAsyncQuery<TResult>:IQuery<Task<TResult>>
	{
	}
}
