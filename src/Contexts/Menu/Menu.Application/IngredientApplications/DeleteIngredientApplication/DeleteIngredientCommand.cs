using MediatR;

namespace Menu.Application.IngredientApplications.DeleteIngredientApplication
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
