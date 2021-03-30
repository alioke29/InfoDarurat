using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InfoDaruratSystem.Web.Library.Entities
{
    public class MenuEntity
    {

        public class Menu
        {
            [Key]
            public long ID { get; set; }

            public string DisplayName { get; set; }
            public string UrlNav     { get; set; }
            public long ParentMenuId { get; set; }
            public string SortNumber { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UpdateBy { get; set; }
            public DateTime? UpdatedDate { get; set; }
        }

    }
}
