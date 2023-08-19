namespace RequestProcessingPipeline
{
    public static class From10001to19999Extensions
    {
        public static IApplicationBuilder UseFrom10001to19999(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<From10001to19999Middleware>();
        }
    }
}
