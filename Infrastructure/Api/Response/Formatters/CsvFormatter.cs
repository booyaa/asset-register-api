using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Infrastructure.Api.Response.Formatters
{
    public class CsvFormatter:TextOutputFormatter
    {
        public CsvFormatter()
        {

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
}
