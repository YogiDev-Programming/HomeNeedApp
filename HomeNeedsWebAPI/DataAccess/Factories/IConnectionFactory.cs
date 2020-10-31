using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Factories
{
    public interface IConnectionFactory
    {
        IDbConnection Connection { get; }
    }
}
