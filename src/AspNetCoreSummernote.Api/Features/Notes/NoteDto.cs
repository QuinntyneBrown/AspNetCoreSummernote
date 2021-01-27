using System;

namespace AspNetCoreSummernote.Api.Features
{
    public class NoteDto
    {
        public Guid NoteId { get; set; }
        public string Body { get; set; }
    }
}
