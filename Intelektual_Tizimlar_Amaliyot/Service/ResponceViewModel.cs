using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelektual_Tizimlar_Amaliyot.Service
{
    public class ResponceViewModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
