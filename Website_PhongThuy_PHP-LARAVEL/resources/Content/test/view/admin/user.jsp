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
 
<!DOCTYPE html>
<html>
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
							
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="dataTable_wrapper">									<form method="POST" action="./" name="frmForm" enctype="multipart/form-data">																												<input type="hidden" name="page" value="">
                                    <table class="table table-striped table-bordered table-hover" id="dataTables-taikhoan">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Họ Và Tên</th>                                                
												<th>Email</th>
												<th>Tài khoản</th>
												<th>Họ Và Tên</th>
												<th>Thời gian tạo</th>
												<th></th>
                                            </tr>
                                        </thead>
                                         <tbody>
                  <c:forEach items="${userList}" var="user">
                      <tr>
                        <td scope="row">${user.id}</td>
                        <td>${user.name }</td>
        				<td>${user.email }</td>
        				<td>${user.phone }</td>
        				<td>${user.username }</td>
        				<td>${user.created }</td>
        				 <td>
					<a href="${pageContext.request.contextPath}/view/admin/edituser?user-id=${user.id}" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/Edit-icon.png">      
					
					     </td>
                     </tr>
                    </c:forEach>
                    </tbody>
                                    </table>
			<!--create modal dialog for display detail info for edit on button cell click-->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <div id="content-data"></div>
            </div>
        </div>									
									</form>
                                </div>
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>

            </div>
        </div>
        <!-- /#wrapper -->
        <!-- jQuery -->
        
		<script src="./js/jquery.min.js"></script>
		<script src="./js/bootstrap.min.js"></script>
        <script src="./js/metisMenu.min.js"></script>
		
        <!-- DataTables JavaScript -->
        <script src="./js/dataTables/jquery.dataTables.min.js"></script>
        <script src="./js/dataTables/dataTables.bootstrap.min.js"></script>
        <script src="./js/startmin.js"></script>
		<script src="./js/account.js"></script>
		<script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
		<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
		
		<link rel="stylesheet" href="./css/bootstrap-dialog.min.css" />
		<script src="./js/bootstrap-dialog.min.js"></script>
		
		<script src="./js/jquery.tabledit.min.js"></script>
		

 


	

	<script type="text/javascript">
        $(document).ready(function() {
                 var table = $('#examplenew').DataTable( {
					stateSave: true,
                 "order": [[ 0, "desc" ]],
                 "lengthMenu": [[10,50,100, -1],[10,50,100,"Tất cả"]],
                 "language": {
                   "search": "Tìm gì cũng được",
                   "paginate": {
                       "first": "Về Đầu",
                       "last": "Về Cuối",
                       "next": "Tiến",
                       "previous": "Lùi"
                   },
                   "info": "Hiển thị _START_ đến _END_ của _TOTAL_ mục",
                   "infoEmpty": "Hiển thị 0 đến 0 của 0 mục",
                   "lengthMenu": "Hiển thị _MENU_ mục",
                   "loadingRecords": "Đang tải...",
                   "emptyTable": "Không có gì để hiển thị",
                 },
                 dom: 'Bfrt<"col-md-6 inline"i><"col-md-6 inline"p>',   
                 buttons: {
                   dom: {
                     container:{
                       tag:'div',
                       className:'flexcontent'
                     },
                     buttonLiner: {
                       tag: null
                     }
                   },
                   buttons: [
                            {
                                 extend:    'copyHtml5',
                                 text:      '<i class="fa fa-clipboard"></i>Copy',
                                 title:'Admin result data copy',
                                 titleAttr: 'Copiar',
                                 className: 'btn btn-app export barras',
                                 exportOptions: {
                                     columns: [ 0, 1 ]
                                 }
                             },
                             {
                                 extend:    'excelHtml5',
                                 text:      '<i class="fa fa-file-excel-o"></i>Excel',
                                 title:'BẢNG KÊ CHI TIẾT HÓA ĐƠN MOMO',
                                 titleAttr: 'Excel',
                                 className: 'btn btn-app export excel',
                                 exportOptions: {
                                     columns: [ 0, 1,2,3,4,5 ]
                                 },
                             },
                             {
                                 extend:    'pageLength',
                                 titleAttr: 'Hiển thị',
                                 className: 'selectTable'
                             }
                         ]
                 }
                 }); 
                 } );
    </script>
	
	<style>
.padd0 {
    padding-left: 0;
    padding-right: 0;
}
.pst {
    border-bottom: 1px solid #cdcdcd;
    margin-bottom: 0;
    padding-bottom: 2px;
    padding-top: 8px;
}
.pst p {
    color: #fff;
    margin-bottom: 0;
    padding-left: 5px;
}

.LockOff {
	display: none;
	visibility: hidden;
}

.LockOn {
	display: block;
	color:#f0f0f0;
	font-size:larger;
	visibility: visible;
	position: fixed;
	z-index: 999;
	top: 0px;
	left: 0px;
	width: 100%;
	height: 100%;
	background-color: #303030;
	text-align: center;
	padding-top: 20%;
	filter: alpha(opacity=96);
	opacity: 0.96;
}
</style>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css">
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.colVis.min.js"></script>

<script>
//$('#dataTables-card').tableTotal();
</script>
</body>
</html>
 