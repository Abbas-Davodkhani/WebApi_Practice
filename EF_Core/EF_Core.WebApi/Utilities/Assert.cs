namespace EF_Core.WebApi.Utilities
{
    public class Assert
    {
        public static void NotNull<T>(T obj, string name, string message = null)
            where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), message);
        }
    }
}
