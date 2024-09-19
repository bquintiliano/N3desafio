namespace N3desafio.Communication.Responses
{
    public class ResponseCreateBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
    }
}
