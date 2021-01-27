using AspNetCoreSummernote.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCoreSummernote.Api.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator) => _mediator = mediator;


        [HttpPost(Name = "CreateNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateNote.Response>> Create([FromBody]CreateNote.Request request)
            => await _mediator.Send(request);


        [HttpPut(Name = "UpdateNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateNote.Response>> Update([FromBody]UpdateNote.Request request)
            => await _mediator.Send(request);


        [HttpDelete("{noteId}", Name = "RemoveNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveNote.Request request)
            => await _mediator.Send(request);


        [HttpGet("{noteId}", Name = "GetNoteByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetNoteById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetNoteById.Response>> GetById([FromRoute]GetNoteById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Note == null)
            {
                return new NotFoundObjectResult(request.NoteId);
            }

            return response;
        }


        [HttpGet(Name = "GetNotesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetNotes.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetNotes.Response>> Get()
            => await _mediator.Send(new GetNotes.Request());           
    }
}
