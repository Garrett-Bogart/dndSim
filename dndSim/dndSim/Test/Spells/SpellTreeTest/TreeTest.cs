using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NUnit.Framework;
using dndSim.Models.Spells;
namespace dndSim.Test.Spells.SpellTreeTest
{
    [TestFixture]
    public class TreeTest
    {
        private StringWriter stringWriter = new StringWriter();
        private TextWriter originalOutput = Console.Out;

        private Models.Spells.Spell s = new Spell("Beast Sense", 2, 5, "Action", "Conc. Up to 1 hour", "A willing beast becomes your eyes and ears while the spell lasts. You can no longer perceive your own senses, becoming blind and deaf, but your perception through the beast includes any special senses the beast may have. You may end the spell early using your action to regain your own senses.");
        private Spell s1 = new Spell("a", 2, 5, "*", "*", "*");
        private Spell s2 = new Spell("b", 2, 5, "*", "*", "*");
        private Spell s3 = new Spell("c", 2, 5, "*", "*", "*");
        private Spell s4 = new Spell("d", 2, 5, "*", "*", "*");
        private Spell s5 = new Spell("e", 2, 5, "*", "*", "*");
        private Spell s6 = new Spell("f", 2, 5, "*", "*", "*");
        private Spell s7 = new Spell("g", 2, 5, "*", "*", "*");
        private Spell s8 = new Spell("h", 2, 5, "*", "*", "*");
        
        private Models.Spells.SpellTree.RBTree t;

        public List<Spell> spellList()
        {
            List<Spell> spellsTest = new List<Spell>();
            spellsTest.Add(s1);
            spellsTest.Add(s2);
            spellsTest.Add(s3);
            spellsTest.Add(s4);
            spellsTest.Add(s5);
            spellsTest.Add(s6);
            spellsTest.Add(s7);
            spellsTest.Add(s8);
            return spellsTest;
        }

        public void NodeCheck(Models.Spells.SpellTree.Node node, int expectedColor, String expectedName)
        {
            Assert.AreEqual(expectedColor, node.Color);
            Assert.AreEqual(expectedName, node.Value.Name);
        }

        public void RootCheck(Models.Spells.SpellTree.RBTree tree)
        {
            Assert.AreEqual(1, tree.Root.Color);
        }

        public void BlackCheck(Models.Spells.SpellTree.Node node )
        {
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, node.Color);
        }

