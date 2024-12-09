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

            Assert.IsTrue(stack.IsEmpty());
        }

        [Test]
        public async Task PushOneItem()
        {
            var stack = new MyStackApp<int>();

            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Size());
        }

        [Test]
        public async Task PushThreeItem()
        {
            var stack = new MyStackApp<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, stack.Size());
        }

        [Test]
        public async Task PushThreePopOne()
        {
            var stack = new MyStackApp<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Size());
        }

        [Test]
        public async Task PushPopAndVerifyTheStackIsEmpty()
        {
            var stack = new MyStackApp<Person>();
            var person = new Person("Abdul", true);

            stack.Push(person);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(0, stack.Size());
        }

        [Test]
        public async Task PushPopAndVerify()
        {
            var stack = new MyStackApp<Person>();
            var pushPerson = new Person("Aziz", true);

            stack.Push(pushPerson);
            var popPerson = await stack.Pop();


            Console.WriteLine(pushPerson.Name, popPerson.IsGraduated);
            Assert.AreEqual(pushPerson, popPerson);
        }

        [Test]
        public async Task PushThreePopThreeAndVerify()
        {
            List<Person> pushItem = new List<Person>();
            pushItem.Add(new Person("A", true));
            pushItem.Add(new Person("B", true));
            pushItem.Add(new Person("C", false));

            var stack = new MyStackApp<Person>();

            for (int i = 0; i < 3; ++i)
            {
                stack.Push(pushItem[i]);
            }

            List<Person> popItem = new List<Person>();


            for (int i = 0; i < 3; ++i)
            {
                popItem.Add(await stack.Pop());
            }

            for (int i = 0; i < 3; ++i) // A B C => C B A
            {
                Console.WriteLine(pushItem[i].Name + " " + popItem[3-i-1].Name);
                Assert.AreEqual(pushItem[i], popItem[3-i-1]);
            }
        }

        [Test]
        public async Task PopAndUnderFlowTest()
        {
            var stack = new MyStackApp<int>();

            var ex = Assert.ThrowsAsync<UnderflowException>(() => stack.Pop());

            Assert.AreEqual("Stack underflow: Cannot pop from an empty stack.", ex.Message);
        }

        [Test]
        public async Task PushCallTopAndVerifyNotEmpty()
        {
            var stack = new MyStackApp<Person>();

            var pushPerson = new Person("A", true);
            stack.Push(pushPerson);

            var topValue = stack.Top();

            Assert.IsFalse(stack.IsEmpty());
        }

        [Test]
        public async Task PushTopAndVerify()
        {
            var stack = new MyStackApp<Person>();
            var pushPerson = new Person("Aziz", true);

            stack.Push(pushPerson);
            var topPerson = await stack.Top();


            Console.WriteLine(pushPerson.Name, topPerson.IsGraduated);
            Assert.AreEqual(pushPerson, topPerson);
        }

        [Test]
        public async Task CallTopAndUnderFlowTest()
        {
            var stack = new MyStackApp<int>();

            var ex = Assert.ThrowsAsync<UnderflowException>(() => stack.Top());

            Assert.AreEqual("Stack underflow: Cannot return top.Because empty stack.", ex.Message);
        }
    }
}
