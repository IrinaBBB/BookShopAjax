﻿using System.Collections.Generic;

namespace BookShop.Data.Entities
{
    public partial class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
