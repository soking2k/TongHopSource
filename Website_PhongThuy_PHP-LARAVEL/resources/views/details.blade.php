    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Phong Thủy Tinh Sơn Tinh</title>

        <!-- Font awesome -->
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.13.0/css/all.css"
              integrity="sha384-Bfad6CLCknfcloXFOyFnlgtENryhrpZCe29RTifKEixXQZ38WheV+i/6YWSzkz3V" crossorigin="anonymous">
        <link href="../../resources/Content/test/view/client/assets/css/font-awesome.css" rel="stylesheet">

        <!-- Bootstrap -->
        <link href="../../resources/Content/test/view/client/assets/css/bootstrap.css" rel="stylesheet">
        <link rel="icon" href="../../resources/Content/test/view/client/assets/images/favicon.png" type="image/x-icon">
        <!-- SmartMenus jQuery Bootstrap Addon CSS -->
        <link href="../../resources/Content/test/view/client/assets/css/jquery.smartmenus.bootstrap.css" rel="stylesheet">
        <!-- Product view slider -->
        <link rel="stylesheet" type="text/css" href="../../resources/Content/test/view/client/assets/css/jquery.simpleLens.css">
        <!-- slick slider -->
        <link rel="stylesheet" type="text/css" href="../../resources/Content/test/view/client/assets/css/slick.css">
        <!-- price picker slider -->
        <link rel="stylesheet" type="text/css" href="../../resources/Content/test/view/client/assets/css/nouislider.css">
        <!-- Theme color -->
        <link id="switcher" href="../../resources/Content/test/view/client/assets/css/theme-color/default-theme.css" rel="stylesheet">

        <!-- Top Slider CSS -->
        <link href="../../resources/Content/test/view/client/assets/css/sequence-theme.modern-slide-in.css" rel="stylesheet" media="all">

        <!-- Main style sheet -->
        <link href="../../resources/Content/test/view/client/assets/css/style.css" rel="stylesheet">

        <!-- Google Font -->
        <link href='https://fonts.googleapis.com/css?family=Lato' rel='stylesheet' type='text/css'>
        <link href='https://fonts.googleapis.com/css?family=Raleway' rel='stylesheet' type='text/css'>
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">


        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    </head>
    <header id="aa-header">
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
                                        <p><span class="fas fa-home"></span>Phong Thủy Tinh Sơn Tinh</p>
                                    </div>
                                    <div class="aa-cartbox">

                                        <a class="aa-cart-link" href="/cart">
                                            <span class="fas fa-cart-arrow-down"></span>
                                            <span class="aa-cart-title">GIỎ HÀNG</span>




                                        </a>

                                    </div>


                                    <!-- start cellphone -->
                                    <!--                <div class="cellphone hidden-xs">
                                  <p><span class="fa fa-phone"></span>00-62-658-658</p>
                                </div>-->
                                    <!-- / cellphone -->

                                </div>
                               
                                  
                                        <div class="aa-header-top-right">
                                            <ul class="aa-head-top-nav-right">

                                                <div class="flex justify-end">
                                                    <a class="btn btn-primary rounded-full f-14 py-2" href="/login">
                                                        Đăng nhập
                                                    </a>
                                                    <a class="btn btn-primary rounded-full f-14 py-2" href="/Login/Register">
                                                        Đăng Ký
                                                    </a>
                                                </div>
                                                <!--  data-toggle="modal" data-target="#login-modal" -->
                                            </ul>
                                        </div>
                                   
                                        <div class="aa-header-top-right">

                                            <div class="dropdown">
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">

                                                  <!--  Xin Chào: @Session["usersname"]
                                                    <span class="caret"></span>-->
                                                </a>
                                                <ul class="dropdown-menu">
                                                    <li><a href="@Url.Action("Index","Cart")">Giỏ Hàng Hiện Tại</a></li>
                                                    <li><a href="@Url.Action("XemDonHang","Cart")">Chi Tiết Đơn Hàng</a></li>
                                                    <li><a href="@Url.Action("Create","Home")">Tạo Bài Viết (FeedBack)</a></li>
                                                    <li><a href="#">Liên Hệ</a></li>

                                                    <li role="separator" class="divider"></li>
                                                    <li><a href="@Url.Action("Logout","Home")">Đăng Xuất</a></li>
                                                
                                                </ul>
                                            </div>
                                        </div>
                               
                                <!-- / header top left -->

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- / header top  -->
        <!-- start header bottom  -->
        <!-- / header bottom  -->
        <!-- Messenger Plugin chat Code -->
        <div id="fb-root"></div>

        <!-- Your Plugin chat code -->
        <div id="fb-customer-chat" class="fb-customerchat">
        </div>

        <script>
            var chatbox = document.getElementById('fb-customer-chat');
            chatbox.setAttribute("page_id", "101875105678239");
            chatbox.setAttribute("attribution", "biz_inbox");
        </script>

        <!-- Your SDK code -->
        <script>
            window.fbAsyncInit = function () {
                FB.init({
                    xfbml: true,
                    version: 'v12.0'
                });
            };

            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = 'https://connect.facebook.net/vi_VN/sdk/xfbml.customerchat.js';
                fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk'));
        </script>
    </header>
    <section id="menu">
        <div class="container">
            <div class="menu-area">
                <!-- Navbar -->
                <div class="navbar navbar-default" role="navigation">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>

                    <div class="navbar-collapse collapse">

                        <!-- Text based logo -->
                        <!--
                                <!-- img based logo -->
                        <!-- Left nav -->
                        <ul class="nav navbar-nav">

                            <li><a href="/">TRANG CHỦ</a></li>
                            <li><a href="@Url.Action("GioiThieu","Home")">GIỚI THIỆU</a></li>
                            <li>
                                <a href="/">SẢN PHẨM</span></a>
                            </li>
                            <li><a href="@Url.Action("ChinhSach","Home")">CHÍNH SÁCH</a></li>
                            <li><a href="http://messenger.com/t/lieuthienthach/">LIÊN HỆ</a></li>
                            <li><a href="@Url.Action("TinTuc","Home")">PHẢN HỒI KHÁCH HÀNG</a></li>


                            <li class="aa-search">
                                <!-- search box -->
                                <a class="aa-search-box">
                                    <form action="/Home/TimKiem/" method="GET">
                                        <input type="text" name="s" id="" placeholder="Tìm kiếm sản phẩm..">
                                        <button class="serach-box"><span class="fa fa-search"></span></button>
                                    </form>
                                    <!-- Tìm kiếm sản phẩm
                                    @using (Html.BeginForm())
                                    {
                                        @Html.AntiForgeryToken()
                                        @Html.ValidationSummary(true, "", new { @class = "text-danger" })

                                    }
                                -->
                                </a>
                                <!-- / search box -->
                            </li>
                        </ul>
                    </div><!--/.nav-collapse -->

                </div>
            </div>
        </div>
    </section>

    <!-- / menu -->
    <!-- SCROLL TOP BUTTON -->
    <a class="scrollToTop" href="#"><i class="fa fa-chevron-up"></i></a>
    <!-- END SCROLL TOP BUTTON -->
    <!-- / header section -->
    <section id="aa-catg-head-banner">
        <img src="../../resources/Content/test/view/client/assets/images/banner-product.png" alt="banner sản phẩm">
        <div class="aa-catg-head-banner-area">
            <div class="container">
                <div class="aa-catg-head-banner-content">
                    <h2>Phong Thủy Tinh Sơn Tinh</h2>
                </div>
            </div>
        </div>
    </section>
    <hr />

    <body>

    <!-- / catg header banner section -->
    <!-- product category -->
    <section id="aa-product-details">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="aa-product-details-area">
                        <div class="aa-product-details-content">
                            <div class="row">
                                <!-- Modal view slider -->

                                <div class="col-md-5 col-sm-5 col-xs-12">
                                    <div class="aa-product-view-slider">
                                        <div id="demo-1" class="simpleLens-gallery-container">
                                            <div class="simpleLens-container">
                                                <div class="simpleLens-big-image-container"><a data-lens-image="../../resources/Content/images/{{ $data->image_link }}" class="simpleLens-lens-image"><img src="../../resources/Content/images/{{ $data->image_link }}" class="simpleLens-big-image"></a></div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- Modal view content -->

                                <div class="col-md-7 col-sm-7 col-xs-12">
                                    <div class="aa-product-view-content">
                                        <h3>
                                            {{ $data->name }}
                                        </h3>
                                        <div class="aa-price-block">



                                        <span class="aa-product-price">
                                        <?php $format_number_1 = number_format($data->price); ?>

                                            {{ $format_number_1}} VND
                                            </span><span class="aa-product-price"></span>



                                            <p class="aa-product-avilability">
                                                Tình trạng: <span>


                                                    <b>   <font color="red">Còn Hàng</font></b>



                                                </span>
                                            </p>
                                        </div>
                                        <p> {{ $data->description }}</p>

                                        <div class="aa-prod-view-bottom">
                                            <a class="aa-add-to-cart-btn" href="~/Cart/AddItem?id=@Html.DisplayFor(model => model.id)">Thêm vào giỏ hàng</a>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="aa-product-details-bottom">
                            <ul class="nav nav-tabs aa-products-tab" id="myTab2">
                                <li class="active"><a href="#description" data-toggle="tab" class="">Mô tả</a></li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="description">
                                {{ $data->content }}
                                </div>
                            </div>
                            <!-- Related product -->
                            <div class="aa-product-related-item">
                                <h3>SẢN PHẨM GỢI Ý</h3>
                                <section id="aa-product">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="aa-product-area">
                                                        <div class="aa-product-inner">
                                                            <ul class="nav nav-tabs aa-products-tab"></ul>
                                                            <div class="tab-content">
                                                                <div class="tab-pane fade in active" id="sanphammoi">
                                                                    <ul class="aa-product-catg">
                                                                 
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                </div>
    </section>

