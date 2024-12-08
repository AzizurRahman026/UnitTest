using MyStackApp;
using NUnit.Framework;

namespace MyStackAppTest
{
    [TestFixture]

    public class MyStackAppTest
    {
        [Test]
        public async Task IsEmpty()
        {
            var stack = new MyStackApp<int>();
            if (stack.IsEmpty())
            {
                Console.WriteLine("Stack is Empty");
            }
            else
            {
                throw new Exception("Stack is not empty...");
            }
            // Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public async Task PushOneItem()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            if (stack.IsEmpty())
            {
                throw new Exception("Stack shouldn't be empty...");
            }
            if (stack.Size() != 1)
            {
                throw new Exception("Stack Size must be 1");
            }

            /*Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Size());*/
        }

        [Test]
        public async Task PushThreeItem()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            if (stack.IsEmpty())
            {
                throw new Exception("Stack shouldn't be empty...");
            }
            if (stack.Size() != 3)
            {
                throw new Exception("Stack Size must be 3");
            }
            /*Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, stack.Size());*/
        }

        [Test]
        public async Task PushThreePopOne()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            if (stack.IsEmpty())
            {
                throw new Exception("Stack shouldn't be empty...");
            }
            if (stack.Size() != 2)
            {
                throw new Exception("Stack Size must be 2");
            }
            /*Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Size());*/
        }
    }
}
