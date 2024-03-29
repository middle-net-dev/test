﻿namespace MailerRobot.Bot.Domain.Models;

public class Subscriber
{
    public string Id { get; set; }
    public InputState State { get; set; } = InputState.Idle;
    public Role Role { get; set; }
    public List<Subscription> Subscriptions { get; set; } = new();

    public SubscriberData SubscriberData { get; set; } = new();
    
    public void RemoveExpiredSubscriptions()
    {
        Subscriptions.RemoveAll(subscription => subscription.GetRemainingDays() < 0);
    }
}

public class SubscriberData
{
    public ServiceType Type { get; set; }
    public string Link { get; set; }
    public string Email { get; set; }
}

public enum ServiceType
{
    EbayDe,
    DHL,
    EbayCongrats
}