using FinallyProject.Controllers;
using FinallyProject.Products;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinallyProject.Web.Models.Product;
using FinallyProject.Products.Dto;

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
            var model = new IndexViewModel(products);
            return View(model);
        }

        // GET: Tạo sản phẩm mới
        public async Task<ActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Items;
            return View();
        }

        // POST: Tạo sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateAsync(input);
                return RedirectToAction("Index");
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Items;
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
                CategoryId = product.CategoryId
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