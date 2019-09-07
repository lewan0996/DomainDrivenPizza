using MediatR;

namespace Application.Menu.Commands.IngredientCommands
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
