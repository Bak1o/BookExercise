using BookExercise;
using BookExercise._22thExercise;
using BookExercise.CreatingAndUsingObjects;
using BookExercise.CustomDataStructures;
using BookExercise.DictionariesAndHashCodes;
using BookExercise.OtherNameSpace;
using BookExercise.TreesAndGraphs;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    static char[,] lab =
{
{' ', ' ', ' ', '*', ' ', ' ', ' '},
{'*', '*', ' ', '*', ' ', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', ' '},
{' ', '*', '*', '*', '*', '*', ' '},
{' ', ' ', ' ', ' ', ' ', ' ', 'e'},
};
    static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int position = 0;

    public static void Main(string[] args)
    {
        

        Graph graph = new Graph(new List<int>[]
        {
            new List<int>() { 1, 2 },
            new List<int>() { 0, 2},
            new List<int>() { 0, 1, 3, 4 },
            new List<int>() { 2, 4 },
            new List<int>() { 2, 3 }

        });
        Graph graph1 = new Graph(new List<int>[]
        {
            new List<int>() { 1, 2 },
            new List<int>() { 0, 3},
            new List<int>() { 0, 3},
            new List<int>() { 1, 2 },
            new List<int>() { 5, 6},
            new List<int>() { 4, 7},
            new List<int>() { 4, 7},
            new List<int>() { 5, 6}


        });
        Graph graph2 = new Graph(new List<int>[]
       {
            new List<int>() { 6, 1},
            new List<int>() { 0, 2, 5},
            new List<int>() { 1, 3 },
            new List<int>() { 2, 4},
            new List<int>() { 3, 5 },
            new List<int>() { 1, 4, 6 },
            new List<int>() { 0, 5 }

       });




        PhoneBook phoneBook = BuildPhoneBookFromFile("phonebook.txt");
        phoneBook.PrintByTown("San Antonio");

        

        
    }
    public static PhoneBook BuildPhoneBookFromFile(string path)
    {
        string[] lines = File.ReadAllLines(path);
        if (lines.Length > 0)
        {
            PhoneBook phoneBook = new PhoneBook();
            
            foreach (string line in lines)
            {
               
                string[] entry = line.Split('|');
                string name = entry[0].Trim();
                string city = entry[1].Trim();
                string phoneNumber = entry[2].Trim();
                Contact contact = new Contact(name, city, phoneNumber);
                phoneBook.Add(contact);
            }
            return phoneBook;

        }
        return null;
    }
    public static void BuildCourcesFromFile(string path)
    {
        try
        {
            
            Dictionary<string, List<Studentt>> courses = new Dictionary<string, List<Studentt>>();
            string[] lines = File.ReadAllLines(path);
            if (lines.Length > 0)
            {
                foreach (string line in lines)
                {
                    string[] entry = line.Split(new char[] { '|' });
                    string firstName = entry[0].Trim();
                    string lastName = entry[1].Trim();
                    string course = entry[2].Trim();
                    List<Studentt> students;
                    if (!courses.TryGetValue(course, out students))
                    {
                        students = new List<Studentt>();
                        courses.Add(course, students);
                    }
                    Studentt student = new Studentt(firstName, lastName);
                    students.Add(student);

                }
            }

            foreach (KeyValuePair<string,List<Studentt>> pair in courses)
            {
                Console.WriteLine($" Cource {pair.Key}:");
                List<Studentt> students = pair.Value;
                students.Sort();
                foreach (Studentt student in students)
                {
                    Console.WriteLine($"/t {student} ");
                }
                Console.WriteLine();
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static void PrintSubSets(string[] arr)
    {
        Queue<List<int>> queue = new Queue<List<int>>();
        List<int> emptySet = new List<int>();
        queue.Enqueue(emptySet);
        while (queue.Count > 0)
        {
            List<int> subset = queue.Dequeue();
            Console.Write("{ ");
            foreach (int i in subset)
            {
                int index = i;
                Console.Write($" {arr[index]} ");

            }
            Console.Write(" }");
            Console.WriteLine();
            int start = -1;
            if (subset.Count > 0)
            {
                start = subset[subset.Count - 1];
            }
            for (int i = start + 1; i < arr.Length; i++)
            {
                List<int> newSubSet = new List<int>();
                newSubSet.AddRange(subset);
                newSubSet.Add(i);
                queue.Enqueue(newSubSet);
            }
        }
        
    }








    
    public static Dictionary<int,int> CountOccurances(IList<int> item)
    {
        Dictionary<int, int> occurances = new Dictionary<int, int>();
        for (int i = 0; i < item.Count; i++)
        {
            int count;
            if (!occurances.TryGetValue(item[i],out count))
            {
                count = 0; 
            }
            occurances[item[i]] = count + 1;
            
        }

        return occurances;
    }
    public static SortedDictionary<T2,List<T1>> OrderByDictionaryValue<T1,T2>(SortedDictionary<T1,T2>  dic )
    {
        SortedDictionary<T2, List<T1>> sortedDic = new SortedDictionary<T2, List<T1>>();
        foreach (KeyValuePair<T1, T2> item in dic)
        {
            T2 key = item.Value;
            T1 value = item.Key;
            if (!sortedDic.ContainsKey(key))
            {
                sortedDic[key] = new List<T1>();
            }
            sortedDic[key].Add(value);
        }
        return sortedDic;
    }

        
        







    
   
    public static void Something(int[] arr)
    {
        int currentIndex;
        for (int i = 1; i < arr.Length; i++)
        {
            currentIndex = i;
            int value = arr[i];
            while (currentIndex > 0 && value < arr[currentIndex - 1])
            {
                arr[currentIndex] = arr[currentIndex - 1];
                currentIndex--;
            }
            arr[currentIndex] = value;
        }
    }
            

            

        
    
    public static T[] InsertInArray<T>(T[] array, T value, int insertAt)
    {
        if (insertAt > array.Length || insertAt < 0)
            throw new IndexOutOfRangeException(" index was out of bounds of array");
        T[] newArr = new T[array.Length + 1];
        newArr[insertAt] = value;
        for (int i = 0; i < newArr.Length; i++)
        {
            if (i < insertAt)
            {
                newArr[i] = array[i];
            }
            else if (i > insertAt)
            {
                newArr[i] = array[i - 1];
            }
        }
        return newArr;
    }
    public static bool HasHamiltonianCycle(Graph graph)
    {
        int count = 0;
        int n = graph.Size;
        for (int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if (!(graph.HasEdge(i, j)))
                {
                    if (!(graph.GetSuccesors(i).Count + graph.GetSuccesors(j).Count >= n))
                    {
                        count++;
                        break;
                    }
                }
            }
        }
        if (count == 0)
            return true;
        bool[] visited = new bool[graph.Size];
        List<int> path = new List<int>();
        bool result = DFSForHamiltonianiCycle(graph, 0, visited, path);
        if (result)
        {
            Console.Write("Hamiltonian cycle: ");
            foreach (int node in path)
                Console.Write(node + " ");

            Console.WriteLine(path[0]);
        }
        return result;

    }
    public static bool DFSForHamiltonianiCycle(Graph graph, int start, bool[] visited, List<int> path)
    {
        int currentNode = start;
            visited[currentNode] = true;
            path.Add(currentNode);
            if (path.Count == graph.Size)
            {
               if (graph.HasEdge(currentNode, path[0]))
                  return true;
                visited[currentNode] = false;
                path.RemoveAt(path.Count - 1);
                return false;
            }
        foreach (int child in graph.GetSuccesors(currentNode))
        {
            if (!visited[child])
            {
                if (DFSForHamiltonianiCycle(graph, child, visited, path))
                    return true;

            }
        }
            visited[currentNode] = false;
            path.RemoveAt(path.Count - 1);
            return false;
        

    }

    public static bool HasEulerianCycle(Graph graph)
    {
        int countIsolatedNodes = 0;
        int countEvenDegreeNodes = 0;
        bool[] isolated = new bool[graph.Size];
        for (int i = 0; i < graph.Size; i++)
        {
            if (graph.GetSuccesors(i).Count() == 0)
            {
                isolated[i] = true;
                countIsolatedNodes++;
            }
            else if (graph.GetSuccesors(i).Count() % 2 == 0)
            {
                countEvenDegreeNodes++;
            }
        }
        if (countIsolatedNodes + countEvenDegreeNodes != graph.Size)
            return false;
        return GraphIsConnected(graph, isolated);
            
       
    }
        
    public static bool GraphIsConnected(Graph graph, bool[] isolated )
    {
        bool[] visited = new bool[graph.Size];
        for (int i = 0; i < graph.Size; i++)
        {
            if (graph.GetSuccesors(i).Count() > 0)
            {
                TraverseDFS(i,graph, visited);
                break;
            }
        }
        for (int i = 0;i < graph.Size; i++)
        {
            if (!(visited[i] == (!isolated[i])))
                return false;
        }
        return true;

    }
        

        

    
    public static void ArrangeTasks(Graph graph)
    {
        bool[] visited = new bool[graph.Size];
        bool[] inStack = new bool[graph.Size];
        Stack<int> result = new Stack<int>();
        for (int i = 0; i < graph.Size; i++)
        {
            if (!visited[i])
            {
                if (!TopologicalDFS(graph, i, visited, inStack, result))
                {
                    Console.WriteLine("Can't arrange tasks. There is a cycle.");
                    return;
                }
            }
        }
        Console.Write("Order:");
        while (result.Count > 0)
        {
            Console.Write(" " + result.Pop());
        }
    }
    public static bool TopologicalDFS(Graph graph, int node, bool[] visited, bool[] inStack, Stack<int> result)
    {
        visited[node] = true;
        inStack[node] = true;
        foreach (int child in graph.GetSuccesors(node))
        {
            if (!visited[child])
            {
                if (!TopologicalDFS(graph, child, visited, inStack, result))
                    return false;
            }
            else if (inStack[child])
            {
                return false; 
            }
        }
        inStack[node] = false;
        result.Push(node);
        return true;
    }
    public static void DjikstraAllShortPath(WeightedGraph graph,int startNode )
    {
        int[] distance = new int[graph.Size];
        for (int i = 0; i < distance.Length; i++)
        {
            distance[i] = int.MaxValue;
        }
        bool[] visited = new bool[graph.Size];
        int[] parent = new int[graph.Size];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = -1;
        }
        PriorityQueue<int,int> pq = new PriorityQueue<int,int>();
        distance[startNode] = 0;
        pq.Enqueue(startNode, distance[startNode]);
        while (pq.Count > 0)
        {
           int currentNode = pq.Dequeue();
            
            if (!visited[currentNode])
            {
                visited[currentNode] = true;
                
                foreach (Edge edge in graph.GetSuccesors(currentNode))
                {
                    if (!visited[edge.To])
                    {
                        int newDistance = distance[currentNode] + edge.Weight;
                        if (newDistance < distance[edge.To])
                        {
                            distance[edge.To] = newDistance;
                            parent[edge.To] = currentNode;
                            pq.Enqueue(edge.To, newDistance);
                        }
                    }
                }
            }
        }
       
        PrintAllPathDjikstra(parent,startNode, distance);

    }
    public static void PrintAllPathDjikstra(int[] parent,int startNode, int[] distance)
    {
       

        for (int i = 0; i < distance.Length; i++)
        {
            if (distance[i] == int.MaxValue)
            {
                Console.WriteLine($"{startNode} --> {i} path not found");
                continue;
            }

            Stack<int> stack = new Stack<int>();

            int currentNode = i;

            while (currentNode != -1)
            {
                stack.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.Write($"{startNode} --> {i} path: ");

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }

            Console.WriteLine($" distance = {distance[i]}");
        }
    }
    public static void DFSForPrintingConnectedComponents(Graph graph)
    {
        bool[] visited = new bool[graph.Size];
        
        
        for (int i = 0; i < graph.Size; i++)
        {
            if (visited[i]) 
                continue;
            Console.Write("Connected compononents : ");
            DFSForPrintingConnectedComponents(i, graph, visited);
            Console.WriteLine();
        }
    }
    public static void DFSForPrintingConnectedComponents(int v, Graph graph, bool[] visited)
    {
        if (!visited[v])
        {
            visited[v] = true;
            Console.Write($" {v}");
            foreach (int child in graph.GetSuccesors(v))
            {
                
                DFSForPrintingConnectedComponents(child, graph, visited);
            }
        }
    }
    public static void TraverseDFSDirectedForPrintingCycle(Graph graph)
    {
        bool[] visited = new bool[graph.Size];
        bool[] inStack = new bool[graph.Size];
        int[] parent = new int[graph.Size];
        for (int i = 0; i < graph.Size; i++)
        {
            parent[i] = -1;
        }
        for (int i = 0; i < graph.Size; i++)
        {
            if (visited[i])
                continue;
            TraverseDFSDirectedForPrintingCycle(i, graph, visited,inStack,parent);
        }
    }
               

    public static void TraverseDFSDirectedForPrintingCycle(int v, Graph graph, bool[] visited, bool[] inStack, int[] parent)
    {
        if (!visited[v])
        {
            visited[v] = true;
            inStack[v] = true;
            foreach (int child in graph.GetSuccesors(v))
            {
                
                if (!visited[child])
                {
                    parent[child] = v;
                    TraverseDFSDirectedForPrintingCycle(child, graph, visited, inStack, parent);
                   
                }
                else if (inStack[child])
                {
                    
                    PrintCycleDirectedGraph(v,child,parent);
                }
            }
            inStack[v] = false;
        }
    }
    public static void PrintCycleDirectedGraph(int currentNode,int startCycleNode, int[] parent)
    {
        // i need to reverse parent for correct order. aka stack it reverses order
        int node = currentNode;
        Stack<int> stack = new Stack<int>();
        while (node != -1)
        {
            if (node == startCycleNode)
            {
                stack.Push(node);
                break;
            }
            stack.Push(node);
            node = parent[node];


        }
        Console.Write("Printing Cycle :");
        while (stack.Count > 0)
        {
            Console.Write($" {stack.Pop()}");
        }
        Console.Write($" {startCycleNode}");
        Console.WriteLine();
        Console.WriteLine();
    }
            

            
        
    
    public static void CopyFilesAndFolders(string path,Folder folder)
    {
        try
        {

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                
                folder.AddFile(new CustomFile(fileInfo.Name,fileInfo.Length));
            }
            string[] directories = Directory.GetDirectories(path);
            
            foreach (string directory in directories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                Folder childFolder = new Folder(directoryInfo.Name);
                CopyFilesAndFolders(directory, childFolder);
                folder.AddFolder(childFolder);
               
              
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(" Unauthorized Access ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
    public static long SumOfAllFileSizes(Folder folder)
    {
        long sum = 0;
        for (int i = 0; i < folder.FileCount; i++)
        {
            sum = sum + folder.GetFile(i).Size;
        }
        for (int i = 0; i < folder.SubFolderCount; i++)
        {
           sum = SumOfAllFileSizes(folder.GetSubFolder(i));
            
        }
        return sum;
    }
    public static void FindExeFiles(string path)
    {
        try
        {

            string[] files = Directory.GetFiles(path, "*.exe");
           
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                FindExeFiles(directory);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(" Unauthorized Access ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static void TraverseBFSDirected(Graph graph)
    {
        List<int>[] childNodes = graph.ChildNodes;
        bool[] visited = new bool[graph.Size];
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < graph.Size; i++)
        {
            if (!visited[i])
            {
                q.Enqueue(i);

                visited[i] = true;
                while (q.Count > 0)
                {
                    int currentNode = q.Dequeue();
                    Console.Write($" {currentNode}");

                    
                     foreach (int child in childNodes[currentNode])
                        {
                             if (!visited[child])
                            {
                                visited[child] = true;
                                q.Enqueue(child);


                            }
                        }
                    
                }
            }
        }
    }
    public static bool IsCyclicBFSUndirected(Graph graph)
    {
        
        List<int>[] childNodes = graph.ChildNodes;
        Queue<int> q = new Queue<int>();
        bool[] isVisited = new bool[graph.Size];
        int[] parent = new int[graph.Size];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = -1;
        }
        for (int i = 0; i < graph.Size; i++)
        {
            if (isVisited[i])
                continue;
            q.Enqueue(i);
            isVisited[i] = true;
            while (q.Count > 0)
            {
                int currentNode = q.Dequeue();
                foreach (int node in childNodes[currentNode])
                {
                    if (!isVisited[node])
                    {

                        isVisited[node] = true;
                        parent[node] = currentNode;
                        q.Enqueue(node);
                    }
                    else if (node != parent[currentNode])
                        return true;
                }
            }
        }
        return false;
    }
    public static bool IsCyclicDFSUndirected(Graph graph)
    {
        List<int>[] children = graph.ChildNodes;
        int[] parent = new int[graph.Size];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = -1;
        }
        bool[] isVisited = new bool[graph.Size];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < graph.Size; i++)
        {
            if (isVisited[i])
                continue;
            stack.Push(i);
            isVisited[i] = true;
            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();
                foreach (int node in children[currentNode])
                {
                    if (!isVisited[node])
                    {
                        isVisited[node] = true;
                        parent[node] = currentNode;
                        stack.Push(node);
                    }
                    else if (node != parent[currentNode])
                        return true;
                }
            }

        }
        return false;
    }
    public static void ShortPathBFS(Graph graph, int startNode, int EndNode)
    {
        if (startNode < 0 || startNode >= graph.Size ||
                     EndNode < 0 || EndNode >= graph.Size)
            return;

        List<int>[] childNodes = graph.ChildNodes;
        if (childNodes[startNode] != null)
        {
            bool[] visited = new bool[graph.Size];
            int[] parent = new int[graph.Size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
            Queue<int> q = new Queue<int>();
            q.Enqueue(startNode);
            visited[startNode] = true;
            while (q.Count > 0)
            {
                int currentNode = q.Dequeue();
                
                if (currentNode == EndNode)
                {
                    PathReconstruction(parent, currentNode);
                    break;
                }
                foreach (int child in childNodes[currentNode])
                {
                    if (!visited[child])
                    {
                        q.Enqueue(child);
                        parent[child] = currentNode;
                        visited[child] = true;
                    }
                }
                
            }
            if (!visited[EndNode])
            {
                Console.WriteLine("Path was not found");
            }

        }
    }
    public static void PathReconstruction(int[] parent, int endNode)
    {
        List<int> path = new List<int>();
        int node = endNode;
        
        while (node != -1)
        {
            path.Add(node);
            node = parent[node];
        }
        path.Reverse();
        Console.Write("path :");
        foreach (int child in path)
        {
            Console.Write($" {child} ");
        }
    }
    public static void TraverseDFS(Graph graph)
    {
        
        bool[] visited = new bool[graph.Size];
        for (int i = 0; i < graph.Size; i++)
        {
            if (visited[i])
                continue;
            TraverseDFS(i, graph, visited);
        }
    }
    public static void TraverseDFS(int v,Graph graph, bool[] visited)
    {
        
        if (!visited[v])
        {
            Console.Write(v + " ");
            visited[v] = true;
            foreach (int child in graph.GetSuccesors(v))
            {
                if (!visited[child])
                {
                    TraverseDFS(child, graph, visited);
                }
            }
        }
    }
    
    public static bool IsBalanced<T>(BinaryTree<T>? tr)
    {
         if (tr == null) 
            return true;
        int leftHeight = Height(tr.LeftChild);
        int rightHeight = Height(tr.RightChild);
         
        
        if (Math.Abs(leftHeight - rightHeight) > 1)
            return false;

        return IsBalanced(tr.LeftChild) && IsBalanced(tr.RightChild);

    }
    private static int Height<T>(BinaryTree<T>? tr)
{
    if (tr == null)
        return 0;


    int leftHeight = Height(tr.LeftChild);
    int rightHeight = Height(tr.RightChild);
    int max = Math.Max(leftHeight, rightHeight) + 1;
        return max;





}
    public static void PrintSumOfNodesEveryLevel(BinaryTree<int> binaryTree)
    {
        
        if (binaryTree == null)
            return;
        
        Queue<BinaryTree<int>> q = new Queue<BinaryTree<int>>();
        int level = 1;
        q.Enqueue(binaryTree);
        while (q.Count > 0)
        {
            int sum = 0;
            int levelSize = q.Count;
           

            for (int i = 0; i < levelSize; i++)
            {
                BinaryTree<int> currentTree = q.Dequeue();
                sum = sum + currentTree.Value;
                if (currentTree.LeftChild != null)
                {
                    q.Enqueue(currentTree.LeftChild);
                }
                if (currentTree.RightChild != null)
                {
                    q.Enqueue(currentTree.RightChild);
                }
            }
            Console.WriteLine($" level : {level}, sum of node values : {sum}");
            level++;
        }

        
    }
    public static void PrintLeavesParentNodes(BinaryTree<int> binaryTree)
    {
        if (!IsLeaf(binaryTree))
        {
            if ((IsLeaf(binaryTree.LeftChild) || binaryTree.LeftChild == null) && (IsLeaf(binaryTree.RightChild) 
                || binaryTree.RightChild == null))
            {
                Console.WriteLine($" value of nodes with only leaves successor : {binaryTree.Value}");
            }
        }
        {
            Console.WriteLine($" {binaryTree.Value}");
        }
        if (binaryTree.LeftChild != null)
        {
            PrintLeavesParentNodes(binaryTree.LeftChild);
        }
        if (binaryTree.RightChild != null)
        {
            PrintLeavesParentNodes(binaryTree.RightChild);
        }
    }
    public static bool IsLeaf(BinaryTree<int> binaryTree)
    {
        if (binaryTree == null)
            return false;
        if (binaryTree.LeftChild == null && binaryTree.RightChild == null)
            return true;

        return false;
    }
    public static bool IsPalindromeRecursive(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input.ToLower())
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
        }
        string cleanText = sb.ToString();
        return IsPalindromeRecursive(cleanText, 0, cleanText.Length - 1);

    }
    public static bool IsPalindromeRecursive(string input,int left, int right)
    {
        bool isPalindrome = true;
        if (left >= right)
            return isPalindrome;
        if (input[left] != input[right])
            return false;
      return  IsPalindromeRecursive(input, left + 1, right - 1);

        

    }
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }
    }

    public static int MultiplicationRecursive(int a, int b)
    {                                        // 4       5

        if (b == 0)
            return 0;
        int sum = MultiplicationRecursive(a, b - 1) + a;
        return sum;

    }
       

        
        


    
    public static void InsertionSort(int[] arr)
    {
        if (arr == null)
            return;
        for (int i = 1; i < arr.Length ; i++)
        {
            int currIndex = i;
            while (currIndex - 1 >= 0)
            {
                if (arr[currIndex] >= arr[currIndex - 1])
                    break;

                Swap(ref arr[currIndex], ref arr[currIndex - 1]);
                currIndex--;

            }
        }
    }
    public static void BfsForDirs(string startPath)
    {
        Queue<string> q = new Queue<string>();
        q.Enqueue(startPath);
        while (q.Count > 0)
        {
            string current = q.Dequeue();
            Console.WriteLine(current);
            try
            {
                var subDirs = Directory.GetDirectories(current);
                foreach (string dir in subDirs)
                {
                    q.Enqueue(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("access denied" + current);
            }
            catch (Exception e)
            {
                Console.WriteLine("error : " + e.Message);
            }
        }
    }
    public static void DfsForDirs(string startPath)
    {
        Stack<string> stack = new Stack<string>();
        HashSet<string> visited = new HashSet<string>();
        stack.Push(startPath);
        while (stack.Count > 0)
        {
            string current = stack.Pop();
            if (visited.Contains(current))
                continue;
            visited.Add(current);
            Console.WriteLine(current);
            try
            {
                var dirs = Directory.GetDirectories(current);
                foreach (string dir in dirs)
                {
                    stack.Push(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied " + current);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }


    
    public static void ShortestSubSequence(int n, int m)
    {
        int next;
        Queue<int> q = new Queue<int>();
        List<int> visited = new List<int>();
        Dictionary<int, int> parent = new Dictionary<int, int>();
        q.Enqueue(n);
        visited.Add(n);

        Console.Write(" S = ");
        while (q.Count > 0)
        {
            int current = q.Dequeue();
            if (current == m)
                break;


            next = current + 1;
            if (!visited.Contains(next))
            {
                q.Enqueue(next);
                visited.Add(next);
                parent.Add(next, current);
            }
            next = current + 2;
            if (!visited.Contains(next))
            {
                q.Enqueue(next);
                visited.Add(next);
                parent.Add(next, current);
            }
            next = current * 2;
            if (!visited.Contains(next))
            {
                q.Enqueue(next);
                visited.Add(next);
                parent.Add(next, current);
            }



        }
        List<int> sequence = new();
        int curr = m;
        sequence.Add(curr);
        while (parent.ContainsKey(curr))
        {

            curr = parent[curr];
            sequence.Add(curr);
        }

        sequence.Reverse();
        foreach (var item in sequence)
        {
            Console.Write($" {item}");
        }

    }
    public static void Swap<T>(ref T item1, ref T item2)
    {
        T temp = item1;
        item1 = item2;
        item2 = temp;
    }
    public static string[,] BfsForLabyrinth(string[,] maze, int startRow, int startCol)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        Queue<(int row, int col)> q = new Queue<(int, int)>();
        int[,] dist = new int[rows, cols];
        (int,int)[,] parent  =  new (int, int)[rows, cols];
        
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
        
        
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                dist[r, c] = -1;
            }
        }

        dist[startRow, startCol] = 0;
        parent[startRow, startCol] = (-1, -1);
        q.Enqueue((startRow, startCol));
        while (q.Count > 0)
        {
            (int currentRow, int currentCol) = q.Dequeue();
            
            for (int i = 0; i < dr.Length && i < dc.Length; i++)
            {
              int  nr = currentRow + dr[i];
              int  nc = currentCol + dc[i];
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols )
                    continue;
                if (maze[nr,nc] == "0" && dist[nr,nc] == -1)
                {
                    dist[nr, nc] = dist[currentRow, currentCol] + 1;
                    parent[nr, nc] = (currentRow, currentCol);
                   
                    q.Enqueue((nr, nc));
                }

            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (maze[r, c] == "0")
                {
                    maze[r, c] = dist[r, c] == -1
                        ? "u"
                        : dist[r, c].ToString();
                }
            }
        }
        maze[startRow, startCol] = "*";
        return maze;
    }
    public static (int,int)[,] BfsForLabyrinthPath(string[,] maze, int startRow, int startCol)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        Queue<(int row, int col)> q = new Queue<(int, int)>();
        int[,] dist = new int[rows, cols];
        (int, int)[,] parent = new (int, int)[rows, cols];

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };


        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                dist[r, c] = -1;
            }
        }

        dist[startRow, startCol] = 0;
        parent[startRow, startCol] = (-1, -1);
        q.Enqueue((startRow, startCol));
        while (q.Count > 0)
        {
            (int currentRow, int currentCol) = q.Dequeue();

            for (int i = 0; i < dr.Length && i < dc.Length; i++)
            {
                int nr = currentRow + dr[i];
                int nc = currentCol + dc[i];
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                    continue;
                if (maze[nr, nc] == "0" && dist[nr, nc] == -1)
                {
                    dist[nr, nc] = dist[currentRow, currentCol] + 1;
                    parent[nr, nc] = (currentRow, currentCol);

                    q.Enqueue((nr, nc));
                }

            }
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (maze[r, c] == "0")
                {
                    maze[r, c] = dist[r, c] == -1
                        ? "u"
                        : dist[r, c].ToString();
                }
            }
        }
        maze[startRow, startCol] = "*";
        return parent;
    }









    public static List<int> GetPrimes(int start, int end)
    {
        List<int> primeList = new List<int>();
        for (int num = start; num <= end; num++)
        {
            bool prime = true;
            double numSqrt = Math.Sqrt(num);
            for (int div = 2; div <= numSqrt; div++)
            {
                if(num %  div == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                primeList.Add(num);
            }
        }
        return primeList;
    }
    public static List<int> Union(List<int> firstList,List<int> secondList)
    {
        List<int> union = new List<int>();
        union.AddRange(firstList);
        foreach (var item in secondList)
        {
            if (!union.Contains(item))
            {
                union.Add(item);
            }
        }
        return union;
    }
    public static List<int> InterSect(List<int> firstList,List<int> secondList)
    {
        List<int> intersect = new List<int>();
        for (int i = 0;  i < firstList.Count; i++)
        {
            if (secondList.Contains(firstList[i]))
            {
                intersect.Add(firstList[i]);
            }
        }
        return intersect;

    }

    public static string ReplaceForbiddenWords(string example, string keys, char c)
    {
        if (keys.Contains(','))
        {
            List<string> key = new List<string>();
            int startIndex = 0;
            int endIndex = 0;
            int containedKeyCounter = 0;
            int keyLength;
            while (startIndex < keys.Length && endIndex < keys.Length)
            {
                endIndex = keys.IndexOf(',', startIndex) - 1;
                if (endIndex == -2)
                {
                    endIndex = keys.Length - 1;
                }

                keyLength = endIndex - startIndex + 1;

                key.Add(keys.Substring(startIndex, keyLength));
                startIndex = endIndex + 2;

            }

         StringBuilder sb = new StringBuilder(example);
            for (int i = 0; i < key.Count; i++)
            {
                if (example.Contains(key[i],StringComparison.CurrentCultureIgnoreCase))
                {
                    string replaceCharacters = new string(c, key[i].Length);
                    string changedExample = (sb.ToString().Replace(key[i], replaceCharacters,StringComparison.CurrentCultureIgnoreCase));
                    sb.Clear();
                    sb.Append(changedExample);
                    containedKeyCounter++;
                }
            }
            if (containedKeyCounter > 0)
            return sb.ToString();

            return "Text doesn't contain forbidden words";
        }
        
            if (example.Contains(keys,StringComparison.CurrentCultureIgnoreCase))
            {
                string replaceCharacters = new string(c, keys.Length);
                return example.Replace(keys, replaceCharacters,StringComparison.CurrentCultureIgnoreCase);
            }
            
                return "Text doesn't contain forbidden words";
            
        

    }
    public static string JoinStrings(char character,string newExample, StringBuilder old)
    {
        StringBuilder sb = new StringBuilder(character);
        sb.AppendJoin(character,newExample,old);
        return sb.ToString();

    }

    public static string ExtractSentence(string source, string key)
    {
        StringBuilder sb = new StringBuilder();
        int startSentence = 0;
        const char dot = '.';
        int endSentence = 0;
        int keyCounter = 0;

        while (startSentence < source.Length && endSentence < source.Length)
        {
            endSentence = source.IndexOf(dot, startSentence);
            if (endSentence == -1)
                return "There was not found full sentence";
            int lengthOfSentence = endSentence - startSentence + 1;
            string sentence = source.Substring(startSentence, lengthOfSentence);
            if (sentence.Contains(key))
            {
                sb.Append(sentence);
                keyCounter++;
            }
            startSentence = endSentence + 1;
        }
        if (keyCounter == 0)
            return $" key : {key} was not found in the given text : {source}";
       
        return sb.ToString();

    }
    public static int[] TextEncrypt(string source, string code)
    {
        int codeIndex = 0;
        int[] result = new int[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            if (codeIndex >= code.Length)
            {
                codeIndex = 0;
            }
            result[i] = source[i] ^ code[codeIndex];
            codeIndex++;
        }
        return result;
    }
    public static string ToHex(int[] elements)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < elements.Length; i++)
        {
            sb.Append($"\\u{elements[i]:X4}");

        }
        return sb.ToString();
    }
            
    public static string ToUpperWords(string example, string key1, string key2)
    {
        int startIndex = example.IndexOf(key1);
        int endIndex = example.IndexOf(key2);
        int length = endIndex - startIndex;
        StringBuilder sb1 = new StringBuilder();
        sb1.Append(example);
        StringBuilder sb = new StringBuilder();


        while (endIndex != -1 && startIndex != -1 && startIndex > endIndex)
        {
            sb.Append(example.Substring(startIndex, length).ToUpper());
            
            sb1.Replace(example.Substring(startIndex, length), sb.ToString());

            sb.Clear();
            startIndex = example.IndexOf(key1, endIndex + 1);
            endIndex = example.IndexOf(key2, endIndex + 1);
            length = endIndex - startIndex;
        }

        string element = RemoveKeys(sb1,key1,key2);
        return element;


    }

    public static string RemoveKeys(StringBuilder builder, string keyOne, string keyTwo)
    {
        string example = builder.ToString();
       example = example.Replace(keyOne,"",StringComparison.CurrentCultureIgnoreCase);
        example = example.Replace(keyTwo, "", StringComparison.CurrentCultureIgnoreCase);
        return example;
    }

    public static bool ParenthesesIsCorrect(string expression)
    {
        string exp = expression.ToString();
        int leftParenthCount = 0;
        int rightParenthCount = 0;
        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i] == '(')
            {
                leftParenthCount++;
            }

            if (exp[i] == ')')
            {
                rightParenthCount++;
            }
        }
        if (leftParenthCount == rightParenthCount)
              return true;

        return false;
        
    }

    public static string ReverseString(string value)
    {
        int n = value.Length;
        StringBuilder sb = new StringBuilder();
        
        for (int i = n - 1; i >= 0; i--)
        {
            sb.Append(value[i]);
        }
        return sb.ToString();
    }

    public static string RandomMessageGenerator(string[] element)
    {
        Random random = new Random();
        int randomIndex = random.Next(element.Length);
        string message = element[randomIndex];
        return message;

    }

    public static void PrintAllMessage(string laudatoryPhrases, string laudatoryStories, string firstName
        , string lastName, string cities)
    {
        Console.WriteLine($" {laudatoryPhrases}. {laudatoryStories}. - - {firstName} {lastName}, {cities}");
    }
    public static int CountWorkingDays(DateTime endDate)
    {
        int workingDaysCount = 0;
        DateTime now = DateTime.Now;
        while (now <= endDate)
        {
            if (now.DayOfWeek != System.DayOfWeek.Sunday && now.DayOfWeek != System.DayOfWeek.Saturday)
            {
                workingDaysCount++;
            }
            // Add logic to increment 'now' to avoid infinite loop
            now = now.AddDays(1);
        }
        return workingDaysCount;
    }
    public static DayOfWeek DayOfWeek()
    {
        DayOfWeek dt = DateTime.Today.DayOfWeek;
        return dt;
    }
    public static void PrintTimePassed()
    {
        var timePassed = Environment.TickCount;
        
        double seconds = timePassed / 1000.0;
        double minutes = seconds / 60.0;
        double hours = minutes / 60.0;
        double days = hours / 24.0;
        Console.WriteLine($" days : {days} , hours : {hours} , minutes : {minutes} , seconds : {seconds}");
    }

    public static void PrintRandomNums(int n)
    {
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            Console.Write($" {random.Next(100, 201)}");
        }
    }

    public static void Bfs(int startRow, int startCol)
    {
       int rows = lab.GetLength(0);
         int cols = lab.GetLength(1);
        bool[,] visited = new bool[rows, cols];
        Queue<(int row, int col)> queue = new Queue<(int , int )>();
        queue.Enqueue((startRow,startCol));
        visited[startRow,startCol] = true;
        int stepCount = 0;

        while (queue.Count > 0)
        {
            (int row, int col) = queue.Dequeue();
            stepCount++;
            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Exit found");
                Console.WriteLine($" step count : {stepCount} ");
                return;
            }

            TryMove(row, col - 1, queue, visited);//Left
            TryMove(row, col + 1, queue, visited); //Right
            TryMove(row - 1, col, queue, visited); //Up
            TryMove(row + 1, col, queue, visited); //Down
        }
        Console.WriteLine("Exit was not found");


        
    }
    public static void BfsWithPath(int startRow, int startCol)
    {
        int rows = lab.GetLength(0);
        int cols = lab.GetLength(1);
        bool[,] visited = new bool [rows, cols];
        (int, int)[,] parent = new (int, int)[rows, cols];
        Queue<(int row, int col)> queue = new Queue<(int , int )>();
        queue.Enqueue((startRow, startCol));
        visited[startRow, startCol] = true;
        parent[startRow, startCol] = (-1, -1);

        while (queue.Count > 0)
        {
            var(row, col) = queue.Dequeue();
            if (lab[row, col] == 'e')
            {
                Console.WriteLine(" Exit was found ");
                return;
            }

            Explore(row, col - 1, row, col, queue, visited, parent); // left
            Explore(row, col + 1, row, col, queue, visited, parent); // right
            Explore(row - 1, col, row, col, queue, visited, parent); // up
            Explore(row + 1, col, row, col, queue, visited, parent); // down

        }
        Console.WriteLine("No exit found.");
    }
    public static void Explore(int newRow, int newCol, int currRow, int currCol,Queue<(int,int)> q,
        bool[,] visited,(int, int)[,] parent)
    {
        if (newRow < 0 || newCol < 0 || newRow >= visited.GetLength(0) || newCol >= visited.GetLength(1))
        {
            return;
        }
        if (visited[newRow, newCol])
            return;
        if (lab[newRow, newCol] == '*')
        {
            return ;
        }
        q.Enqueue((newRow, newCol));
        visited[newRow, newCol] = true;
        parent[newRow, newCol] = (currRow, currCol);

    }

    public static void PrintPath((int, int)[,] parent, int row, int col)
    {
        List<(int, int)> path = new List<(int, int)>();

        while (row != -1 && col != -1)
        {
            path.Add((row, col));
            var p = parent[row, col];
            row = p.Item1;
            col = p.Item2;
        }

        path.Reverse();

        Console.WriteLine("Path:");
        foreach (var (r, c) in path)
        {
            Console.WriteLine($"({r}, {c})");
        }
    }
    public static void Dfs(int startRow, int startCol)
    {
        int rows = lab.GetLength(0);
        int cols = lab.GetLength(1);
        bool[,] visited = new bool[rows, cols];
        Stack<(int row, int col)> stack = new Stack<(int, int)>();
        stack.Push((startRow, startCol));
        visited[startRow, startCol] = true;

        while (stack.Count > 0)
        {
           (int row, int col) = stack.Pop();
            if (lab[row, col] == 'e')
            {
                Console.WriteLine(" Exit was found");
                return;
            }

            TryMove(row, col - 1, stack, visited); //Left
            TryMove(row, col + 1, stack, visited); //right
            TryMove(row - 1, col, stack, visited); // up
            TryMove(row + 1, col, stack, visited); // down

        }
        Console.WriteLine(" exit was not found ");
    }
   public static void TryMove(int toMoveRow, int toMoveCol,Queue<(int,int)> q, bool[,] visited)
    {
        if(toMoveRow < 0 || toMoveCol < 0 || toMoveRow >= visited.GetLength(0) || toMoveCol >= visited.GetLength(1))
            return;
        if (visited[toMoveRow, toMoveCol])
            return;
        if (lab[toMoveRow, toMoveCol] == '*')
            return;
        visited[toMoveRow, toMoveCol] = true;
        q.Enqueue((toMoveRow, toMoveCol));
    }
    public static void TryMove(int toMoveRow, int toMoveCol, Stack<(int, int)> s, bool[,] visited)
    {
        if (toMoveRow < 0 || toMoveCol < 0 || toMoveRow >= visited.GetLength(0) || toMoveCol >= visited.GetLength(1))
            return;
        if (visited[toMoveRow, toMoveCol])
            return;
        if (lab[toMoveRow, toMoveCol] == '*')
            return;
        visited[toMoveRow, toMoveCol] = true;
        s.Push((toMoveRow, toMoveCol));
    }
    static void FindPath(int row, int col, char direction)
    {
        Console.WriteLine($"Enter: ({row}, {col})");
        if (row < 0 || col < 0 || row >= lab.GetLength(0) || col >= lab.GetLength(1))
        {
            Console.WriteLine(" outside of maze ");
            return;
        }
        path[position] = direction;
        position++;
        if(lab[row, col] == 'e')
        {
            PrintPath(path, 1, position - 1);
           
        }

        //if(lab[row, col] != ' ')
        //{
        //    Console.WriteLine($"Blocked or visited: ({row}, {col})");
        //    return;
        //}
        if (lab[row, col] ==' ')
        {

            lab[row, col] = 's';
            Console.WriteLine($"Mark: ({row}, {col})");
            Console.WriteLine($"Try LEFT from ({row}, {col})");
            FindPath(row, col - 1,'L');

            Console.WriteLine($"Try RIGHT from ({row}, {col})");
            FindPath(row, col + 1,'R');

            Console.WriteLine($"Try UP from ({row}, {col})");
            FindPath(row - 1, col,'U');

            Console.WriteLine($"Try DOWN from ({row}, {col})");
            FindPath(row + 1, col,'D');

            Console.WriteLine($"Backtrack (leave): ({row}, {col})");
            lab[row, col] = ' ';
        }
        position--;

    }

    public static void PrintPath(char[] path,int startPos, int endPos)
    {
        Console.Write(" Found path to exit: ");
        for (int pos = startPos; pos <= endPos; pos++)
        {
            Console.Write($" {path[pos]} ");
        }
        Console.WriteLine();
    }

    public static void GenerateSubsets(int[] arr, int index, List<int> current)
    {
        
        if (index == arr.Length)
        {
            if (current.Sum() == arr.Length)
            {
                Print(current);
            }
            return;
        }

        current.Add(arr[index]);
        GenerateSubsets(arr, index + 1, current);
        current.RemoveAt(current.Count - 1);
        GenerateSubsets(arr, index + 1, current);

    }
    public static void Print(List<int> subset)
    {
        Console.Write(" { ");
        foreach (int i in subset)
        {
            Console.Write($" {i} ");
        }
        Console.WriteLine(" } ");
    }
}