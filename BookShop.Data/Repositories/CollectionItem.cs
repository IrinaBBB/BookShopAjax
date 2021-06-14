using BookShop.Shared.Interfaces;

namespace BookShop.Data.Repositories
{
    public class CollectionItem : ICollectionItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
