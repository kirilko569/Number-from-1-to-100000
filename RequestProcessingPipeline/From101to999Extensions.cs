namespace RequestProcessingPipeline
{
    public static class From101to999Extensions
    {
        public static IApplicationBuilder UseFrom101to999(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<From101to999Middleware>();
        }
    }
}
