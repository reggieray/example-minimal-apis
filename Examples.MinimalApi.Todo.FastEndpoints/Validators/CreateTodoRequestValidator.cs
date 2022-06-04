using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace Examples.MinimalApi.Todo.FastEndpoints.Validators
{
    public class CreateTodoRequestValidator : Validator<CreateTodoRequest>
    {
        public CreateTodoRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
