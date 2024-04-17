using System.Data.SqlClient;
using Bogus;
using Bogus.Extensions.Brazil;
using Dapper;
using Seeder;
using Seeder.Seeds;

const string connectionString = "Server=localhost,1433;Database=menu;User Id=SA;Password=Amister@4879;";

await using var connection = new SqlConnection(connectionString);

var faker = new Faker("pt_BR");

var restaurantSeeder = new RestaurantSeeder(connection, faker);

for (var i = 0; i < 10; i++)
{
    await restaurantSeeder.InsertRestaurant();
}
