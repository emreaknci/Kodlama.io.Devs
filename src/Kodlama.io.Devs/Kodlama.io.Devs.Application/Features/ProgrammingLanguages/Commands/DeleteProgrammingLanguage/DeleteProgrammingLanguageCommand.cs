using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler:IRequestHandler<DeleteProgrammingLanguageCommand,DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _languageBusinessRules;
            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper, ProgrammingLanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var language = await _languageRepository.GetAsync(pl => pl.Id == request.Id);
                _languageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(language);
                await _languageRepository.DeleteAsync(language!);

                var deleteProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLanguageDto>(language);

                return deleteProgrammingLanguageDto;
            }
        }
    }
}
