using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BFS
    {
    class Program
        {
        static void Main(string[] args)
            {
            //declare varis used in main
            string recordIn;
            int numberItems, maxWeight, item;
            //string filename = "text.txt.txt";
            //open file
            FileStream inFile = new FileStream("text.txt.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            //read in values used in main to read file
            recordIn = reader.ReadLine( );
            numberItems = Convert.ToInt32(recordIn);
            recordIn = reader.ReadLine( );
            maxWeight = Convert.ToInt32(recordIn);
            int[] value = new int[numberItems];
            int[] weight = new int[numberItems];
            for (int a = 0; a < numberItems; ++a)
                {
                recordIn = reader.ReadLine( );
                item = Convert.ToInt32(recordIn);
                value[a] = item;
                }
            for (int b = 0; b < numberItems; ++b)
                {
                recordIn = reader.ReadLine( );
                item = Convert.ToInt32(recordIn);
                weight[b] = item;
                }
            reader.Close( );
            inFile.Close( );
            //make top node in tree
            Node Start = new Node
            {
                Parent = null,
                Weight = 0,
                Value = 0,
                Children = new Node[numberItems],
                NumberChild = numberItems,
                NodeNum = "",
            };
            //call method
            DepthFS(Start, numberItems, value, weight, maxWeight);
            }
        public static void DepthFS(Node Start, int numberItems, int[] value, int[] weight, int MaxWeight)
            {
            //make all nodes used in method
            Node Top = new Node( );
            Node Solution = new Node( );
            Node Solution1 = new Node( );
            Node B;
            Stack<Node> Q = new Stack<Node>( );
            Q.Push(Start);
            //start loop to put out of stack
            while (Q.Count > 0)
                {
                //view 1st node
                Top = Q.Pop( );
                //make all child nodes
                for (int x = 0; x < Top.NumberChild; ++x)
                    {
                    if (!(Top.NodeNum.Contains(x + "	")))
                        {
                        B = new Node
                        {
                            Weight = Top.Weight + weight[x],
                            Value = Top.Value + value[x],
                            NumberChild = Top.NumberChild - 1,
                            Children = new Node[numberItems - 1],
                            Parent = Top,
                            NodeNum =  x + "	" + Top.NodeNum,
                        };
                        //Console.WriteLine("Value" + B.Value + "," + B.Weight + " is created");
                        Top.Children[x] = B;
                        if (Top.Children[x].NumberChild > 0 && B.Weight <= MaxWeight)
                            {
                            Q.Push(B);
                            //Console.WriteLine("Value"+ B.Value +"," +B.Weight + " is Pushed onto the stack");
                            }
                        }
                    }
                //check to find solution  
                Solution1 = Top;//Q.Pop( );
                //Console.WriteLine("Value" + Solution1.Value + "," + Solution1.Weight + " is Poped off the stack");
                if (Solution.Value < Solution1.Value && Solution1.Weight <= MaxWeight)
                    {
                    Solution = Solution1;
                    }
                }

            //print to screen
            Console.WriteLine(Solution.NodeNum);
            Console.WriteLine("w:" + Solution.Weight);
            Console.WriteLine("v:" + Solution.Value);
            Console.ReadKey( );
            }
        }
    //class to make nodes
    public class Node
        {
        public Node Parent { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public Node[] Children;
        public int NumberChild;
        public string NodeNum = "";
        }
    }

