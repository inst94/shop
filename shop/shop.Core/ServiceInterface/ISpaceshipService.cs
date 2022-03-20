using shop.Core.Domain;
using shop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface ISpaceshipService : IApplicationService
    {
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> GetAsync(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
    }
}
