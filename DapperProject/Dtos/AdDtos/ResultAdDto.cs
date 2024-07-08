namespace DapperProject.Dtos.AdDtos
{
	public class ResultAdDto
	{
        public int AdId { get; set; }
        public string AdTitle { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public int Garage { get; set; }
        public int BuildYear { get; set; }
        public int SquareMeter { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public int BuildAge { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public bool IsRentorSale { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int ImageId { get; set; }
        public int Image1 { get; set; }
        public int Image2 { get; set; }
        public int Image3 { get; set; }
        public int Image4 { get; set; }
        public int Image5 { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
		public int AdStiuationId { get; set; }
		public string AdStiuation { get; set; }
		public int TagId { get; set; }
		public string TagName { get; set; }
        public string ImageURL { get; set; }
    }
}
