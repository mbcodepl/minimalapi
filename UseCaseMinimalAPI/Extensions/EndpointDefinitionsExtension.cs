using UseCaseMinimalAPI.Interfaces;

namespace UseCaseMinimalAPI.Extensions;

public static class EndpointDefinitionsExtension
{
    public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] scanMarkers)
    {
        List<IEndpointDefinition> endpointDefinitions = new();
        foreach (var marker in scanMarkers)
        {
            endpointDefinitions.AddRange(
                    marker.Assembly.ExportedTypes
                        .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && x is {IsInterface: false, IsAbstract: false})
                        .Select(Activator.CreateInstance)
                        .Cast<IEndpointDefinition>()
                );
        }

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineServices(services);
        }
        
        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }
    
    public static void UseEndpointDefinitions(this WebApplication app)
    {
        IReadOnlyCollection<IEndpointDefinition> endpointDefinitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineEndpoints(app);
        }
    }
}