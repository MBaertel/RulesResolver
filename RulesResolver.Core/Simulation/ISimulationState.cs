using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Simulation
{
    public interface ISimulationState
    {
        T Get<T>(StateKey key);
        void Set<T>(StateKey key,T value);
        bool Has<T>(StateKey key);
    }
}
