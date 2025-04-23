using System;

namespace APIanimais.DataBase.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Origin { get; set; }
        public string Reprodution { get; set; }
        public string Feeding { get; set; }
    }
}
