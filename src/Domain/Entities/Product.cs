using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : NormalEntity<int>
    {
        public string Title { get; set; } = null!;

        public int? ParentId { get; private set; }
        public Product? Parent { get; private set; }
        public string ParentPath { get; private set; } = null!;

        public int ParentDepth => this.ParentPath.Split(Product.ParentSepratorCharacter).Length;

        public const int MaxParentDepth = 4;
        public const char ParentSepratorCharacter = '/';

        public void SetParent(Product parent)
        {
            if (parent.ParentDepth==Product.MaxParentDepth)
            {
                throw new Exception();
            }

            this.Parent = parent;
            this.ParentId = parent.Id;
            this.ParentPath=parent.ParentPath+Product.ParentSepratorCharacter+this.Id;
        }

    }
}
