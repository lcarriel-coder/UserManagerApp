using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerApp.Domain.Model.Reusable;

namespace UserManagerApp.Domain.Model
{
    public class Person : AuditEntity
    {
        [Key]
        public Guid IdPerson { get; set; }
        //public Guid PersonId { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; } 
        public string Identification { get; set; } 
        public string Email { get; set; }  
        public string IdentificationType { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public string FullIdentification
        {
            get { return Identification + "-" + IdentificationType; }
        }

   
        public string FullName
        {
            get { return FirstName + " " + LastName;}
        }
    }
}
