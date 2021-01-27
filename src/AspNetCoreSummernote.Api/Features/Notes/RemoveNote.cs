using AspNetCoreSummernote.Api.Data;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace AspNetCoreSummernote.Api.Features
{
    public class RemoveNote
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {

            }
        }

        public class Request : IRequest<Unit> {  
            public Guid NoteId { get; set; }
        }

        public class Response
        {
            public NoteDto Note { get; set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IAspNetCoreSummernoteDbContext _context;

            public Handler(IAspNetCoreSummernoteDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {

                var note = await _context.Notes.FindAsync(request.NoteId);

                await _context.SaveChangesAsync(cancellationToken);

                return new ()
                {

                };
            }
        }
    }
}
