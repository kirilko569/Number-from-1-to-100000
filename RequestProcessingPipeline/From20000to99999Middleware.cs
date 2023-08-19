namespace RequestProcessingPipeline
{
    public class From20000to99999Middleware
    {
        private readonly RequestDelegate _next;

        public From20000to99999Middleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);
                if (number < 20000)
                {
                    await _next.Invoke(context);
                }
                else if (number > 100000)
                {
                    await context.Response.WriteAsync("Number greater than one hundred thousand");
                }
                else if (number == 100000)
                {
                    await context.Response.WriteAsync("Your number is one hundred thousand");
                }
                else
                {
                    string? result = string.Empty;
                    result = context.Session.GetString("number");
                    number /= 10000;
                    string[] Numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                    context.Session.SetString("number", result+" "+ Numbers[number - 2] + " thousand");
                    await _next.Invoke(context);
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter 1");
            }
        }
    }
}
