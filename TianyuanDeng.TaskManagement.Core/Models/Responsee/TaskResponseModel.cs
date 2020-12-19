using System;
using System.Collections.Generic;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Responsee
{
    public class TaskResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
    }
}
