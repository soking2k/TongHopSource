package phongthuy.service;

import phongthuy.model.SanPham;
import java.util.List;
public interface ProductService {
	void insert(SanPham product);

	void edit(SanPham product);

	void delete(String id);

	SanPham get(int id);
	
	SanPham get(String name);

	List<SanPham> getAll();
	
	List<SanPham> getProductById(int id);

	List<SanPham> searchByName(String productName);

	List<SanPham> getProductByIdCate(int idCate);

}

