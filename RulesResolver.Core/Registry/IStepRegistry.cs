using RulesResolver.Core.Steps;
using RulesResolver.Metadata.Ids;
using RulesResolver.Metadata.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Registry
{
    public interface IStepRegistry
    {
        void Register(IStep step, StepSource source);
        bool TryGetStep(StepId stepId, out IStep? step);
    }
}
