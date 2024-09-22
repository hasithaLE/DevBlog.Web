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
        public void OnGet(Guid Id)
        {
            BlogPost = devBlogDbContext.BlogPosts.Find(Id);
        }
        public IActionResult OnPost()
        {
            var existingBlogPost = devBlogDbContext.BlogPosts.Find(BlogPost.Id);
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
            devBlogDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
