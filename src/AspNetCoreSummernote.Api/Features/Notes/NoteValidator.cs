using FluentValidation;

namespace AspNetCoreSummernote.Api.Features
{
    public class NoteValidator : AbstractValidator<NoteDto>
    {
        public NoteValidator()
        {
            
        }
    }
}
