<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
  response.setHeader("Cache-control", "no-cache, no-store, must-revalidate");
  response.setHeader("Pragma" , "no-cache");
  response.setHeader("Expires" , "0");
  
  
  if (session.getAttribute("admin-username") == null){
	  response.sendRedirect(request.getContextPath() + "/view/admin/login"); 
  }
  %>
 <html>
  <jsp:include page = "./header/header.jsp" flush = "true" />

  
			
			<div id="page-wrapper" style="margin-left: 0px;">
				
						<div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Administrator</h1>
                    </div>
                    <!-- /.col-lg-12 -->
            </div>
			<!-- /.row -->
				
                <div class="row">
					<div class="col-lg-2 col-md-6">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <div class="row">
                                    <span class="count_top"><i class="fa fa-user"></i> Tổng Users</span>
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_user1">${soluong}</div>
                                        <div>Hôm nay đăng ký <i class="green" id="total_user_date1">${soluonghomnay}</i> Users</div>
                                    </div>
                                </div>
                            </div>
                            <a href="quan-ly-tai-khoan">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
				<div class="col-lg-2 col-md-6">
					<div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
									<span class="count_top"><i class="fa fa-bitcoin"></i> Doanh Thu Cả Năm<!--</span-->
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_card1">${soluongsphomnay}</div>
                                        <div>Hôm nay <i class="green" id="total_card_count1">${soluongsp}</i> Bill</div>
                                    </div>
                                </span></div>
                            </div>
                            <a href="danh-sach-card">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
					</div>
                   <div class="col-lg-2 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <span class="count_top"><i class="fa fa-money"></i> Doanh Thu Tháng Này<!--</span-->
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_momo1">${soluongsphomnay}</div>
                                        <div>Hôm nay <i class="green" id="total_momo_count1">${soluongsp}</i> Bill</div>
                                    </div>
                                </span></div>
                            </div>
                            <a href="danh-sach-chuyen-khoan">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
					<div class="col-lg-2 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <span class="count_top"><i class="fa fa-user"></i> Doanh Thu Hôm Nay</span>
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_bank1">${soluongsphomnay}</div>
                                        <div>Hôm nay <i class="green" id="total_bank_count1">${soluongsp}</i> Bill</div>
                                    </div>
                                </div>
                            </div>
                            <a href="quan-ly-tai-khoan">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
					<!--
					<div class="col-lg-2 col-md-6">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <div class="row">
                                    <span class="count_top"><i class="fa fa-user"></i> Tổng Users</span>
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_user2"></div>
                                        <div>Hôm nay đăng ký <i class="green" id="total_user_date2"></i> Users</div>
                                    </div>
                                </div>
                            </div>
                            <a href="quan-ly-tai-khoan">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
					<div class="col-lg-2 col-md-6">
					<div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
									<span class="count_top"><i class="fa fa-bitcoin"></i> Tổng Thanh Toán Trực TIếp</</span>
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_card2"></div>
                                        <div>Hôm nay <i class="green" id="total_card_count2"></i> Card</div>
                                    </div>
                                </div>
                            </div>
                            <a href="danh-sach-card">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
					</div>
                    <div class="col-lg-2 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <span class="count_top"><i class="fa fa-money"></i> Momo, Bank</</span>
                                    <div class="col-xs-12 text-right">
                                        <div class="huge" id="total_momo2"></div>
                                        <div>Hôm nay <i class="green" id="total_momo_count2"></i> Bill</div>
                                    </div>
                                </div>
                            </div>
                            <a href="danh-sach-chuyen-khoan">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>-->
                </div>
				<!--<div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"></h1>
                    </div>
                </div>-->
				<div class="row">
					<div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Doanh thu ngày</div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="flot-chart">
                                    
									<div id="chart_ngay_1" style="height: 370px; width: 100%;"><div class="canvasjs-chart-container" style="position: relative; text-align: left; cursor: auto; direction: ltr;"><canvas class="canvasjs-chart-canvas" width="1035" height="462" style="width: 828px; height: 370px; position: absolute; user-select: none;"></canvas><canvas class="canvasjs-chart-canvas" width="1035" height="462" style="width: 828px; height: 370px; position: absolute; -webkit-tap-highlight-color: transparent; user-select: none; cursor: default;"></canvas><div class="canvasjs-chart-toolbar" style="position: absolute; right: 1px; top: 1px; border: 1px solid transparent;"><button state="menu" type="button" title="More Options" style="background-color: white; color: black; border: none; user-select: none; padding: 5px 12px; cursor: pointer; float: left; width: 40px; height: 25px; outline: 0px; vertical-align: baseline; line-height: 0; display: inline;"><img style="height: 95%; pointer-events: none; filter: invert(0%);" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAeCAYAAABE4bxTAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADoSURBVFhH7dc9CsJAFATgRxIIBCwCqZKATX5sbawsY2MvWOtF9AB6AU8gguAJbD2AnZ2VXQT/Ko2TYGCL2OYtYQc+BuYA+1hCtnCVwMm27SGaXpDJIAiCvCkVR05hGOZNN3HkFMdx3nQRR06+76/R1IcFLJlNQEWlmWlBTwJtKLKHynehZqnjOGM0PYWRVXk61C37p7xlZ3Hk5HneCk1dmMH811xGoKLSzDiQwIBZB4ocoPJdqNkDt2yKlueWRVGUtzy3rPwo3sWRU3nLjuLI6OO67oZM00wMw3hrmpZx0XU9syxrR0T0BeMpb9dneSR2AAAAAElFTkSuQmCC" alt="More Options"></button><div tabindex="-1" style="position: absolute; z-index: 1; user-select: none; cursor: pointer; right: 0px; top: 25px; min-width: 120px; outline: 0px; font-size: 14px; font-family: Arial, Helvetica, sans-serif; padding: 5px 0px; text-align: left; line-height: 10px; background-color: white; box-shadow: rgb(136, 136, 136) 2px 2px 10px; display: none;"><div style="padding: 12px 8px; background-color: white; color: black;">Print</div><div style="padding: 12px 8px; background-color: white; color: black;">Save as JPEG</div><div style="padding: 12px 8px; background-color: white; color: black;">Save as PNG</div></div></div><div class="canvasjs-chart-tooltip" style="position: absolute; height: auto; box-shadow: rgba(0, 0, 0, 0.1) 1px 1px 2px 2px; z-index: 1000; pointer-events: none; display: none; border-radius: 0px; left: 137px; bottom: -77px; transition: left 0.1s ease-out 0s, bottom 0.1s ease-out 0s;"><div style="width: auto; height: auto; min-width: 50px; margin: 0px; padding: 5px; font-family: &quot;Trebuchet MS&quot;, Helvetica, sans-serif; font-weight: normal; font-style: normal; font-size: 14px; color: black; text-shadow: rgba(0, 0, 0, 0.1) 1px 1px 1px; text-align: left; border: 1px solid rgb(79, 129, 188); background: rgba(255, 255, 255, 0.9); text-indent: 0px; white-space: nowrap; border-radius: 0px; user-select: none;">17/05<br><span style="color:#4F81BC;">Card:</span>&nbsp;&nbsp;850<br><span style="color:#C0504E;">Momo,Bank:</span>&nbsp;&nbsp;50</div></div><a class="canvasjs-chart-credit" title="JavaScript Charts" style="outline: none; margin: 0px; position: absolute; right: auto; top: 356px; color: dimgrey; text-decoration: none; font-size: 11px; font-family: Calibri, &quot;Lucida Grande&quot;, &quot;Lucida Sans Unicode&quot;, Arial, sans-serif;" tabindex="-1" target="_blank" href="https://canvasjs.com/">CanvasJS.com</a></div></div>
									
									
                                </div>
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
					
					<div class="col-lg-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">Doanh thu tháng</div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="flot-chart">
                                    
									<div id="chart_thang_1" style="height: 370px; width: 100%;"></div>
									
									
                                </div>
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
					
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
		
