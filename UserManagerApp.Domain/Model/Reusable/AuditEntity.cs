using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerApp.Domain.Model.Reusable
{
    public  class AuditEntity
    {
        public DateTime CreatedOn { get; set; }

        // [Column(TypeName = "varchar(250)")]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        // [Column(TypeName = "varchar(250)")]
        public string UpdatedBy { get; set; }
    }
}
