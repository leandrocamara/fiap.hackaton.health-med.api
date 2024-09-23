using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace External.HostedServices.Consumers;

public sealed class AppointmentScheduledConsumer(
    IServiceProvider serviceProvider,
    IAmazonSQS sqsClient,
    ILogger<SqsConsumerHostedService<AppointmentScheduled>> logger)
    : SqsConsumerHostedService<AppointmentScheduled>(serviceProvider, sqsClient, logger)
{
    protected override string QueueName() => "appointment-scheduled";

    protected override Task Process(IServiceScope scope, AppointmentScheduled appointmentScheduled)
    {
        throw new NotImplementedException();
    }
}

public record AppointmentScheduled(Guid AppointmentId);