namespace CarService.Core.BusinessLogicLayer
{
    /// <summary>
    /// All possible statuses of one order
    /// </summary>
    public enum OrderCurrentStatus
    {
        Draft, // initial, once order is created
        New, // when user has added something into order
        Completed // When order has been paid
    }
}