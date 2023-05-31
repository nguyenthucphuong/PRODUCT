using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Models
{
    public class Handle
    {
        private static List<Handle> handleList = new List<Handle>();
        public string TenSanPham { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TamTinh { get; set; }

        public Handle(string sanpham, decimal soluong, decimal dongia, decimal giamgia)
        {
            this.TenSanPham = sanpham;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.GiamGia = giamgia;
            this.TamTinh = soluong * dongia;
        }
        public static List<Handle> GetHandleList() => handleList;
        public void AddHandle(string sanpham, decimal soluong, decimal dongia, decimal giamgia)
        {
            Handle handle = new Handle(sanpham, soluong, dongia, giamgia);
            handleList.Add(handle);
        }
        public static decimal tongTamTinh => handleList.Sum(h => h.TamTinh);
        public decimal tinhGiamGia() => TamTinh * GiamGia / 100;
        public static decimal tongGiamGia() => handleList.Sum(h => h.tinhGiamGia());
        public static decimal tongCong() => tongTamTinh - tongGiamGia();
        public void Thanhtoan() => handleList?.Clear();
        public static void DeleteHandle(int id) => handleList?.RemoveAt(id);
    }
}
