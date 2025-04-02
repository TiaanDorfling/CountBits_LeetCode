using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CountBits_LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display();
        }

        enum menu
        {
            Calculate,
            Exit
        };

        static void Display()
        {
            foreach (var var in Enum.GetValues(typeof(menu)))
            {
                Console.WriteLine($"{(int)var + 1}. {var.ToString()}");
            }
            input();
            Console.ReadLine();
        }

        static void input()
        {
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice) 
            {
                case 1:
                    Console.WriteLine("Enter value for calculation.");
                    Solution solution = new Solution();
                    solution.CountBits(int.Parse(Console.ReadLine()));
                    Display();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }

        }

        public class Solution
        {
            public Solution() { }
            public void CountBits(int n)
            {
                string binary = "";
                int k = 0;
                List<int> list = new List<int>();
                for (int i = 0; i <= n; i++)
                {
                    if (binary == "")
                    {
                        binary += "0";
                    }
                    else if (binary == "0")
                    {
                        binary = "1";
                    }
                    else if (binary == "1")
                    {
                        binary = "10";
                    }
                    else if (binary.Length > 1)
                    {
                        binary = steps(binary);
                    }

                    k = 0;

                    for (int var = 0; var < binary.Length; var++)
                    {
                        if (binary[var] == '1')
                        {
                            k++;
                        }
                    }

                    list.Add(k);
                }
                int[] ans = new int[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    ans[i] = list[i];
                }

                //return ans;
                Console.WriteLine($"The binary value of {n} is {binary}.");
                Console.WriteLine($"The amount of bits per n is as follows: ");
                Console.WriteLine("-----------------------------------------");
                foreach (var var in ans)
                {
                    Console.Write($"{var},");
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
            }

            private string steps(string binary)
            {
                string focus = "";
                if (binary.Length == 2)
                {
                    focus = binary;
                    binary = "";
                }
                else
                {
                    focus = binary.Substring(binary.Length - 2, 2);
                    binary = binary.Substring(0, binary.Length - 2);
                }

                if (focus == "00")
                {
                    focus = "01";
                    binary += focus;
                }
                else if (focus == "01")
                {
                    focus = "10";
                    binary += focus;
                }
                else if (focus == "10")
                {
                    focus = "11";
                    binary += focus;
                }
                else if (focus == "11")
                {
                    focus = "00";
                    //work left make 0 - 1 and 1 - 0. only go further if first one was 1 - 0.
                    if (binary.Length != 0)
                    {
                        if (binary.Last() == '0')
                        {
                            binary = binary.Remove(binary.Length - 1, 1);
                            focus = "1" + focus;
                            binary += focus;
                        }
                        else if (binary.Last() == '1')
                        {
                            while (binary.Last() == '1')
                            {
                                if (binary.Length > 1)
                                {
                                    binary = binary.Remove(binary.Length - 1, 1);
                                    focus = "0" + focus;
                                }
                                else
                                {
                                    focus = "0" + focus;
                                    break;
                                }
                            }
                            if (binary.Last() == '0')
                            {
                                binary = binary.Remove(binary.Length - 1, 1);
                                focus = "1" + focus;
                                binary += focus;
                            }
                            else
                                binary += focus;
                        }
                    }
                    else
                    {
                        binary = "100";
                    }
                }

                return binary;
            }
        }
    }
}