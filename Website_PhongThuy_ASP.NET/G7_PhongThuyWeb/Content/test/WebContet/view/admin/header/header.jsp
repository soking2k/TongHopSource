<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>
<c:url value = "/view/admin/assets" var="url"/>
<!DOCTYPE html>
<html lang="en">

  <head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		
        <title>Quản lý</title>

        <link href="./css/bootstrap.min.css" rel="stylesheet">
        <link href="./css/metisMenu.min.css" rel="stylesheet">

        <!-- DataTables CSS -->
        <link href="./css/dataTables/dataTables.bootstrap.css" rel="stylesheet">
        <!-- DataTables Responsive CSS -->
        <link href="./css/dataTables/dataTables.responsive.css" rel="stylesheet">

        <link href="./css/startmin.css" rel="stylesheet">
        <link href="./css/font-awesome.min.css" rel="stylesheet" type="text/css">
		
		<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
		<link rel="stylesheet" href="/resources/demos/style.css">
		<script src="./js/sweetalert2.all.js"></script>
		<script src="./js/bootstrap-datetimepicker.js"></script> 
		
<style>
		.slides img {
   height: 100%;
   width: 100%;
}
	</style>	


    </head>

  <body>

        <div id="wrapper">

            <!-- Navigation -->
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <div class="navbar-header">
                    <a class="navbar-brand" href="">Phong Thủy Diệp Tâm</a>
				
                </div>

                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <ul class="nav navbar-nav navbar-left navbar-top-links">
                    <li><a href="${pageContext.request.contextPath}/view/admin/homepage"><i class="fa fa-home fa-fw"></i> Home</a></li>
                </ul>
												
				<ul class="nav navbar-nav navbar-left navbar-top-links">
                    <li><a href="${pageContext.request.contextPath}/view/admin/listuser"><i class="fa fa-pencil fa-fw"></i> Quản lý tài khoản</a></li>
                    <li><a href="${pageContext.request.contextPath}/view/admin/listsanpham"><i class="fa fa-pencil fa-fw"></i> Quản lý sản phẩm</a></li>
                    <li><a href="${pageContext.request.contextPath}/view/admin/listorder"><i class="fa fa-pencil fa-fw"></i> Quản lý Hóa Đơn</a></li>
                    <li><a href="${pageContext.request.contextPath}/view/admin/listtintuc"><i class="fa fa-pencil fa-fw"></i> Quản lý Tin Tức</a></li>
                     <li><a href="${pageContext.request.contextPath}/view/admin/listcate"><i class="fa fa-pencil fa-fw"></i> Cấu Hình Chuyên Mục Sản Phẩm</a></li>
 
                </ul>
				
								
                <ul class="nav navbar-right navbar-top-links">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                            <i class="fa fa-user fa-fw"></i> <%=session.getAttribute("admin-username") %> <b class="caret"></b>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <!--<li><a href="#"><i class="fa fa-user fa-fw"></i> User Profile</a>
                            </li>-->
                            <li><a href="#"><i class="fa fa-gear fa-fw"></i> Đổi mật khẩu</a>
                            </li>
                            <li class="divider"></li>
                            <li>
								<a href="${pageContext.request.contextPath}/view/admin/logout"><i class="fa fa-sign-out fa-fw"></i> Thoát</a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>

			
			
    <div class="clearfix"></div>