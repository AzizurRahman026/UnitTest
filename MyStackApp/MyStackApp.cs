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
                throw new UnderflowException("Stack underflow: Cannot pop from an empty stack.");
            }
            var obj = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            return obj;
        }

        public async Task<T> Top()
        {

            if (Items.Count == 0)
            {
                throw new UnderflowException("Stack underflow: Cannot return top.Because empty stack.");
            }
            return Items[Items.Count - 1];
        }

    }
}
