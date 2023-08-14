using Microsoft.AspNetCore.Mvc;

namespace dgPad.Components
{
        [ViewComponent]
        public class PageSize : ViewComponent
        {
                public async Task<IViewComponentResult> InvokeAsync()
                {
                        HttpClient client = new();
                        HttpResponseMessage response = await client.GetAsync("http://google.com");

                        return View((long)response.Content.Headers.ContentLength);
                }
        }
}
