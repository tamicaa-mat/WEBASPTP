﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public string Ciudad { get; set; }    
        public int CodigoPostal { get; set; }

        public string Direccion { get; set; }

        
        //public List<Voucher> Vouchers { get; set; }  // Lista de vouchers asociados al cliente

       
    }
}