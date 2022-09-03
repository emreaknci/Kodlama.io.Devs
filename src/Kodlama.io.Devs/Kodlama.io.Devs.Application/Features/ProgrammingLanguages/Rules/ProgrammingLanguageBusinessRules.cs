using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _languageRepository;


        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException($"'{name}' language already exists.");
        }
        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage language)
        {
            if (language == null) throw new BusinessException("Requested language does not exist");
        }
    }
}
