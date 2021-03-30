using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoDaruratSystem.Web.Library.Entities
{
    public class UserEntity
    {

        public class User
        {
            [Key]
            public long ID { get; set; }

            public long IDRole { get; set; }
            public long IDKartu { get; set; }
            public string Code { get; set; }
            public string UserName { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsLogin { get; set; }
            public bool IsActive { get; set; }
            public DateTime? LastLoginDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }

        }
    }
}
