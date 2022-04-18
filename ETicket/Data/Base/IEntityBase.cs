using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }

        DateTime CreateDate { get; set; }
        DateTime? ModifyDate { get; set; }
        string UserId { get; set; }
        bool IsActive { get; set; }
        bool? IsDelete { get; set; }

    }
}
