// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CTPH_CoreData.Models
{
    public partial class Tipos_Valores
    {
        public Tipos_Valores()
        {
            Elementos = new HashSet<Elementos>();
        }

        [Key]
        public byte idTipoValor { get; set; }
        [StringLength(55)]
        public string TipoValor { get; set; }

        [InverseProperty("idTipoValorNavigation")]
        public virtual ICollection<Elementos> Elementos { get; set; }
    }
}