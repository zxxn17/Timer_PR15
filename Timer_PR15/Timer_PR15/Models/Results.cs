using System;
using SQLite;

namespace Timer_PR15.Models
{
    public class Results
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Result { get; set; }
    }
}
