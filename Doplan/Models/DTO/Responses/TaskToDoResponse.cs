using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doplan.Models.DTO.Responses
{
    public class TaskToDoResponse
    {
        public string Text { get; set; } 
        public bool IsCompleted { get; set; }
    }
}
