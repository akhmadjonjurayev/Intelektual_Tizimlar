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

        public async Task<ResponceViewModel> GetAtributesAsync(int skip, int take)
        {
            var atributes = await _dB.Atributes.AsNoTracking().Skip(skip).Take(take).AsQueryable().ToListAsync();
            return new ResponceViewModel { IsSuccess = true, Data = atributes, Message = "success" };
        }

        public async Task<ResponceViewModel> GetConditionsAsync(int skip, int take)
        {
            var conditions = await _dB.Conditions.AsNoTracking().Skip(skip).Take(take).AsQueryable().ToListAsync();
            return new ResponceViewModel { IsSuccess = true, Data = conditions, Message = "success" };
        }

        public async Task<ResponceViewModel> CreateAgreementAsync(List<CreateAgreementViewModel> viewModels)
        {
            try
            {
                if (viewModels == null || !viewModels.Any())
                    return new ResponceViewModel { IsSuccess = false, Message = "error-invalid-data" };

                var oldAgreement = _dB.Agreements.OrderByDescending(l => l.Sequence).FirstOrDefault();

                var agreement = new Agreement()
                {
                    Sequence = oldAgreement == null ? 1 : oldAgreement.Sequence + 1
                };

                await _dB.Agreements.AddAsync(agreement);

                int count = 0;

                foreach(var item in viewModels)
                {
                    var situation = new Situation
                    {
                        AgreementId = agreement.AgreementId,
                        ConditionId = item.ConditionId,
                        AtributeId = item.AtributeId,
                        Sequence = ++count,
                        IsResult = item.Result
                    };
                    await _dB.Situations.AddAsync(situation);
                }

                if(await _dB.SaveChangesAsync() > 0)
                {
                    return new ResponceViewModel { IsSuccess = true, Message = "success-saved-data" };
                }
                return new ResponceViewModel { IsSuccess = false, Message = "error-saved-data" };
            }
            catch (Exception ex)
            {
                return new ResponceViewModel { Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<ResponceViewModel> GetAgreements()
        {
            try
            {
                var agreements = await _dB.Agreements.AsNoTracking().Select(l => new
                {
                    l.AgreementId,
                    l.Sequence,
                    Situations = l.Situations.Select(p => new
                    {
                        p.SituationId,
                        p.Sequence,
                        p.Condition,
                        p.Atribute,
                        p.IsResult
                    }).OrderBy(r => r.Sequence)
                }).OrderBy(l => l.Sequence)
                    .ToListAsync();
                return new ResponceViewModel { IsSuccess = true, Message = "success", Data = agreements };
            }
            catch(Exception ex)
            {
                return new ResponceViewModel { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
