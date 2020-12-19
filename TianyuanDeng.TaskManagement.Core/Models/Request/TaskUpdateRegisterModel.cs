using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Request
{
    public class TaskUpdateRegisterModel
    {
        [Required]
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }

        [StringLength(500)]
        public string Remakrs { get; set; }
    }
}
