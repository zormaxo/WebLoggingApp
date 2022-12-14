using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebLogging.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly ILogger _logger;

        //// Standard way of capturing the category
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IndexModel(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory");
        }

        public void OnGet()
        {
            ////The Logging Levels
            //_logger.LogTrace("This is a trace log");
            //_logger.LogDebug("This is a debug log");
            //_logger.LogInformation("This is an information log");
            //_logger.LogWarning("This is a warning log");
            //_logger.LogError("This is an  error log");
            //_logger.LogCritical("This is a critical log");
            //_logger.LogInformation(LoggingId.DemoCode, "This is our first logged message.");


            //// Advanced logging messages
            //_logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);

            _logger.LogInformation("You requested the Index page.  ");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 6)
                    {
                        throw new Exception("You forgot to catch me");
                    }
                    else
                    {
                        _logger.LogInformation("The value of i is {iVar}", i);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.UtcNow);
            }

            ////-----Serilog-----

            //_logger.LogInformation("You requested the Index page.  ");
        }
    }

    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}