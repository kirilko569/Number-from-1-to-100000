﻿namespace RequestProcessingPipeline
{
    public class FromTwentyToHundredMiddleware
    {
        private readonly RequestDelegate _next;

        public FromTwentyToHundredMiddleware(RequestDelegate next)
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
                number %= 100;
                if (number < 20)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    string? result = string.Empty;
                    result = context.Session.GetString("number");
                    number /= 10;
                    string[] Numbers = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                    context.Session.SetString("number", result + ' '+ Numbers[number - 2]);
                    await _next.Invoke(context);
                }              
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter 6");
            }
        }
    }
}
