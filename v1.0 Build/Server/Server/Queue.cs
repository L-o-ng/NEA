namespace Server
{
    public class _Queue<T>
    {
        private T[] items;
        private int front; 
        private int rear; 
        private int count; 

        public _Queue(int capacity) {
            items = new T[capacity];
            front = 0;
            rear = -1; 
            count = 0;
        }

        public void Enqueue(T item) {
            if (count == items.Length) {
                throw new InvalidOperationException("Queue is full.");
            }
            rear = (rear + 1) % items.Length; 
            items[rear] = item;
            count++;
        }

        public T Dequeue() {
            if (count == 0) {
                throw new InvalidOperationException("Queue is empty.");
            }
            T item = items[front];
            front = (front + 1) % items.Length; 
            count--;
            return item;
        }

        public int Count
        {
            get { return count; }
        }

        
        public T Peek() {
            if (count == 0) {
                throw new InvalidOperationException("Queue is empty.");
            }
            return items[front];
        }

        
        public bool IsEmpty() {
            return count == 0;
        }

       
        public bool IsFull() {
            return count == items.Length;
        }
    }
}
