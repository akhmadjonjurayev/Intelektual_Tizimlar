using Intelektual_Tizimlar_Amaliyot.Service;
using Intelektual_Tizimlar_Amaliyot.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IntelektController : ControllerBase
    {
        private readonly IntelektBaseService _intelekt;

        public IntelektController(IntelektBaseService intelekt)
        {
            this._intelekt = intelekt;
        }

        [HttpPost]
        public async Task<ResponceViewModel> CreateAtribute(InputViewModel viewModel)
        {
            var result = await _intelekt.CreateAtribute(viewModel);
            if (result)
                return new ResponceViewModel { IsSuccess = true, Message = "success-add-data" };
            return new ResponceViewModel { IsSuccess = false, Message = "error-add-data" };
        }

        [HttpPost]
        public async Task<ResponceViewModel> CreateCondition(InputViewModel viewModel)
        {
            var result = await _intelekt.CreateConditionAsync(viewModel);
            if (result)
                return new ResponceViewModel { IsSuccess = true, Message = "success-add-data" };
            return new ResponceViewModel { IsSuccess = false, Message = "error-add-data" };
        }

        [HttpGet]
        public async Task<ResponceViewModel> GetAtributes([FromQuery]int skip = 0, int take = 20)
        {
            return await _intelekt.GetAtributesAsync(skip, take);
        }

        [HttpGet]
        public async Task<ResponceViewModel> GetConditions([FromQuery]int skip = 0, int take = 20)
        {
            return await _intelekt.GetConditionsAsync(skip, take);
        }
    }
}
