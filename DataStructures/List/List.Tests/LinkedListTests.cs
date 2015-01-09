using System;
using NUnit.Framework;

namespace List.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void AddOnEmptySet()
        {
            var array = new Main.LinkedList<int>();
            array.Add(5);
            Assert.That(array.Get(0), Is.EqualTo(5));
        }

        [Test]
        public void AddOnFullSet()
        {
            var array = new Main.LinkedList<int>();
            array.Add(0);
            array.Add(5);
            array.Add(10);
            Assert.That(array.Get(2), Is.EqualTo(10));
        }

        [Test]
        public void RemoveOnEmptySet()
        {
            var array = new Main.LinkedList<int>();
            Assert.That(() => array.Remove(10), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void RemoveOnFullSetWorks()
        {
            var array = new Main.LinkedList<int>();
            array.Add(10);
            array.Add(5);
            var removed = array.Remove(1);

            Assert.That(removed, Is.EqualTo(5));
            Assert.That(array.Length(), Is.EqualTo(1));
        }

        [Test]
        public void RemoveOnFullSetReordersElements()
        {
            var array = new Main.LinkedList<int>();
            array.Add(10);
            array.Add(5);
            array.Remove(0);

            Assert.That(array.Get(0), Is.EqualTo(5));
        }

        [Test]
        public void GetOnEmptySet()
        {
            var array = new Main.LinkedList<int>();

            Assert.That(() => array.Get(10), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void GetOnFullSet()
        {
            var array = new Main.LinkedList<int>();
            array.Add(0);
            array.Add(5);
            array.Add(10);
            Assert.That(array.Get(1), Is.EqualTo(5));
        }

        [Test]
        public void LengthOnEmptySet()
        {
            var array = new Main.LinkedList<int>();
            Assert.That(array.Length(), Is.EqualTo(1));
        }

        [Test]
        public void LengthOnFullSet()
        {
            var array = new Main.LinkedList<int>();
            array.Add(0);
            array.Add(5);
            Assert.That(array.Length(), Is.EqualTo(3));
        }
    }
}