</body>
    <footer id="aa-footer">
        <!-- footer bottom -->
        <div class="aa-footer-top">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="aa-footer-top-area">
                            <div class="row">
                                <div class="col-md-4 col-sm-6">
                                    <div class="aa-footer-widget">
                                        <h3>PHONG THUỶ TINH SƠN TINH</h3>
                                        <ul class="aa-footer-nav">

                                            <li><p style="color:#888; text-align: justify; width: 95%">92 Huyền Trân Công Chúa Hòa Hải, Ngũ Hành Sơn Đà Nẵng..</p></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <div class="aa-footer-widget">
                                        <div class="aa-footer-widget">
                                            <h3>TƯ VẤN MUA HÀNG</h3>
                                            <ul class="aa-footer-nav">
                                                <li><p style="color:#ffffff; text-align: justify; width: 95%">Hotline:</p></li>
                                                <li><p style="color:#888; text-align: justify; width: 95%">0847.8888.27</p></li>
                                                <li><p style="color:#888; text-align: justify; width: 95%">0384.539.458</p></li>
                                                <li><p style="color:#ffffff; text-align: justify; width: 95%">Zalo:</p></li>
                                                <li><p style="color:#888; text-align: justify; width: 95%">0384.539.458</p></li>
                                                <li><p style="color:#888; text-align: justify; width: 95%">079.591.4327</p></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6">
                                    <div class="aa-footer-widget">
                                        <div class="aa-footer-widget">
                                            <h3>THÔNG TIN CHUYỂN KHOẢN</h3>
                                            <address>
                                                <p>Chủ Tài Khoản: PHAM THE BAO</p>
                                                <p>Số Tài Khoản: 6028117</p>
                                                <p>Ngân Hàng Á Châu ACB</p>
                                            </address>
                                            <address>
                                                <p>Chủ Tài Khoản: PHAM THE BAO</p>
                                                <p>Số Tài Khoản: 56510000308376</p>
                                                <p>Ngân Hàng BIDV Đà Nẵng</p>
                                            </address>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </footer>

    </html>
