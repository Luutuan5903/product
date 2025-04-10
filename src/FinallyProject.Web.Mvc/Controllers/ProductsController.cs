using FinallyProject.Controllers;
using FinallyProject.Products;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinallyProject.Web.Models.Product;
using FinallyProject.Products.Dto;
using System.Linq;

namespace FinallyProject.Web.Controllers
{
    public class ProductsController : FinallyProjectControllerBase
    {
        private readonly IProductAppService _productService;
        private readonly ICategoryAppService _categoryService;

        public ProductsController(
            IProductAppService productService,
            ICategoryAppService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // Danh sách sản phẩm

        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();

            var model = new IndexViewModel
            {
                Products = products.Items.ToList(), // Nếu products là PagedResultDto<ProductDto>
                Categories = categories.Items.ToList()
            };

            return View(model);
        }


        // GET: Tạo sản phẩm mới
        public async Task<ActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();

            var model = new ProductCreateViewModel
            {
                Categories = categories.Items.ToList()
            };

            return View(model);
        }


        // POST: Tạo sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                var productDto = new CreateUpdateDto
                {
                    Name = input.ProductName,
                    Price = input.Price,
                    Image = input.ProductImage,
                    CategoryId = input.CategoryId
                };

                await _productService.CreateAsync(productDto);
                return RedirectToAction("Index");
            }

            var categories = await _categoryService.GetAllAsync();
            input.Categories = categories.Items.ToList();

            return View(input);
        }


        // GET: Chỉnh sửa sản phẩm
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetAsync(id);
            var updateDto = new CreateUpdateDto
            {
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                
            };

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Items;
            ViewBag.ProductId = product.Id;

            return View(updateDto);
        }

        // POST: Cập nhật sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(id, input);
                return RedirectToAction("Index");
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Items;
            ViewBag.ProductId = id;

            return View(input);
        }

        // Xoá sản phẩm
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}