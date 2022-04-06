using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G7_PhongThuyWeb.Models;

namespace G7_PhongThuyWeb.Models
{
    public class CartItem
    {
        public SanPham sanpham { get; set; }
        public int qty { get; set; }
    }
}