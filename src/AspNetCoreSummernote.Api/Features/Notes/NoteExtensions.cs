

using AspNetCoreSummernote.Api.Models;

namespace AspNetCoreSummernote.Api.Features
{
    public static class NoteExtensions
    {
        public static NoteDto ToDto(this Note note)
        {
            return new NoteDto
            {
                NoteId = note.NoteId,
                Body = note.Body
            };
        }
    }
}
