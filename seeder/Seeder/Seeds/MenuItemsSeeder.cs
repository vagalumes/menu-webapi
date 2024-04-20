using System.Data.SqlClient;
using Bogus;
using Dapper;

namespace Seeder.Seeds;

public class MenuItemsSeeder(SqlConnection connection, Faker faker)
{
    public async Task InsertMenuItem(Guid restaurantId)
    {
        var menuItemId = await connection.QuerySingleAsync<Guid>(SqlConstants.InsertMenuItem, new
        {
            Id = Guid.NewGuid(),
            Name = faker.Commerce.Product(),
            Description = faker.Lorem.Random.Words(5),
            Price = float.Parse(faker.Commerce.Price()),
            RestaurantId = restaurantId
        });

        for (var i = 0; i < 3; i++)
        {
            await InsertMenuItemImages(menuItemId);
        }
    }

    private async Task InsertMenuItemImages(Guid menuItemId)
    {
        await connection.ExecuteAsync(SqlConstants.InsertMenuItemImages, new
        {
            Id = Guid.NewGuid(),
            MenuItemId = menuItemId,
            Name = faker.Commerce.Product(),
            Path = faker.Image.LoremFlickrUrl(800, 800, "food"),
            Extension = ".png"
        });
    }
}