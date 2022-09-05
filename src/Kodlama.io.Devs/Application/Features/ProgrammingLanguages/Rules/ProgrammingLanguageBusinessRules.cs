using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programminglanguage)
        {
            if (programminglanguage == null) throw new BusinessException("Requested programming language does not exist.");
        }

        public void ProgrammingLanguageToBeUpdatedShouldExist(ProgrammingLanguage programminglanguage)
        {
            if (programminglanguage == null) throw new BusinessException("Programming language to be updated does not exist.");
        }


        public void ProgrammingLanguageToBeDeletedShouldExist(ProgrammingLanguage programminglanguage)
        {
            if (programminglanguage == null) throw new BusinessException("Programming language to be deleted does not exist.");
        }

    }
}
