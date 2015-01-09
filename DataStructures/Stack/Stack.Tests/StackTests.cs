using NUnit.Framework;
using Stack.Main;

namespace Stack.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push()
        {
            var stack = new Stack<int>();
            stack.Push(3);

            Assert.That(() => stack.Peek(), Is.EqualTo(3));
        }

        [Test]
        public void Pop()
        {
            var stack = new Stack<int>();
            stack.Push(3);
            stack.Push(4);

            Assert.That(() => stack.Pop(), Is.EqualTo(4));
            Assert.That(() => stack.Size(), Is.EqualTo(1));
        }

        [Test]
        public void Size()
        {
            var stack = new Stack<int>();
            stack.Push(6);
            stack.Push(26);

            Assert.That(() => stack.Size(), Is.EqualTo(2));
        }

        [Test]
        public void Peek()
        {
            var stack = new Stack<int>();
            stack.Push(4);
            stack.Push(5);

            Assert.That(() => stack.Peek(), Is.EqualTo(5));
            Assert.That(() => stack.Size(), Is.EqualTo(2));
        }

        [Test]
        public void IsEmptyOnEmptySet()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.IsEmpty(), Is.True);
        }

        [Test]
        public void IsEmptyOnFullSet()
        {
            var stack = new Stack<int>();
            stack.Push(4);

            Assert.That(() => stack.IsEmpty(), Is.False);
        }

        [Test]
        public void ClearOnFullSet()
        {
            var stack = new Stack<int>();
            stack.Push(4);
            stack.Clear();

            Assert.That(() => stack.IsEmpty(), Is.True);
        }
    }
}
