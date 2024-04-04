using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookieMonster.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Counter to store number of cookies eaten
        public int counter { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Get the existing cookie value
            string? cookieValue = Request.Cookies["MyCookie"];

            // Cookie does not exist
            if (cookieValue ==  null)
            {
                // Create cookie and set its initial value to 0
                createCookie(0);
            }
            else
            {
                // Get cookie value and plug into counter               
                counter = Convert.ToInt32(cookieValue);
            }
        }

        public void OnPost()
        {
            // Get the existing cookie value
            string? cookieValue = Request.Cookies["MyCookie"];

            if(cookieValue !=  null)
            {
                // Get existing count from cookie
                counter = Convert.ToInt32(cookieValue);
                
                // Increment by 1
                counter++;

                // Update cookie
                createCookie(counter);
            }
        }

        // A helper function to create a cookie and set its value to count
        private void createCookie(int count)
        {
            Response.Cookies.Append("MyCookie", count.ToString(), new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            });
        }
    }
}
