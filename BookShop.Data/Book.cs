﻿namespace BookShop.Data
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int YearPublished { get; set; }
        public int AuthorId { get; set; }
        public bool IsCheckeddOut { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
