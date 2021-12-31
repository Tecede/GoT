namespace Gems.Diamond.CQRS.Abstractions
{
	public interface IHandler<in TIn,out TOut>
	{
		TOut Handle(TIn input);
	}
}
