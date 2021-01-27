using AspNetCoreSummernote.Api.Data;
using AspNetCoreSummernote.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace AspNetCoreSummernote.Api.Features
{
    public class UpdateNote
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Note).NotNull();
                RuleFor(request => request.Note).SetValidator(new NoteValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public NoteDto Note { get; set; }
        }

        public class Response
        {
            public NoteDto Note { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreSummernoteDbContext _context;

            public Handler(IAspNetCoreSummernoteDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var note = await _context.Notes.FindAsync(request.Note.NoteId);

                note.Body = request.Note.Body;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Note = note.ToDto()
                };
            }
        }
    }
}
