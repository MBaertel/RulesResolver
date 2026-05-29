using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Metadata.Ids
{
    public readonly record struct StepId
    {
        public string Value { get; }

        public StepId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("value cannot be empty",nameof(value));
            Value = value;
        }

        public static StepId Of(string value) => new(value);
    }
}
