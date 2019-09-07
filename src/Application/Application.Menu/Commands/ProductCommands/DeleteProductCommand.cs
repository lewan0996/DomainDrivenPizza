using MediatR;

namespace Application.Menu.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
