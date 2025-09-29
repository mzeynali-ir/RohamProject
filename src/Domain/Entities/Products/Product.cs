using Domain.Entities.Common;

namespace Domain.Entities.Products
{
    public class Product : NormalEntity<int>
    {
        public string Title { get; set; } = null!;

        public int? ParentId { get; private set; }
        public Product? Parent { get; private set; }
        public string? ParentPath { get; private set; }

        public const int MaxHirarechyDepth = 4;
        public const char HirarechySepratorCharacter = '/';

        public int GetHirarechyDepth() => this.ParentPath?.Split(Product.HirarechySepratorCharacter).Length ?? 0;

        public bool HasChild() => this.GetHirarechyDepth() > 1;

        public bool CanAddChild() => this.GetHirarechyDepth() >= Product.MaxHirarechyDepth;

        public void SetParent(Product parent)
        {
            if (parent.CanAddChild() is false)
            {
                throw new ProductParentOverFlowException();
            }

            this.Parent = parent;
            this.ParentId = parent.Id;
            this.ParentPath=parent.ParentPath+Product.HirarechySepratorCharacter+this.Id;
        }

        public void ResetParentPath()
        {
            this.ParentPath=this.Id.ToString();
        }

    }
}
