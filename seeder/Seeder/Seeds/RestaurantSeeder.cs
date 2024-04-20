using System.Data.SqlClient;
using Bogus;
using Bogus.Extensions.Brazil;
using Dapper;

namespace Seeder.Seeds;

public class RestaurantSeeder(SqlConnection connection, Faker faker)
{
    public async Task InsertRestaurant()
    {
        
        var restaurantId = await connection.QuerySingleAsync<Guid>(SqlConstants.InsertRestaurant,
            new
            {
                Id = Guid.NewGuid(),
                Name = faker.Company.CompanyName(),
                Cnpj = faker.Company.Cnpj(),
                ProfileImage = faker.Image.PlaceholderUrl(800, 800)
            });

        await InsertAddress(restaurantId);
        var informationId = await InsertInformation(restaurantId);
        for (var i = 0; i < 6; i++)
        {
            await InsertSchedule(informationId, i);
        }
        var menuItemsSeeder = new MenuItemsSeeder(connection: connection, faker: faker);
        for (var i = 0; i < 4; i++)
        {
            await menuItemsSeeder.InsertMenuItem(restaurantId);
        }
    }

    private async Task InsertAddress(Guid restaurantId)
    {
        await connection.QuerySingleAsync(SqlConstants.InsertAddress,
            new
            {
                Id = Guid.NewGuid(),
                Street = faker.Address.StreetName(),
                Neighborhood = faker.Address.County(),
                City = faker.Address.City(),
                State = faker.Address.State(),
                ZipCode = faker.Address.ZipCode(),
                Number = faker.Address.BuildingNumber(),
                RestaurantId = restaurantId
            });
    }

    private async Task<Guid> InsertInformation(Guid restaurantId)
    {
        var informationId = await connection.QuerySingleAsync<Guid>(SqlConstants.InsertInformation,
            new
            {
                Id = Guid.NewGuid(),
                Description = faker.Random.Words(),
                RestaurantId = restaurantId
            });

        return informationId;
    }

    private async Task InsertSchedule(Guid informationId, int day)
    {
        await connection.QuerySingleAsync(SqlConstants.InsertSchedule,
            new
            {
                Id = Guid.NewGuid(),
                DayOfWeek = day + 1,
                Start = "08:00:00",
                End = "18:00:00",
                InformationId = informationId
            });
    }
}