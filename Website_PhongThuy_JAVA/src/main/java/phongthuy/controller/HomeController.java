package phongthuy.controller;
import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;

import phongthuy.model.SanPham;
import phongthuy.service.ProductService;
import phongthuy.service.impl.ProductServiceImpl;
import javax.servlet.http.HttpServletResponse;



public class HomeController extends HttpServlet{
	private static final long serialVersionUID = 1L;
	ProductService productService = new ProductServiceImpl();
	DecimalFormat df = new DecimalFormat("#.000");
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		// Product san pham moi nhat
		List<SanPham> product_vatpham= productService.getProductById(1);
		req.setAttribute("product_vatpham", product_vatpham);	
		
		// Product phụ kiện
		List<SanPham> product_phukien= productService.getProductById(2);
		req.setAttribute("product_phukien", product_phukien);	
		
		// Product linh vật
		List<SanPham> product_linhvat= productService.getProductById(3);
		req.setAttribute("product_linhvat", product_linhvat);	
		
		// Product tượng đá
		List<SanPham> product_tuongda= productService.getProductById(4);
		req.setAttribute("product_tuongda", product_tuongda);	
		
		// Product tất cả
		List<SanPham> productList = productService.getAll();
		req.setAttribute("productlist", productList);	
		// Giảm Giá
		List<SanPham> productsList1 = new ArrayList<SanPham>();
		for(SanPham product: productList)
		{
			SanPham product1 = productService.get(Integer.parseInt(product.getId()));
			product1.setPrice(String.valueOf(df.format(Double.parseDouble(product.getPrice()) * (1 - (Double.parseDouble(product.getDiscount())/100)))));
			productsList1.add(product1);
			
		}
		req.setAttribute("productlist1", productsList1);
		

		RequestDispatcher dispatcher = req.getRequestDispatcher("/view/client/index.jsp");
		dispatcher.forward(req, resp);
	}
}
