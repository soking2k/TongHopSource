$(document).ready(function() 
{
	//--------------------------Chức năng key Enter Login-----------------------------------
    $('.keydown').keydown(function (e) {
        if (e.keyCode == 13){
            loginUser('#form-login','.kq-login');
        }
    });
	//--------------------------Chức năng key Enter Đăng ký-----------------------------------
    $('.keydown-rg').keydown(function (e) {
        if (e.keyCode == 13){
            registerUser('#form-register','.kq-rg');
        }
    });
	//---------------------Chức năng đổi mật khẩu cấp 1 ----------------------------
	//ajaxForm('#change_password1', 'ajax/ajaxPass1.php');
	 //---------------------Chức năng đổi mật khẩu cấp 2 ----------------------------
	//ajaxForm('#change_password2', 'ajax/ajaxPass2.php');
	 //---------------------Chức năng cập nhật thông tin ----------------------------
	//ajaxForm('#form-infomation', 'ajax/ajaxUpdateInfo.php');
});
function ajaxForm(form, url){
	                $(form).ajaxForm({
                    dataType : 'json',
                    url: url,
                    beforeSubmit : function() {
                        $("#loading_napthe").show();
                    },
                    success: function(data) {
                        if(data.code == 0) 
						{
							$(form).resetForm();
							$("#msg").html('<div class="alert alert-success btn-lg" role="alert"><span class="glyphicon glyphicon-ok-sign">&nbsp;</span><b>'+data.msg+'</b></div>');
							if(data.load == 1){setTimeout(function(){location.reload();},300);}
                        }
                        else {
							if(data.focus != ''){$(data.focus).focus();}
							$("#msg").html('<div class="alert alert-danger" role="alert"><span class="glyphicon glyphicon-remove-sign">&nbsp;</span><b>'+data.msg+'</b></div>');
                        }
                        $("#loading_napthe").hide();
                    }
                });
}



function ajax_post(page,url,id,flag)
{
	if (document.getElementById) {
		var x = (window.ActiveXObject) ? new ActiveXObject("Microsoft.XMLHTTP") : new XMLHttpRequest();
	}
	if (x)
	{
		x.onreadystatechange = function()
		{
			el = document.getElementById(id);
			//linkz = document.getElementById("linkz");
			//el.innerHTML = loadstatustext;
			//document.getElementById('loading').style.display = 'block';
			if (x.readyState == 4 && x.status == 200)
			{
				el.innerHTML = x.responseText;
				if(flag==1){
					setTimeout(' document.location=document.location' ,100);
				}
				//linkz.innerHTML = "Please F5.";
				//document.getElementById('loading').style.display = 'none';
			}
		}
	x.open("POST", page);
	x.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
	x.send(url);
	}
}

//-----------Dang xuat
function dangxuat() {
			var xacnhan=confirm('Bạn có đồng ý đăng xuất không ?');
			if (xacnhan==true)
				{
					var url='page=dangxuat';
					ajax_post('ajax/ajaxLogout.php?'+url,'','main_reg',1);
				}
				setTimeout(' document.location=document.location' ,1500);
		return false;
}