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
    public class FlowInstance
    {
        public object? Payload { get; set; }

        private Dictionary<string, object?> _variables = new();
        public IReadOnlyDictionary<string, object?> Variables => _variables.AsReadOnly();

        public void SetVariable(string key, object? value) =>
            _variables[key] = value;

        public bool TryGetVariable(string key, out object? value) =>
            _variables.TryGetValue(key, out value);


        private Dictionary<StepNodeId, IStep> steps = new();
        private Dictionary<StepNodeId, List<FlowTransition>> transitions = new();

        private StepNodeId currentStep;

        private FlowContext context;


        public FlowInstance(IStepRegistry stepRegistry,FlowDefinition definition)
        {
            context = new FlowContext(this);
            currentStep = definition.EntryStep;
            foreach (var step in definition.Steps)
            {
                var resolved = stepRegistry.TryGetStep(step.Value.Step, out var resolvedStep);
                if (!resolved) throw new InvalidOperationException("StepId not found");
                steps.Add(step.Key, resolvedStep!);

                transitions[step.Key] = step.Value.Transitions.ToList();
            }
        }

        public FlowResult Step()
        {
            var step = steps[currentStep];
            var result = step.Execute(Payload, out var resultObject);

            if(result == StepResult.Continue)
            {
                Payload = resultObject;
                var stepNext = GetNextStep(currentStep);
                if (stepNext == null) return FlowResult.Completed;

                currentStep = stepNext!.Value.id;
                Payload = stepNext.Value.payload;

                return FlowResult.Advanced;
            }
            else if(result == StepResult.Suspend)
            {
                return FlowResult.Suspended;
            }
            else
            {
                return FlowResult.Cancelled;
            }
        }

        private (StepNodeId id,object? payload)? GetNextStep(StepNodeId currentStep)
        {
            var relevantTransitions = transitions[currentStep];
            foreach (var transition in relevantTransitions)
            {
                if (transition.Condition == null || transition.Condition(context))
                {
                    var newPayload = transition.Transform(context);
                    return (transition.Target, newPayload);
                }
            }
            return null;
        }
    }
}
