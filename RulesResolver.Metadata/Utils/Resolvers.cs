using RulesResolver.Metadata.Attributes;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RulesResolver.Metadata.Utils
{
    public static class Resolvers
    {
        public static string ResolveLocalStepId(Type stepType)
        {
            var attr = stepType.GetCustomAttribute<StepIdAttribute>();
            if (attr != null)
                return attr.LocalIdString;

            return stepType.Name.EndsWith("Step")
                ? stepType.Name[..^4]
                : stepType.Name;
        }
    }
}
