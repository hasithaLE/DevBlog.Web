using DevBlog.Web.Data;
using DevBlog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DevBlogDbContext devBlogDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        [BindProperty]
        public List<BlogPost> BlogPosts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DevBlogDbContext devBlogDbContext)
        {
            _logger = logger;
            this.devBlogDbContext = devBlogDbContext;
        }

        public void OnGet()
        {
            BlogPost = devBlogDbContext.BlogPosts.OrderByDescending(r => r.PublishedDate).FirstOrDefault();

            BlogPosts = devBlogDbContext.BlogPosts.ToList();
        }
    }
}
