﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
<link href="~/styles/font-awesome.css" rel="stylesheet" />
<link href="~/styles/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Spin Login Form </h1>
    <div class="clear-loading spinner">
        <span></span>
    </div>
    <div class="w3ls-login box box--big">
        <!-- form starts here -->
        <form action="#" method="post">
            <div class="agile-field-txt">
                <label><i class="fa fa-user" aria-hidden="true"></i> Username </label>
                <input type="text" name="name" placeholder="Enter User Name" required="" />
            </div>
            <div class="agile-field-txt">
                <label><i class="fa fa-unlock-alt" aria-hidden="true"></i> password </label>
                <input type="password" name="password" placeholder="Enter Password" required="" id="myInput" />
                <div class="agile_label">
                    <input id="check3" name="check3" type="checkbox" value="show password" onclick="myFunction()">
                    <label class="check" for="check3">Show password</label>
                </div>
                <div class="agile-right">
                    <a href="#">forgot password?</a>
                </div>
            </div>
            <!-- script for show password -->
            <script>
				function myFunction() {
					var x = document.getElementById("myInput");
					if (x.type === "password") {
						x.type = "text";
					} else {
						x.type = "password";
					}
				}
            </script>
            <!-- //end script -->
            <input type="submit" value="LOGIN">
        </form>
    </div>
    <!-- //form ends here -->
    <!--copyright-->
    <div class="copy-wthree">
        <p>
            © 2018 Spin Login Form . All Rights Reserved | Design by
            <a href="http://w3layouts.com/" target="_blank">W3layouts</a>
        </p>
    </div>
    <!--//copyright-->
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
