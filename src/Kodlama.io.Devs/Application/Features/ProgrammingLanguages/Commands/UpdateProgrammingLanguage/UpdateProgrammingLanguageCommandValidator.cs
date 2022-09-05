using Application.Features.ProgrammingLanguages.Dtos;
using FluentValidation;


namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdatedProgrammingLanguageDto>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(1);
        }

    }
}
