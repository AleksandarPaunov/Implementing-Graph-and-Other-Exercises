using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

namespace Graph
{
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> nodes, IEnumerable<Tuple<T, T>> links)
        {
            foreach (var vertex in nodes)
                AddVertex(vertex);
            foreach (var edge in links)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();
        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }
        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {

                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);

            }
        }

    } // Implementation of  a graph
    public class Algorithms
    {
        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))

                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))

                    continue;
                visited.Add(vertex);

                foreach (var neightbour in graph.AdjacencyList[vertex])

                    if (!visited.Contains(neightbour))
                        queue.Enqueue(neightbour);




            }
            return visited;
        }





    }





    class Program
    {
        private static void TraverseDirectories(DirectoryInfo dir, string identification)
        {
            Console.WriteLine(identification + dir.FullName);
            DirectoryInfo[] subFolders = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            foreach (var folder in subFolders)
            {
                TraverseDirectories(folder, "");
                foreach (var file in files)
                {
                    Console.WriteLine(file.FullName);
                }
            }
        }
        private static void TraverseDirectories(string path)
        {
            TraverseDirectories(new DirectoryInfo(path), " ");
        }
        private static void TraverseDirectoriesBFS(string path)
        {
            Queue<DirectoryInfo> visitedQueue = new Queue<DirectoryInfo>();
            visitedQueue.Enqueue(new DirectoryInfo(path));
            while (visitedQueue.Count > 0)
            {
                var currentDir = visitedQueue.Dequeue();
                Console.WriteLine(currentDir.FullName);

                var children = currentDir.GetDirectories();
                foreach (var child in children)
                {
                    visitedQueue.Enqueue(child);
                }
            }

        }      // Method for finding all subfolders
       

        public static int FindMaxElement(int[] array)
        {
            int maxEl = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxEl)
                {
                    maxEl = array[i];
                }
            }
            return maxEl;
        } // find maximum value element in array
        public static string MinElement(int[] arr)
        {
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }
            string result = minValue + " " + maxValue;
            return result;

        }   // find minimum value element in array

        static void Main()
        {

            
            #region Dictionary zadacha 1 
            // Find all the even occurences of number in a array. Use of dictionary is a must.
            int newValue = 1;
            int[] randomNum = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };
            Dictionary<int, int> Dictionary = new Dictionary<int, int>();
            for (int i = 0; i < randomNum.Length; i++)
            {
                int count = 1;
                if (Dictionary.TryGetValue(randomNum[i], out count))
                {
                    Dictionary[randomNum[i]] = count + newValue;
                }
                else
                {
                    Dictionary.Add(randomNum[i], newValue);
                }

            }


            //foreach (var n in Dictionary)
            //{

            //    if (n.Value % 2 == 0)
            //    {
            //        Console.WriteLine(n.Key + " " + n.Value);
            //    }


            //}
            #endregion;
            #region Dictionary zadacha2 
            // Find how many times each word is found in a random string, ignoring upper case.
            //Printing the results commented out.
            string text = "This is Random,text for texts,lol test text.Is this the text?";
            string edited = text.ToLower();
            edited = edited.Trim();
            string[] words = edited.Split(',', ' ', '.', '?');

            Dictionary<string, int> asd = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i]=="")
                {
                    break;
                }
                int count;
                if (asd.TryGetValue(words[i], out count))
                {
                    count = 1;
                }
                asd[words[i]] = count+1;

            }

            //foreach (var qwe in asd)
            //{
            //    Console.WriteLine(qwe.Key + " " + qwe.Value);


            //}



            #endregion


        }
        }
    }

