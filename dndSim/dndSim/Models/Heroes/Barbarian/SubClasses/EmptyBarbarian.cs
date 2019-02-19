using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Heroes.Barbarians.SubClasses
{
    public class EmptyBarbarian : PrimalPath
    {
        public EmptyBarbarian(){}
        public override List<String> toString()
        {
            return new List<String>() { "No primal path available" };
        }
    }
}