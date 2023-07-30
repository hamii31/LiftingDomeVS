namespace LiftingDome.Web.ViewModels.Forum
{
	using LiftingDome.Web.ViewModels.ForumCategories;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.ForumPost;

	public class MessageFormModel
	{
		public MessageFormModel()
		{
			this.Categories = new HashSet<ForumCategorySelectFormModel>();
		}
        [Required]
        [MaxLength(TextMaxLength)]
		[Display(Name = "Text")]
        public string MessageText { get; set; } = null!;
        [Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
        public IEnumerable<ForumCategorySelectFormModel> Categories { get; set; }
    }
}
