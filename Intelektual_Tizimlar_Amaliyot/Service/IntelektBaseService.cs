using Intelektual_Tizimlar_Amaliyot.Models;
using Intelektual_Tizimlar_Amaliyot.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Service
{
    public class IntelektBaseService
    {
        private readonly IntelektDB _dB;
        public IntelektBaseService(IntelektDB dB)
        {
            this._dB = dB;
        }

        public async Task<bool> CreateAtribute(InputViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.EntityValue))
                return false;
            var newAtribute = new Atribute
            {
                AtributeName = viewModel.EntityValue
            };
            var maxSequenceAtribute = _dB.Atributes.AsNoTracking().OrderByDescending(l => l.Sequence).AsQueryable().FirstOrDefault();
            if (maxSequenceAtribute != null)
                newAtribute.Sequence = ++maxSequenceAtribute.Sequence;
            else
                newAtribute.Sequence = 0;
            await _dB.Atributes.AddAsync(newAtribute);
            if(await _dB.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateConditionAsync(InputViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.EntityValue))
                return false;
            var newCondition = new Condition
            {
                ConditionValue = viewModel.EntityValue
            };
            var maxSequenceCondition = _dB.Conditions.AsNoTracking().OrderByDescending(l => l.Sequence).AsQueryable().FirstOrDefault();
            if (maxSequenceCondition != null)
                newCondition.Sequence = ++maxSequenceCondition.Sequence;
            await _dB.Conditions.AddAsync(newCondition);
            if (await _dB.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
