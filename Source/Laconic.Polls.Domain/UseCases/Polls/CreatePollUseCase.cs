using System.Linq;
using System.Threading.Tasks;
using Laconic.Polls.Domain.Data;
using Laconic.Polls.Domain.Entities;
using Laconic.Polls.Domain.Tools;

namespace Laconic.Polls.Domain.UseCases.Polls
{
    public class CreatePollUseCase : IUseCase<CreatePollUseCase.Input, CreatePollUseCase.Output>
    {
        private readonly IDataContext _dataContext;
        private readonly IClock _clock;

        public CreatePollUseCase(IDataContext dataContext, IClock clock)
        {
            _dataContext = dataContext;
            _clock = clock;
        }

        public async Task<Output> ActAsync(Input input)
        {
            var poll = CreatePoll(input);

            _dataContext.Polls.Add(poll);
            await _dataContext.SaveChangesAsync();

            return new Output
                   {
                       Poll = poll
                   };
        }

        private Poll CreatePoll(Input input)
        {
            return new Poll
                   {
                       Question = input.Question,
                       Created = _clock.Now,
                       Options = input.Options.Select(x => new Option {Statement = x}).ToList()
                   };
        }

        public class Input
        {
            public string Question { get; set; }
            public string[] Options { get; set; }
        }

        public class Output
        {
            public Poll Poll { get; set; }
        }
    }
}