using RulesResolver.Core.Flows.Definitions;
using RulesResolver.Core.Registry;
using RulesResolver.Core.Steps;
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
            var steps = new Dictionary<Guid, IStep>();
            var transitions = new Dictionary<Guid, IEnumerable<FlowTransition>>();
			foreach (var stepKvp in flowDefinition.Steps)
			{
                var id = stepKvp.Key;
                if (!_stepRegisty.TryGetStep(stepKvp.Value.Step, out var step))
                    throw new InvalidOperationException();

                steps[id] = step!;
                transitions[id] = stepKvp.Value.Transitions;
			}

            return new FlowInstance { 
                Steps = steps,
                Transitions = transitions
            };
		}
    }
}
