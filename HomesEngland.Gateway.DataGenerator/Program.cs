using System;
using HomesEngland.UseCase.Models;
using Infrastructure.Api.Response.Validation;

namespace HomesEngland.Gateway.DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IInputSanitizer
    {
        
    }

    public class GenerateDataRequest : IRequest
    {
        public RequestValidationResponse Validate(IRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
