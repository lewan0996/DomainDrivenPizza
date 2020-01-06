using MediatR;

namespace Menu.Application.PizzaApplications.DeletePizzaApplication
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
