using DevBlog.Web.Data;
using DevBlog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly DevBlogDbContext devBlogDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(DevBlogDbContext devBlogDbContext)
        {
            this.devBlogDbContext = devBlogDbContext;
        }
        public async Task OnGet(Guid Id)
        {
            BlogPost = await devBlogDbContext.BlogPosts.FindAsync(Id);
        }
        
        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await devBlogDbContext.BlogPosts.FindAsync(BlogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }
            await devBlogDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlogPost = await devBlogDbContext.BlogPosts.FindAsync(BlogPost.Id);
            if (existingBlogPost != null)
            {
                devBlogDbContext.BlogPosts.Remove(existingBlogPost);
                await devBlogDbContext.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
