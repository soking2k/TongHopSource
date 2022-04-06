package phongthuy.dao.impl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import java.util.ArrayList;
import java.util.List;


import java.sql.ResultSet;

import phongthuy.model.SanPham;

import phongthuy.dao.ProductDao;
import phongthuy.jdbc.connectDB;

public class ProductDaoImpl extends connectDB implements ProductDao {

	@Override
	public void insert(SanPham sanpham) {
		String sql = "INSERT INTO sanpham(loaisp_id, name, price, status, description, content, discount, image_link, created) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
		new connectDB();
		Connection con = connectDB.getConnect();

		try {
			PreparedStatement ps = con.prepareStatement(sql);
			ps.setString(1, sanpham.getloaisp_id());
			ps.setString(2, sanpham.getName());
			ps.setString(3, sanpham.getPrice());
			ps.setString(4, sanpham.getStatus());
			ps.setString(5, sanpham.getDescription());
			ps.setString(6, sanpham.getContent());
			ps.setString(7, sanpham.getDiscount());
			ps.setString(8, sanpham.getImage_link());
			ps.setString(9, sanpham.getCreated());
			ps.executeUpdate();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	@Override
	public void edit(SanPham sanpham) {
		String sql = "UPDATE sanpham SET name = ?, loaisp_id = ?, price = ?, status = ?, description = ?, content = ?, discount = ?, image_link = ?, created = ? WHERE id = ?";
		new connectDB();
		Connection con = connectDB.getConnect();

		try {
			PreparedStatement ps = con.prepareStatement(sql);
			ps.setString(1, sanpham.getName());
			ps.setString(2, sanpham.getloaisp_id());
			ps.setString(3, sanpham.getPrice());
			ps.setString(4, sanpham.getStatus());
			ps.setString(5, sanpham.getDescription());
			ps.setString(6, sanpham.getContent());
			ps.setString(7, sanpham.getDiscount());
			ps.setString(8, sanpham.getImage_link());
			ps.setString(9, sanpham.getCreated());
			ps.setString(10, sanpham.getId());
			ps.executeUpdate();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}

	@Override
	public void delete(String id) {
		String sql = "DELETE FROM sanpham WHERE id = ?";
		new connectDB();
		Connection conn = connectDB.getConnect();
		try {
			PreparedStatement ps = conn.prepareStatement(sql);
			ps.setString(1, id);
			ps.executeUpdate();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}

	@Override
	public SanPham get(int id) {
		String sql = "SELECT * FROM sanpham WHERE id = ? ";
		new connectDB();
		Connection con = connectDB.getConnect();

		try {
			PreparedStatement ps = con.prepareStatement(sql);
			ps.setInt(1, id);
			ResultSet rs = ps.executeQuery();

			while (rs.next()) {
				SanPham sanpham = new SanPham();
				sanpham.setId(rs.getString("id"));
				sanpham.seloaisp_id(rs.getString("loaisp_id"));
				sanpham.setName(rs.getString("name"));
				sanpham.setPrice(rs.getString("price"));
				sanpham.setStatus(rs.getString("status"));
				sanpham.setDescription(rs.getString("description"));
				sanpham.setContent(rs.getString("content"));
				sanpham.setDiscount(rs.getString("discount"));
				sanpham.setImage_link(rs.getString("image_link"));
				sanpham.setCreated(rs.getString("created"));
				return sanpham;

			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return null;
	}

	@Override
	public SanPham get(String name) {
		return null;
	}

	@Override
	public List<SanPham> getAll() {
		List<SanPham> sanphams = new ArrayList<SanPham>();
		String sql = "SELECT * FROM sanpham";
		Connection conn = connectDB.getConnect();

		try {
			PreparedStatement ps = conn.prepareStatement(sql);
			ResultSet rs = ps.executeQuery();

			while (rs.next()) {
				SanPham sanpham = new SanPham();

				sanpham.setId(rs.getString("id"));
				sanpham.seloaisp_id(rs.getString("loaisp_id"));
				sanpham.setName(rs.getString("name"));
				sanpham.setPrice(rs.getString("price"));
				sanpham.setStatus(rs.getString("status"));
				sanpham.setDescription(rs.getString("description"));
				sanpham.setContent(rs.getString("content"));
				sanpham.setDiscount(rs.getString("discount"));
				sanpham.setImage_link(rs.getString("image_link"));
				sanpham.setCreated(rs.getString("created"));
				sanphams.add(sanpham);
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}

		return sanphams;
	}

	@Override
	public List<SanPham> getProductById(int id) {
		List<SanPham> sanphams = new ArrayList<SanPham>();
		String sql = "SELECT * FROM sanpham WHERE loaisp_id=?";
		Connection conn = connectDB.getConnect();
		
		try {
			PreparedStatement ps = conn.prepareStatement(sql);
			ps.setInt(1, id);
			ResultSet rs = ps.executeQuery();

			while (rs.next()) {
				SanPham sanpham = new SanPham();

				sanpham.setId(rs.getString("id"));
				sanpham.seloaisp_id(rs.getString("loaisp_id"));
				sanpham.setName(rs.getString("name"));
				sanpham.setPrice(rs.getString("price"));
				sanpham.setStatus(rs.getString("status"));
				sanpham.setDescription(rs.getString("description"));
				sanpham.setContent(rs.getString("content"));
				sanpham.setDiscount(rs.getString("discount"));
				sanpham.setImage_link(rs.getString("image_link"));
				sanpham.setCreated(rs.getString("created"));
				sanphams.add(sanpham);
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		return sanphams;
	}
	

	@Override
	public List<SanPham> searchByName(String keyword) {
		List<SanPham> productList = new ArrayList<SanPham>();
		String sql = "SELECT * FROM sanpham WHERE name LIKE ? ";
		Connection conn = connectDB.getConnect();

		try {
			PreparedStatement ps = conn.prepareStatement(sql);
			ps.setString(1, "%" + keyword + "%");
			ResultSet rs = ps.executeQuery();

			while (rs.next()) {
				SanPham sanpham = new SanPham();
				sanpham.setId(rs.getString("id"));
				sanpham.seloaisp_id(rs.getString("loaisp_id"));
				sanpham.setName(rs.getString("name"));
				sanpham.setPrice(rs.getString("price"));
				sanpham.setStatus(rs.getString("status"));
				sanpham.setDescription(rs.getString("description"));
				sanpham.setContent(rs.getString("content"));
				sanpham.setDiscount(rs.getString("discount"));
				sanpham.setImage_link(rs.getString("image_link"));
				sanpham.setCreated(rs.getString("created"));
				productList.add(sanpham);
			}

		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return productList;
	}

	
	

}
