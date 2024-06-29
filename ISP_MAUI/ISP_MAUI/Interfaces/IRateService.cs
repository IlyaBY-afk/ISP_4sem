namespace ISP_MAUI.Interfaces;

using Entities;

public interface IRateService
{
    Task<IEnumerable<Rate>> GetRates(DateTime date);
}