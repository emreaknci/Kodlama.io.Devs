using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Students.Dtos
{
    public class StudentListDto
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
