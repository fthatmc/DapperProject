namespace DapperProject.Dtos.AdDtos
{
	public class ResultResentAdPostDto
	{
		public int AdId { get; set; }
		public string AdTitle { get; set; }
		public string ImageURL { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int AdStiuationId { get; set; }
		public string AdStiuation { get; set; }
		public decimal Price { get; set; }
	}
}