<script>
 $('#dataTables-role2').on('draw.dt', function(){
  $('#dataTables-role2').Tabledit({
   url:'ajax/ajax_Action.php',
   dataType:'json',
   columns:{
    identifier : [0, 'id'],
    editable:[
		[8, 'first_name'],
		//[3, 'last_name'],
		//[4, 'gender', '{"1":"Male","2":"Female"}']
	]
   },
   deleteButton: false,
   restoreButton:false,
   onSuccess:function(data, textStatus, jqXHR)
   {
    if(data.action == 'edit')
    {
		swal("Thành công!", "", "success");
     $('#' + data.id).remove();
     $('#dataTables-role2').DataTable().ajax.reload();
    }
   }
  });
 });
</script>
 
		<script>
			$( function() {
				$("#start_date_1").datepicker({ dateFormat: 'dd/mm/yy' });
				$("#end_date_1" ).datepicker({ dateFormat: 'dd/mm/yy' });
				
				$("#start_date").datepicker({ dateFormat: 'dd/mm/yy' });
				$("#end_date" ).datepicker({ dateFormat: 'dd/mm/yy' });
				
				$("#start_date_lsad").datepicker({ dateFormat: 'dd-mm-yy' });
				$("#end_date_lsad" ).datepicker({ dateFormat: 'dd-mm-yy' });
				//$("#rut_start_date").datepicker({ dateFormat: 'dd-mm-yy' });
				//$("#rut_end_date" ).datepicker({ dateFormat: 'dd-mm-yy' });
				$("#rut_box_date" ).datepicker({ dateFormat: 'dd-mm-yy' });
				$("#momo_dates" ).datepicker({ dateFormat: 'd MM yy' });
				$("#check_dates" ).datepicker({ dateFormat: 'dd-mm-yy' });
				$("#check_date_mac" ).datepicker({ dateFormat: 'dd-mm-yy' });
				$("#giaodich_start_date").datepicker({ dateFormat: 'dd-mm-yy' });
				$("#giaodich_end_date" ).datepicker({ dateFormat: 'dd-mm-yy' });
				
			} );
		</script>
	 <script>
            $(document).ready(function(){
            $('#cbMayChu').change(function(){
                var inputValue = $(this).val();
                $.post('ajax/ajax_MayChu.php', { dropdownValue: inputValue }, function(data){
					location.reload();
                });
            });
        });
        </script>
	 
	<!-- Danh sách tài khoản-->	 
	<script>
	function LoadClick(type,file) {
        $(document).on('click','#'+type,function(e){
            e.preventDefault();
			var id=$(this).data('id');
            var user=$(this).data('user');
            $('#content-data').html('');
            $.ajax({
                url:'mod/'+file,
                type:'POST',
                data:'id='+id+'&user='+user,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
	}
	
	function XoaItem(type,file) {
		$(document).on('click','#'+type,function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn xóa ID " + del_id + "?",
				text: "Sau khi xóa sẽ không thể phục hồi!",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Xóa",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/"+file, "del_id="+del_id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
	}
	function ThuHoi(type,file) {
		$(document).on('click','#'+type,function(e){
			e.preventDefault();
			var id=$(this).data('id');
			var magd=$(this).data('magd');
			swal({
				title: "Muốn thu hồi ID " + id + "?",
				text: "Bạn muốn thu hồi " + magd + "?. Điều kiện còn Xu và trong ngày",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Thu hồi",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/"+file, "id="+id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
	}
	
	function LoadDataTable(htmldata,file,tbdata)
	{
		var dataTable = $('#'+htmldata).DataTable( {
		stateSave: true,
		"autoWidth": false,
		//"order": [[ 5, "desc" ]], //load mặc định sắp xếp
		"processing": true,		
		//"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
		"language": {processing: "<img src='images/loading.gif'> Loading...",},
		"serverSide": true,
		"lengthMenu": [[10, 20, 50, 100], [10, 20, 50,100]],
		"ajax":{
			url :"ajax/"+file,
			type: "post", 
			data: {data: JSON.stringify(tbdata)},
			error: function(){
				$(".grid-error").html("");
				$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
				$("#grid_processing").css("display","none");
			}
		}
		} );
	}
    </script>
	
	<!--------LOAD-------->
	<script>
				function fetch_data_chuyenkhoan(is_date_search, start_date='', end_date='',taikhoan,trangthai)
				{
					var dataTable = $('#dataTables-chuyenkhoan').DataTable( {
						stateSave: true,
						
						"footerCallback": function ( row, data, start, end, display ) {
							var api = this.api(), data;
							// converting to interger to find total
							var intVal = function ( i ) {
								return typeof i === 'string' ?
									i.replace(/[\$,]/g, '')*1 :
									typeof i === 'number' ?
										i : 0;
							};
							var cot2Total = api.column( 3 ).data().reduce( function (a, b) {
										return intVal(a) + intVal(b);
									}, 0 );
							var cot4Total = api.column( 4 ).data().reduce( function (a, b) {
										return intVal(a) + intVal(b);
									}, 0 );
								$( api.column( 0 ).footer() ).html('Tổng');
								$( api.column( 3 ).footer() ).html(cot2Total.toLocaleString('en-US'));
								$( api.column( 4 ).footer() ).html(cot4Total.toLocaleString('en-US'));
						},
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						//"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"language": {processing: "<img src='images/loading.gif'> Loading...",},
						"serverSide": true,
						//"lengthMenu": [[10, 50, 100, 200,500,], [10, 50, 100,200,500]],
						"lengthMenu": [[10, 50, 100,200,500], [10, 50, 100,200,500]],     // page length options
						
						"ajax":{
							url :"ajax/ajax_DanhSachBank.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, start_date:start_date, end_date:end_date,taikhoan:taikhoan,trangthai:trangthai
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_doitennv(is_date_search, start_date='', end_date='',taikhoan,trangthai)
				{
					var dataTable = $('#dataTables-role').DataTable( {
						stateSave: true,
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						//"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"language": {processing: "<img src='images/loading.gif'> Loading...",},
						"serverSide": true,
						//"lengthMenu": [[10, 50, 100, 200,500,], [10, 50, 100,200,500]],
						"lengthMenu": [[10, 50, 100,200,500], [10, 50, 100,200,500]],     // page length options
						
						"ajax":{
							url :"ajax/ajax_DanhSachRole.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, start_date:start_date, end_date:end_date,taikhoan:taikhoan,trangthai:trangthai
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_momo(is_date_search, start_date='', end_date='',taikhoan)
				{
					var dataTable = $('#dataTables-logmomo').DataTable( {
						stateSave: true,
						"footerCallback": function ( row, data, start, end, display ) {
							var api = this.api(), data;
							// converting to interger to find total
							var intVal = function ( i ) {
								return typeof i === 'string' ?
									i.replace(/[\$,]/g, '')*1 :
									typeof i === 'number' ?
										i : 0;
							};
							var cot4Total = api.column( 4 ).data().reduce( function (a, b) {
										return intVal(a) + intVal(b);
							}, 0 );
							
							$( api.column( 0 ).footer() ).html('Tổng');
							$( api.column( 4 ).footer() ).html(cot4Total.toLocaleString('en-US'));
						},
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"serverSide": true,
						"lengthMenu": [[10, 50, 100,200,500, -1], [10, 50, 100,200,500, "All"]],     // page length options
						"dom": 'Bfrt<"col-md-6 inline"i><"col-md-6 inline"p>',
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
                                 extend:    'excelHtml5',
                                 text:      '<i class="fa fa-file-excel-o"></i>Excel',
                                 title:'BẢNG KÊ CHI TIẾT HÓA ĐƠN MOMO',
                                 titleAttr: 'Excel',
                                 className: 'btn btn-app export excel',
                                 exportOptions: {
                                     columns: [ 0, 1,2,3,4,5,6 ]
                                 },
                             },
                             {
                                 extend:    'pageLength',
                                 titleAttr: 'Hiển thị',
                                 className: 'selectTable'
                             }
						],},
			
						"ajax":{
							url :"ajax/ajax_logmomo.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, start_date:start_date, end_date:end_date,magd:taikhoan
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_rutxu(is_date_search, start_date='', end_date='',acc)
				{
					var dataTable = $('#dataTables-rutcredit').DataTable( {
					stateSave: true,
					"autoWidth": false,
					"order": [[ 0, "desc" ]], //load mặc định sắp xếp
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthMenu": [[10, 50, 100, 200,500,], [10, 50, 100,200,500]],
                    "ajax":{
                        url :"ajax/ajax_Danhsachrutxu.php",
                        type: "post", 
						data:{
							is_date_search:is_date_search, start_date:start_date, end_date:end_date,acc:acc
						},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    }
					} );
				}
				function fetch_data_giaodich(is_date_search, start_date='', end_date='',acc)
				{
					var dataTable = $('#dataTables-giaodich').DataTable( {
					stateSave: true,
					"order": [[ 6, "desc" ]], //load mặc định sắp xếp
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthMenu": [[10, 50, 100, 200,500,], [10, 50, 100,200,500]],
                    "ajax":{
                        url :"ajax/ajax_Danhsachgiaodich.php",
                        type: "post", 
						data:{
							is_date_search:is_date_search, start_date:start_date, end_date:end_date,acc:acc
						},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    }
					} );
				}
				
				function fetch_data_role(is_date_search,serverid,role_item)
				{
					var dataTable = $('#dataTables-roleitem').DataTable( {
						stateSave: true,
						"autoWidth": false,
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"serverSide": true,
						"lengthMenu": [[10, 50, 100,200,500, -1], [10, 50, 100,200,500, "All"]],     // page length options
						"ajax":{
							url :"ajax/ajax_log_roleitem.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, serverid:serverid, role_item:role_item,
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_thongtin_nhanvat(is_date_search,serverid)
				{
					var dataTable = $('#dataTables-thongtinrole').DataTable( {
						stateSave: true,
						"autoWidth": false,
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"serverSide": true,
						"lengthMenu": [[10, 50, 100,200,500, -1], [10, 50, 100,200,500, "All"]],     // page length options
						"ajax":{
							url :"ajax/ajax_log_thongtinrole.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, serverid:serverid,
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_mac(is_date_search,serverid,times)
				{
					var dataTable = $('#dataTables-mac').DataTable( {
						stateSave: true,
						"autoWidth": false,
						"order": [[ 0, "desc" ]], //load mặc định sắp xếp
						"processing": true,		
						"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
						"serverSide": true,
						"lengthMenu": [[10, 50, 100,200,500, -1], [10, 50, 100,200,500, "All"]],     // page length options
						"ajax":{
							url :"ajax/ajax_log_mac.php",
							type: "post", 
							data:{
								is_date_search:is_date_search, serverid:serverid, times:times,
							},
							error: function(){
								$(".grid-error").html("");
								$("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
								$("#grid_processing").css("display","none");

							}
						}
					} );
				}
				
				function fetch_data_admin(is_date_search, status,user,start_date='', end_date='')
				{
					var dataTable = $('#dataTables-admin').DataTable( {
					stateSave: true,
					"footerCallback": function ( row, data, start, end, display ) {
						var api = this.api(), data;
			 
						// converting to interger to find total
						var intVal = function ( i ) {
							return typeof i === 'string' ?
								i.replace(/[\$,]/g, '')*1 :
								typeof i === 'number' ?
									i : 0;
						};
						var cot4Total = api
								.column( 3 )
								.data()
								.reduce( function (a, b) {
									return intVal(a) + intVal(b);
								}, 0 );
						var cot5Total = api
								.column( 4 )
								.data()
								.reduce( function (a, b) {
									return intVal(a) + intVal(b);
								}, 0 );
						$( api.column( 0 ).footer() ).html('Total');
							$( api.column( 3 ).footer() ).html(cot4Total.toLocaleString('en-US'));
							$( api.column( 4 ).footer() ).html(cot5Total.toLocaleString('en-US'));
					},
					"order": [[ 0, "desc" ]], //load mặc định sắp xếp
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthMenu": [[10, 20, 50, 100], [10, 20, 50,100]],
					
                    "ajax":{
                        url :"ajax/ajax_Lichsuadmin.php",
                        type: "post", 
						data:{
							is_date_search:is_date_search,status:status,user:user,start_date:start_date, end_date:end_date
						},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    }
					} );
				}
				function fetch_data_card(datatb,file,tbdata)
				{
					var dataTable = $('#'+datatb).DataTable( {
					stateSave: true,
					"autoWidth": false,
					"footerCallback": function ( row, data, start, end, display ) {
						var api = this.api(), data;
						var intVal = function ( i ) {
							return typeof i === 'string' ?
								i.replace(/[\$,]/g, '')*1 :
								typeof i === 'number' ?
									i : 0;
						};
						
						var cot5Total = api.column( 5 ).data().reduce( function (a, b) {
									return intVal(a) + intVal(b);
								}, 0 );
						var cot6Total = api.column( 6 ).data().reduce( function (a, b) {
									return intVal(a) + intVal(b);
								}, 0 );
							$( api.column( 0 ).footer() ).html('Tổng');
							$( api.column( 5 ).footer() ).html(cot5Total.toLocaleString('en-US'));
							$( api.column( 6 ).footer() ).html(cot6Total.toLocaleString('en-US'));
					},
					
					"order": [[ 0, "desc" ]], //load mặc định sắp xếp
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthMenu": [[10, 50, 100, 200,500,], [10, 50, 100,200,500]],
                    "ajax":{
                        url :"ajax/"+file,
                        type: "post", 
						data: {data: JSON.stringify(tbdata)},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    },
					
					} );
				}
	</script>
	
	<!-- Hanh dong click-->
	<script>
		function search_ck() {
					var start_date = $('#start_date').val();
					var end_date = $('#end_date').val();
					var taikhoan = $('#taikhoan_').val();
					var status = $('#status_ck').val();
					$('#dataTables-chuyenkhoan').DataTable().destroy();
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_chuyenkhoan('yes', start_date, end_date, taikhoan,status);
		}
		function search_role() {
					var start_date = $('#start_date_role').val();
					var end_date = $('#end_date_role').val();
					var taikhoan = $('#taikhoan_role').val();
					$('#dataTables-role').DataTable().destroy();
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_doitennv('yes', start_date, end_date, taikhoan);
		}
		function search_momo() {
					var start_date = $('#start_date').val();
					var end_date = $('#end_date').val();
					var taikhoan = $('#magd_').val();
					$('#dataTables-logmomo').DataTable().destroy();
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_momo('yes', start_date, end_date, taikhoan);
		}
		
		$('#search_rutxu').click(function(){
					var start_date = $('#rut_start_date').val();
					var end_date = $('#rut_end_date').val();
					var acc = $('#rut_acc').val();
					$('#dataTables-rutcredit').DataTable().destroy();
					
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_rutxu('yes', start_date, end_date,acc);
		});
		$('#search_giaodich').click(function(){
					var start_date = $('#rut_start_date').val();
					var end_date = $('#rut_end_date').val();
					var acc = $('#accgd').val();
					$('#dataTables-giaodich').DataTable().destroy();
					
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_giaodich('yes', start_date, end_date,acc);
		});
		$('#search_roleitem').click(function(){
					 $('#dataTables-roleitem').DataTable().destroy();
					var serverid = $('#serverid').val();
					var role_item = $('#role_item').val();
					if(serverid < 0){
						swal("Xảy ra lỗi!", "Hãy chọn máy chủ", "error");
					} else if(role_item == ""){
						swal("Xảy ra lỗi!", "Hãy chọn vật phẩm", "error");
					}
					else
						fetch_data_role('yes',serverid,role_item);
					if(role_item == "ROLE") {
						$("th").each(function(){$(this).html($(this).html()
						.replace("nTên Item","nChuyển Sinh").replace("nSố lượng","nCấp độ").replace("nThời gian","LastLoginDate"));});
					} else {
						$("th").each(function(){$(this).html($(this).html()
						.replace("nChuyển Sinh","nTên Item").replace("nCấp độ","nSố lượng").replace("LastLoginDate","nThời gian"));});
					}
		});
		$('#search_thongtinrole').click(function(){
					 $('#dataTables-thongtinrole').DataTable().destroy();
					var serverid = $('#serverid').val();
					if(serverid == '-1'){
						swal("Xảy ra lỗi!", "Hãy chọn máy chủ", "error");
					}
					else
						fetch_data_thongtin_nhanvat('yes',serverid);
		});
		
		$('#search_mac').click(function(){
					 $('#dataTables-mac').DataTable().destroy();
					var serverid = $('#serverid').val();
					var times = $('#check_date_mac').val();
					if(serverid == '-1'){
						swal("Xảy ra lỗi!", "Hãy chọn máy chủ", "error");
					}
					else
						fetch_data_mac('yes',serverid,times);
		});
		
		$('#search').click(function(){
					var status = $('#status_ad').val();
					var user = $('#taikhoan_lsad').val();
					var start_date = $('#start_date_lsad').val();
					var end_date = $('#end_date_lsad').val();
					$('#dataTables-admin').DataTable().destroy();
					
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data_admin('yes', status,user,start_date,end_date);
		});
		$('#search_card').click(function(){
					var start_date = $('#start_date_1').val();
					var end_date = $('#end_date_1').val();
					var status = $('#status_1').val();
					$('#dataTables-card').DataTable().destroy();
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else {
						var tbdata = {"is_date_search":"yes","start_date":""+start_date,"end_date":""+end_date,"status":""+status,};
						fetch_data_card('dataTables-card','ajax_danhsachcard.php',tbdata);
					}
		});		
    </script>
	<script>
		
		$(document).on('click','#getDuyetCk',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn duyệt ID " + del_id + "?",
				text: "Sau khi duyệt sẽ add credit cho tài khoản!",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Duyệt",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Duyet_Bank.php", "del_id="+del_id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								//swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
		
    </script>
	
	<!-- Danh sách giao dich-->	 
	<script>
			$(document).on('click','#add_giaodich',function(e){
            e.preventDefault();
			var id=$(this).data('id');
            var user=$(this).data('user');
            $('#content-data').html('');
            $.ajax({
                url:'mod/box_giaodich.php',
                type:'POST',
                data:'id='+id+'&user='+user,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
    </script>
	
	<!-- Danh sách giao dich-->	 
	<script>
				 
				
            
				
			
			$(document).on('click','#add_giaodich',function(e){
            e.preventDefault();
			var id=$(this).data('id');
            var user=$(this).data('user');
            $('#content-data').html('');
            $.ajax({
                url:'mod/box_giaodich.php',
                type:'POST',
                data:'id='+id+'&user='+user,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
    </script>

	<!-- Danh sách momo-->	 
	<script>
	
				 
				
				
					
			$(document).on('click','#add_momo',function(e){
				e.preventDefault();
				var id=$(this).data('id');
				var user=$(this).data('user');
				$('#content-data').html('');
				$.ajax({
					url:'mod/box_momo.php',
					type:'POST',
					data:'id='+id+'&user='+user,
					dataType:'html'
				}).done(function(data){
					$('#content-data').html('');
					$('#content-data').html(data);
				}).fial(function(){
					$('#content-data').html('<p>Error</p>');
				});
			});
		
			$(document).on('click','#getMomo',function(e){
			e.preventDefault();
			var date_s = $('#momo_dates').val();
			swal({
				title: "Muốn cập nhật thông tin MOMO?",
				text: ""+date_s,
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Đồng ý",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					window.swal({
						title: "Loading...",
						text: "Please wait",
						imageUrl: "images/loading.gif",
						showConfirmButton: false,
						allowOutsideClick: false
					});
					$.post("ajax/ajax_Momo.php", "date_s="+date_s, function (json) {
							if (json['status'] != 0) {
								//swal("Xảy ra lỗi!", json.msg, "error");
								window.swal({
									title: json.msg,
									showConfirmButton: false,
									timer: 500
								});
								//location.reload();
							} else {
								//swal("Thành công!", json.msg, "success");
								window.swal({
									title: json.msg,
									showConfirmButton: false,
									timer: 500
								});
								location.reload();
								//setTimeout(function() {
								//	location.reload();
								//}, 500);
							}
						}, 'json');
				}
			});
        });
		
		$(document).on('click','#CheckMOMO',function(e){
			e.preventDefault();
			var date_s = $('#check_dates').val();
			swal({
				title: "Muốn cập nhật thông tin MOMO?",
				text: ""+date_s,
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Đồng ý",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					window.swal({
						title: "Loading...",
						text: "Please wait",
						imageUrl: "images/loading.gif",
						showConfirmButton: false,
						allowOutsideClick: false
					});
					$.post("ajax/ajax_CheckCK.php", "date_s="+date_s, function (json) {
							if (json['status'] != 0) {
								//swal("Xảy ra lỗi!", json.msg, "error");
								window.swal({
									title: json.msg,
									showConfirmButton: false,
									timer: 500
								});
								//location.reload();
							} else {
								//swal("Thành công!", json.msg, "success");
								window.swal({
									title: json.msg,
									showConfirmButton: false,
									timer: 500
								});
								location.reload();
								//setTimeout(function() {
								//	location.reload();
								//}, 500);
							}
						}, 'json');
				}
			});
        });
    </script>
	
	<!-- Danh sách shop-->	 
	<script>
            
    </script>
	<script>
        $(document).on('click','#getEditShop',function(e){
            e.preventDefault();
			var id=$(this).data('id');
            var user=$(this).data('user');
            $('#content-data').html('');
            $.ajax({
                url:'mod/box_Edit_Shop.php',
                type:'POST',
                data:'id='+id,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
		
		
		$(document).on('click','#getBanShop',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn chỉnh bán ID " + del_id + "?",
				text: "",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Xóa",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Ban_Shop.php", "del_id="+del_id+"&fun=2", function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
		$(document).on('click','#getHuyBanShop',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn hủy bán ID " + del_id + "?",
				text: "",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Xóa",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Ban_Shop.php", "del_id="+del_id+"&fun=1", function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
		
		$(document).on('click','#getLockCk',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn Khóa ID " + del_id + "?",
				text: "Sau khi Khóa sẽ không thể phục hồi!",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Khóa",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Lock_Bank.php", "del_id="+del_id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								//swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 100);
							}
						}, 'json');
				}
			});
        });
		
		$(document).on('click','#getLockRole',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn Khóa ID " + del_id + "?",
				text: "Sau khi Khóa sẽ không thể phục hồi!",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Khóa",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Lock_Role.php", "del_id="+del_id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								//swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 100);
							}
						}, 'json');
				}
			});
        });
		
		$(document).on('click','#getEditRole',function(e){
			e.preventDefault();
			var index=$(this).data('index');
			var id=$(this).data('id');

			var aTable = $('#dataTables-role').DataTable();
			var cell = aTable.cell({ row: index, column: 8 }).node();
			var colAchange = $('input', cell).val();
			//var colAchange = aTable.cell(index,8).data();
			//var colAchange = $('input', colAchange).val();
			swal({
				title: "Muốn ghi chú ID " + colAchange + "?",
				text: "",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Lưu",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Edit_Role.php", "id="+id+"&ghichu="+colAchange, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								//swal("Thành công!", json.msg, "success");
									setTimeout(function() {
									location.reload();
								}, 100);
							}
						}, 'json');
				}
			});
        });
    </script>
	
	<script>
		
		$(document).on('click','#getDuyetCard',function(e){
			e.preventDefault();
			var del_id=$(this).data('id');
			swal({
				title: "Muốn duyệt Card ID " + del_id + "?",
				text: "",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Duyệt",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajax_Duyet_Card.php", "del_id="+del_id, function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });
    </script>
	

	<!-- Chức năng bài viết-->
	<script>
		$(document).on('click','#getEditBaiViet',function(e){
            e.preventDefault();
			var id=$(this).data('id');
			var danhmuc=$(this).data('danhmuc');
            $('#content-data').html('');
            $.ajax({
                url:'mod/box_Edit_DS_BaiViet.php',
                type:'POST',
                data:'id='+id+'&danhmuc='+danhmuc,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
		
		
		$(document).on('click','#add_baiviet',function(e){
            e.preventDefault();
			var id=$(this).data('id');
            var danhmuc=$(this).data('danhmuc');
            $('#content-data').html('');
            $.ajax({
                url:'mod/box_Edit_DS_BaiViet.php',
                type:'POST',
                data:'id='+id+'&danhmuc='+danhmuc,
                dataType:'html'
            }).done(function(data){
                $('#content-data').html('');
                $('#content-data').html(data);
            }).fial(function(){
                $('#content-data').html('<p>Error</p>');
            });
        });
		
		
		$(document).on('click','#dangxuat_admin',function(e){
			e.preventDefault();
			swal({
				title: "Muốn xóa đăng xuất?",
				text: "Thoát tài khoản",
				type: "warning",
				showCancelButton: true,
				confirmButtonColor: "#DD6B55",
				confirmButtonText: "Đăng xuất",
				cancelButtonText: "Hủy",
				closeOnConfirm: false,
				closeOnCancel: false
			}).then((result) => {
				if (result.value) {
					$.post("ajax/ajaxLogout.php", "id=0", function (json) {
							if (json['status'] != 0) {
								swal("Xảy ra lỗi!", json.msg, "error");
							} else {
								swal("Thành công!", json.msg, "success");
								setTimeout(function() {
									location.reload();
								}, 500);
							}
						}, 'json');
				}
			});
        });

    </script>
	
	
	<!-- Danh sách doanh thu-->
	<script>
            $(document).ready(function() {
				 $('#search_card_v').click(function(){
					var start_date = $('#start_date').val();
					var end_date = $('#end_date').val();
					$('#dataTables-doanhthu').DataTable().destroy();
					
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data('yes', start_date, end_date);
				});
				fetch_data('no');
            
				function fetch_data(is_date_search, start_date='', end_date='')
				{
				var dataTable = $('#dataTables-doanhthu').DataTable( {
					stateSave: true,
					"footerCallback": function ( row, data, start, end, display ) {
						var api = this.api(), data;
						// converting to interger to find total
						var intVal = function ( i ) {
							return typeof i === 'string' ?
								i.replace(/[\$,]/g, '')*1 :
								typeof i === 'number' ?
									i : 0;
						};
						var cot2Total = api.column( 1 ).data().reduce( function (a, b) {
									return intVal(a) + intVal(b);
						}, 0 );
						$( api.column( 0 ).footer() ).html('Tổng');
						$( api.column( 1 ).footer() ).html(cot2Total.toLocaleString('en-US'));
					},
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthChange": false ,
					"searching": false,
					"bInfo" : false,
					"paging": false,
                    "ajax":{
                        url :"ajax/ajax_Danhsachdoanhthu.php",
                        type: "post", 
						data:{
							is_date_search:is_date_search, start_date:start_date, end_date:end_date
						},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    }
                } );
				}
			});
			
			$(document).ready(function() {
				 $('#search_card').click(function(){
					var start_date = $('#start_date').val();
					var end_date = $('#end_date').val();
					$('#dataTables-doanhthu2').DataTable().destroy();
					
					var check1 = parseInt(start_date.substring(6, 11)+start_date.substring(3, 5)+start_date.substring(0, 2));
					var check2 = parseInt(end_date.substring(6, 11)+end_date.substring(3, 5)+end_date.substring(0, 2));
					if(check2 < check1)
						swal("Xảy ra lỗi!", "Chọn ngày không hợp lệ!!", "error");
					else
						fetch_data('yes', start_date, end_date);
				});
				fetch_data('no');
            
				function fetch_data(is_date_search, start_date='', end_date='')
				{
				var dataTable = $('#dataTables-doanhthu2').DataTable( {
					stateSave: true,
					"footerCallback": function ( row, data, start, end, display ) {
						var api = this.api(), data;
						// converting to interger to find total
						var intVal = function ( i ) {
							return typeof i === 'string' ?
								i.replace(/[\$,]/g, '')*1 :
								typeof i === 'number' ?
									i : 0;
						};
						var cot2Total = api.column( 1 ).data().reduce( function (a, b) {
									return intVal(a) + intVal(b);
								}, 0 );
							$( api.column( 0 ).footer() ).html('Tổng');
							$( api.column( 1 ).footer() ).html(cot2Total.toLocaleString('en-US'));
					},
                    "processing": true,		
					"language": {processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span> '},
                    "serverSide": true,
					"lengthMenu": [[1,], [1]],
                    "ajax":{
                        url :"ajax/ajax_Danhsachdoanhthu2.php",
                        type: "post", 
						data:{
							is_date_search:is_date_search, start_date:start_date, end_date:end_date
						},
                        error: function(){
                            $(".grid-error").html("");
                            $("#grid").append('<tbody class="employee-grid-error"><tr><th colspan="3">No data found in the server</th></tr></tbody>');
                            $("#grid_processing").css("display","none");

                        }
                    }
                } );
				}
			});
    </script>

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
var typedata = "";
switch (typedata){
	case "danhsachtaikhoan" :
		LoadDataTable("dataTables-taikhoan","ajax_danhsachtaikhoan.php");
		LoadClick("getEditInfo","box_Edit_Acc.php");
		LoadClick("getEditPoint","box_Edit_Point.php");
		break;
	case "danhsachchuyenkhoan" :
		fetch_data_chuyenkhoan('no');
		LoadClick("add_ck","box_Edit_Bank.php");
		LoadClick("getEditCk","box_Edit_Bank.php");
		XoaItem("getDelCk","ajax_Del_Bank.php");
		ThuHoi("getThuHoiCk","ajax_Reset_Bank.php");
		break;
	case "doitennhanvat" :
		fetch_data_doitennv('no');
		break;
	case "danhsachcard" :
		var tbdata = {"is_date_search":"no","start_date":"","end_date":"","status":"",};
		fetch_data_card('dataTables-card','ajax_danhsachcard.php',tbdata);
		LoadClick("getEditCard","box_Edit_Card.php");
		LoadClick("add_card","box_Edit_Card.php");
		XoaItem("getDelCard","ajax_Del_Card.php");
		break;
	case "danhsachshop" :	
		XoaItem("getDelShop","ajax_Del_Shop.php");
		break;
	case "tintuc" :
		var tbdata = {"danhmuc":"vn_tintuc","is_search":"no",};
		LoadDataTable('dataTables-tintuc',"ajax_Load_BaiViet.php",tbdata);
		XoaItem("getDelBaiViet","ajax_Del_BaiViet.php");
		break;
	case "huongdan" :
		var tbdata = {"danhmuc":"vn_huongdan","is_search":"no",};
		LoadDataTable('dataTables-huongdan',"ajax_Load_BaiViet.php",tbdata);
		XoaItem("getDelBaiViet","ajax_Del_BaiViet.php");
		break;
	case "tinhnang" :
		var tbdata = {"danhmuc":"vn_tinhnang","is_search":"no",};
		LoadDataTable('dataTables-sukien',"ajax_Load_BaiViet.php",tbdata);
		XoaItem("getDelBaiViet","ajax_Del_BaiViet.php");
		break;
	case "logmomo":
		fetch_data_momo('no');
		break;
	case "danhsachrutxu":
		fetch_data_rutxu('no');
		break;
	case "danhsachgiaodich":	
		fetch_data_giaodich('no');
		break;
	case "danhsachshop" :
		LoadDataTable("dataTables-shop","ajax_Danhsachshop.php");
		break;
	case "danhsachlogadmin" :
		fetch_data_admin('no');
		break;
	default  : 
		DoThi("chart_ngay_1",1,1);
		//DoThi("chart_ngay_2",2,1);
		DoThi("chart_thang_1",1,2);
		//DoThi("chart_thang_2",2,2);
		load_home(1,1);
		//load_home(2,1);
		break;
}
			
function load_home(ver,type)
{
			$.ajax({
				type: 'POST',
				url: 'ajax/ajaxHome.php',       
				data: {type : type,ver : ver}, 
				dataType: 'json', //data format      
				success: function (data) {
					$('#total_user'+ver).html(''+data.total_user);
					$('#total_user_date'+ver).html(''+data.total_user_date);
					$('#total_card'+ver).html(''+data.total_card);
					$('#total_card_count'+ver).html(''+data.total_card_count);
					$('#total_momo'+ver).html(''+data.total_momo);
					$('#total_momo_count'+ver).html(''+data.total_momo_count);
					$('#total_bank'+ver).html(''+data.total_bank);
					$('#total_bank_count'+ver).html(''+data.total_bank_count);
				}
			});
}
		
function DoThi(type,ver,loai) {
	$.getJSON("ajax/ajaxBarChart.php?ver="+ver+"&type="+loai, function (result) {
		var chart = new CanvasJS.Chart(type, {
	exportEnabled: true,
	animationEnabled: true,
	title:{
		text: ""
	},
	subtitles: [{
		text: ""
	}], 
	axisX: {
		valueFormatString: "#,###,.##K",
		title: ""
	},
	axisY: {
		valueFormatString: "#,###,.##K",
		title: "Doanh thu Card,Momo,Bank (triệu đồng)",
		titleFontColor: "#4F81BC",
		lineColor: "#4F81BC",
		labelFontColor: "#4F81BC",
		tickColor: "#4F81BC",
		includeZero: true
	},
	axisY2: {
		valueFormatString: "#,##0.##",
		title: "Users đăng ký",
		titleFontColor: "#C0504E",
		lineColor: "#C0504E",
		labelFontColor: "#C0504E",
		tickColor: "#C0504E",
		includeZero: true
	},
	toolTip: {
		shared: true
	},
	legend: {
		cursor: "pointer",
		itemclick: toggleDataSeries
	},
	data: [
	{
		type: "column",
		name: "Card",
		indexLabel: "{y}",
		showInLegend: true,      
		yValueFormatString: "#,###,.##",
		dataPoints: result[0]
	},
	{
		type: "column",
		name: "Momo,Bank",
		indexLabel: "{y}",
		//axisYType: "secondary",
		showInLegend: true,
		yValueFormatString: "#,###,.##",
		dataPoints: result[1]
	},
	/*{
		type: "line",
		name: "Users",
		indexLabel: "{y}",
		axisYType: "secondary",
		showInLegend: true,
		yValueFormatString: "#,##0.##",
		dataPoints: result[2]
	},*/
	]
});
chart.render();
    });
}
function toggleDataSeries(e) {
	if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
		e.dataSeries.visible = false;
	} else {
		e.dataSeries.visible = true;
	}
	e.chart.render();
}
</script>

<script>
//$('#dataTables-card').tableTotal();
</script>
</body>
    <jsp:include page = "./footer/footer.jsp" flush = "true" />
</html>