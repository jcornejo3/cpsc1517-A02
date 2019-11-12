using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using NorthWindSystem.Data;
#endregion

namespace NorthWindSystem.DDL
{

    //security enhancement using access privilage: internal
    //restricts the access to this class to call from within this library property

    //this class needs to be "tied" into EntityFramework
    //this will be done by inheriting the class DbContext
    internal class NorthWindContext:DbContext
    {
        //this class needs to supply DbContext with the application's
        //connection string name
        //this name is supplied to DbContext using the contructor of this class

        public NorthWindContext():base("myconnectionstringname") { }

        //we need properties in  this class tht will be used by EntityFramework to transpot the Data
        // into/out-of the application.
        //each entity will have their own "tranpotation set"

        //the coding standard for this course will be plural nameing for 
        //  the Dbset<T> property name

        public DbSet<Product> Products { get; set; }
    }
}
