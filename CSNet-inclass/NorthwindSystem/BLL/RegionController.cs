using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional Namespaces
using NorthwindSystem.DAL;
using NorthwindSystem.Data;
#endregion

namespace NorthwindSystem.BLL
{
    public class RegionController
    {
        //each method in this controller is exposed to the outside world
        //it is the interface to the application library
        //the method will interact with the internal context class
        public List<Region> Region_List()
        {
            //create an instance of the context class that you wist to interact with.
            //in this case, we will interact with region

            //wrap our work inside a transaction.
            //this transaction will help in insert, update, and delete 
            //      to ensure proper commits and rollbacks
            //this transaction is not neccesarry for queries, but we will use it so we need to
            //      only learn one technique.
            using (var context = new NorthwindContext())
            {
                //entityframework has many bult in methods that have 
                //      been deem common requirements for 99.99999999% of applications

                //to return a complete set of records associated with the 
                //      Dbset<T>; you simply have to reference the DbSet property.

                //i want a list of all region

                return context.Regions.ToList();
            }
        }

        //this method is to lookup a entity record by its primary key
        public Region Regions_FindByID(int regionid)
        {
            using(var context = new NorthwindContext())
            {
                return context.Regions.Find(regionid);
            }
        }


       
    }
}
