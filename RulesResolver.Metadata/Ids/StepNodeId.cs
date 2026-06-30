using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Metadata.Ids
{
    public readonly record struct StepNodeId
    {
        public int Value { get; }

        public StepNodeId(int value)
        {
            Value = value;
        }

        public static StepNodeId Of(int value) => new(value);
    }
}
