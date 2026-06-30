using RulesResolver.Core.Flows.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Instances
{
    public interface IFlowInstanceFactory
    {
        FlowInstance Create(FlowDefinition flowDefinition);
    }
}
