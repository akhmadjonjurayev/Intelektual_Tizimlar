using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class Atribute
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AtributeId { get; set; }

        public int Sequence { get; set; }

        public string AtributeName { get; set; }

        public virtual ICollection<Situation> Situations { get; set; }
    }
}
