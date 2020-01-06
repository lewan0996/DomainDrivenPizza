using MediatR;

namespace Menu.Application.ProductApplications.DeleteProductApplication
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
