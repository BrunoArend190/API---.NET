using System;
using Exemplo1;

Importacao importacao = new();

var produtos = importacao.ConverterParaLista();

foreach (var produto in produtos)
{
    Console.WriteLine(produto.Id.ToString() + " " + produto.Nome);
}


Console.WriteLine("Hello, World!");

