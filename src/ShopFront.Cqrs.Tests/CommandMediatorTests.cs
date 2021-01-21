using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopFront.Cqrs.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopFron.Cqrs.Tests
{
    [TestClass]
    public class CommandMediatorTests
    {
        private ICommandHandler PrimareCommandHandler = new TestCommandHandler(CommandHandlerPriority.High);
        private ICommandHandler SecondayCommandHandler = new TestCommandHandler(CommandHandlerPriority.Normal);

        private class OtherTestCommand : ICommand { }

        // ++++++++++++++++++++++++++++++++++++
        // helper classes
        // ++++++++++++++++++++++++++++++++++++
        private class TestCommand : ICommand { }

        private class TestCommandHandler : ICommandHandler
        {
            public TestCommandHandler(CommandHandlerPriority commandHandlerPriority)
            {
                Priority = commandHandlerPriority;
            }

            public CommandHandlerPriority Priority { get; }

            public bool CanHandle(ICommand operation)
            {
                return operation is TestCommand;
            }

            public Task<ICommandResult> Do(ICommand operation)
            {
                Thread.Sleep(200);
                var rtn = Task.FromResult<ICommandResult>(new TestCommandResult());
                return rtn;
            }
        }

        private class TestCommandResult : ICommandResult
        {
            public TestCommandResult()
            {
                CreatedOn = DateTime.Now;
            }

            public DateTime CreatedOn { get; }
        }

        private ICommandMediator CommandMediator => GetTestSubject();

        [TestMethod]
        public void CanBeConstructed()
        {
            Assert.IsNotNull(CommandMediator);
        }

        [TestMethod]
        public async Task CanHandleCommand()
        {
            var result = await CommandMediator.Do(new TestCommand());
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public async Task CanHandleCommandsInCorrectOrder()
        {
            var result = (await CommandMediator.Do(new TestCommand())).Cast<TestCommandResult>().ToArray();
            Assert.IsTrue(result[0].CreatedOn.Ticks < result[1].CreatedOn.Ticks);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task ThrowsException()
        {
            await CommandMediator.Do(new OtherTestCommand());
        }

        // ++++++++++++++++++++++++++++++++++++
        // helper methods
        // ++++++++++++++++++++++++++++++++++++
        private ICommandMediator GetTestSubject()
        {
            var rtn = new CommandMediator(new ICommandHandler[] { SecondayCommandHandler, PrimareCommandHandler });
            return rtn;
        }
    }
}