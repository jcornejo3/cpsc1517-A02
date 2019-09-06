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
    }
}
