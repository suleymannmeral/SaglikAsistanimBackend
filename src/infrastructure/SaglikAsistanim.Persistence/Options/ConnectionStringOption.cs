using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.Options;

public sealed class ConnectionStringOption
{
    public const string Key = "ConnectionStrings";
    public string SqlServer { get; set; } = null!;
}
