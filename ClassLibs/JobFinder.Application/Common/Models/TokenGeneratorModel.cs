using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Common.Models
{
    public enum TokenGeneratorType
    {
        User = 0,
        Employer = 1,
    }
    public class TokenGeneratorModel
    {
        public string Identifier { get; set; }
        public string Email { get; set; }
        public TokenGeneratorType Type { get; set; }
    }
}
