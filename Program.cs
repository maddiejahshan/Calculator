using System;
using System.IO;
using StackLibrary;
using QueueLibrary;
using System.Collections.Generic;

namespace CalculatorProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter an equation with spaces inbetween each token.");
                string input = Console.ReadLine();

                if(input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    break;
                }
                
                if(Calculator.CheckParenthesis(input) == false)
                {
                    Console.WriteLine("Error");
                    return;
                }

                MyQueue<string> equation = Calculator.ParseEquation(input);

                double answer = Calculator.Compute(equation);
                Console.WriteLine($"{answer}");
            }

        }
        class Calculator
        {
            public static bool CheckParenthesis(string equation)
            {

                StackLibrary<string> TestStack = new StackLibrary<string>();
                string opening = "(";
                string closing = ")";
                try
                {
                    for (int i = 0; i < equation.Length; i++)
                    {
                        string current = equation.Substring(i, 1);
                        if (opening.Contains(current))
                        {
                            TestStack.Push(current);
                        }
                        else if (closing.Contains(current))
                        {
                            string saved = TestStack.Pop();
                            if (opening.IndexOf(saved) != closing.IndexOf(current))
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
                return true;
            }


            public static MyQueue<string> ParseEquation(string equation)
            {
                MyQueue<string> eq = new MyQueue<string>();

                string[] tokens = equation.Split(' ');

                int countOperators = 0;
                int countParenthesis = 0;
                
                for(int i = 0; i < tokens.Length; i++)
                {
                    if(tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/" || tokens[i] == "sin" || tokens[i] == "cos" || tokens[i] == "tan" || tokens[i] == "sqrt" || tokens[i] =="**")
                    {
                        countOperators++;
                    }
                    else if(tokens[i] == "(" || tokens[i] == ")")
                    {
                        countParenthesis++;
                    }
                    eq.Enqueue(tokens[i]);
                }
                
                if(countOperators == (countParenthesis/2))
                {
                    return eq;
                }
                else
                {
                    return null;
                }
                
            }

            public static double Compute(MyQueue<string> equationTokens)
            {
                StackLibrary<double> values = new StackLibrary<double>();
                StackLibrary<string> operands = new StackLibrary<string>();

                while (!equationTokens.IsEmpty())
                {
                 
                    string s = equationTokens.Dequeue();
                    if (s.Equals("("))
                    {

                    }
                    else if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/") || s.Equals("sqrt"))
                    {
                        operands.Push(s);
                    }
                    else if (double.TryParse(s, out double value))
                    {
                        values.Push(value);
                    }
                    else if (s.Equals(")"))
                    {
                        string op = operands.Pop();
                        double v = values.Pop();

                        if (op.Equals("+"))
                        {
                            v = values.Pop() + v;
                        }
                        else if (op.Equals("-"))
                        {
                            v = values.Pop() - v;
                        }
                        else if (op.Equals("*"))
                        {
                            v = values.Pop() * v;
                        }
                        else if (op.Equals("/"))
                        {
                            v = values.Pop() / v;
                        }
                        else if (op.Equals("sqrt"))
                        {
                            v = Math.Sqrt(v);
                        }
                        else values.Push(Double.Parse(s));

                        values.Push(v);

                    }
                }
                return(values.Pop());
                Console.WriteLine($"{values}");
            }
        }
    }
    // 1. check for balanced parenthesis <-- stack
    // 2. tokenize/enqueue the tokens <-- queue
    // 3. solve using djistras 2-stack algorithm
}
      
