namespace RequestProcessingPipeline
{
    public static class From20000to99999Extensions
    {
        public static IApplicationBuilder UseFrom20000to99999(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<From20000to99999Middleware>();
        }
    }
}
