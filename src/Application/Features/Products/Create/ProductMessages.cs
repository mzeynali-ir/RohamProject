using Domain.Entities;

namespace Application.Features.Products
{
    public class ProductMessages
    {
        public static string NameIsDuplicate => "نام محصول تکراری است";
        public static string NotFound => "محصول پیدا نشد";
        public static string ParentNotFound => "محصول سرگروه پیدا نشد";
        public static string ErrorInAdd => "محصول اضافه نشد";
        public static string ErrorInUpdate => "محصول ویرایش نشد";
        public static string ParentDepthOwerFlow => $"تعداد سرگروه های محصول نمیتواند بیشتر از {Product.MaxParentDepth} عدد باشد";
    }

}
