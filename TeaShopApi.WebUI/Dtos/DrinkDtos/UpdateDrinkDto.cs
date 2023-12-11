namespace TeaShopApi.WebUI.Dtos.DrinkDtos
{
    public class UpdateDrinkDto
    {
        public int DrinksID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
