<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
  <!-- Start header section -->
  <jsp:include page = "./header/header.jsp" flush = "true" />
    <div class="content-wrapper">
      <div class="container-fluid">

        <div class="row mt-3">
          <div class="col-lg-8">
            <div class="card">
              <div class="card-body">
                <div class="card-title">Sửa chuyên mục</div>
                <hr>
          	
	                <form action="${pageContext.request.contextPath}/view/admin/editcate" method="post">
	                  <div class="form-group">
	                    <label for="input-1">ID</label>
	                    <input type="text" class="form-control" readonly id="input-1" placeholder="ID" name="id" value="${catelist.id}">
	                  </div>
	                  <div class="form-group">
	                    <label for="input-1">Tên chuyên mục</label>
	                    <input type="text" class="form-control" id="input-1" placeholder="Tên chuyên mục" name="name" value="${catelist.name }">
	                  </div>
		               </div>
	                   <div class="form-footer">
	                      <button class="btn btn-danger"><a href="${pageContext.request.contextPath}/view/admin/listcate">Hủy</a></button>
                         
                     		<button type="submit" class="btn btn-success">Cập nhật</button>
	                   </div> 
	               
	                </form>
	                 
              </div>
            </div>
          </div>
        </div>
        <div class="overlay toggle-menu"></div>
      </div>
    </div>
  
