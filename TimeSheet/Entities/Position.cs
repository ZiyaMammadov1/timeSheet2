﻿namespace TimeSheet.Entities
{
    public class Position
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
        public string codeUR { get; set; }

        public string code { get; set; }
    }
}
