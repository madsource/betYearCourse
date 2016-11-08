using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadListTask
{
    class MadList
    {
        private string[] array;
        private static int currentIndex;

        public event ChangeDelegate OnAdd;
        public event ChangeDelegate OnRemove;

        public MadList()
        {
            array = new string[2];
            currentIndex = 0;
            OnAdd += showAddInfo;
            OnRemove += showRemoveInfo;
        }

        public MadList(ChangeDelegate onAdd, ChangeDelegate onRemove) : this()
        {
            OnAdd += onAdd;
            OnRemove += onRemove;
        }

        public void Add(string element)
        {
            if (currentIndex >= array.Length)
            {
                var doubledArray = new string[currentIndex*2];
                array.CopyTo(doubledArray, 0);
                this.array = doubledArray;
            }
            
            array[currentIndex] = element;
            currentIndex++;
            this.OnAdd(this, new ChangeDelegateArgs());
        }

        public void Remove(string element)
        {
            int elementIndex = Array.IndexOf(array, element);
            
            if (elementIndex > 0)
            {
                var newArray = new string[array.Length - 1];
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

            this.OnRemove(this, new ChangeDelegateArgs());
        }

        public bool Contains(string element)
        {
            return Array.IndexOf(array, element) != -1;
        }

        public string GetElementAt(int index)
        {
            return array[index];
        }

        static void showAddInfo(object sender, ChangeDelegateArgs args)
        {
            Console.WriteLine("\nAdded");
        }

        static void showRemoveInfo(object sender, ChangeDelegateArgs args)
        {
            Console.WriteLine("\nRemoved");
        }
    }

    internal delegate void ChangeDelegate(object sender, ChangeDelegateArgs args);

   
}
