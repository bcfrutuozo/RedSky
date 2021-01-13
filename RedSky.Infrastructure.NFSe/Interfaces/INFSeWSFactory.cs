using RedSky.Domain.Entities;

namespace RedSky.Infrastructure.NFSe.Interfaces
{
    public interface INFSeWSFactory
    {
        INFSeWS GetWS(Filial filial);
    }
}