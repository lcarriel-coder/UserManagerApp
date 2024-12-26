using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerApp.Services.Uitls
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public string Token { get; set; }
    }
}
