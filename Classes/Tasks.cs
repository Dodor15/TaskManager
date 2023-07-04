using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes
{
    public class Tasks 
    {
        [JsonIgnore]
        public string Id { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        public string NameTask { get; set; }
        public string ExecutorTask { get; set; }
        public string DateTime { get; set; }
        public  int Status { get; set; }
        public string Description { get; set; }
        public string TaskID { get; set; }
        public string TaskDone { get; set; }

        [JsonIgnore]
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "Не выполнено";
                        break;
                    case 1:
                        return "Выполнено";
                        break;
                    case 2:
                        return "Завершено";
                    default:
                        return "";
                        break;

                }
            }
        }

    }
}
