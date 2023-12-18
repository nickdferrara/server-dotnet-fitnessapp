namespace server_dotnet_fitnessapp.Extensions;

public static class ObjectExtensions
{
    public static T Also<T>(this T self, Action<T> block)
    {
        block(self);
        return self;
    }     
}