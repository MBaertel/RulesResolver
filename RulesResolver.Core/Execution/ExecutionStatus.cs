using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Execution
{
    public enum ExecutionStatus
    {
        Pending,
        Running,
        Suspended,
        Waiting,
        Faulted,
        Cancelled
    }
}
