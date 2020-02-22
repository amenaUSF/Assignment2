using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    class Program
    {

        static void Main(string[] args)
        {

            /************* :order checked O(n): question # 1 - INPUTS GO HERE - INITIAL AND FINAL INDEX OF GIVEN TARGET O(N) **************/
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            Console.WriteLine("the given array is: ");
            DisplayArray(l1);
            Console.WriteLine("the given target is: "+target);
            Console.WriteLine("Initial and Final index of given target in array: ");
            DisplayArray(r);
            Console.WriteLine("\n");

            /**************** :order checked O(a+b):question # 2 - REVERSING EACH WORD WITHIN A SENTENCE O(N) *******************/
            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine("the given string is: "+s);
            Console.WriteLine("Reversed string is: "+rs);
            Console.WriteLine("\n");

            /**************** :order checked (n) : question # 3 - MAKE ELEMENTS DISTINCT WITH MINIMUM SUM O(N)  *******************/
            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2,2,3,4,6 };
            Console.WriteLine("the given array is: ");
            DisplayArray(l2);
            Console.WriteLine("the updated array is: ");
            int sum = MinimumSum(l2);
            Console.WriteLine("the minimum sum is: "+sum);
            Console.WriteLine("\n");

            /*****************  : question # 4 SORT STRING IN DECREASING ORDER OF FREQUENCY ****************/
            Console.WriteLine("Question 4");
            string s2 = "Yykkxyy";
            string sortedString = FreqSort(s2);
            Console.WriteLine("the given string is: "+s2);
            Console.WriteLine( "The sorted string is: "+sortedString);
            Console.WriteLine("\n");

            /**************** QUESTION # 5 - COMPUTER INTERSECTION OF TWO ARRAYS DICTIONARY - O(N), O(N LOG N)**********************/
            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = {3,6,2 };
            int[] nums2 = { 6,3,6,7,3 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("the first given array is: ");
            DisplayArray(nums1);
            Console.WriteLine("the second given array is: ");
            DisplayArray(nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");

            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            /*************** QUESTION # 6 -order of N - ARRAY OF CHARACTERS, INT K, BETWEEN 2 CHAR,  DISTANCE=K -USE DICTIONARY O(N) *********/
            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'k', 'y', 'k','k' };
            int k = 1;
            Console.WriteLine("the given array is: ");
            DisplayCharArray(arr);
            Console.WriteLine("the given distance k is: "+k);
            Console.WriteLine("output is:  "+ContainsDuplicate(arr, k));
            Console.WriteLine("\n");

            /************ QUESTION # 7 GOLD BAR LENGTH N, PRICE N, VALUE OF COLLECTION V= PRICE P OF EACH BAR*PRICE P OF INDIVIDUAL PIECES*/
            Console.WriteLine("Question 7");
            int rodLength = -10;
            Console.WriteLine("given rod length is : " + rodLength);
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine("\n");

            /******************** Amena  question #8 Inputs go here ********************/
            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "rocky";
            Console.WriteLine("Given Dictionary for words is: ");
            DisplayStringArray(userDict);
            Console.WriteLine("Given keyword is: "+keyword);
            Console.WriteLine( DictSearch(userDict, keyword));
            Console.WriteLine("\n");

            /****************** Amena: question # 9 Inputs go here ******************/
            Console.WriteLine("Question 9");
            string i1 =  "altitude";
            string i2 = "remedied";
            string op = "umbrella";
            SolvePuzzle(i1, i2, op);

        }


        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public static void DisplayCharArray(char[] a)
        {
            foreach (char n in a)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public static void DisplayStringArray(string[] a)
        {
            foreach (string n in a)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }


        /************************** question no. 1 code **************************/
        /* LOGIC - - initialize start and end index and a flag to declare when the start is found
         * run a loop to traverse through the array lookng for the target
         * update the start index and flag the first time target is found
         * if start found flag is already 1 and target is matching with the array element,
         * keep updating and looking for target till the end of loop
         */
        public static int[] TargetRange(int[] l1, int target)
        {
            /*initializing st and end index and a flag to indicate when the start index is found
             */
            int st_index = -1;
            int end_index = -1;
            int st_found = 0;

            try
            {
                //corner case of empty array
                if (l1.Length == 0) {
                    Exception ex = new Exception("Empty Array - enter a filled array");
                    throw ex;
                }
                /*the for loop traverses through each element looking for the target*/
                for (int i = 0; i < l1.Length; i++)
                {
                    /*the first time the target is found, st found==0 and is incremented to 1 which indicates st found 
                     st index takes the corresponding index value - st found==0 condition ensures our st index isn't changed once found*/
                    if (l1[i] == target && st_found == 0)
                    {
                        st_index = i;
                        st_found = 1;
                    }
                    /*once st is found, all we have to do is keep updating the end index with traversal index
                     until the time it matches the target*/
                    if (l1[i] == target && st_found == 1)
                    {
                        end_index = i;
                    }
                }
                /*initialize an array for output and return - if st and end index aren't found, the default values of -1,-1 will
                 * be passsed automatically */
                int[] output = { st_index, end_index };
                return output;
            }//end of try
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error occured computing targetrange");
                return null;
            }
        }//end of targetrange program

        /************************** question no. 2 code version two with Order of N where n is the length of string **************************/
        /*initialize a string for answer and one temporary string to store individual words
         * traverse the string from end to start - adding each alphabet to the temp string
         * when the character is a "space", add the temp string at the start of the answer string and make temp blank again
         * if i==0, it means its at the start of the string so you cant wait for the space now, just add space at the end of temp
         * and add temp at the start of answer string
         * **/
        public static string StringReverse(string s)
        {
            try
            {
                string answer = "";
                string temp = "";

                if (s.Length == 0)
                {
                    Exception ex = new Exception("Empty String Entered");
                    throw ex;
                }
                for (int i = s.Length-1; i >=0; i--)
                {
                    temp += s[i];
                    if (s[i] == ' ')//to handle space
                    {
                        answer = temp + answer;
                        temp= "";
                    }
                    if (i ==0)//means i is at the first character
                    {
                        temp += " ";
                        answer = temp + answer;
                    }
                }
                return answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing the StringReverse");
                return null;
            }
        }


        /************************** question no. 3 code Time Complexity: O(n) **************************/
        /*initialize an integer with sum=0 ->this will store the array sum
         * traverse through the array - once the index is greater than 0, start comparing it to the previous index
         * if 2 consecutive numbers are the same, increment the later number by 1
         * add it to sum
         * ***/
        public static int MinimumSum(int[] l2)
        {
            try
            {
                if (l2.Length == 0)//corner case
                {
                    Exception ex = new Exception("Empty Array - enter a filled array");
                    throw ex;
                }

                int sum = 0;
                for (int i=0;i<l2.Length;i++)
                {
                    if (i > 0)
                    {
                        if (l2[i] == l2[i - 1])
                        {
                            l2[i] = l2[i] + 1;
                        }
                     }
                    sum += l2[i];
                }
                DisplayArray(l2);
                Console.WriteLine();
                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing the MinimumSum");
                return 0;
            }
        }

        /************************** question no. 4 code **************************/
        /**sorting the given string in decreasing order of frequency of occurrence of each character.
         * start with initializing a dict and sorted string
         * for the input string s, loop through each character and insert it as a key and value=1
         * if the character already exists in the dictionary, just increment its value by 1 (frequecy of the character)
         * sort the dictionary based on its values
         *While loop -  based on each value of sorted dictionary, repeat the character and concatenate to string
            **/
        public static string FreqSort(string s)
        {
            try
            {
                if (s.Length == 0)
                {
                    Exception ex = new Exception("Empty string");
                    throw ex;
                }
                Dictionary<string, int> dict = new Dictionary<string, int>();
                string sortedstring = "";

                for (int i = 0; i < s.Length; i++)
                { /* if key not found add that key value else increment the value to show alphabet count*/
                    if (dict.ContainsKey(s[i].ToString()) == false)
                    {
                        dict.Add(s[i].ToString(), 1);
                    }
                    else
                    {
                        dict[s[i].ToString()] += 1;
                    }
                }
                //ordering the dictionary by values - loop runs through each order pair
                foreach (KeyValuePair<string, int> d in dict.OrderByDescending(key => key.Value))
                {
                    int a = 0;
                    //depending on each value (going on from biggest) the while loop runs to repeat the key "value times"
                    //and put it in the sorted string
                    while (a < d.Value)
                    {
                        sortedstring += d.Key;
                        a += 1;
                    }
                }
                return sortedstring;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error occured during computing freqSort");
                return null;
            }
        }//end of FreqSort function

        /************************** question no. 5 code - order should be less than n^2 **************************/

            /*Method one of finding intersection is via traversing arrays
             * sort both the arrays
             * make an empty list to add common interactions to (interaction list)
             * initialize variables i (for nums1) and j(for nums2)
             * while either one of the arrays haven't reached its end, if the number in both the arrays is same,
             * increment both indexes and add to the interaction list
             * else increment the one with smaller number than the other one
             */
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                if (nums1.Length == 0 || nums2.Length == 0)
                {
                    Exception ex = new Exception("Empty array error ");
                    throw ex;
                }

                Array.Sort(nums1);
                Array.Sort(nums2);
                List<int> interaction_list=new List<int> { };
                int i = 0;
                int j = 0;
                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] == nums2[j])
                    {
                        interaction_list.Add(nums1[i]);
                        i++; j++;
                    }
                    else if (nums1[i] < nums2[j])
                    {
                        i++; 
                    }
                    else
                    {
                        j++;
                    }
                }
                return interaction_list.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing the Intersect1");
                return new int[] { };
            }
        }
        /*Method two of finding intersection is using list*/
        /**initialize a list and convert nums1 to that list
         * initialize an interaction list to store interactions in
         * for each integer in nums2, if it exists in num1, add it to the interaction list and
         * remove it from the num1 list.
         * convert interaction list to array
         * ***/
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                if (nums1.Length == 0 || nums2.Length == 0)
                {
                    Exception ex = new Exception("Empty array error ");
                    throw ex;
                }

                List<int> n1_list = new List<int> { };
                n1_list= nums1.ToList();
                List<int> interaction_list = new List<int> { };
                for (int a = 0; a < nums2.Length; a++)
                {
                    if (n1_list.Contains(nums2[a]))
                    {
                        interaction_list.Add(nums2[a]);
                        n1_list.Remove(nums2[a]);
                    }
                }
                return interaction_list.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing the intersect2");
                return new int[] { };
            }
        }
        /************************** question no. 6 code - The algorithm’s runtime complexity must be in the order of O(n) **************************/
        /*intialize the boolean output as false and a dictionary to store the characters at
         *dictionary key=characters and values =indexes
         * if a character doesnt exist in dictionary add it and its index
         * if its already in the dictionary, 1. check the difference of current index-its value
         * if its ==k return true as output and break from the loop cause you dont need to traverse through it anymore
         * if difference isn't==k, replace the value for the key with the current index
         */
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                if (arr.Length == 0 )
                {
                    Exception ex = new Exception("Empty array error ");
                    throw ex;
                }

                bool output = false;
                Dictionary<char, int> dict = new Dictionary<char, int> { };
                for (int i=0;i<arr.Length;i++)
                {
                    if (dict.ContainsKey(arr[i]) == false)
                    {
                        dict.Add(arr[i], i);
                    }
                    else 
                    {
                        if (i - dict[arr[i]] == k)
                        { output = true;
                            break;
                        }
                        else
                        {
                            dict[arr[i]] = i;
                        }
                    }
                }//end of for
                return output;
            }//end of try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing ContainsDuplicate");
                return default;
            }
        }//end of containsduplicate

        /************************** question no. 7 code **************************/
        /*check if the rod length is less than 1 - throw an exception -corner case
         * if rod length is/remaining is less than 3, return that length
         * if the rod length is 4, split it in twos and call the recursive goldrod function with length-2
         * else, try going for 3s first (that will give the highest product) and go for 2's once length==4
         * keep calling recursive function with decremented length of the rod as long as the length is greater than 3
         * ***/
        public static int GoldRod(int rodLength)
        {
            try
            {
                if (rodLength < 1)
                {
                    Exception ex = new Exception("Rod Length is less than 1, provide a positive number for rod length");
                    throw ex;
                }
                if (rodLength <= 3)
                {
                    Console.WriteLine(rodLength);
                    return rodLength;
                }
                else if (rodLength == 4)
                {
                    Console.Write("2*");
                    return 2 * GoldRod(rodLength - 2);
                }
                else 
                {
                    Console.Write("3*");
                    return 3 * GoldRod(rodLength - 3);
                }
            }//end of try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error while computing GoldRod");
            }
            return 0;
        }


        /************************** question no. 8 code *******************/
        /** find whether just changing one character in the keyword will make it a word from the dictionary
         * initialize variable to keep count of differences - different
         * initialize keyword length variable
         * for each word in the user dictionary given, start with different=0
         * quick check - if the current word in user dict length is equal to the length of keyword and its not equal to keyword, proceed
         * **/
        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                if (userDict.Length == 0 || keyword.Length == 0)
                {
                    Exception ex = new Exception("Empty user dictionary/keyword error ");
                    throw ex;
                }


                int different = 0;//counter to set how many alphabets are different between dictionary word and keyword if its exactly one return true else false
                int keyword_length = keyword.Length;
                bool output = false;
                /*for loop traverses through each element in a dictionary to compare it to keyword and check*/
                for (int i = 0; i < userDict.Length; i++)
                {/*if the length of keyword matches the length of a word in the dictionary-consider it*/
                    different = 0;
                    /*if keyword length matches dictionary word length and the word isnt exactly the same, theres a probability
                     that if we change an alphabet the word can be fixed else return false*/
                    if (userDict[i].Length == keyword_length && userDict[i] != keyword)
                    {
                        for (int x = 0; x < userDict[i].Length; x++)// /*for loop to compare each alphabet*/
                        {
                            if (userDict[i][x] != keyword[x]) /*increment the different variable if locked word alphabet is different from keyword alphabet*/
                            {
                                different += 1;
                            }
                            if (different > 1)//break through the loop cause there's no point in traversing
                            {
                                break;
                            }
                        }
                    }
                    if (different == 1)
                    {
                        output= true;
                    }
                }//end of first for loop
                return output;
            }//end of try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error computing DictSearch");
                return default;
            }
        }//end of DictSearch method


        /*******    question # 9 functions and methods ******/

        /*function to load the inputs and output to a dictionary callled assignments 
         its called assignments cause we will be making final assignments to this
         this will also be used to cater for a corner case*/
        public static Dictionary<char, int> Populate_unique_alpabets(string i1, string i2, string op)
        {
            try
            {             //to contain all the unique alphabets and their assignments
                Dictionary<char, int> assignments = new Dictionary<char, int>();
                /*populating dictionary with unique alphabets - op first so that first char has to be 1
                 * no matter what - this way we save one whole nested loop recursion and hence time - that will
                 * be shown in main solve puzzle function
                 * */
                string x = op + i1 + i2;
                /*run a loop to iterate through the combo of 3 strings x
                 if the alphabet doesnt exist in dictionary assignments, add it 
                 else move on to next iteration*/
                for (int a = 0; a < (i2.Length + i1.Length + op.Length); a++)
                {
                    if (assignments.ContainsKey(x[a]) == false)
                    {
                        assignments[x[a]] = x[a];
                    }
                }
                /*return the populated dictionary*/
                return assignments;
            }
            catch (Exception)
            { Console.WriteLine("an error occured while populating_unique alphabets - as a part of solved puzzle");
                return null;
            }
        }


        /**********       recursive function - heart of the program ***********/
        /**takes start (which is initially passed 1 since no number can start with 0 and hence we dont want our first loop to waste time on 0s
         * depth keeps a check on each level down we go (max dept can be 10 since available digits to play with)
         * s is empty string - which will be storing probable solution assignments for our final solution - sequential assignment for each unique alphabet in assignments
         * assignments dictionary is only passed so we can use it to assign values to the keys in the assign_numbers function
         * string i1,i2,op are input and output strings- main puzzle- they're only used in the problem_solved function to decode what number the two inputs and output represent
         */
        static void Recursionfunction(int start, int depth, int maxdepth, int iterationend,String s, Dictionary<char, int> assignments, string i1, string i2, string op)
        {
            try
            {
                /**start with solved bool==false (defaultstate) so that we can change it to true and get out of the recursion */
                bool solved = false;
                /**this loop will become a nested version of itself via recursion and shall traverse through each digit from 0-10 (except in 1st run its 1)*/
                for (int a = start; a < iterationend; a++)
                {
                   
                    /*if you're at max depth, no need to call recursion again  
                     * check whether a is already part of the string or not - only add if its not (dont want duplicate assignments)
                     * if this is not first iteration of the current loop, delete the character previously added and then add the new one
                     */
                    if (depth == maxdepth-1  && a > 0 && s.Contains(a.ToString()) == false)
                    {
                        s = s.Substring(0, depth);
                        s += a.ToString();
                    }
                    /*if its the first iteration of the current loop - depicted by a=0, directly add the digit a to string s as a character*/
                    if (depth == maxdepth-1 && a == 0 && s.Contains(a.ToString()) == false)
                    {
                        s += a.ToString();
                    }
                    /*if you're not at max depth, call recursion again, to solve for the next blank
                     * depth +1 to track that we are going to the next level
                     * if not the first iteration - delete the last addded character and then add the current digit as character*/
                    if (depth < maxdepth-1  && a > 0 && s.Contains(a.ToString()) == false)
                    {
                        s = s.Substring(0, depth);
                        s += a.ToString();
                        Recursionfunction(0, depth + 1, maxdepth, iterationend,s, assignments, i1, i2, op);
                    }
                    /*if its the first iteration of the current loop - depicted by a=0, directly add the digit a to string s as a character*/
                    if (depth < maxdepth-1  && a == 0 && s.Contains(a.ToString()) == false)
                    {
                        s += a.ToString();
                        Recursionfunction(0, depth + 1, maxdepth, iterationend,s, assignments, i1, i2, op);
                    }
                    /*if string length==assignments dictionary with unique letter inside (we have found probable assignments for alphabets)
                    * - that string is ready to be tested as a  solution
                    *put the assigned values in this variable assignments (assign_numbers)
                    * call the function to check whether this is indeed our required solution (problem solve)
                    *if solved is returned true - output the solution and exit the program*/
                    if (s.Length == assignments.Count)
                    {
                        assignments = assign_numbers(s, assignments);
                        solved = problemsolve(assignments, i1, i2, op);
                        if (solved == true)
                        {
                            return;
//                            System.Environment.Exit(0);
                            /*
                            Exception ex = new Exception("solution found -stopping recursion");
                            throw ex;
                            */
                        }

                    }

                }//end of for loop
            }//end of try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*         *********        assign numbers function          ***************
         *         send the probable answer (as store answer) and the assignment dictionary to assign values to
         *         returns the nicely populated with assigned values dictionary
         *         convert string to character array
         *         run a loop through the assignments dictionary
         *         store the key at each index in x
         *         remove that key (since you wont be able to override its value
         *         add that key with the corresponding int(its a character in the character array but we convert it to int by parsing)
         *         back into the dictionary - viola you haev all your keys and corresponding values
         */

        public static Dictionary<char, int> assign_numbers(string store_answer, Dictionary<char, int> assignments)
        {
            try
            {             
                char[] ans_char_array = store_answer.ToCharArray();
                char x;
                for (int a = 0; a < assignments.Count; a++)
                {
                    x = assignments.ElementAt(a).Key;
                    assignments.Remove(x);
                    assignments.Add(x, Int32.Parse(ans_char_array[a].ToString()));
                }
                return assignments;
            }
            catch (Exception)
            {
                Console.WriteLine("error occured while computing assign numbers - as a part of solve puzzle");
                return null;
            }
        }//end of assign numbers




        /**************************     problem solve method ************************************
         * checks whether the assigned numbers solved the problem puzzle or not
         takes the assignments , both the inputs and the output
         makes a bool variable solved with default state false - if assignments and solution is correct make it true
         initialize power, 3 integers to store corresponding numerical values for each string input/output
         */
        public static bool problemsolve(Dictionary<char, int> assignments, string i1, string i2, string op)
        {
            try
            {
                bool solved = false;
                int pow = 0;
                int a_ip1 = 0;
                int b_ip2 = 0;
                int c_op = 0;

                //translating  the three words into the 3 numbers one by one 
                /*for each character in the string, start with the right most (that depicts 10s)
                 * add it to the corresponding integer variable -a_ip1 for first input
                 * increase the power by 1 (units to 10s, tens to hundereds and hundereds to thousands and so on)
                 * gives the sum (integer) depicting the word
                 */
                for (int x = i1.Length - 1; x >= 0; x--)
                {
                    a_ip1 += Convert.ToInt32(assignments[i1[x]] * Math.Pow(10, pow));
                    pow++;
                }

                /*set power back to 0 (to get units) before starting it for next word */
                pow = 0;
                for (int x = i2.Length - 1; x >= 0; x--)
                {
                    b_ip2 += Convert.ToInt32(assignments[i2[x]] * Math.Pow(10, pow));
                    pow++;
                }


                pow = 0;
                for (int x = op.Length - 1; x >= 0; x--)
                {
                    c_op += Convert.ToInt32(assignments[op[x]] * Math.Pow(10, pow));
                    pow++;
                }
                /*if sum of the two input integers depicted by words == output depicted by words - we have found the solution
                 *display it 
                 return true*/
                if (a_ip1 + b_ip2 == c_op)
                {
                    solved = true;
                    Console.WriteLine(i1 + "  " + a_ip1);
                    Console.WriteLine(i2 + "  " + b_ip2);
                    Console.WriteLine(op + "  " + c_op);
                    foreach (KeyValuePair<char, int> item in assignments)
                    {
                        Console.Write("{0}={1}  ", item.Key.ToString().ToUpper(), item.Value);
                    }
                    Console.WriteLine();
                }
                return solved;
            }//end of try
               catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error computing problemsolve - as a part of solve puzzle");
                return false;
            }
        
        }


        /****************  Solve puzzle method      ********************/
        /* display the inputs first
         * populate unique alphabets
         * initialize depth and max depth
         * check for corner case
         * start the recursion
         */
        public static void SolvePuzzle(string i1, string i2, string op)
        {
            try
            {
                Console.WriteLine("input1 is: " + i1);
                Console.WriteLine("input2 is: " + i2);
                Console.WriteLine("output is: " + op);

                if (i1.Length == 0 || i2.Length == 0 || op.Length == 0 )
                {
                    Exception ex = new Exception("Empty inputs error ");
                    throw ex;
                }


                /** step1 **/ //call function to populate distinct alphabets.
                Dictionary<char, int> assignments = Populate_unique_alpabets(i1, i2, op);
                //initialize variable depth to keep a track of how deep we are inside the recursive loops and when to stop recursion
                int depth = 0;

                //depends on the unique alphabets we need to solve for 
                int maxdepth = assignments.Count;
                //this is based on the fact that each alphabet can take a max of 10 values (0,1,2,3,4,5,6,7,8,9)
                int iterationend = 10;
                /*handling the corner case of more than 10 unique alphabets - since only 1 digit is allowed
                per alphabet and no repetitions - and we have total 10 single length digits in maths*/
                if (assignments.Count > 10)
                {
                    Exception ex = new Exception("unique alphabets are more than 10");
                    throw ex;
                }
                /** step2 - start recursion
                 * initialize an empty string s which will store all the probable values for the answer
                 * and unique alphabets assignment**/
                 /*pass start as 1 since every first digit in result atleast starts with 1 - starting with 0 isn't a possibility*/
                string s = "";
                Recursionfunction(1, depth, maxdepth,iterationend, s, assignments, i1, i2, op);
            }//end of try

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }//end of solvepuzzle






    }
}



