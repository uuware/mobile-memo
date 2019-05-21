using System;
using SQLite;

namespace MemoSaver.Services
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Done { get; set; }
        public string Time { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }

        public string Title { get; set; }
        public string Notes { get; set; }
        public string Ids { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Card { get; set; }
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
        public string Field06 { get; set; }
        public string Field07 { get; set; }
        public string Field08 { get; set; }
        public string Field09 { get; set; }
        public string Field10 { get; set; }
        public string FieldT01 { get; set; }
        public string FieldT02 { get; set; }
        public string FieldT03 { get; set; }
        public string FieldT04 { get; set; }
        public string FieldT05 { get; set; }
        public string FieldT06 { get; set; }
        public string FieldT07 { get; set; }
        public string FieldT08 { get; set; }
        public string FieldT09 { get; set; }
        public string FieldT10 { get; set; }
    }
}