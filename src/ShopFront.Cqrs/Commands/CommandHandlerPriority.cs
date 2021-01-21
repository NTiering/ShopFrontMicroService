namespace ShopFront.Cqrs.Commands
{
    public enum CommandHandlerPriority
    {
        VaryLow = -2,
        Low = -1,
        Normal = 0,
        High = 1,
        VeryHigh = 2,
    }
}