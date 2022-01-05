using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Models
{
    public class Situation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SituationId { get; set; }

        public int Sequence { get; set; }

        [ForeignKey("Atribute")]
        public Guid AgreementId { get; set; }

        [ForeignKey("Condition")]
        public Guid ConditionId { get; set; }

        [ForeignKey("Agreement")]
        public Guid AtributeId { get; set; }

        public virtual Atribute Atribute { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Agreement Agreement { get; set; }
    }
}
