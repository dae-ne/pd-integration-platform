﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using PD.INT001.Application.Commands;

namespace PD.INT001.Function.Functions;

public sealed class GoogleTokenRefresh
{
    private readonly IMediator _mediator;
    
    public GoogleTokenRefresh(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    //[FunctionName("google-token-refresh")]
    public async Task RunAsync(
        [TimerTrigger("0 */5 * * * *", RunOnStartup = true)]
        TimerInfo myTimer,
        ILogger log,
        CancellationToken cancellationToken)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
        await _mediator.Send(new RefreshGoogleTokenCommand(), cancellationToken);
    }
}