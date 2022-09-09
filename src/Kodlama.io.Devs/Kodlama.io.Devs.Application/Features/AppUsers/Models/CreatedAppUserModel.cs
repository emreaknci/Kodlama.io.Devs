using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.AppUsers.Models
{
    public class CreatedAppUserModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
