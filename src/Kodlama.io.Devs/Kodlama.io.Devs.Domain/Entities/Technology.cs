using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Technology : Entity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage Language { get; set; }

        public Technology()
        {
        }

        public Technology(int id, int languageId, string name) : this()
        {
            Id = id;
            LanguageId = languageId;
            Name = name;
        }



    }
}
