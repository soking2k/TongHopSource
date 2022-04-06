<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>
<c:url value = "/view/client/assets" var="url"/>
         <!-- start header top  -->
    <div class="aa-header-top">
             <div class="aa-header-bottom">
    
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <div class="aa-header-top-area">
              <!-- start header top left -->
              <div class="aa-header-top-left">
                <div class="cellphone hidden-xs">
                  <p><span class="fas fa-home"></span>Phong Thủy Diệp Tâm</p>
                </div>
             <div class="aa-cartbox">
                <a class="aa-cart-link" href="${pageContext.request.contextPath}/view/client/cart">
                  <span class="fas fa-cart-arrow-down"></span>
                  <span class="aa-cart-title">GIỎ HÀNG</span>
                 
                  <c:if test="${length_order != NULL}">
                  	<span class="aa-cart-notify">${length_order}</span>
                  </c:if>
                  

                </a>
                <div class="aa-cartbox-summary">
                  <ul class="scroll-product">
                  <c:forEach items="${order.items}" var="item" >
                    <li>
                      <a class="aa-cartbox-img" href="${pageContext.request.contextPath}/view/client/cart"><img src="${pageContext.request.contextPath}/view/client/assets/images/products/img-test/${item.product.image_link}" alt="img"></a>
                      <div class="aa-cartbox-info">
                        <h4><a href="${pageContext.request.contextPath}/view/client/cart">${item.product.name}</a></h4>
                        <p>${item.qty} x ${item.product.price * (1-((item.product.discount)/100))}00 VNĐ</p>
                      </div>
                    </li>
                   	</c:forEach>               
                  </ul>
                  <div class="total-detailproduct">
                  		<span class="aa-cartbox-total-title">
                        <b>Tổng:</b>
                      </span>
                      <span class="aa-cartbox-total-price">
                        ${sumprice} VNĐ
                      </span>
                  </div>
                  <a class="aa-cartbox-checkout aa-primary-btn" href="${pageContext.request.contextPath}/view/client/cart">Chi tiết</a>
                  <a class="aa-cartbox-checkout aa-primary-btn" href="${pageContext.request.contextPath}/view/client/checkout">Thanh toán</a>
                </div>
              </div>
              
                <!-- start cellphone -->
<!--                <div class="cellphone hidden-xs">
                  <p><span class="fa fa-phone"></span>00-62-658-658</p>
                </div>-->
                <!-- / cellphone -->
              </div>
              <!-- / header top left -->
              <div class="aa-header-top-right">
                <ul class="aa-head-top-nav-right">
               
	                <c:if test="${sessionScope.username != null}">
	                 <li>
						<a><strong>Chào</strong> ${username }</a>
					</li>
					<li class="hidden-xs"><a href="${pageContext.request.contextPath}/view/client/logout">Đăng xuất</a></li>
					</c:if>
				
				 <c:if test="${sessionScope.username == null}">
       <div class="flex justify-end">
      <a class="btn btn-primary rounded-full f-14 py-2" href="${pageContext.request.contextPath}/view/client/login" >
        Đăng nhập      </a>
      <a class="btn btn-primary rounded-full f-14 py-2" href="${pageContext.request.contextPath}/view/client/register" >
        Đăng Ký      </a>
    </div>	          
    
        
	              </c:if>
                  
                   <!--  data-toggle="modal" data-target="#login-modal" -->
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    </div>
    <!-- / header top  -->
