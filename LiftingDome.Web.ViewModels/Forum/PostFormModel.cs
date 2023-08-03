namespace LiftingDome.Web.ViewModels.Forum
{
	using LiftingDome.Web.ViewModels.ForumCategories;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Post;

	public class PostFormModel
	{
		public PostFormModel()
		{
			this.Categories = new HashSet<ForumCategorySelectFormModel>();
			this.EditedOn = DateTime.Now;
		}
        [Required]
        [MaxLength(TextMaxLength)]
		[Display(Name = "Text")]
        public string Text { get; set; } = null!;
        [Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
        public IEnumerable<ForumCategorySelectFormModel> Categories { get; set; }
		public string? TaggedUser { get; set; }
		public DateTime EditedOn { get; set; }
    }
}
