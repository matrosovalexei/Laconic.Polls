namespace Laconic.Polls.Domain.UseCases
{
    public interface IUseCaseFactory
    {
        T Create<T>() where T : IUseCase;
    }
}