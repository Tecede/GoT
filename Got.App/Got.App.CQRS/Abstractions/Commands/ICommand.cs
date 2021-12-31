namespace Gems.Diamond.CQRS.Abstractions.Commands
{
	/// <summary>
	/// Interface for commands contexts marking
	/// </summary>
	public interface ICommand
	{
	}
	public interface ICommand<out TResult>
	{
	}
}
