using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;

namespace AspNetCore.Mvc;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("v{version:apiVersion}/[controller]")]
[Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Text.Plain)]
public abstract class ApiControllerBase : ControllerBase
{
    protected record struct Pagination(int PageSize);

    protected static readonly Pagination PaginationOptions = new(10);

    protected BadRequestObjectResult ValidationBadRequest(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        var problemDetails = new ValidationProblemDetails(ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Extensions =
            {
                ["traceId"] = Activity.Current?.Id
            }
        };

        return new BadRequestObjectResult(problemDetails);
    }

    protected ObjectResult BadRequest(string title, string? detail = default, IDictionary<string, object?>? extensions = default)
    {
        Activity.Current?.SetTag("http.response_problem_title", title);

        return Problem(title: title, statusCode: StatusCodes.Status400BadRequest, detail: detail, extensions: extensions);
    }
}