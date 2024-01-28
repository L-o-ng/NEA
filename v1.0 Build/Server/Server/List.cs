namespace Server
{
    public class _List<T>
    {
        private T[] items;
        private int count;
        public int Count
        {
            get { return count; }
        }
        public T this[int index]
        {
            get {
                if (index < 0 || index >= count) {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return items[index];
            }
            set {
                if (index < 0 || index >= count) {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                items[index] = value;
            }
        }

        public _List() {
            items = new T[4]; 
            count = 0;
        }

        public void Add(T item) {
            if (count == items.Length) {
                Array.Resize(ref items, items.Length + 1);
            }
            items[count++] = item;
        }

        public void RemoveAt(int index) {
            if (index < 0 || index >= count) {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < count - 1; i++) {
                items[i] = items[i + 1];
            }

            items[count - 1] = default(T);
            count--;
        }
        public bool Remove(T item) {
            int index = IndexOf(item);
            if (index != -1) {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        private int IndexOf(T item) {
            for (int i = 0; i < count; i++) {
                if (Equals(items[i], item)) {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
