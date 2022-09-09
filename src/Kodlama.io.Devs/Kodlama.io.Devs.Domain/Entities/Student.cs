using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Student : Entity
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        public virtual User User { get; set; }

        public Student()
        {

        }

        public Student(int id, int userId) : this()
        {
            Id = id;
            UserId = userId;
        }

    }
}
