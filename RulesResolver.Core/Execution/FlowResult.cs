using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Execution
{
    public enum FlowResult
    {
        Advanced,
        Suspended,
        Completed,
        Cancelled
    }
}
