using Examples.MinimalApi.Todo.FastEndpoints.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace Examples.MinimalApi.Todo.FastEndpoints.Validators
{
    public class UpdateTodoRequestValidator : Validator<UpdateTodoRequest>
    {
        public UpdateTodoRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
