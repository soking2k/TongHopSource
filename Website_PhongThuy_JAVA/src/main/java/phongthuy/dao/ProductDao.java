package phongthuy.dao;

import java.util.List;

import phongthuy.model.SanPham;

public interface ProductDao {
	void insert(SanPham product);

	void edit(SanPham product);

	void delete(String id);

	SanPham get(int id);
	
	SanPham get(String name);

	List<SanPham> getAll();
	
	List<SanPham> getProductById(int id);

	List<SanPham> searchByName(String productName);


}
