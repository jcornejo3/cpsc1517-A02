using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review
{
    class ConsoleController
    {
        public static void background()
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
    class Program
    {  
        static void Main(string[] args)
        {
            ConsoleController.background();
            //know how to do data inpt into a console application
            double linearLength = 135.0;
            double height = 6.5;
            //width
            double width = 8.0;
            string style = "Neighbour friendly: Spruce";
            double price = 108.0;

            //situation: have the required data for the class instance
            //option A: create instance using default instructor;five lines of code AND
            //  multiple assignment statements
            //option B: Create instance using Greedy Constructor; only take one line of code

            //option B:
            //Fence Panle is a non static class
            //Console is a static class(DOES NOT store Data)
            //for a non static class, you must create an instance of the class 
            //  to be able to use the class
            //syntax using the new keyword which requires a reference to the 
            //      appropriate class constructor

            FencePanel panel = new FencePanel(height, width,style,price);


            //handle numerous gates
            //create a class pointer that is able to reference the gate class
            //this pointer will be null
            Gate gateinfo;

            //a structure to hold a collection of Gate
            //The structure to use should hold an unknown number of instances
            //structure will be a List<T>
            //create the instance of the list of T when it is defined
            List<Gate> gatelist = new List<Gate>();

            //assume that i am in a loop to gather
            //      multiple gates
            //1st gate
            //technique 1
            //create instance of gate
            //colect data
            //add to list

            gateinfo = new Gate();
            height = 6.25;
            width = 4;
            style = "Neighbour friendly - 1/2 picket golden Spruce";
            price = 86.45;
            gateinfo.Height = height;
            gateinfo.Width = width;
            gateinfo.Style = style;
            gateinfo.Price = price;
            gatelist.Add(gateinfo);

            //2nd gate
            //technique 2
            //collect data
            //create the Gate instance
            //add to list

            height = 6.25;
            width = 3.0;
            style = "neighbour friendly spruce";
            price = 72.45;
            gateinfo = new Gate(height, width, style, price);
            gatelist.Add(gateinfo);

            //create the Estimate
            Estimate ClientEstimate = new Estimate();
            ClientEstimate.LinearLegnth = linearLength;
            ClientEstimate.Panel = panel;
            ClientEstimate.Gates = gatelist;
            ClientEstimate.CalculatePrice();

            //output client information
            Console.WriteLine($"The Fence is to be a {ClientEstimate.Panel.Style} style.");
            Console.Write($"The Linear Fence Length require is {ClientEstimate.LinearLegnth}");
            Console.Write($"\nNumber of required panels: {ClientEstimate.Panel.EstematedNumberOfPanels(ClientEstimate.LinearLegnth)}");
            Console.WriteLine($"\nNumber of required gates {ClientEstimate.Gates.Count}");
            double fenceArea = ClientEstimate.Panel.FenceArea(ClientEstimate.LinearLegnth);
            foreach (var item in ClientEstimate.Gates)
            {
                fenceArea += item.GateArea();
            }
            Console.WriteLine(string.Format("Total Fence surface area {0:0.00}", fenceArea * 2));
            Console.ReadKey();





        }
    }
}
