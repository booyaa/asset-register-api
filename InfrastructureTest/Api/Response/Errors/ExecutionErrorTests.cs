using System;
using FluentAssertions;
using Infrastructure.Api.Response.Errors;
using NUnit.Framework;

namespace InfrastructureTest.Api.Response.Errors
{
    [TestFixture]
    public class ExecutionErrorTests
    {
        [Test]
        public void GivenExceptionIsNull_ExecutionErrorHas_EmptyMessage()
        {
            //arrange
            //act
            var exception = new ExecutionError(null);
            //assert
            exception.Message.Should().BeNullOrEmpty();

        }

        [Test]
        public void GivenNewExecutionError_ExecutionErrorHas_EmptyMessage()
        {
            //arrange
            //act
            var exception = new ExecutionError();
            //assert
            exception.Message.Should().BeNullOrEmpty();

        }

        [TestCase("Unhandled Exception")]
        [TestCase("Threading Exception")]
        public void GivenException_ApiExceptionHas_Message(string message)
        {
            //arrange
            //act
            var exception = new ExecutionError(new Exception(message));
            //assert
            exception.Message.Should().BeEquivalentTo(message);
        }
    }
}