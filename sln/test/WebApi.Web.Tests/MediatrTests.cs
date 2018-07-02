namespace WebApi.Web.Tests
{
    using System;
    using System.Threading;
    using WebApi.Core.CommandHandlers;
    using WebApi.Core.Commands;
    using Xunit;

    public class MediatrTests
    {
        [Fact]
        public async void AuditableCommandTest()
        {
            var input = "test";
            var commandWithReturn = new SimpleWithReturnCommandHandler();
            var result = await commandWithReturn.Handle(new SimpleWithReturnCommand<Core.Responses.SimpleWithReturnResponse>(input), new CancellationToken());
            Assert.NotNull(result);
            Assert.Equal($"{input}{input}", result.Result);
        }
    }
}
