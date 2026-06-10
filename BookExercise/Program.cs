using BookExercise;
using BookExercise._22thExercise;
using BookExercise.Chapter20;
using BookExercise.Chapter20.Exercise_8;
using BookExercise.CreatingAndUsingObjects;
using BookExercise.CustomDataStructures;
using BookExercise.CustomExercise;
using BookExercise.DictionariesAndHashCodes;
using BookExercise.Extensions;
using BookExercise.OtherNameSpace;
using BookExercise.SearchEngine;
using BookExercise.CustomDataStructures.TreesAndGraphs;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

delegate bool ProductChecker(Product product);
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

    static Dictionary<char, int> dict = new Dictionary<char, int>();
    static char[] lettersOrder = { 'M', 'B', 'T', 'A', 'K', 'O', 'F', 'H', 'V', 'L', 'S', 'N', 'Z', 'Y', 'X', 'W', 'R', 'Q', 'P', 'G', 'D', 'C', 'E', 'U', 'I', 'J' };
    static Program()
    {
        int i = 0;
        for (i = 0; i < lettersOrder.Length; i++)
        {

            dict[char.ToLower(lettersOrder[i])] = i;
        }

    }


    public static void Main(string[] args)
    {
        

       

    }




        

    
   

  

   
    public static int[] SortHalfAscHalfDesc(int[] arr)
    {
        int[] result = (int[])arr.Clone();

       
        MergeSort(result);

        
        int mid = result.Length / 2;
        int left = mid;
        int right = result.Length - 1;

        while (left < right)
        {
            Swap(ref result[left], ref result[right]);
            left++;
            right--;
        }

        return result;
    }
    public static int[] SortHalfAscHalfDesc2(int[] arr)
    {
        int[] sorted = (int[])arr.Clone();
        Array.Sort(sorted); 

        int mid = sorted.Length / 2;

       
        Array.Reverse(sorted, mid, sorted.Length - mid);

        return sorted;
    }
    public static void MergeSort(int[] arr)
    {
        Divide(arr, 0, arr.Length - 1);
        foreach (int number in arr)
        {
            Console.Write($" {number}");
        }
    }
    public static void Divide(int[] arr, int startIndex, int endIndex)
    {

        if (startIndex >= endIndex)
            return;
        int mid = (startIndex + endIndex) / 2;
        Divide(arr, startIndex, mid);  //left
        Divide(arr, mid + 1, endIndex); //right
        Merge(arr, startIndex, mid, endIndex); //merge

    }
    public static void Merge(int[] array, int start, int midd, int end)
    {
        int lengthL = midd - start + 1;
        int lengthR = end - midd;
        int[] left = new int[lengthL];
        int[] right = new int[lengthR];
        int i, j;
        for (i = 0; i < lengthL; i++)
        {
            left[i] = array[start + i];
        }
        for (j = 0; j < lengthR; j++)
        {
            right[j] = array[midd + 1 + j];
        }
        i = 0;
        j = 0;
        int k = start;
        while (i < lengthL && j < lengthR)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i];
                i++;
            }
            else
            {
                array[k] = right[j];
                j++;
            }
            k++;
        }
        while (i < lengthL)
        {
            array[k] = left[i];
            i++;
            k++;
        }
        while (j < lengthR)
        {
            array[k] = right[j];
            j++;
            k++;
        }

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

            foreach (KeyValuePair<string, List<Studentt>> pair in courses)
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









    public static Dictionary<int, int> CountOccurances(IList<int> item)
    {
        Dictionary<int, int> occurances = new Dictionary<int, int>();
        for (int i = 0; i < item.Count; i++)
        {
            int count;
            if (!occurances.TryGetValue(item[i], out count))
            {
                count = 0;
            }
            occurances[item[i]] = count + 1;

        }

        return occurances;
    }
    public static SortedDictionary<T2, List<T1>> OrderByDictionaryValue<T1, T2>(SortedDictionary<T1, T2> dic)
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

















    public static void CopyFilesAndFolders(string path, Folder folder)
    {
        try
        {

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                folder.AddFile(new CustomFile(fileInfo.Name, fileInfo.Length));
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
    public static bool IsPalindromeRecursive(string input, int left, int right)
    {
        bool isPalindrome = true;
        if (left >= right)
            return isPalindrome;
        if (input[left] != input[right])
            return false;
        return IsPalindromeRecursive(input, left + 1, right - 1);



    }
   

    public static int MultiplicationRecursive(int a, int b)
    {                                        // 4       5

        if (b == 0)
            return 0;
        int sum = MultiplicationRecursive(a, b - 1) + a;
        return sum;

    }







    





    public static void Swap<T>(ref T item1, ref T item2)
    {
        T temp = item1;
        item1 = item2;
        item2 = temp;
    }

    public static (int, int)[,] BfsForLabyrinthPath(string[,] maze, int startRow, int startCol)
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
                if (num % div == 0)
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
    public static List<int> Union(List<int> firstList, List<int> secondList)
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
    public static List<int> InterSect(List<int> firstList, List<int> secondList)
    {
        List<int> intersect = new List<int>();
        for (int i = 0; i < firstList.Count; i++)
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
                if (example.Contains(key[i], StringComparison.CurrentCultureIgnoreCase))
                {
                    string replaceCharacters = new string(c, key[i].Length);
                    string changedExample = (sb.ToString().Replace(key[i], replaceCharacters, StringComparison.CurrentCultureIgnoreCase));
                    sb.Clear();
                    sb.Append(changedExample);
                    containedKeyCounter++;
                }
            }
            if (containedKeyCounter > 0)
                return sb.ToString();

            return "Text doesn't contain forbidden words";
        }

        if (example.Contains(keys, StringComparison.CurrentCultureIgnoreCase))
        {
            string replaceCharacters = new string(c, keys.Length);
            return example.Replace(keys, replaceCharacters, StringComparison.CurrentCultureIgnoreCase);
        }

        return "Text doesn't contain forbidden words";



    }
    public static string JoinStrings(char character, string newExample, StringBuilder old)
    {
        StringBuilder sb = new StringBuilder(character);
        sb.AppendJoin(character, newExample, old);
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

        string element = RemoveKeys(sb1, key1, key2);
        return element;


    }

    public static string RemoveKeys(StringBuilder builder, string keyOne, string keyTwo)
    {
        string example = builder.ToString();
        example = example.Replace(keyOne, "", StringComparison.CurrentCultureIgnoreCase);
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



    public static void Explore(int newRow, int newCol, int currRow, int currCol, Queue<(int, int)> q,
        bool[,] visited, (int, int)[,] parent)
    {
        if (newRow < 0 || newCol < 0 || newRow >= visited.GetLength(0) || newCol >= visited.GetLength(1))
        {
            return;
        }
        if (visited[newRow, newCol])
            return;
        if (lab[newRow, newCol] == '*')
        {
            return;
        }
        q.Enqueue((newRow, newCol));
        visited[newRow, newCol] = true;
        parent[newRow, newCol] = (currRow, currCol);

    }






    public class Felidae
    {
        private bool male;
        // This constructor calls another constructor
        public Felidae() : this(true)
        { }
        // This is the constructor that is inherited
        public Felidae(bool male)
        {
            this.male = male;
        }
        public bool Male
        {
            get { return male; }
            set { this.male = value; }
        }
    }
    public class Lion : Felidae, IReproducible<Lion>
    {
        private int weight;
        // Keyword "base" will be explained in the next paragraph
        public Lion(bool male, int weight) : base(male)
        {
            this.weight = weight;
        }
        public int Weight
        {
            get { return weight; }
            set { this.weight = value; }
        }

        public Lion[] Reproduce(Lion mate)
        {
            throw new NotImplementedException();
        }
    }
    public class AfricanLion : Lion
    {
        // …
        // If we comment out the ": base(male, weight)" line
        // the class will not compile. Try it.
        public AfricanLion(bool male, int weight)
        : base(male, weight)
        { }
        public override string ToString()
        {
            return string.Format(
            "(AfricanLion, male: {0}, weight: {1})",
            this.Male, this.Weight);
        }
        // …
    }
    public interface IReproducible<T> where T : Felidae
    {
        T[] Reproduce(T mate);
    }
    public class Singleton
    {
        private static Singleton _instance;
        static Singleton()
        {
            _instance = new Singleton();
        }
        public static Singleton Instance
        {
            get { return _instance; }
        }
        private Singleton()
        {

        }
    }
    public class Thumbnail
    { }
    public interface IImage
    {
        Thumbnail CreateThumbnail();
    }
    public class GifImage : IImage
    {
       public Thumbnail CreateThumbnail()
        {
            throw new NotImplementedException();
        }
    }
    public class JpegImage : IImage
    {
        public Thumbnail CreateThumbnail()
        {
            throw new NotImplementedException();
        }
    }
    public class ImageCollection
    {
        private IList<IImage> _images;
        public ImageCollection(IList<IImage> images)
        {
            _images = images;
        }
        public IList<Thumbnail> CreateThumbnails()
        {
            IList<Thumbnail> thumbnails = new List<Thumbnail>(_images.Count);
            foreach (IImage thumb in _images)
            {
                thumbnails.Add(thumb.CreateThumbnail());
            }
            return thumbnails;
        }
    }
}
internal class Stu
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Stu(string firstName, string lastName, int age)
    {
      FirstName = firstName;
         LastName = lastName;
        Age = age;
    }
    public override string ToString()
    {
        return $"first name: {FirstName}, last name: {LastName}, age: {Age}";
    }
}