using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells.SpellTree
{
    public class RBTree
    {
        public Node Root { get; set; }
        public Node Current { get; set; }
        public RBTree()
        {
            Root = null;
        }

        public RBTree(Spell s)
        {
            Root = new Node(s);
        }

        public void insertLeft(Spell s, Node current)//might have to be by reference
        {
            if(current.Left == null)
            {
                current.Left = new Node(s);
            }
            else
            {
                insert(s, current.Left);// go to new node
            }
        }

        public void insertRight(Spell s, Node current)
        {
            if(current.Right == null)
            {
                current.Right = new Node(s);
            }
            else
            {
                insert(s, current.Right);
            }
        }

        public void insert(Spell s, Node current)
        {
            if(string.Compare(s.Name, Current.Value.Name) == -1)
            {
                insertLeft(s, current);
            }
            else if(string.Compare(s.Name, Current.Value.Name) == 1)
            {
                insertRight(s, current);
            }
        }

        public void insert(Spell s)
        {
            if(Root == null)
            {
                Root = new Node(s);
                return;
            }
            if(string.Compare(s.Name, Current.Value.Name) == -1)//new spell is < current spell
            {
                insertLeft(s, Root);
            }
            else if(string.Compare(s.Name, Current.Value.Name) == 1)
            {
                insertRight(s, Root);
            }
        }

        public void printTree()
        {
            if(Root != null)
            {
                
            }
        }

        public void printTree(Node node)
        {
            //if(node )
        }
    }
}