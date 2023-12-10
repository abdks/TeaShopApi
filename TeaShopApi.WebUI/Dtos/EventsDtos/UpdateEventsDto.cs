namespace TeaShopApi.WebUI.Dtos.EventsDtos
{
    public class UpdateEventsDto
    {
        public int EventsID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
