using System;
using System.Data;
using System.Threading.Tasks;

using HomesEngland.Domain;
using HomesEngland.Gateway.Exceptions;
using PeregrineDb;
using PeregrineDb.Databases;
using PeregrineDb.Dialects.Postgres;
using PeregrineDb.Schema;

namespace HomesEngland.Gateway
{
    public class PascalCaseColumnNameFactory : IColumnNameFactory
    {
        public string GetColumnName(PropertySchema property)
        {
            return property.Name;
        }
    }
}
