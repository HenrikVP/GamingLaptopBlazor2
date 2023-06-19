namespace MyBlazor.Data
{
    public class GamingLaptop
    {
        public GamingLaptop()
        {
        }

        public GamingLaptop(int id, string? name, string? brand, int rAM, string? gPU, string? cPU, double price, string imageUrl)
        {
            Id = id;
            Name = name;
            Brand = brand;
            RAM = rAM;
            GPU = gPU;
            CPU = cPU;
            Price = price;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int RAM { get; set; }
        public string? GPU { get; set; }
        public string? CPU { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
