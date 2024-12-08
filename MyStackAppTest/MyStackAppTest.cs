using System.Threading.Channels;
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
            var person = new Person("Abdul", true);
            var stack = new MyStackApp<Person>();
            stack.Push(person);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(0, stack.Size());
        }

        [Test]
        public async Task PushPopAndVerify()
        {
            var pushPerson = new Person("Aziz", true);
            var stack = new MyStackApp<Person>();
            stack.Push(pushPerson);
            var popPerson = await stack.Pop();
            Console.WriteLine(popPerson.Name, popPerson.IsGraduated);
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
        public async void PopAndUnderFlowTest()
        {
            var stack = new MyStackApp<int>();
            Assert.Throws<InvalidOperationException>(async()=>await stack.Pop());
        }
    }
}
