using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models.ViewModels
{
    public class SucessViewModel
    {
        public string RequestId { get; set; }

        public string Message { get; set; }

        public string ViewToGo { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
