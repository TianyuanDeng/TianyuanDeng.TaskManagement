using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TianyuanDeng.TaskManagement.Core.Models.Request
{
    public class UserDeleteModel
    {
        [Required]
        public int Id { get; set; }
    }
}
