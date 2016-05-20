using System.Threading.Tasks;

namespace Laconic.Polls.Domain.UseCases
{
    public interface IUseCase
    {
    }

    public interface IUseCase<in TInput, TOutput> : IUseCase
    {
        Task<TOutput> ActAsync(TInput input);
    }
}