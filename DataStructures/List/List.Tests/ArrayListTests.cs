using System;
using List.Main;
using NUnit.Framework;

namespace List.Tests
{
    [TestFixture]
    public class ArrayListTests
    {
        [Test]
        public void DefaultConstructorSizeTen()
        {
            var array = new ArrayList<int>();
            Assert.That(array.Length(), Is.EqualTo(10));
        }

        [Test]
        public void AddOnEmptySet()
        {
            var array = new ArrayList<int>(2);
            array.Add(5);
            Assert.That(array.Get(0), Is.EqualTo(5));
        }

        [Test]
        public void AddOnFullSetCreatesNewArrayIfMaxed()
        {
            var array = new ArrayList<int>(2);
            array.Add(0);
            array.Add(5);
            array.Add(10);
            Assert.That(array.Length(), Is.EqualTo(12));
        }

        [Test]
        public void RemoveOnEmptySet()
        {
            var array = new ArrayList<int>();
            Assert.That(() => array.Remove(10), Throws.Exception);
        }

        [Test]
        public void RemoveOnFullSetWorks()
        {
            var array = new ArrayList<int>();
            array.Add(10);
            array.Add(5);
            var removed = array.Remove(1);

            Assert.That(removed, Is.EqualTo(5));
        }

        [Test]
        public void RemoveOnFullSetReordersElements()
        {
            var array = new ArrayList<int>();
            array.Add(10);
            array.Add(5);
            array.Remove(0);

            Assert.That(array.Get(0), Is.EqualTo(5));
        }

        [Test]
        public void GetOnEmptySet()
        {
            var array = new ArrayList<int>();

            Assert.That(() => array.Get(10), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void GetOnFullSet()
        {
            var array = new ArrayList<int>(2);
            array.Add(0);
            array.Add(5);
            array.Add(10);
            Assert.That(array.Get(1), Is.EqualTo(5));
        }

        [Test]
        public void LengthOnFullSet()
        {
            var array = new ArrayList<int>(3);
            array.Add(0);
            array.Add(5);
            Assert.That(array.Length(), Is.EqualTo(3));
        }
    }
}
