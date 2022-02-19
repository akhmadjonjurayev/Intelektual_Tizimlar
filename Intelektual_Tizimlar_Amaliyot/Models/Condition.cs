using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class Condition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ConditionId { get; set; }

        public int Sequence { get; set; }

        public string ConditionValue { get; set; }

        [JsonIgnore]
        public virtual ICollection<Situation> Situations { get; set; }
    }
}
