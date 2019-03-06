using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
namespace dndSim.Models.Spells.SpellTree
{
    public enum color { red, black };
    public class RBTree
    {
        public int Count { get; set; } = 0;
        public Node Root { get; set; }
        public String Order { get; set; } = "";
        public RBTree()
        {
            Root = null;
        }

        public RBTree(Spell s)
        {
            Root = new Node(s);
            Count++;
            checkRoot();
        }

        public void insertLeft(Spell s, Node current)//might have to be by reference
        {
            if(current.Left == null)
            {
                current.Left = new Node(s);
                Count++;
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
                Count++;
            }
            else
            {
                insert(s, current.Right);
            }
        }

        public void insert(Spell s, Node current)
        {
            if(string.Compare(s.Name, current.Value.Name) == -1)
            {
                insertLeft(s, current);
            }
            else if(string.Compare(s.Name, current.Value.Name) == 1)
            {
                insertRight(s, current);
            }
            check(ref current);
        }

        public void insert(Spell s)
        {
            if(Root == null)
            {
                Root = new Node(s);
                Count++;
            }
            else if(string.Compare(s.Name, Root.Value.Name) == -1)
            {
                insertLeft(s, Root);
            }
            else if(string.Compare(s.Name, Root.Value.Name) == 1)
            {
                insertRight(s, Root);
            }
            checkRoot();
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
            Node grandparent = current;
            Node parent = null;
            Node temp = null;
            if (current.Color == (int)color.black)
            {
                //RR
                bool uncle = (current.Left == null || current.Left.Color == (int)color.black) ? true : false;
                if(current.Right != null && current.Right.Color == (int)color.red && uncle)
                {
                    if (current.Right.Right != null && current.Right.Right.Color == (int)color.red)
                    {
                        temp = new Node(current);
                        parent = current.Right;

                        temp.Right = parent.Left;
                        parent.Left = temp;

                        parent.Color = (int)color.black;
                        temp.Color = (int)color.red;
                        changed = true;
                    }
                }
                //LL
                if (current.Left != null && current.Left.Color == (int)color.red)
                {
                    uncle = (current.Right == null || current.Right.Color == (int)color.black) ? true : false;
                    if (current.Left.Left != null && current.Left.Left.Color == (int)color.red && uncle)
                    {
                        temp = new Node(current);
                        parent = current.Left;

                        temp.Left = parent.Right;
                        parent.Right = temp;

                        parent.Color = (int)color.black;
                        temp.Color = (int)color.red;
                        changed = true;
                    }
                }
            }

            if (changed && parent != null)
            {
                current.Value = parent.Value;
                current.Right = parent.Right;
                current.Left = parent.Left;
            }
                
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
                        Node parent = current.Right;
                        Node child = current.Right.Left;
                        current.Right = child;
                        parent.Left = child.Right;
                        child.Right = parent;
                    }
                }
                
                if(current.Left != null && current.Left.Color == (int)color.red)
                {
                    bool uncle = (current.Right == null || current.Right.Color == (int)color.black) ? true : false;
                    {
                        if(current.Left.Right != null && current.Left.Right.Color == (int)color.red && uncle)
                        {
                            Node parent = current.Left;
                            Node child = current.Left.Right; 
                            current.Left = child;
                            parent.Right = child.Left;
                            child.Left = parent;
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
            RedUncle(current);
            UnbalancedTriangle(ref current);
            UnbalancedLine(ref current);
            Root.Color = (int)color.black;
        }
        public void checkRoot()
        {
            Node root = Root;
            check(ref root);
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