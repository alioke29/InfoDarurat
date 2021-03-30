using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoDaruratSystem.Web.Library.Entities
{
    public class PanggilanEntity
    {

        public class Panggilan
        {
            [Key]
            public long ID { get; set; }
            public long IDLevel { get; set; }
            public string Nama { get; set; }
            public string Spec { get; set; }
            public string NoPanggilan { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }

        }

    }
}
