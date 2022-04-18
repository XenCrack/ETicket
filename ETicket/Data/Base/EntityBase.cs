using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Base
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get ; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? ModifyDate { get; set; }

        public string UserId { get; set; }

        public bool IsActive { get; set; } = true;

        public bool? IsDelete { get; set; }
    }
}
