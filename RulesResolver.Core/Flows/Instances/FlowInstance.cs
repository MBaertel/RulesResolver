using RulesResolver.Core.Context;
using RulesResolver.Core.Execution;
using RulesResolver.Core.Flows.Definitions;
using RulesResolver.Core.Registry;
using RulesResolver.Core.Steps;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Instances
{
    /// <summary>
    /// The Flow Instance holds all runtime entities required by the flow, and knows how to advance the flow. Essentially a Hydrated FlowDefinition.
    /// </summary>
    public class FlowInstance
    {
        public required IReadOnlyDictionary<Guid,IStep> Steps { get; init; }
        public required IReadOnlyDictionary<Guid,IEnumerable<FlowTransition>> Transitions { get; init; }

        /// <summary>
        /// Resolve the next Node and Transition.
        /// </summary>
        /// <param name="currentNodeId">Id of the last node.</param>
        /// <param name="ctx">flow context.</param>
        /// <returns>Id of the next node, as well as the necessary transition, in a tuple.</returns>
        public (Guid nextNodeId,FlowTransition transition)? GetNextStep(Guid currentNodeId,FlowContext ctx)
        {
            var relevantTransitions = Transitions[currentNodeId];
            foreach (var transition in relevantTransitions)
            {
                if (transition.Condition == null || transition.Condition(ctx))
                {
                    return (transition.Target, transition);
                }
            }
            return null;
        }
    }
}
