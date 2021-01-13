using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Application.Processing.Interfaces
{
    public interface IReportGenerator
    {
        Fatura Execute(Fatura entity);
    }
}
