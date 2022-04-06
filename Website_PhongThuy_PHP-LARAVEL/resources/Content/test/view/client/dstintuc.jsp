<%-- 
    Document   : index
    Created on : May 5, 2020, 10:57:00 PM
    Author     : LENOVO
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ taglib uri = "http://java.sun.com/jsp/jstl/core" prefix = "c" %>
<c:url value = "/view/client/assets" var="url"/>

  <!-- Start header section -->
  <jsp:include page = "./header/mainHeader.jsp" flush = "true" />
  <!-- / header section -->
    <section id="aa-catg-head-banner">
      <img src="${pageContext.request.contextPath}/view/client/assets/images/banner-product.png" alt="banner sản phẩm">
   <div class="aa-catg-head-banner-area">
     <div class="container">
      <div class="aa-catg-head-banner-content">
        <h2>Phong Thủy Diệp Tâm</h2>
      </div>
     </div>
   </div>
  </section>
<!--  content -->
  <!-- catg header banner section -->

  <!-- / catg header banner section -->

  <!-- Blog Archive -->
  <section id="aa-blog-archive">
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <div class="aa-blog-archive-area">
            <div class="row">
              <div class="col-md-12">
                <div class="aa-blog-content">
                  <div class="row">
                  <c:forEach items="${tintuclist}" var="tintuc">
                    <div class="col-md-4 col-sm-4">
                      <article class="aa-blog-content-single">                        
                        <h4><a href="${pageContext.request.contextPath}/view/client/news-list-detail?id=${tintuc.id}">${tintuc.title}</a></h4>
                        <figure class="aa-blog-img">
                          <a href="${pageContext.request.contextPath}/view/client/news-list-detail?id=${tintuc.id}"><img src="${pageContext.request.contextPath}/view/client/assets/images/news/${tintuc.image_link}" alt="farm products" height="180px" width="300px"></a>
                        </figure>
                        <p class="desc-tintucs">${tintuc.content}</p>
                        <div class="aa-article-bottom">
                          <div class="aa-post-author">
                            Đăng bởi <a href="#">${tintuc.author}</a>
                          </div>
                          <div class="aa-post-date">${tintuc.created}</div>
                        </div>
                      </article>
                    </div>
                    </c:forEach>
                  </div>
                </div>
                <!-- Blog Pagination -->
               
              </div>
             
            </div>
          </div>
        </div>
      </div>
	</div>
  </section>
  <!-- / Blog Archive -->

<!--  end content-->
  
<!--  footer-->
 <jsp:include page = "./footer/footer.jsp" flush = "true" />
<!-- end footer-->
  
  
