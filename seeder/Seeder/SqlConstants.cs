using System.Text;

namespace Seeder;

public static class SqlConstants
{
    public const string InsertRestaurant = """
                                           INSERT INTO Restaurants (Id, Name, Cnpj, ProfileImage)
                                           OUTPUT INSERTED.[Id]
                                           VALUES (@Id, @Name, @Cnpj, @ProfileImage);
                                           """;

    public const string InsertAddress = """
                                        INSERT INTO Address (Id, Street, Neighborhood, City, State, ZipCode, Number, RestaurantId)
                                        OUTPUT INSERTED.[Id]
                                        VALUES (@Id, @Street, @Neighborhood, @City, @State, @ZipCode, @Number, @RestaurantId);
                                        """;

    public const string InsertInformation = """
                                            INSERT INTO Information (Id, Description, RestaurantId)
                                            OUTPUT INSERTED.[Id]
                                            VALUES (@Id, @Description, @RestaurantId);
                                            """;

    public const string InsertSchedule = """
                                         INSERT INTO Schedules (Id, DayOfWeek, Start, "End", InformationId)
                                         OUTPUT INSERTED.[Id]
                                         VALUES (@Id, @DayOfWeek, @Start, @End, @InformationId);
                                         """;

    public const string InsertMenuItem = """
                                         insert into MenuItem (Id, Name, Description, Price, RestaurantId)
                                         OUTPUT INSERTED.[Id]
                                         values (@Id, @Name, @Description, @Price, @RestaurantId);
                                         """;

    public const string InsertMenuItemImages = """
                                               insert into MenuItemsImages (Id, MenuItemId, Name, Path, Extension)
                                               values (@Id, @MenuItemId, @Name, @Path, @Extension);
                                               """;
}