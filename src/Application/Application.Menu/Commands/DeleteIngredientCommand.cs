using MediatR;

namespace Application.Menu.Commands
{
    public class DeleteIngredientCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteIngredientCommand(int id)
        {
            Id = id;
        }
    }
}
