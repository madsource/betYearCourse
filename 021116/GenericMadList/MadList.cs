using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMadList
{
    class MadList<T> : IEnumerable<T> where T : struct
    {
        private T[] array;
        private int currentIndex;

        public event Action OnAddEvent;
        public event Action OnRemoveEvent;

        public MadList()
        {
            array = new T[2];
            currentIndex = 0;
            OnAddEvent += showAddInfo;
            OnRemoveEvent += showRemoveInfo;
        }

        public MadList(Action onAddEvent, Action onRemoveEvent) : this()
        {
            OnAddEvent += onAddEvent;
            OnRemoveEvent += onRemoveEvent;
        }
        // Indexer
        public T this[int index]
        {
            get { return this.GetElementAt(index); }
            set { this.SetElementAt(index, value); }
        }

        public void Add(T element)
        {
            if (currentIndex >= array.Length)
            {
                var doubledArray = new T[currentIndex*2];
                array.CopyTo(doubledArray, 0);
                this.array = doubledArray;
            }
            
            array[currentIndex] = element;
            currentIndex++;
            this.OnAddEvent?.Invoke();
        }

        public void Remove(T element)
        {
            int elementIndex = Array.IndexOf(array, element);
            
            if (elementIndex > 0)
            {
                var newArray = new T[array.Length - 1];
                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (i != elementIndex)
                    {
                        newArray[index] = array[i];
                        Console.Write(newArray[index] + " ");
                        index++;
                    }
                    else
                    {
                        index = i - 1;
                        continue;
                    }
                }
            }

            this.OnRemoveEvent?.Invoke();
        }

        public bool Contains(T element)
        {
            return Array.IndexOf(array, element) != -1;
        }

        public T GetElementAt(int index)
        {
            CheckIndexValid(index);
            return this.array[index];
        }

        public void SetElementAt(int index, T value)
        {
            CheckIndexValid(index);
            this.array[index] = value;
        }

        private void CheckIndexValid(int index)
        {
            if (index >= this.currentIndex || index < 0)
                throw new IndexOutOfRangeException();
        }

        static void showAddInfo()
        {
            Console.WriteLine("\nAdded");
        }

        static void showRemoveInfo()
        {
            Console.WriteLine("\nRemoved");
        }

        // yield - only for enumerators. Return without ending in foreach.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal delegate void ChangeDelegate(object sender, ChangeDelegateArgs args);

   
}
