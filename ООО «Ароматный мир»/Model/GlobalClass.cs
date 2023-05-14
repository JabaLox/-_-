using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООО__Ароматный_мир_.Model
{
    public class GlobalClass
    {
        public static string? Name { get; set; }
        public static string? SurName { get; set; }
        public static string? Patronomyc { get; set; }
        public static int? RoleId { get; set; }
    }

    public partial class Product
    {
        public string image { get { return ProductPhoto != "" ? $@"\Resorces\ImageProduct\{ProductPhoto}" : null; } }

        public decimal? NewCost
        {
            get
            {
                if (ProductDiscountAmount != null)
                    return Math.Round(Convert.ToDecimal(ProductCost - (ProductCost * ProductDiscountAmount / 100)),2);
                else return null;
            }
        }

        public decimal? Discount
        {
            get
            {
                if (ProductDiscountAmount != null)
                    return Math.Round(Convert.ToDecimal(ProductCost * ProductDiscountAmount / 100),2);
                else return null;
            }
        }

        public string? decor
        {
            get
            {
                if (ProductDiscountAmount != null)
                    return "Strikethrough";
                else return null;
            }
        }

        public string? color
        {
            get
            {
                if (ProductDiscountAmount != null)
                    return "#7fff00";
                else return null;
            }
        }
    }
}
