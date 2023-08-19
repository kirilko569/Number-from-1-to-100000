namespace RequestProcessingPipeline
{
    public class From101to999Middleware
    {
        
            private readonly RequestDelegate _next;

            public From101to999Middleware(RequestDelegate next)
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
                if (number == 1000)
                {
                    await context.Response.WriteAsync("Your number is one thousen");
                }
                else if(number==100)
                    await context.Response.WriteAsync("Your number is one hundred");
                else
                {
                    string? result = string.Empty;
                    number %= 1000;
                    number /= 100;
                    result = context.Session.GetString("number");

                    string[] Numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                    if (number > 0)
                    {
                        context.Session.SetString("number",result+' ' + Numbers[number - 1]+ " hundred");
                        await _next.Invoke(context);
                    }
                    else
                        await _next.Invoke(context);
                }
            }
                catch (Exception)
                {
                    await context.Response.WriteAsync("Incorrect parameter 4");
                }
            }
    }
    

}

