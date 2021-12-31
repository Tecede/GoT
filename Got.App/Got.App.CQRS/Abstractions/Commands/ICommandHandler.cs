namespace Gems.Diamond.CQRS.Abstractions.Commands
{
	/// <summary>
	/// Interface for synchronous command handlers
	/// </summary>
	/// <typeparam name="TCommand">Command type</typeparam>
	/// <typeparam name="TResult">Command result type</typeparam>
	public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<TResult>
	{
		/// <summary>
		/// Method for command execution
		/// </summary>
		/// <param name="command">Information needed for command execution</param>
		void Handle(TCommand command);
	}

	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		/// <summary>
		/// Method for command execution
		/// </summary>
		/// <param name="command">Information needed for command execution</param>
		void Handle(TCommand command);
	}
}
