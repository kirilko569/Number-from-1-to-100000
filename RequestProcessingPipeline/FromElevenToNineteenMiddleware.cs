namespace RequestProcessingPipeline
{
    public class FromElevenToNineteenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromElevenToNineteenMiddleware(RequestDelegate next)
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
                int suportnumber=number;
                number %= 100;
                if (number < 11||number>19)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    string? result = string.Empty;
                    if(suportnumber>100)
                        result = context.Session.GetString("number");
                    string[] Numbers = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                    await context.Response.WriteAsync("Your number is "+result +" " + Numbers[number - 11]);
                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter 5");
            }
        }
    }
}
