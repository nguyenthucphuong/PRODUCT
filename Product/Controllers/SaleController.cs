using Microsoft.AspNetCore.Mvc;
using Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.Controllers
{
    public class SaleController : Controller
    {
        private static List<Handle> handleList = new List<Handle>();
        public IActionResult Index()
        {
            if (handleList != null)
            {
                foreach (var handle in handleList)
                {
                    decimal tienTamTinh = handle.SoLuong * handle.DonGia;
                    ViewData["TienTamTinh_" + handle.STT] = tienTamTinh;
                }
                decimal tongTien = handleList.Sum(h => h.SoLuong * h.DonGia);
                ViewData["TongTien"] = tongTien.ToString("N0");
            }
            else
            {
                ViewData["TongTien"] = "0";
            }
            return View(handleList);
        }

        [HttpPost]
        public ActionResult AddToCart(string sanPham, int soLuong, decimal donGia)
        {
            var handle = new Handle
            {
                STT = handleList.Count + 1,
                TenSanPham = sanPham,
                SoLuong = soLuong,
                DonGia = donGia
            };
            handleList.Add(handle);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ThanhToan()
        {
            if (handleList != null)
                handleList.Clear();
            ViewData["TongTien"] = "0";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAction(int id)
        {
            var handle = handleList.FirstOrDefault(h => h.STT == id);
            if (handle != null)
            {
                handleList.Remove(handle);
            }

            for (int i = 0; i < handleList.Count; i++)
            {
                handleList[i].STT = i + 1;
            }
            return RedirectToAction("Index");
        }
    }
}
