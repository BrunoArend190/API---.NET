using APIanimais.DataBase.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace APIanimais.DataBase
{
    public class DBContext
    {
        private const string Pathname =
            "C:\\Users\\Bruno\\Desktop\\Paradigma\\Projetos\\APIanimais\\animais.txt";

        private readonly List<Animal> _animais = new();
        public DBContext()
        {
            string[] lines = File.ReadAllLines(Pathname);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] coluns = lines[i].Split(";");
                Animal animal = new();              
                    animal.Id = int.Parse(coluns[0]);
                    animal.Name = coluns[1];
                    animal.Classification = coluns[2];
                    animal.Origin = coluns[3];
                    animal.Reprodution = coluns[4];
                    animal.Feeding = coluns[5];
                    _animais.Add(animal);
            }
        }
        public List<Animal> Animals => _animais;
    }
}
