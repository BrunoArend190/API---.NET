using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo1
{
    public class Importacao
    {
        readonly string[] _arquivo;
        //construtor
        public Importacao()
        {
            _arquivo = 
            File.ReadAllLines("C:\\Users\\Bruno\\Desktop\\Paradigma\\Projetos\\Exemplo1\\produtos.txt");
        }
       
        public List <Produto> ConverterParaLista()
        {
            List<Produto> produtos = new();

            for (int i = 1; i < _arquivo.Length; i++)
            {
                string[] colunas = _arquivo[i].Split(';');

                Produto produto = new();
                produto.Id = Convert.ToInt32 (colunas[0]);
                produto.Nome = colunas[1];
                produto.Descricao = colunas[2];
                produto.Preco = Convert.ToDouble(colunas[3]);
                produto.Quantidade = Convert.ToInt32(colunas[4]);
                produto.CodBarras = colunas[5];

                produtos.Add(produto);
            }
            return produtos;
        }
    }


}
