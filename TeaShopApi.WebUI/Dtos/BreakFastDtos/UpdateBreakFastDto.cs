namespace TeaShopApi.WebUI.Dtos.BreakFastDtos
{
    public class UpdateBreakFastDto
    {
        public int BreakFastID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
