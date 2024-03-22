﻿namespace ShopEase.Backend.PassportService.Persistence.Models.Outbox
{
    /// <summary>
    /// Anemic Model Class for the OutboxMessages
    /// </summary>
    public sealed class OutboxMessage
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime OccurredOnUtc { get; set; }

        public DateTime? ProcessedOnUtc { get; set; }

        public string? Error { get; set; }
    }
}