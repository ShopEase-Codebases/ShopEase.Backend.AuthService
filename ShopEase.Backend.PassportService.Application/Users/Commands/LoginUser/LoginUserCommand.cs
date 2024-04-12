﻿using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Application.Shared.Models;

namespace ShopEase.Backend.PassportService.Application
{
    public sealed record LoginUserCommand(
        string Email,
        string Password
    ) : ICommand<AuthenticationResult>
    {
    }
}