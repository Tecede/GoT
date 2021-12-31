using System.Threading;
using System.Threading.Tasks;

namespace Gems.Diamond.CQRS.Abstractions.Commands
{
	/// <summary>
	/// Commands dispatcher interface
	/// </summary>
	public interface ICommandDispatcher
    {
		/// <summary>
		/// Method for synchronous commands execution
		/// </summary>
		/// <param name="command">Information needed for commands execution</param>
		TResult Execute<TResult>(ICommand<TResult> command);

	    Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);


	    void Execute<TCommand>(TCommand command) where TCommand : ICommand;
	   
	    Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;

	    Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;

	}
}
