namespace TeaShopApi.WebUI.Dtos.MainFoodDtos
{
    public class UpdateMainFoodDto
    {
        public int MainFoodID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
