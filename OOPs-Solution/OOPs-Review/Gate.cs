using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review
{
    public class Gate
    {
        public double Height { get; set; }

        private string _Style;
        private double _Width;
        public string Style
        {
            get
            {
                return _Style;// if "return Style(no underscore)" is in this line, the program will loop. you know why.
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        _Style = null;
                    }
                    else
                    {
                        _Style = value;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            }
        }
        public double Width
        {
            get
            {
                return _Width;
            }
            set
            {
                try
                {
                    if (value > 0.0)
                    {
                        new Exception("width can not be 0 or less than 0");
                    }
                    else
                    {
                        _Width = value;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

        }
        public double? Price { get; set; }
        public Gate()
        {

        }
        public Gate(double height, double width, string style, double? price)
        {
            Height = height;
            Width = width;
            Price = price;
            Style = style;
            //these are constructors
        }

        
        public double GateArea(double linearlegnth)
        {
            //property Heights is auto implemented, there is no choice
            return linearlegnth * Height;
        }
    }
}
