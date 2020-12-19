using System;
using System.Collections.Generic;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Request
{
    public class DeleteModel
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
