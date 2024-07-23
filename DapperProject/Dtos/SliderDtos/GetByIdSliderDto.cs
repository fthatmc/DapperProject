namespace DapperProject.Dtos.SliderDtos
{
	public class GetByIdSliderDto
	{
		public int SliderId { get; set; }
		public string ImageURL { get; set; }
		public string Address { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
