using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Infrastructure.Api.Response.Formatters
{
    public class CsvFormatter:TextOutputFormatter
    {
        public CsvFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            throw new NotImplementedException();
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICsvTypeChecker
    {
        bool CanWriteType(Type type);
    }

    public class CsvTypeChecker : ICsvTypeChecker
    {
        public bool CanWriteType(Type type)
        {
            if(type.GetInterfaces().Contains(typeof(ICsvFormattable)))
        }
    }


}
