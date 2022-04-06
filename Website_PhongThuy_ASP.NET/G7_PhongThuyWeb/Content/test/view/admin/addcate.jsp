<%@page contentType="text/html" pageEncoding="UTF-8"%>
  <!-- Start header section -->
  <jsp:include page = "./header/header.jsp" flush = "true" />
    <div class="content-wrapper">
      <div class="container-fluid">

        <div class="row mt-3">
          <div class="col-lg-8">
            <div class="card">
              <div class="card-body">
                <div class="card-title">Thêm chuyên mục</div>
                <hr>
                <form action="${pageContext.request.contextPath}/view/admin/addcate" method="post">
                
                  <div class="form-group">
                    <label for="input-1">Tên chuyên mục</label>
                    <input type="text" class="form-control" id="input-1" placeholder="Tên chuyên mục" name="cate-name">
                  </div>
	              
                 <div class="form-footer">
                  <button type="submit" class="btn btn-success"><i class="fa fa-check-square-o"></i> Thêm</button>
               		<a href="${pageContext.request.contextPath}/view/admin/listcate" target="_self"><img class="pointer" style="cursor: pointer;" src="./img/huy.png">                    
                </div>
                </form>
              </div>
            </div>
          </div>
        </div>
        <div class="overlay toggle-menu"></div>
      </div>
    </div>
  
