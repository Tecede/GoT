using System.Threading;
using System.Threading.Tasks;

namespace Gems.Diamond.CQRS.Abstractions.Commands
{
	/// <summary>
	/// Interface for asynchronous commands
	/// </summary>
	/// <typeparam name="TCommand">Command type</typeparam>
	/// <typeparam name="TResult">Command result type</typeparam>
	public interface IAsyncCommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
	{
		/// <summary>
		/// Method for command execution
		/// </summary>
		/// <param name="command">Information needed for command execution</param>
		/// <param name="cancellationToken"></param>
		Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
	}

	public interface IAsyncCommandHandler<in TCommand> where TCommand : ICommand
	{
		/// <summary>
		/// Method for command execution
		/// </summary>
		/// <param name="command">Information needed for command execution</param>
		Task Handle(TCommand command);

		/// <summary>
		/// Method for command execution
		/// </summary>
		/// <param name="command">Information needed for command execution</param>
		/// <param name="cancellationToken"></param>
		Task Handle(TCommand command, CancellationToken cancellationToken);
	}
}
