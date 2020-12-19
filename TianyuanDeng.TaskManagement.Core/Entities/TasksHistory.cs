using System;
using System.Collections.Generic;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Entities
{
    public class TasksHistory
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Completed { get; set; }
        public string Remarks { get; set; }

        public Users Users { get; set; }
    }
}
