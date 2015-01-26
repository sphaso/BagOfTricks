using System;
using Iterator.Main;
using NUnit.Framework;

namespace Iterator.Tests
{
    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void NextOnEmptySet()
        {
            var iterator = new Iterator<int>(new int[] {});
            Assert.That(() => iterator.Next(), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void NextOnFullSet()
        {
            var iterator = new Iterator<int>(new int[] {1, 2, 3});
            Assert.That(() => iterator.Next(), Is.EqualTo(2));
        }

        [Test]
        public void CurrentOnEmptySet()
        {
            var iterator = new Iterator<int>(new int[] { });
            Assert.That(() => iterator.Current(), Throws.Exception);
        }

        [Test]
        public void CurrentOnFullSet()
        {
            var iterator = new Iterator<int>(new int[] { 1, 2, 3 });
            Assert.That(() => iterator.Current(), Is.EqualTo(1));
        }

        [Test]
        public void CurrentOnFullSetAfterNext()
        {
            var iterator = new Iterator<int>(new int[] { 1, 2, 3 });
            iterator.Next();
            Assert.That(() => iterator.Current(), Is.EqualTo(2));
        }

        [Test]
        public void EofOnEmptySet()
        {
            var iterator = new Iterator<int>(new int[] { });
            Assert.That(() => iterator.Eof(), Is.False);
        }

        [Test]
        public void EofOnFullSet()
        {
            var iterator = new Iterator<int>(new int[] { 1, 2, 3 });
            iterator.Next();
            iterator.Next();
            Assert.That(() => iterator.Eof(), Is.True);
        }
    }
}
