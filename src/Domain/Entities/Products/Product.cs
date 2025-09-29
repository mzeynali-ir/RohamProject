using Domain.Entities.Common;

namespace Domain.Entities.Products
{
    public class Product : NormalEntity<int>
    {
        public string Title { get; set; } = null!;

        public int? ParentId { get; private set; }
        public Product? Parent { get; private set; }
        public string? ParentPath { get; private set; }

        public const int MaxHierarchyDepth = 4;
        public const char HierarchySeparatorCharacter = '/';

        public int GetHierarchyDepth() => this.ParentPath?.Split(Product.HierarchySeparatorCharacter).Length ?? 0;

        public bool HasChild() => this.GetHierarchyDepth() > 1;

        public bool CanAddChild() => this.GetHierarchyDepth() >= Product.MaxHierarchyDepth;

        public void SetParent(Product parent)
        {
            if (parent.CanAddChild() is false)
            {
                throw new ProductParentOverFlowException();
            }

            this.Parent = parent;
            this.ParentId = parent.Id;
            this.ParentPath=parent.ParentPath+Product.HierarchySeparatorCharacter + this.Id;
        }

        public void ResetParentPath()
        {
            this.ParentPath=this.Id.ToString();
        }

    }
}
