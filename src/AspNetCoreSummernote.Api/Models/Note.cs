using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreSummernote.Api.Models
{
    public class Note
    {
        [Key]
        public Guid NoteId { get; set; }

        public string Body { get; set; }
    }

}
