using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Request
{
    public class TasksHistoryUpdateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
   
        [StringLength(50)]
        public string Title { get; set; }
       
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }

        [StringLength(500)]
        public string Remakrs { get; set; }
    }
}
