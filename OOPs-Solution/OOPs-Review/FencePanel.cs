using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review
{
    //the default permissions is private
    //if an outside user of this class wanted access to the
    //class contents, then the class permisions must be public

    public class FencePanel
    {
        //properties
        //property is associated with a single piece of data
        //property has 2 self components:
        // get : returns a value to the calling agent(outside user).
        // set : recieves a value from the calling agent
        //      the key word used to represent the incoming data
        //      is value
        //a property DOES NOT have in a developer's parameter 

        //two ways to code a propert
        //
        //--Auto Implemented
        //  a private data member DOES NOT need to be coded
        //  the system will create an internal data that 
        //      the system will manage

        public double Height { get; set; }
        //public double Width { get; set; }

        //--Fully implemented property
        // a private data member WILL be coded for use for this property
        // typically, the incomoing data need additional processing
        // such as validation
        // Example: the characteristic is a string that can be null(0) or requires atleast one character (that is the string
        // can not be empty)

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
                    if(string.IsNullOrEmpty(value))
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
                    if(value > 0.0)
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

        //does a nullable non-string data value need a fully implemented property?
        // NO. a nullable numeric(can be empty) will either be given a numeric value or null(none).
        //However, if the numeric needs additional checking, then you should consider using a fully implemented property.

        public double? Price { get; set; }//  the '?' means that it is nullable

        //Constructors

        //default
        public FencePanel()
        {

        }

        //greedy constructor
        //list of parameters representing each posible data value in your 
        // class (properties);

        public FencePanel(double height, double width, string style, double? price)
        {
            Height = height;
            Width = width;
            Price = price;
            Style = style;
            //these are constructors
        }
    }
}
