namespace DapperProject.Dtos.AdDtos
{
	public class ResultLast4AdsDto
	{
		public int AdId { get; set; }
		public string AdTitle { get; set; }
		public string Desciption { get; set; }
		public decimal Price { get; set; }
		public int SquareMeter { get; set; }
		public int BedRooms { get; set; }
		public int BathRooms { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int AdStiuationId { get; set; }
		public string AdStiuation { get; set; }
		public string ImageURL { get; set; }
		public int LocationId { get; set; }
		public string Location { get; set; }
	}
}
