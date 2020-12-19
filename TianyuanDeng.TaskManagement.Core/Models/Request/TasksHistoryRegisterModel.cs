using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Request
{
    public class TasksHistoryRegisterModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public DateTime? Completed { get; set; }

        [Required]
        [StringLength(500)]
        public string Remakrs { get; set; }
    }
}
