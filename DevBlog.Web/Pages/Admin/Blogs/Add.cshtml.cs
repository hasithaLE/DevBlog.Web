using DevBlog.Web.Data;
using DevBlog.Web.Models.Domain;
using DevBlog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevBlog.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly DevBlogDbContext devBlogDbContext;

        [BindProperty]
        public AddBlog AddBlogPostRequest { get; set; }
        public AddModel(DevBlogDbContext devBlogDbContext)
        {
            this.devBlogDbContext = devBlogDbContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var blogPost = new BlogPost
            {
                Heading = AddBlogPostRequest.Heading ?? "",
                PageTitle = AddBlogPostRequest.PageTitle ?? "",
                Content = AddBlogPostRequest.Content ?? "",
                ShortDescription = AddBlogPostRequest.ShortDescription ?? "",
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl ?? "",
                UrlHandle = AddBlogPostRequest.UrlHandle ?? "",
                PublishedDate = DateTime.Now,
                Author = AddBlogPostRequest.Author ?? "",
                Visible = AddBlogPostRequest.Visible
            };
            await devBlogDbContext.AddAsync(blogPost);
            await devBlogDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
