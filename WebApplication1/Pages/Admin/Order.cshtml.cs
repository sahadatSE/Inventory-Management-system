using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class SelectedProduct
    {
        public int PId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderPageModel(OrderService orderService, ProductService productService) : PageModel
    {
        private readonly OrderService _orderService = orderService;
        private readonly ProductService _productService = productService;

        [BindProperty]
        public Order OrderData { get; set; } = new();

        [BindProperty]
        public List<SelectedProduct> SelectedProducts { get; set; } = [];

        public List<Product> Products { get; set; } = [];

        public void OnGet()
        {
            Result result = _orderService.GetAvailableProducts();
            Products = result.Data as List<Product> ?? [];
        }

        public IActionResult OnPost()
        {
            ModelState.Clear();

            Result productResult = _orderService.GetAvailableProducts();
            Products = productResult.Data as List<Product> ?? [];

            if (SelectedProducts.Count == 0)
            {
                ModelState.AddModelError("", "??????? ???? product select ????");
                return Page();
            }

            // OrderDetails ????
            var details = SelectedProducts.Select(sp => new OrderDetails
            {
                PId = sp.PId,
                Quantity = sp.Quantity,
                UnitPrice = 0 // Stock ???? price ???? ????? ??? ??? ????
            }).ToList();

            Result result = _orderService.AddOrder(OrderData, details);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Admin/OrderList");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();
            }
        }
    }
}