using System;
using System.Threading;
using System.Threading.Tasks;
using Gems.Diamond.CQRS.Abstractions.Commands;

namespace Gems.Diamond.CQRS.Implementations.Commands
{
	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly IServiceProvider _provider;

		
		public CommandDispatcher(IServiceProvider provider)
		{
			_provider = provider;
		}

		public TResult Execute<TResult>(ICommand<TResult> query)
		{
			var handlerType = typeof(ICommandHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			dynamic handler = _provider.GetService(handlerType);
			return handler.Handle((dynamic)query);
		}

		public Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
		{
			var handlerType = typeof(IAsyncCommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
			dynamic handler = _provider.GetService(handlerType);
			return handler.Handle((dynamic)command, cancellationToken);
		}

		//---------------------//
		public void Execute<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
			dynamic handler = _provider.GetService(handlerType);
			handler.Handle((dynamic)command);
		}

		public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
		{
			//var handlerType = typeof(IAsyncCommandHandler<>).MakeGenericType(command.GetType());
			//dynamic handler = _provider.GetService(handlerType);
			//return handler.Handle(command);

			var handlerType = typeof(IAsyncCommandHandler<>).MakeGenericType(command.GetType());
			var handler = _provider.GetService(handlerType) as IAsyncCommandHandler<TCommand>;
			if (handler == null)
				throw new InvalidOperationException($"Command handler for {handlerType.ToString()} not register.");
			return handler.Handle(command);

		}

		public Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
		{

			var handlerType = typeof(IAsyncCommandHandler<>).MakeGenericType(command.GetType());
			var handler = _provider.GetService(handlerType) as IAsyncCommandHandler<TCommand>;
			if (handler == null)
				throw new InvalidOperationException($"Command handler for {handlerType.ToString()} not register.");
			return handler.Handle(command, cancellationToken);
		}
	}
}
