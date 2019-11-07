using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthWindSystem
{
    //all classes by default are private. Change to public
    //all ebtity or Data classes in this course will be SINGULAR in name
    
        //An annotation that will point this class to the appropriate
        // sql table is needed in front of the class header
        // an annotation syntax is [annotation]
        //syntax: [Table("mysqltablename"[,Schema="sqlschemaname"])]
        //sometimes, your sql database will be divided into groups:
        // you can recognize a schema on a table by the name it is using
        // ex. umanResources.Employees
        //IF your database does not have schemas, then you omit the schema attribue
        //      from your annotation
        //the creation of this class is called mapping.
        // you are supplying a defenition of the sql table to the application

    [Table("Products")]

    class Product
    {
        //all sql attributes will have a correspnding class property

        //if you use the attribute name as your property name,
        // the physical order pf the properties do NOT need to match
        // the sql attribute order

        // you need a [Key] annotation for your primary key field
        //[Key] use on an identity pkey field (default)
        //optional style [Key, [DatabaseGenerated(DatabaseGeneratedOption.identity)]
        //[Key, Column(Order=n) use on compound pkey of the components

        //  n represnts the PHYSICAL order of the components
        //  n starts at 1 (natural number)
        //[Key, DataGenerated(DataGeneratedOption.None)] usse for
        //  pkeys that are NOT compound OR NOT identity; that is the user
        //  must supply the pkey value

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        //[ForeignKey] DO NOT USE
        //this is optional
        //use this annotation ONLY IF your foreign key
        //  sql field name is NOT the same as the associated
        //  primary key field name OR if you use a different
        //  name in your mapping

            //'?' means nullable. check for sql table columns and allow nulls in ms sql server management
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitInStock { get; set; }
        public Int16? unitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool? Discontinued { get; set; }
        
        public Product() { }

        

        //optionally add your constructors (default and greedy)

        //other annotation
        //computed field:
        //computed field does not exist on the database table
        //this field does NOT expect data from the user nor does
        //      EntityFramework expect data to pass to this sql attribute

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal Total { get; set; }


        //Read-Only application property
        //lets assume you would like to concatenate some fields together
        //  withon your applicaton on several occasions such as
        // creating a full name out of 2 attributes like Firstname and Lastname

        //these Read-Only propertie are non mapped feilds
        //they do not exist on the SQL table
        //Entity framework is not expecting to be supplied data NOT will
        //  it supply data for the property
        [NotMapped]

        public string ProductandID
        {
            get
            {
                return ProductName + "(" + ProductID + ")";
            }
            
        }
    }
}
