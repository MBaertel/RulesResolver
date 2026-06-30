using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Registry
{
    public readonly struct StepSource
    {
        public string Prefix { get; }

        public StepSource(string prefix)
        {
            Prefix = prefix;
        }

        public StepId Qualify(string localId)
            => new StepId($"{Prefix}.{localId}");
    }
}
