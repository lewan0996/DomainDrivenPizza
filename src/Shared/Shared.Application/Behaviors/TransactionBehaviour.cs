using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Application.Extensions;
using Shared.Domain;

namespace Shared.Application.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;

        private readonly IUnitOfWork _unitOfWork;
        //private readonly IIntegrationEventService _integrationEventService;

        public TransactionBehaviour(IUnitOfWork unitOfWork,
            /*IIntegrationEventService orderingIntegrationEventService,*/
            ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(IUnitOfWork));
            /*_integrationEventService = integrationEventService ?? throw new ArgumentException(nameof(integrationEventService));*/
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();

            try
            {
                if (_unitOfWork.HasActiveTransaction)
                {
                    return await next();
                }

                TResponse response;
                using (var transaction = await _unitOfWork.BeginTransactionAsync())
                {
                    _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.Id, typeName, request);

                    response = await next();

                    _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.Id, typeName);
                    //await _integrationEventService.PublishEventsAsync();
                    await _unitOfWork.SaveEntitiesAsync();
                    await _unitOfWork.CommitTransactionAsync(transaction);
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

                throw;
            }
        }
    }
}
