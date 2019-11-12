using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace NorthwindSystem.Data
{
    [Table("Region")]
    class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]// since that there is no primary key
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }

        public Region() { }

        public Region(int regionid, string regiondescription)
        {
            RegionID = regionid;
            RegionDescription = regiondescription;
        }
        

    }
}
