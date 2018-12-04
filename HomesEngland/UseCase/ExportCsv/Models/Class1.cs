using System;
using System.Collections.Generic;
using System.Text;

namespace HomesEngland.UseCase.ExportCsv.Models
{
    public interface ICsvFormattable
    {
        string ToCsv();
    }
}
