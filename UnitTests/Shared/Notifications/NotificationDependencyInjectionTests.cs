using Application.Shared.Notifications;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.Shared.Notifications;

public class NotificationDependencyInjectionTests
{
    [Fact]
    public void Should_Get_CreateRestaurantUseCase()
    {
        var services = new ServiceCollection();
        
        services.AddNotifications();

        var provider = services.BuildServiceProvider();

        var useCase = provider.GetService<Notification>();

        useCase.Should().NotBeNull();
    }
}