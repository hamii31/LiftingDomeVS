namespace LiftingDome.Web.ViewModels.Forum
{
	using LiftingDome.Web.ViewModels.ForumCategories;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.ForumPost;

	public class PostFormModel
	{
		public PostFormModel()
		{
			this.Categories = new HashSet<ForumCategorySelectFormModel>();
		}
        [Required]
        [MaxLength(TextMaxLength)]
		[Display(Name = "Text")]
        public string Text { get; set; } = null!;
        [Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
        public IEnumerable<ForumCategorySelectFormModel> Categories { get; set; }
    }
}
