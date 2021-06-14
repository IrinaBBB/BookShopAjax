using BookShop.Shared.Interfaces;

namespace BookShop.Shared.BooksDto
{
    public class CollectionItem : ICollectionItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
