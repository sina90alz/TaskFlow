using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Queries.GetAllTasks;
using TaskFlow.Application.Queries.GetTaskById;

namespace TaskFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateTaskCommand command,
            CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(new { TaskId = id });
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TaskDto>>> GetAll(
            CancellationToken cancellationToken)
        {
            var tasks = await _mediator.Send(
                new GetAllTasksQuery(),
                cancellationToken);

            return Ok(tasks);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskDto>> GetById(
            Guid id,
            CancellationToken cancellationToken)
        {
            var task = await _mediator.Send(
                new GetTaskByIdQuery(id),
                cancellationToken);

            return task is null ? NotFound() : Ok(task);
        }
    }
}
