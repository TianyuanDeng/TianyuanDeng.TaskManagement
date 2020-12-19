using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TianyuanDeng.TaskManagement.Core.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }


        [JsonIgnore]
        public ICollection<Tasks> Tasks { get; set; }
        
        [JsonIgnore]
        public ICollection<TasksHistory> TasksHistories { get; set; }
    }
}
