using DevBlog.Web.Data;
using DevBlog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevBlog.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly DevBlogDbContext devBlogDbContext;
        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(DevBlogDbContext devBlogDbContext)
        {
            this.devBlogDbContext = devBlogDbContext;
        }
        public async Task OnGet()
        {
            BlogPosts = await devBlogDbContext.BlogPosts.ToListAsync();
        }
    }
}
