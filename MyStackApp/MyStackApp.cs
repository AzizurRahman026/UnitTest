namespace MyStackApp
{
    public class MyStackApp<T>
    {
        private List<T> Items { get; set; } = new List<T>();
        public bool IsEmpty()
        {

            return !Items.Any();
        }

        public void Push(T item)
        {
            Items.Add(item);
        }

        public int Size()
        {
            return Items.Count;
        }

        public void Pop()
        {
            Items.RemoveAt(Items.Count - 1);
        }

    }
}
