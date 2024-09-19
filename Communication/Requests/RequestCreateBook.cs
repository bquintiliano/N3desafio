namespace N3desafio.Communication.Requests
{
    public class RequestCreateBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
    }
}
