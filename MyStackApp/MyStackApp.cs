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

        public async Task<T> Pop()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Stack underflow");
            }
            var obj = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            return obj;
        }

    }
}
