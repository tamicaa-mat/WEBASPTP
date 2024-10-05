using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string Url { get; set; }
        public bool Estado { get; set; }
        public Imagen() { }
        public Imagen(string img) 
        { 
        Url = img;
        }
        public override string ToString()
        {
            return Url;
        }
    }
}
