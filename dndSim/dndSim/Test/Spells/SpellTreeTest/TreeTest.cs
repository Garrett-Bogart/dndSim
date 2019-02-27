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
        private Spell s9 = new Spell("i", 2, 5, "*", "*", "*");
        private Spell s10 = new Spell("j", 2, 5, "*", "*", "*");
        
        private Models.Spells.SpellTree.RBTree t;

        public List<Spell> spellList()
        {
            List<Spell> spellsTest = new List<Spell>();
            spellsTest.Add(s1);
            spellsTest.Add(s2);
            spellsTest.Add(s3);
            spellsTest.Add(s4);
            spellsTest.Add(s5);
            //spellsTest.Add(s6);
            /*spellsTest.Add(s7);
            spellsTest.Add(s8);
            spellsTest.Add(s9);
            spellsTest.Add(s10);*/
            return spellsTest;
        }

        [Test]
        public void treeConstructorTest()
        {
            t = new Models.Spells.SpellTree.RBTree();

            t = new Models.Spells.SpellTree.RBTree(s);

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
        public void PrintTreeTest_10_ordered()
        {
            t = new Models.Spells.SpellTree.RBTree();
            String orderTest = "";
            foreach (Spell spell in spellList())
            {
                t.insert(spell);
                orderTest += spell.Name + " ";
                t.Order = "";
                t.printTree();
                //Assert.AreEqual(orderTest, t.Order);
            }
            t.Order = "";
            t.printTree();
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
            t.insert(s6);// grandchild: RL uncle: L
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
            t.insert(s3);//d
            t.insert(s4);//c

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
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Left.Color);
            Assert.AreEqual((int)Models.Spells.SpellTree.color.red, t.Root.Right.Color);

        }
    }
}