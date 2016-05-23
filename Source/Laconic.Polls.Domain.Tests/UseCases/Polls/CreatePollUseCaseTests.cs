using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Laconic.Polls.Domain.Data;
using Laconic.Polls.Domain.Entities;
using Laconic.Polls.Domain.Tests.FakeData;
using Laconic.Polls.Domain.Tools;
using Laconic.Polls.Domain.UseCases.Polls;
using NUnit.Framework;

namespace Laconic.Polls.Domain.Tests.UseCases.Polls
{
    [TestFixture]
    public class CreatePollUseCaseTests
    {
        private CreatePollUseCase.Input _input;
        private List<Poll> _polls;
        private IDataContext _dataContext;
        private IClock _clock;

        [SetUp]
        public void SetUp()
        {
            _input = new CreatePollUseCase.Input
                     {
                         Question = "To be or not to be?",
                         Options = new[] {"To be", "Not to be"}
                     };

            _polls = new List<Poll>();

            _dataContext = A.Fake<IDataContext>();
            A.CallTo(() => _dataContext.Polls).Returns(new FakeDataSet<Poll>(_polls));

            _clock = A.Fake<IClock>();
            A.CallTo(() => _clock.Now).Returns(DateTimeOffset.Now);
        }

        [Test]
        public async Task ActAsync_CreatesNewPoll()
        {
            A.CallTo(() => _dataContext.SaveChangesAsync())
                .Invokes(() => Assert.That(_polls.FirstOrDefault(), Is.Not.Null))
                .Returns(Task.CompletedTask);

            await CreateUseCase().ActAsync(_input);

            A.CallTo(() => _dataContext.SaveChangesAsync()).MustHaveHappened();
        }

        [Test]
        public async Task ActAsync_ReturnsNewPoll()
        {
            var output = await CreateUseCase().ActAsync(_input);

            Assert.That(output.Poll, Is.SameAs(_polls.First()));
        }

        [Test]
        public async Task ActAsync_SetsPollQuestion()
        {
            await CreateUseCase().ActAsync(_input);
            
            Assert.That(_polls.First().Question, Is.EqualTo(_input.Question));
        }

        [Test]
        public async Task ActAsync_SetsPollCreatedTimestamp()
        {
            await CreateUseCase().ActAsync(_input);

            Assert.That(_polls.First().Created, Is.EqualTo(_clock.Now));
        }

        [Test]
        public async Task ActAsync_SetsPollOptions()
        {
            await CreateUseCase().ActAsync(_input);

            Assert.That(_polls.First().Options.Select(x => x.Statement), Is.EqualTo(_input.Options));
        }

        private CreatePollUseCase CreateUseCase()
        {
            return new CreatePollUseCase(_dataContext, _clock);
        }
    }
}
