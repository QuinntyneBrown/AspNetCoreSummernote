using AspNetCoreSummernote.Api.Data;
using AspNetCoreSummernote.Api.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSummernote.Api.Features
{
    public class GetNotes
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<NoteDto> Notes { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAspNetCoreSummernoteDbContext _context;

            public Handler(IAspNetCoreSummernoteDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Notes = _context.Notes.Select(x => x.ToDto()).ToList()
                };
            }
        }
    }
}
