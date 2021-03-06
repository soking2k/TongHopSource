<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<c:url value ="/view/admin/assets" var="url"/>
<%
  response.setHeader("Cache-control", "no-cache, no-store, must-revalidate");
  response.setHeader("Pragma" , "no-cache");
  response.setHeader("Expires" , "0");
  
  
  if (session.getAttribute("admin-username") != null){
	  response.sendRedirect(request.getContextPath() + "/view/admin/homepage");
  }
  %>
<!DOCTYPE html>
<html lang="en">
 <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>Startmin - Bootstrap Admin Theme</title>
        <!-- Bootstrap Core CSS -->
        <link href="./css/bootstrap.min.css" rel="stylesheet">
        <!-- MetisMenu CSS -->
        <link href="./css/metisMenu.min.css" rel="stylesheet">
        <!-- Custom CSS -->
        <link href="./css/startmin.css" rel="stylesheet">
        <!-- Custom Fonts -->
        <link href="./css/font-awesome.min.css" rel="stylesheet" type="text/css">
		

		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		<link href="./css/bootstrap-dialog.min.css" rel="stylesheet" type="text/css" />
		<script src="./js/bootstrap-dialog.min.js"></script>
		<script src="./js/main.js"></script>
		
		
		        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
		        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
		        <!--[if lt IE 9]>
		        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
		        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
		        <![endif]-->
	</head>

 <body>
        <div class="container">
		<center><div id="skm_LockPane"></div></center>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="color: #298cc9;font-size: 22px;font-weight: bold;text-align: center;">????ng nh???p</h3>
                        </div>
                        <div class="panel-body">
                            <form action="${pageContext.request.contextPath}/view/admin/login"  method="post">
								  <div class="form-group">
								  <label for="exampleInputUsername" class="sr-only">Username</label>
								   <div class="position-relative has-icon-right">
									  <input type="text" id="exampleInputUsername" class="form-control input-shadow" placeholder="Username" name="admin-username" required>
									  <div class="form-control-position">
										  <i class="icon-user"></i>
									  </div>
								   </div>
								  </div>
								  <div class="form-group">
								  <label for="exampleInputPassword" class="sr-only">Password</label>
								   <div class="position-relative has-icon-right">
									  <input type="password" id="exampleInputPassword" class="form-control input-shadow" placeholder="Password" name="admin-password" required>
									  <div class="form-control-position">
										  <i class="icon-lock"></i>
									  </div>
								   </div>
								  </div>
								    <div class="checkbox">
                                        <label><input name="remember" type="checkbox" value="Remember Me">Remember Me</label>
                                    </div>
								  <div><b> <span style="color:#00d9e8"> ${errorMessage}</span></b></div>
								 <button type="submit" class="btn btn-primary btn-submit btn-block">????ng nh???p</button>
								 </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- jQuery -->
        <script src="./js/jquery.min.js"></script>
        <!-- Bootstrap Core JavaScript -->
        <script src="./js/bootstrap.min.js"></script>
        <!-- Metis Menu Plugin JavaScript -->
        <script src="./js/metisMenu.min.js"></script>
        <!-- Custom Theme JavaScript -->
        <script src="./js/startmin.js"></script>
		<script src="./js/jquery.form.js"></script> 
		<script>
            $(document).ready(function() {
                 // nap the
                $("#frm_1_l").ajaxForm({
                    dataType : 'json',
					url: 'ajax/ajaxLogin.php',
                    beforeSubmit : function() {
						$('#skm_LockPane').attr("class", "LockOn").html("Please wait a moment, do not close the window<br/><img src='./images/loading.gif' style='width: 70px;'>");
                    },
                    success: function(data) 
					{
                        if(data.code == 0) {
                            $("#frm_1_l").resetForm();
							APIMUMOBILE.alertTarget(data.msg, '');
                        }
                        else {
							BootstrapDialogError(data.msg);
                        }
						$('#skm_LockPane').attr("class", "LockOff");
						
                    }
                });
            });
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
    </body>
</html>
