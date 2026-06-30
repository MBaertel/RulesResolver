using RulesResolver.Core.Flows.Definitions;
using RulesResolver.Core.Registry;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Instances
{
    internal class FlowInstanceFactory : IFlowInstanceFactory
    {
        private readonly IStepRegistry _stepRegisty;
        public FlowInstanceFactory(IStepRegistry stepRegistry)
        {
            _stepRegisty = stepRegistry;
        }

        public FlowInstance Create(FlowDefinition flowDefinition)
        {
            return new FlowInstance(_stepRegisty,flowDefinition);
        }
    }
}
