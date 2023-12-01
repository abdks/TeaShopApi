namespace TeaShopApi.WebUI.Dtos.DrinkDtos
{
	public class ResultDrinkDto
	{
		//Eğer veri türlerini bilmiyorsan apiden get fonksiyonu ile verileri kopyala gelen verileri özel yapıştır yap en üstte edit kısmından 
		public int DrinkID { get; set; }
		public string drinkName { get; set; }
		public decimal drinkPrice { get; set; }
		public string drinkImageUrl { get; set; }
	}
}
