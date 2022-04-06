<html>
<head>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
</head>   
<body>  
<div class="container"> 
    <div class="row" style="margin-bottom: 20px;">
        <div class="col-lg-12 margin-tb">
            <div class="pull-left">
                <h3>Sửa thành viên</h3>
            </div>
        </div>
    </div>

    <form action="{{ route('update',$data->id) }}" method="POST">
        {{ csrf_field() }}

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="form-group">
                    <strong>Username:</strong>
                    <input type="text" name="username" value="{{ $data->name }}" class="form-control">
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="form-group">
                    <strong>Mật khẩu:</strong>
                    <input type="text" name="password" value="{{ $data->id_loaisp }}" class="form-control">
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 text-center">
                <button type="submit" class="btn btn-success">Cập nhật</button>
            </div>
        </div>

    </form>

</div>
</body>
</html>