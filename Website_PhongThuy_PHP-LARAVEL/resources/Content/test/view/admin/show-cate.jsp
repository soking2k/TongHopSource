<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%
  response.setHeader("Cache-control", "no-cache, no-store, must-revalidate");
  response.setHeader("Pragma" , "no-cache");
  response.setHeader("Expires" , "0");
  
  
  if (session.getAttribute("admin-username") == null){
	  response.sendRedirect(request.getContextPath() + "/admin/login");
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
          	<button class="btn btn-success"><a href="${pageContext.request.contextPath}/view/admin/addcate"> <font color="white">Thêm chuyên mục</font></a></button>
          
            <div class="card">
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table table-striped">
                    <thead>
                      <tr>
                     	<th scope="col">#</th>
                        <th scope="col">Tên chuyên mục</th>
                        <th scope="col">Hành động</th>
                      </tr>
                    </thead>
                   <tbody>
                  <c:forEach items="${catelist}" var="cate">
                      <tr>
                        <td scope="row">${cate.id}</td>
                        <td>${cate.name}</td>
        				
        				 <td>
                       	<a href="${pageContext.request.contextPath}/view/admin/editcate?id=${cate.id}" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/Edit-icon.png">      
                        <a href="${pageContext.request.contextPath}/view/admin/deletecate?id=${cate.id}" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/xoa.png">                             
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

  
