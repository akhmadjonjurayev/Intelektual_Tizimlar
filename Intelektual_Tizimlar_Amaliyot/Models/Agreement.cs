using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class Agreement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AgreementId { get; set; }

        public int Sequence { get; set; }

        [JsonIgnore]
        public ICollection<Situation> Situations { get; set; }
    }
}
