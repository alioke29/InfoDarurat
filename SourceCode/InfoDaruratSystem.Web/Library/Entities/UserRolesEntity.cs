using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoDaruratSystem.Web.Library.Entities
{
    public class UserRolesEntity
    {

        public class UserRoles
        {
            [Key]
            public long ID { get; set; }

            public long IDRole { get; set; }
            public long IDMenu { get; set; }
            public bool IsActiveMenu { get; set; }
            public bool IsAdd { get; set; }
            public bool IsEdit { get; set; }
            public bool IsDelete { get; set; }
            public bool IsExport { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UpdateBy { get; set; }
            public DateTime? UpdatedDate { get; set; }

        }

    }
}
