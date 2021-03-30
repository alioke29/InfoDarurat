using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoDaruratSystem.Web.Library.Entities
{
    public class KartuEntity
    {

        public class Kartu
        {
            [Key]
            public long ID { get; set; }

            public string NoKartu { get; set; }
            public string Desc { get; set; }
            public string NamaPetugas { get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }

        }

    }
}
