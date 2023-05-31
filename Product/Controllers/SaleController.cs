using Microsoft.AspNetCore.Mvc;
using Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            List<Handle> handleList = Handle.GetHandleList();
            return View(handleList);
        }

        [HttpPost]
        public ActionResult AddToCart(
            string sanpham,
            decimal soluong,
            decimal dongia,
            decimal giamgia
        )
        {
            Handle handle = new Handle(sanpham, soluong, dongia, giamgia);
            handle.AddHandle(sanpham, soluong, dongia, giamgia);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ThanhToan(
            string sanpham,
            decimal soluong,
            decimal dongia,
            decimal giamgia
        )
        {
            Handle handle = new Handle(sanpham, soluong, dongia, giamgia);
            handle.Thanhtoan();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAction(int id)
        {
            Handle.DeleteHandle(id);
            return RedirectToAction("Index");
        }
    }
}

