namespace RequestProcessingPipeline
{
    public class From10001to19999Middleware
    {
        private readonly RequestDelegate _next;

        public From10001to19999Middleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
                int number = Convert.ToInt32(token);
                string? result = string.Empty;
                number = Math.Abs(number);
                number %= 100000;
                if (number < 10001 || number > 19999)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    
                    number /= 1000;
                    string[] Numbers = { "ten","eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                    context.Session.SetString("number", result+" "+ Numbers[number - 10] + " thousand");
                    await _next.Invoke(context);
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter 2");
            }
        }
    }
}
