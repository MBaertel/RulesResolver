using RulesResolver.Core.Steps;
using RulesResolver.Metadata.Ids;
using RulesResolver.Metadata.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Registry
{
    internal sealed class StepRegistry : IStepRegistry
    {
        private readonly Dictionary<StepId, IStep> _steps = new();

        public void Register(IStep step,StepSource source)
        {
            var localId = Resolvers.ResolveLocalStepId(step.GetType());
            var stepId = source.Qualify(localId);

            if (_steps.ContainsKey(stepId))
                throw new InvalidOperationException($"Duplicate Step Id: {stepId}");

            _steps.Add(stepId, step);
        }

        public bool TryGetStep(StepId stepId, out IStep? step)
        {
            if (!_steps.ContainsKey(stepId))
            {
                step = null;
                return false;
            }
            else
            {
                step = _steps[stepId];
                return true;
            }
        }
    }
}
