using System;

namespace Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
    public interface ICommand<TFirst,TSecond> : IUseCase
    {
        void Execute(TFirst first, TSecond second);
    }
}
