<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%
  response.setHeader("Cache-control", "no-cache, no-store, must-revalidate");
  response.setHeader("Pragma" , "no-cache");
  response.setHeader("Expires" , "0");
  
  
  if (session.getAttribute("admin-username") == null){
	  response.sendRedirect(request.getContextPath() + "/view/admin/login");
  }
  %>
  <!-- Start header section -->
  <jsp:include page = "./header/header.jsp" flush = "true" />
  			<div id="page-wrapper" style="margin-left: 0px;">
			          
				<div class="row">
                     <div class="col-lg-12" style="height: 20px;">
                        <h1 class="page-header"></h1>
                    </div>
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">DANH SÁCH TÀI KHOẢN <span id="award_un" class="badge badge-primary" style="font-size: 20px;background: #df6363;color: #fff;padding: 3px 8px;">PhongThuyDiepTam</span></div>
							
    <div class="content-wrapper">
      <div class="container-fluid">

        <div class="row mt-3">
          <div class="col-lg-12">
         
          </div>
          <div class="col-lg-12">
          	<button class="btn btn-success"><a href="${pageContext.request.contextPath}/view/admin/addtintuc"> <font color="white">Thêm Tin Tức</font></a></button>
          
            <div class="card">
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table table-striped">
                    <thead>
                      <tr>
                        <th scope="col">#</th>
                        <th scope="col">Tiêu đề</th>
                        <th scope="col">Hình ảnh</th>
                        <th scope="col">Người đăng</th>
                        <th scope="col">Ngày đăng</th>
                        <th scope="col">Hành động</th>
                      </tr>
                    </thead>
                    <tbody>
                                      <c:forEach items="${tintuclist}" var="tintuc">
                      <tr>
                        <td scope="row">${tintuc.id}</td>
                        <td>${tintuc.title}</td>
        				<td><img style="width: 110px;height: 67px; object-fit: cover;border: 1px solid #fff;" src="${pageContext.request.contextPath}/view/client/assets/images/news/${tintuc.image_link}"></td>
        				<td>${tintuc.author}</td>
        				<td>${tintuc.created}</td>
        				 <td>
        				    <a href="${pageContext.request.contextPath}/view/admin/edittintuc?id=${tintuc.id}" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/Edit-icon.png">      
                        	<a href="${pageContext.request.contextPath}/view/admin/deletetintuc?id=${tintuc.id}" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/xoa.png">       
                         
                        </td>
                     </tr>
                    </c:forEach>
                     
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="overlay toggle-menu"></div>
      </div>
    </div>

  
