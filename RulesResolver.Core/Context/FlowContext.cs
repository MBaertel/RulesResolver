using RulesResolver.Core.Flows;
using RulesResolver.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Context
{
    public sealed class FlowContext
    {
        public IFlowDefinition FlowDefinition { get; }
        public ISimulationState State { get; }

        public CancellationToken Cancellation { get; }

        public FlowContext(
            IFlowDefinition definition,
            ISimulationState state,
            ExecutionContext locals,
            CancellationToken cancellation)
        {
            FlowDefinition = definition;
            State = state;
            Cancellation = cancellation;
        }
    }
}
