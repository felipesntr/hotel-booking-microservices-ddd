using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0,
        Finish = 1, // after paid and used
        Cancel = 2, // can never be paid
        Refound = 3, // paid then refound
        Reopen = 4 // canceled
    }
}
