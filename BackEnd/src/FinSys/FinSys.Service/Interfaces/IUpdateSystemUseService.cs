using FinSys.Service.Domain;

namespace FinSys.Service.Interfaces
{
    public interface IUpdateSystemUseService
    {
        Task<SystemUserDTO> UpdateSystemUser(SystemUserDTO expending);
    }
}
