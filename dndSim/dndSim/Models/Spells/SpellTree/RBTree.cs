using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dndSim.Models.Spells.SpellTree
{
    public enum color { red, black };
    public class RBTree
    {
        public int Count { get; set; } = 0;
        public Node Root { get; set; }
        public Node Tracker { get; set; }
        public String Order { get; set; } = "";
        public RBTree()
        {
            Root = null;
            Tracker = null; 
        }

        public RBTree(Spell s)
        {
            Root = new Node(s);
            Tracker = Root;
            Count++;
            //check(Root);
        }

        public void insertLeft(Spell s, Node tracker)//might have to be by reference
        {
            if(tracker.Left == null)
            {
                tracker.Left = new Node(s);
                Count++;
            }
            else
            {
                insert(s, tracker.Left);// go to new node
            }
        }

        public void insertRight(Spell s, Node tracker)
        {
            if(tracker.Right == null)
            {
                tracker.Right = new Node(s);
                Count++;
            }
            else
            {
                insert(s, tracker.Right);
            }
        }

        public void insert(Spell s, Node tracker)
        {
            if(string.Compare(s.Name, tracker.Value.Name) == -1)
            {
                insertLeft(s, tracker);
            }
            else if(string.Compare(s.Name, tracker.Value.Name) == 1)
            {
                insertRight(s, tracker);
            }
            check(ref tracker);
        }

        public void insert(Spell s)
        {
            Tracker = Root;
            if(Root == null)
            {
                Root = new Node(s);
                Count++;
            }
            else if(string.Compare(s.Name, Tracker.Value.Name) == -1)
            {
                Tracker = Root.Left;
                insertLeft(s, Tracker);
            }
            else if(string.Compare(s.Name, Root.Value.Name) == 1)
            {
                Tracker = Root.Right;
                insertRight(s, Tracker);
            }
            Root.Color = (int)color.black;
        }

        public void rotateRR(ref Node gp, ref Node p, ref Node c, ref Node s)
        {
            Node newGP = new Node(p);
            Node newParent = new Node(gp);
            newParent.Right = s;
            newGP.Left = newParent;
            gp = new Node(newGP);
            gp.Value = newGP.Value;
            gp.Right = newGP.Right;
            gp.Left = newGP.Left;
            newGP.Color = (int)color.black;
            newParent.Color = (int)color.red;
        }

        public void UnbalancedLine(ref Node current)
        {
            bool isRoot = current.Value.Name == Root.Value.Name ? true : false;
            bool changed = false;
            
            if(current.Color == (int)color.black)
            {
                bool uncle = (current.Left == null || current.Left.Color == (int)color.black) ? true : false;
                if(current.Right != null && current.Right.Color == (int)color.red && uncle)
                {
                    if (current.Right.Right != null && current.Right.Right.Color == (int)color.red)
                    {
                        Node parent = current.Right;
                        Node child = current.Right.Right;
                        Node sibling = current.Right.Left;
                        rotateRR(ref current, ref parent, ref child, ref sibling);
                        changed = true;
                    }
                }
            }

            if(current.Left != null && current.Left.Color == (int)color.red)
            {
                bool uncle = (current.Right == null || current.Right.Color == (int)color.black) ? true : false;
                if (current.Left.Left != null && current.Left.Left.Color == (int)color.red && uncle)
                {
                    Node currentHolder = current;
                    Node siblingHolder = current.Left.Right;
                    current = current.Left;
                    current.Left = current.Left;
                    currentHolder.Left = siblingHolder;
                    current.Right = currentHolder;
                    current.Color = (int)color.black;
                    current.Right.Color = (int)color.red;
                    changed = true;
                }
            }

            if (isRoot && changed)
                Root = current;
        }

        public void UnbalancedTriangle(ref Node current)
        {
            if(current.Color == (int)color.black)
            { 
                if (current.Right != null && current.Right.Color == (int)color.red )
                {
                    bool uncle = (current.Left == null || current.Left.Color == (int)color.black) ? true : false;
                    if (current.Right.Left != null && current.Right.Left.Color == (int)color.red && uncle)
                    {
                        Node parentHolder = current.Right;
                        current.Right = current.Right.Left;
                        parentHolder.Left = current.Right.Right;
                        current.Right.Right = parentHolder;
                    }
                }
                
                if(current.Left != null && current.Left.Color == (int)color.red)
                {
                    bool uncle = (current.Right == null || current.Right.Color == (int)color.black) ? true : false;
                    {
                        if(current.Left.Right != null && current.Left.Right.Color == (int)color.red && uncle)
                        {
                            Node parentHolder = current.Left;
                            current.Left = current.Left.Right;
                            parentHolder.Right = current.Left.Left;
                            current.Left.Left = parentHolder;
                        }
                    }
                }
                 
            }
        }

        public void RedUncle(Node grandparent)
        {
            bool changeColor = false;
            int newColor = grandparent.Color;
            if(grandparent.Left != null && grandparent.Left.Color == (int)color.red)
            {
                if(grandparent.Right != null)
                {
                    if(grandparent.Right.Left != null && grandparent.Right.Left.Color == (int)color.red)
                        changeColor = true;
                    else if(grandparent.Right.Right != null && grandparent.Right.Right.Color == (int)color.red)
                        changeColor = true;
                }
            }

            if(grandparent.Right != null && grandparent.Right.Color == (int)color.red)
            {
                if(grandparent.Left != null)
                {
                    if (grandparent.Left.Right != null && grandparent.Left.Right.Color == (int)color.red)
                        changeColor = true;
                    else if (grandparent.Left.Left != null && grandparent.Left.Left.Color == (int)color.red)
                        changeColor = true;
                }
            }
            
            if (changeColor)
            {
                grandparent.Right.Color = newColor;
                grandparent.Left.Color = newColor;
                grandparent.Color = (int)color.red;
            }
        }

        public void check(ref Node current)
        {
            /*RedUncle(current);
            UnbalancedTriangle(ref current);
            UnbalancedLine(ref current);*/
            Root.Color = (int)color.black;
        }

        public void printTree()
        {
            if(Root != null)
            {
                printTree(Root);
            }
        }

        public void printTree(Node node)
        {
            if (node == null)
                return;
            printTree(node.Left);
            Order += node.Value.Name + " ";
            printTree(node.Right);
            
        }
    }
}