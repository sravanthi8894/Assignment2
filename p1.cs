using System;
using System.Collections.Generic;
using System.Linq;///for List
using System.Collections;//for Stack
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{

    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.Write("Most frequent word is : ");
            Console.WriteLine(commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.Write("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nume, int targt)
        {
            try
            {
                int p = 0;
                int q = nume.Length - 1;
                int anser = -1;
                while (p <= q)
                {                           
                    int mide = (p + q) / 2;             
                    if (nume[mide] == targt) return mide; 
                    if (nume[mide] > targt)
                    {            
                        q = mide - 1;
                        anser = mide;
                    }
                    else
                    {
                        p = mide + 1;
                        anser = mide + 1;
                    }
                }

                return anser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
        It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the 
        most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), 
        and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */
        public static string change_to_small(string f)
        {
            return f.ToLower();
        }
        public static string MostCommonWord(string pargh, string[] bande)
        {
            try
            {
                Console.WriteLine(pargh);
                Dictionary<string, int> map = new Dictionary<string, int>();
                string temper = "";
                for (int p = 0; p < pargh.Length; p++)
                {                    
                    if (pargh[p] == ',') continue;                         
                    if (pargh[p] == ' ' || pargh[p] == '.')
                    {           
                        string new_string = change_to_small(temper);        
                        if (map.ContainsKey(new_string))
                        {                
                            map[new_string] = map[new_string] + 1;           
                        }
                        else
                        {
                            map[new_string] = 1;                          
                        }
                        temper = "";
                    }
                    else
                    {
                        temper = temper + pargh[p];
                    }
                }
                for (int q = 0; q< bande.Length; q++)
                {                       
                    if (map.ContainsKey(change_to_small(bande[q])))
                    {
                        map[change_to_small(bande[q])] = 0;
                    }
                }
                var valie = map.Keys.ToList();
                int max_fre = 0;
                string anse = "";
                foreach (var key in valie)
                {                                 
                    if (map[key] > max_fre)
                    {
                        max_fre = map[key];
                        anse = key;
                    }
                }

                return anse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arry)
        {
            try
            {
                Dictionary<int, int> luke_num = new Dictionary<int, int>();
                foreach (var elemt in arry)
                {                             
                    if (luke_num.ContainsKey(elemt)) { 

                        luke_num[elemt] = luke_num[elemt] + 1;
                    }
                    else
                    {
                        luke_num[elemt] = 1;
                    }
                }
                var valie = luke_num.Keys.ToList();
                int ansi = -1;
                foreach (var key in valie)
                {                                 
                    if (luke_num[key] == key)
                    {
                        ansi = (Math.Max(ansi, key));
                    }
                }
                return ansi;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your frie
        nd to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
        
          |
        "7810"
        */

        public static string GetHint(string scrt, string gusee)
        {
            try
            {
                int p = 0;
                int q = 0;
                bool[] same_value = new bool[scrt.Length];
                Dictionary<char, int> map = new Dictionary<char, int>();
                for (int k = 0; k < scrt.Length; k++)
                {                  
                    if (scrt[k] == gusee[k])
                    {                            
                        k++;
                        same_value[k] = true;
                        
                    }
                    else
                    {
                        same_value[p] = false;                           
                        if (map.ContainsKey(scrt[k]))
                        {                    
                            map[scrt[p]] = map[scrt[k]] + 1;
                        }
                        else
                        {
                            map[scrt[k]] = 1;                               
                        }
                    }
                }
                
               
                for (int f = 0; f < gusee.Length; f++)
                {                  

                    if (same_value[f]) continue;                       
                    if (map.ContainsKey(gusee[f]) && map[gusee[f]] > 0)
                    {
                        q++;
                        map[gusee[f]] = map[gusee[f]] - 1;
                    }
                }
                string ans = p + "c" + q + "d";                          
                return ans;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string f)
        {
            try
            {
                int len = f.Length;
                List<int> reslt = new List<int>();
                int[] map = new int[26];
                for (int k = len - 1; k >= 0; k--)
                {
                    if (map[f[k] - 97] == 0)
                    {
                        map[f[k] - 97] = k;
                    }
                }

                int indx = 0;
                while (indx < len)
                {
                    int low = indx;
                    int qi = map[f[indx] - 97];
                    int diffe = qi - low + 1;
                    for (int g = low; g <= qi; g++)
                    {
                        if (map[f[g] - 97] > qi)
                        {
                            qi = map[f[g] - 97];
                            diffe = qi - low + 1;
                        }
                    }

                    reslt.Add(diffe);
                    indx = qi + 1;
                }


                return reslt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, 
        widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters 
        on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you 
        can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] wieth, string k)
        {
            try
            {
                int linre = 1;
                int cueer_pixl = 0;
                for (int p = 0; p < k.Length; p++)
                {        
                    int f = k[p] - 97;                  
                    if (cueer_pixl + wieth[f] <= 100)
                    {            
                        cueer_pixl = cueer_pixl + wieth[f];  
                    }
                    else
                    {
                        cueer_pixl = 0;                         
                        linre++;                                 
                        cueer_pixl = cueer_pixl + wieth[f];   
                    }
                }
                List<int> anser = new List<int>();               
                anser.Add(linre);
                anser.Add(cueer_pixl);
                return anser;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulssi_string10)
        {

            try
            {
                Stack<char> seti = new Stack<char>();
                for (int k = 0; k < bulssi_string10.Length; k++)
                {                                         
                    if (bulssi_string10[k] == '(' || bulssi_string10[k] == '{' || bulssi_string10[k] == '[')
                    {   
                        seti.Push(bulssi_string10[k]);
                    }
                    if (bulssi_string10[k] == ')' || bulssi_string10[k] == '}' || bulssi_string10[k] == ']')
                    {       
                        if (seti.Count <= 0)
                        {
                            return false;
                        }
                        if (bulssi_string10[k] == ')')
                        {
                            if (seti.Peek() == '(')
                            {
                                seti.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulssi_string10[k] == '}')
                        {
                            if (seti.Peek() == '{')
                            {
                                seti.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulssi_string10[k] == ']')
                        {
                            if (seti.Peek() == '[')
                            {
                                seti.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }
                }

                return true;

            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation 
            the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                
                string[] moser = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                HashSet<string> set = new HashSet<string>();

               
                for (int p = 0; p < words.Length; p++)
                {
                    var sibi = new StringBuilder();
                    foreach (var ch in words[p])
                    {
                        sibi.Append(moser[ch - 'a']);
                    }
                    set.Add(sibi.ToString());
                }
                return set.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
            
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally 
        adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time.
        Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */
        public static int findpath(int[,] grdie, int p, int q, bool[,] path)
        {

            int cali = grdie.GetLength(0);
            int row = grdie.Length / grdie.GetLength(0);
            if (p >= row || q >= cali || p < 0 || q < 0) return 0;
            int ansie1, ansie2, ansie3, ansie4;
            if (path[p, q])
            { 
            
                path[p, q] = false;
                ansie1 = Math.Max(grdie[p, q], findpath(grdie, p, q + 1, path));//right
                ansie2 = Math.Max(grdie[p, q], findpath(grdie, p + 1, q, path));//down
                ansie3 = Math.Max(grdie[p, q], findpath(grdie, p - 1, q, path));//top
                ansie4 = Math.Max(grdie[p, q], findpath(grdie, p, q - 1, path));//left
            }
            else
            {
                return 0;
            }

            return Math.Max(Math.Max(ansie1, ansie2), Math.Max(ansie3, ansie4));

        }
        public static int SwimInWater(int[,] gride)
        {
            try
            {
                bool[,] path = { { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true } };
                return findpath(gride, 0, 0, path);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        public static int dfs(string wrdee1, string wrdee2, Dictionary<string, int> memi)
        {
            if (wrdee1 == wrdee2) return 0;
            if (wrdee1 == "") return wrdee2.Length;
            if (wrdee2 == "") return wrdee1.Length;

            string key = wrdee1 + "#" + wrdee2;
            if( memi.ContainsKey(key)) return memi[key];

            string p1 = (wrdee1.Length > 1) ? wrdee1.Substring(1) : "";
            string p2 = (wrdee2.Length > 1) ? wrdee2.Substring(1) : "";

            if (wrdee1[0] == wrdee2[0])
            {
                int ope = dfs(p1, p2, memi);
                memi.Add(key, ope);
            }
            else
            {
                int insert = 1 + dfs(wrdee2[0] + wrdee1, wrdee2, memi);
                int delete = 1 + dfs(p1, wrdee2, memi);
                int replace = 1 + dfs(p1, p2, memi);
                int ope = Math.Min(insert, Math.Min(delete, replace));
                memi.Add(key, ope);
            }
            return memi[key];
        }
        public static int MinDistance(string wrd1, string wrd2)
        {
            try
            {
                return dfs(wrd1, wrd2, new Dictionary<string, int>());

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


