using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections;

namespace CompareCollections
{
    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CollectionsComparer>();
        }

        public class CollectionsComparer
        {
            private List<int> _findInList;
            private ArrayList _findInArrayList;
            private LinkedList<int> _findInLinkedList;

            public CollectionsComparer()
            {
                _findInList = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    _findInList.Add(i);
                }
                _findInArrayList = new ArrayList();
                for (int i = 0; i < 1000; i++)
                {
                    _findInArrayList.Add(i);
                }
                _findInLinkedList = new LinkedList<int>();
                for (int i = 0; i < 1000; i++)
                {
                    _findInLinkedList.AddLast(i);
                }
            }

            [Benchmark]
            public void FillList()
            {
                List<int> list = new List<int>();
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(i);
                }
            }

            [Benchmark]
            public int Find496ElInList()
            {
                return this._findInList[496];
            }

            [Benchmark]
            public int Find496ElInArrayList()
            {
                return (int)this._findInArrayList[496];
            }

            [Benchmark]
            public int Find496ElInLinkedList()
            {
                foreach (var item in this._findInLinkedList)
                {
                    if (item == 496)
                    {
                        return item;
                    }
                }
                return -1;
            }
            [Benchmark]
            public void Out777InList()
            {
                foreach(var item in this._findInList)
                {
                    if(item % 777 == 0)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            [Benchmark]
            public void Out777InArrayList()
            {
                foreach (var item in this._findInArrayList)
                {
                    if (Convert.ToInt32(item) % 777 == 0)
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            [Benchmark]
            public void Out777InLinkedList()
            {
                foreach (var item in this._findInLinkedList)
                {
                    if (item % 777 ==  0)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            [Benchmark]
            public void FillArrayList()
            {
                ArrayList arrayList = new ArrayList();
                for (int i = 0; i < 1000; i++)
                {
                    arrayList.Add(i);
                }
            }

            [Benchmark]
            public void FillLinkedList()
            {
                LinkedList<int> linkList = new LinkedList<int>();
                for (int i = 0; i < 1000; i++)
                {
                    linkList.AddLast(i);
                }
            }
        }
    }
}