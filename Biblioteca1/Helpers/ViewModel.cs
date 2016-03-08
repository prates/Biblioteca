using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca1.Helpers
{
    public class ViewModel
    {
        public ViewModel(Livro livro, List<Genero> generos)
        {
            Livro = livro;
            Generos = generos;

        }

        public Livro Livro { get; private set; }
        public List<Genero> Generos { get; private set; }
    }
}