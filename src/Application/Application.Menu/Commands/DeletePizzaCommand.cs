using MediatR;

namespace Application.Menu.Commands
{
    public class DeletePizzaCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePizzaCommand(int id)
        {
            Id = id;
        }
    }
}
