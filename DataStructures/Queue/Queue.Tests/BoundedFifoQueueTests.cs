using System;
using NUnit.Framework;
using Queue.Main;

namespace Queue.Tests
{
    [TestFixture]
    public class BoundedFifoQueueTests
    {
        [Test]
        public void DefaultThresholdIs10()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);
            queue.Enqueue(4);


            Assert.That(() => queue.Enqueue(4), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(0)]
        public void CanAssignThreshold(int threshold)
        {
            var queue = new BoundedFifoQueue<int>(threshold);

            for (var i = 0; i < threshold; i++)
            {
                queue.Enqueue(i);
            }

            Assert.That(() => queue.Enqueue(4), Throws.InstanceOf<IndexOutOfRangeException>());
        }

        [Test]
        public void EnquqeOnEmptySet()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.Size(), Is.EqualTo(1));
        }

        [Test]
        public void DequeueOnEmptySet()
        {
            var queue = new BoundedFifoQueue<int>();

            Assert.That(() => queue.Dequeue(), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DequeueOnFullSet()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.That(() => queue.Dequeue(), Is.EqualTo(4));
        }

        [Test]
        public void ClearOnFullSet()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);
            queue.Clear();

            Assert.That(() => queue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void SizeOnFullSet()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.Size(), Is.EqualTo(1));
        }

        [Test]
        public void SizeOnEmptySet()
        {
            var queue = new BoundedFifoQueue<int>();

            Assert.That(() => queue.Size(), Is.EqualTo(0));
        }

        [Test]
        public void IsEmptyOnFullSet()
        {
            var queue = new BoundedFifoQueue<int>();
            queue.Enqueue(4);

            Assert.That(() => queue.IsEmpty(), Is.False);
        }

        [Test]
        public void IsEmptyOnEmptySet()
        {
            var queue = new BoundedFifoQueue<int>();

            Assert.That(() => queue.IsEmpty(), Is.True);
        }
    }
}
