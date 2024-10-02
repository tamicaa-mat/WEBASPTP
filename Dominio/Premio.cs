using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Premio
    {
        public int Id { get; set; }  // Identificador único del premio
        public string Nombre { get; set; }  // Nombre del premio
        public string Descripcion { get; set; }  // Descripción del premio
        public decimal Valor { get; set; }  // Valor monetario o estimado del premio
        public List<string> Imagenes { get; set; }  // Lista de URLs o rutas de imágenes del premio

        public Premio()
        {
            Imagenes = new List<string>();  // Inicializa la lista de imágenes
        }
    }
}
