using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;


namespace TianyuanDeng.TaskManagement.Core.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        
        public int userId { get; set; }

        [JsonIgnore]
        public Users Users { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public string Remakrs { get; set; }
    }
}
