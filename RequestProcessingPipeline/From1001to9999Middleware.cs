namespace RequestProcessingPipeline
{
    public class From1001to9999Middleware
    {

        private readonly RequestDelegate _next;

        public From1001to9999Middleware(RequestDelegate next)
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
                if (number == 10000)
                {
                    await context.Response.WriteAsync("Your number is ten thousand");
                }
                else
                {
                    if (number > 1000 && number < 9999)
                    {
                        string? result = string.Empty;
                        result = context.Session.GetString("number");
                        number %= 10000;
                        number /= 1000;
                        string[] Numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                        if (number > 0)
                        {
                            context.Session.SetString("number", result + ' ' + Numbers[number - 1] + " thousand");
                            await _next.Invoke(context);
                        }
                        else
                            await _next.Invoke(context);
                    }
                    else
                    {
                        await _next.Invoke(context);
                    }
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter 3");
            }
        }
    }
}


