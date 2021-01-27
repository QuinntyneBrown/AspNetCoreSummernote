using AspNetCoreSummernote.Api.Data;
using AspNetCoreSummernote.Api.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace AspNetCoreSummernote.Api.Features
{
    public class GetNoteById
    {
        public class Request : IRequest<Response> {  
            public Guid NoteId { get; set; }        
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

                var note = await _context.Notes.FindAsync(request.NoteId);

                return new Response() { 
                    Note = note.ToDto()
                };
            }
        }
    }
}
