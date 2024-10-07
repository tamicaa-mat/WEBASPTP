using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    
    
        public class Voucher
        {
            public string Codigo { get; set; }  
            public bool Usado { get; set; } 
            public int IdCliente { get; set; }
            public DateTime FechaCaje { get; set; }
            public int IdArticulo { get; set; }
           // public Premio PremioSeleccionado { get; set; }  // Premio seleccionado por el cliente (relación)

            public bool EsValido()
            {
                // Lógica para verificar si el voucher es válido (por ejemplo, no usado y dentro del período de validez)
                return !Usado;
            }

           // public void MarcarComoUsado()
           // {
             //   Usado = true;
               // FechaUso = DateTime.Now;
           // }
        }









    }