        public void RedCheck(Models.Spells.SpellTree.Node node)
        {
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, node.Color);
        }

        [Test]
        public void treeConstructorTest()
        {
            t = new Models.Spells.SpellTree.RBTree();

            t = new Models.Spells.SpellTree.RBTree(s);
            Models.Spells.SpellTree.Node root = t.Root;
            Assert.AreSame(root, t.Root);
            root.Color = (int)Models.Spells.SpellTree.color.red;
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Color);
            t.Root.Color = (int)Models.Spells.SpellTree.color.black;
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, root.Color);
        }

        [Test]
        public void printTreeTest_SingleElement()
        {
            t = new Models.Spells.SpellTree.RBTree(s);
            t.printTree();

            Assert.AreEqual("Beast Sense ", t.Order);
        }

        [Test]
        public void printTreeTest_ThreeElements()
        {
            t = new Models.Spells.SpellTree.RBTree(s2);
            t.insert(s1);
            t.insert(s3);
            t.printTree();
            Assert.AreEqual("a b c ", t.Order);
        }

        [Test]
        public void PrintTreeTest_8_ordered()
        {
            t = new Models.Spells.SpellTree.RBTree();
            String orderTest = "";
            foreach (Spell spell in spellList())
            {
                t.insert(spell);
                orderTest += spell.Name + " ";
                t.Order = "";
                t.printTree();
                Assert.AreEqual(orderTest, t.Order);
            }

            NodeCheck(t.Root, 1, "d");
                NodeCheck(t.Root.Right, 0, "f");
                    NodeCheck(t.Root.Right.Left, 1, "e");
                    NodeCheck(t.Root.Right.Right, 1, "g");
                        NodeCheck(t.Root.Right.Right.Right, 0, "h");
            NodeCheck(t.Root.Left, 0, "b");
                NodeCheck(t.Root.Left.Right, 1, "c");
                NodeCheck(t.Root.Left.Left, 1, "a");
            

        }

        [Test]
        public void PrintTreeTest_8_ReverseOrdered()
        {
            t = new Models.Spells.SpellTree.RBTree();
            String orderTest = "";
            List<Models.Spells.Spell> spells = spellList();
            spells.Reverse();
            foreach (Spell spell in spells)
            {
                t.insert(spell);
            }

            NodeCheck(t.Root, 1, "e");
                NodeCheck(t.Root.Right, 0, "g");
                        NodeCheck(t.Root.Right.Left, 1, "f");
                        NodeCheck(t.Root.Right.Right, 1, "h");
                NodeCheck(t.Root.Left, 0, "c");
                    NodeCheck(t.Root.Left.Right, 1, "d");
                    NodeCheck(t.Root.Left.Left, 1, "b");
                        NodeCheck(t.Root.Left.Left.Left, 0, "a");
        }

        [Test]
        public void PrintTreeTest_6_ordered()
        {
            t = new Models.Spells.SpellTree.RBTree();
            String orderTest = "";
            foreach (Spell spell in spellList())
            {
                t.insert(spell);
                orderTest += spell.Name + " ";
                t.Order = "";
                t.printTree();
                Assert.AreEqual(orderTest, t.Order);
            }
            t.Order = "";
            t.printTree();
        }


        [Test]
        public void RootRecolorationTest()
        {
            t = new Models.Spells.SpellTree.RBTree(s2);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
            t = new Models.Spells.SpellTree.RBTree();
            t.insert(s2);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
        }

        [Test]
        public void UncleRecolorationTestRL()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);
            t.insert(s4);
            t.insert(s7);
            t.insert(s6);// grandchild: RL, uncle: L
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
        }

        [Test]
        public void UncleRecolorationTestRR()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);
            t.insert(s4);
            t.insert(s7);
            t.insert(s8);// grandchild: RR uncle: L
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
        }

        [Test]
        public void UncleRecolorationTestLL()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);
            t.insert(s4);
            t.insert(s7);
            t.insert(s3);// grandchild: LL uncle: R
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
        }

        [Test]
        public void UncleRecolorationTestLR()
        {
            t = new Models.Spells.SpellTree.RBTree(s6);
            t.insert(s3);
            t.insert(s7);
            t.insert(s4);// grandchild: LR uncle: R
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
        }

        [Test]
        public void lineRotationRightTest()
        {
            t = new Models.Spells.SpellTree.RBTree(s1);
            t.insert(s2);
            t.insert(s3);
            Assert.AreEqual("b", t.Root.Value.Name);
            Assert.AreEqual("a", t.Root.Left.Value.Name);
            Assert.AreEqual("c", t.Root.Right.Value.Name);

            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Color);
        }

        [Test]
        public void lineRotationLeftTest()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);//e
            t.insert(s4);//d
            t.insert(s3);//c
            Assert.AreEqual("d", t.Root.Value.Name);
            Assert.AreEqual("c", t.Root.Left.Value.Name);
            Assert.AreEqual("e", t.Root.Right.Value.Name);

            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Color);
        }

        [Test]
        public void TriangleRotationLRTest()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);//e
            RootCheck(t);
            t.insert(s3);//c
            t.insert(s4);//d

            Assert.AreEqual("d", t.Root.Value.Name);
            Assert.AreEqual("c", t.Root.Left.Value.Name);
            Assert.AreEqual("e", t.Root.Right.Value.Name);

            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Color);

        }

        [Test]
        public void TriangleRotationRLTest()
        {
            t = new Models.Spells.SpellTree.RBTree(s1);//a
            t.insert(s3);//c
            t.insert(s2);//b

            Assert.AreEqual("b", t.Root.Value.Name);
            Assert.AreEqual("a", t.Root.Left.Value.Name);
            Assert.AreEqual("c", t.Root.Right.Value.Name);

            Assert.AreEqual((int)Models.Spells.SpellTree.color.black, t.Root.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Color);

        }

        [Test]
        public void NonRootRR()
        {
            t = new Models.Spells.SpellTree.RBTree(s3);
            t.insert(s2);
            t.insert(s4);
            t.insert(s5);

            RootCheck(t);
            BlackCheck(t.Root.Right);
            BlackCheck(t.Root.Left);
            RedCheck(t.Root.Right.Right);

            Assert.AreEqual("c", t.Root.Value.Name);
                Assert.AreEqual("d", t.Root.Right.Value.Name);
                    Assert.IsNull(t.Root.Right.Left);
                        Assert.AreEqual("e", t.Root.Right.Right.Value.Name);
                        Assert.IsNull(t.Root.Right.Right.Left);
                        Assert.IsNull(t.Root.Right.Right.Right);
            Assert.AreEqual("b", t.Root.Left.Value.Name);

            t.insert(s6);

            Assert.AreEqual("c", t.Root.Value.Name);
                Assert.AreEqual("e", t.Root.Right.Value.Name);
                    Assert.AreEqual("f", t.Root.Right.Right.Value.Name);
                    Assert.AreEqual("d", t.Root.Right.Left.Value.Name);
                Assert.AreEqual("b", t.Root.Left.Value.Name);

            BlackCheck(t.Root);
            BlackCheck(t.Root.Right);
                RedCheck(t.Root.Right.Right);
                RedCheck(t.Root.Right.Left);
            BlackCheck(t.Root.Left);


        }

        [Test]
        public void NonRootLL()
        {
            t = new Models.Spells.SpellTree.RBTree(s5);//e
            t.insert(s6);
            t.insert(s4);
            t.insert(s3);

            RootCheck(t);
            BlackCheck(t.Root.Right);
            BlackCheck(t.Root.Left);
            RedCheck(t.Root.Left.Left);

            Assert.AreEqual("e", t.Root.Value.Name);
                Assert.AreEqual("f", t.Root.Right.Value.Name);
                    Assert.IsNull(t.Root.Right.Left);
                    Assert.IsNull(t.Root.Right.Right);
                Assert.AreEqual("d", t.Root.Left.Value.Name);
                    Assert.AreEqual("c",t.Root.Left.Left.Value.Name);
                    Assert.IsNull(t.Root.Left.Right);

            t.insert(s2);

            Assert.AreEqual("e", t.Root.Value.Name);
            Assert.AreEqual("f", t.Root.Right.Value.Name);
            Assert.AreEqual("c", t.Root.Left.Value.Name);
            Assert.AreEqual("d", t.Root.Left.Right.Value.Name);
            Assert.AreEqual("b", t.Root.Left.Left.Value.Name);

            BlackCheck(t.Root);
            BlackCheck(t.Root.Right);
            RedCheck(t.Root.Left.Right);
            RedCheck(t.Root.Left.Left);
            BlackCheck(t.Root.Left);


        }
    }
}