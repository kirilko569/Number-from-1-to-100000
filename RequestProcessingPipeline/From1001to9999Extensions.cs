namespace RequestProcessingPipeline
{
    public static class From1001to9999Extensions
    {
        public static IApplicationBuilder UseFrom1000to9999(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<From1001to9999Middleware>();
        }
    }
}
