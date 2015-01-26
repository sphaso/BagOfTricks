using System;
using NUnit.Framework;
using Queue.Main;

namespace Queue.Tests
{
    [TestFixture]
    public class FifoQueueTests
    {
        [Test]
        public void EnquqeOnEmptySet()
        {
            var queue = new FifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.Size(), Is.EqualTo(1));
        }

        [Test]
        public void DequeueOnEmptySet()
        {
            var queue = new FifoQueue<int>();

            Assert.That(() => queue.Dequeue(), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DequeueOnFullSet()
        {
            var queue = new FifoQueue<int>();
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.That(() => queue.Dequeue(), Is.EqualTo(4));
        }

        [Test]
        public void ClearOnFullSet()
        {
            var queue = new FifoQueue<int>();
            queue.Enqueue(4);
            queue.Clear();

            Assert.That(() => queue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void SizeOnFullSet()
        {
            var queue = new FifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.Size(), Is.EqualTo(1));
        }

        [Test]
        public void SizeOnEmptySet()
        {
            var queue = new FifoQueue<int>();

            Assert.That(() => queue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void IsEmptyOnFullSet()
        {
            var queue = new FifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.IsEmpty(), Is.False);
        }

        [Test]
        public void IsEmptyOnEmptySet()
        {
            var queue = new FifoQueue<int>();
            
            Assert.That(() => queue.IsEmpty(), Is.True);
        }
    }
}
