using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells.SpellTree
{
    public class Node
    {
        enum color { red, black};
        public int Color { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public Spell Value { get; set; }

        public Node(Spell s)
        {
            Value = s;
            Right = null;
            Left = null;
            Color = (int) color.black;
        }

        public String printNode()
        {
            return Value.Name;
        }
    }
}