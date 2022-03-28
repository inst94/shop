using shop.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using shop.Core.Dtos;
using Xunit;
using shop.SpaceshipTest;

namespace shop.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task Should_AddNewSpaceship_WhenReturnResult()
        {
            string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            SpaceshipDto spaceship = new SpaceshipDto();
            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Space";
            spaceship.Type = "Estonia";
            spaceship.Prise = 123;
            spaceship.Crew = 123;
            spaceship.Mass = 123;
            spaceship.Constructed = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipService>().Add(spaceship);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Check_Guid_IsNotInt()
        {
            string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
            var insertGuid = Guid.Parse(guid);
            await Svc<ISpaceshipService>().GetAsync(insertGuid);

            Assert.False(insertGuid.GetType() == typeof(int));
        }

        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<ISpaceshipService>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        }
        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<ISpaceshipService>().GetAsync(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);

            var result = await Svc<ISpaceshipService>().Delete(insertGuid);

            Assert.NotEmpty((System.Collections.IEnumerable)result);
            Assert.Single((System.Collections.IEnumerable)result);
        }
        [Fact]
        public async Task Should_UpdateByIdSpaceship_WhenUpdateSpaceship()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Space";
            spaceship.Type = "Estonia";
            spaceship.Prise = 123;
            spaceship.Crew = 123;
            spaceship.Mass = 123;
            spaceship.Constructed = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await Svc<ISpaceshipService>().Update(spaceship);

            Assert.NotEmpty((System.Collections.IEnumerable)spaceship);
        }
    }
}
