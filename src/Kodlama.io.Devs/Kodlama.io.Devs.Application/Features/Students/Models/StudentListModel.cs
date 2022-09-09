using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Students.Models
{
    public class StudentListModel : BasePageableModel
    {
        public IList<StudentListDto> Items { get; set; }
    }
}
