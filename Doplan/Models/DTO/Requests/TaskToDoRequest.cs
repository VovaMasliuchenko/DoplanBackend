using Doplan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doplan.Models.DTO.Requests;

public class TaskToDoRequest
{
    public string Text { get; set; }
    public string Id_User { get; set; }
    public int Id { get; set; }
}
