package phongthuy.service.impl;


import java.util.List;


import phongthuy.dao.ProductDao;
import phongthuy.dao.impl.ProductDaoImpl;
import phongthuy.model.SanPham;
import phongthuy.service.ProductService;

public class ProductServiceImpl implements ProductService {
	ProductDao productDao = new ProductDaoImpl();

	@Override
	public void insert(SanPham product) {
		productDao.insert(product);
	}

	@Override
	public void edit(SanPham newProduct) {
		SanPham oldProduct = productDao.get(Integer.parseInt(newProduct.getId()));
		oldProduct.setName(newProduct.getName());
		oldProduct.seloaisp_id(newProduct.getloaisp_id());
		oldProduct.setStatus(newProduct.getStatus());
		oldProduct.setPrice(newProduct.getPrice());
		oldProduct.setDescription(newProduct.getDescription());
		oldProduct.setContent(newProduct.getContent());
		oldProduct.setDiscount(newProduct.getDiscount());
		oldProduct.setImage_link(newProduct.getImage_link());
		oldProduct.setCreated(newProduct.getCreated());

		productDao.edit(oldProduct);

	}

	@Override
	public void delete(String id) {
		productDao.delete(id);

	}

	@Override
	public SanPham get(int id) {
		return productDao.get(id);
	}

	@Override
	public SanPham get(String name) {
		return productDao.get(name);
	}

	@Override
	public List<SanPham> getAll() {
		return productDao.getAll();
	}

	@Override
	public List<SanPham> getProductById(int id) {
		return productDao.getProductById(id);
	}
	
	@Override
	public List<SanPham> searchByName(String productName) {
		return productDao.searchByName(productName);
	}

	@Override
	public List<SanPham> getProductByIdCate(int idCate) {
		// TODO Auto-generated method stub
		return null;
	}



}