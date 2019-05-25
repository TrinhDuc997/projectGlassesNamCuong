$(document).ready(function(){

/******** Menu Show Hide Sub Menu ********/
$('#menu > ul > li').mouseover(function() {
			$screensize = $(window).width();
			if ($screensize > 801) {
			$(this).find('> div').css('display', 'block');
			}			
			$(this).bind('mouseleave', function() {
				$screensize = $(window).width();
			if ($screensize > 801) {
				$(this).find('> div').css('display', 'none');
			}
		});
			});
/******** Navigation Menu **********/
$('#menu > span').click(function () {
	  $(this).toggleClass("active");  
	  $(this).parent().find("> ul").slideToggle('medium');
	});

/******** Accordion **********/
$('.accordion-heading, .checkout-heading').live('click', function() {
	$('.accordion-content, .checkout-content').slideUp('slow');
	$(this).parent().find('.accordion-content, .checkout-content').slideDown('slow');
});

/******** Footer Link **********/
$(".column h3").click(function () {
			$screensize = $(window).width();
			if ($screensize < 801) {
				$(this).toggleClass("active");  
				$(this).parent().find("ul").slideToggle('medium');
			}
		});

/******** Span wrap in Title Heading **********/
$('.box-heading').wrapInner('<span></span>')

/******** Colorbox **********/

		$('.colorbox').colorbox({
			overlayClose: true,
			opacity: 0.8,
			maxHeight: 550,
			maxWidth: 550,
			width:'100%'
		});

/******** Tabs **********/
$('#tabs a').tabs();

/******** plus mines button in qty **********/
$(".qtyBtn").click(function(){
		if($(this).hasClass("plus")){
			var qty = $("#qty").val();
			qty++;
			$("#qty").val(qty);
		}else{
			var qty = $("#qty").val();
			qty--;
			if(qty>0){
				$("#qty").val(qty);
			}
		}
	});

/******** Ajax Cart **********/
	$('#cart > .heading a').live('click', function() {
		$('#cart').addClass('active');		
		$('#cart').live('mouseleave', function() {
			$(this).removeClass('active');
		});
	});
	
/******** Mega Menu **********/
	$('#menu ul > li > a + div').each(function(index, element) {
		// IE6 & IE7 Fixes
		if ($.browser.msie && ($.browser.version == 7 || $.browser.version == 6)) {
			var category = $(element).find('a');
			var columns = $(element).find('ul').length;
			
			$(element).css('width', (columns * 143) + 'px');
			$(element).find('ul').css('float', 'left');
		}		
		
		var menu = $('#menu').offset();
		var dropdown = $(this).parent().offset();
		
		i = (dropdown.left + $(this).outerWidth()) - (menu.left + $('#menu').outerWidth());
		
		if (i > 0) {
			$(this).css('margin-left', '-' + (i + 5) + 'px');
		}
	});
	
/********Category Accordion **********/
$(document).ready(function() {
	$('#custom_accordion').customAccordion({
		classExpand : 'cid0',
		menuClose: false,
		autoClose: true,
		saveState: false,
		disableLink: false,		
		autoExpand: true
	});
});

/******** Carousel **********/
$('#carousel ul').jcarousel({
	vertical: false,
	visible: 5,
	scroll: 3
});
    /******************* Dang Nhap Binh Luan******************/

$("#btnDangNhapBL").click(function () {
    $("#DangNhapBinhLuan").css({ "display": "none" });
    $("#frmDangNhapBinhLuan").css({"display":"block"})
});
    /************************** xu ly dang nhap binh luan ********************************/
$("#btnfrmDangNhapBL").click(function () {
    var TenDN = $("#TenDNBinhLuan").val();
    var MatKhau = $("#MKDNBinhLuan").val();
    
    $.ajax({
        url: "/DKDN/XuLyDangNhap",
        data: { TenDN: TenDN, MatKhau: MatKhau },
        type: "POST",
        success:function(result) {
            $("#ThongBaoBinhLuan").html("Xin chào! " + result + " hay cho chúng tôi biết ý kiến của bạn về sản phẩm!")
            $("#TenKhachHang").html("Xin Chào! " +result)
            $("#frmDangNhapBinhLuan").css({ "display": "none" })
            $("#frmBinhLuan").css({ "opacity": "1" })

        }
    });
});
$("#button-review").click(function () {
    var _MaSP = $("#LuuMaSP").val();
    var BinhLuan = $("#VietBinhLuan").val();
    var DiemDG = $("input:radio[name='rating']:checked").val();
    var ngay = new Date();
    var thang = new Date();
    var nam = new Date();
    $.ajax({
        url: "/ChiTiet/XuLyBinhLuan",
        data: { DanhGia: BinhLuan, SoDiemDG: DiemDG, _MaSP:_MaSP},
        type:"POST",
        success: function (result) {
                if (DiemDG == 1) {
                    var Add = "<div class='author'><b>" + result + "</b> vào  " +nam.getFullYear()+"-"+thang.getMonth()+"-"+ ngay.getDate() + "</div>"
                        + "<div class='rating'><img src='/Content/Images/Design/stars-1.png' /></div>"
                        + "<div class='text'>" + BinhLuan + "</div>"
                        + "<br />"
                }
                else if (DiemDG == 2) {
                    var Add = "<div class='author'><b>" + result + "</b> vào  " +nam.getFullYear()+"-"+thang.getMonth()+"-"+ ngay.getDate() + "</div>"
                         + "<div class='rating'><img src='/Content/Images/Design/stars-2.png' /></div>"
                         + "<div class='text'>" + BinhLuan + "</div>"
                         + "<br />"
                }
                else if (DiemDG == 3) {
                    var Add = "<div class='author'><b>" + result + "</b> vào  " + nam.getFullYear() + "-" + thang.getMonth() + "-" + ngay.getDate() + "</div>"
                        + "<div class='rating'><img src='/Content/Images/Design/stars-3.png' /></div>"
                        + "<div class='text'>" + BinhLuan + "</div>"
                        + "<br />"
                }
                else if (DiemDG == 4) {
                    var Add = "<div class='author'><b>" + result + "</b> vào  " + nam.getFullYear() + "-" + thang.getMonth() + "-" + ngay.getDate() + "</div>"
                        + "<div class='rating'><img src='/Content/Images/Design/stars-4.png' /></div>"
                        + "<div class='text'>" + BinhLuan + "</div>"
                        + "<br />"
                }
                else {
                    var Add = "<div class='author'><b>" + result + "</b> vào  " + nam.getFullYear() + "-" + thang.getMonth() + "-" + ngay.getDate() + "</div>"
                        + "<div class='rating'><img src='/Content/Images/Design/stars-5.png' /></div>"
                        + "<div class='text'>" + BinhLuan + "</div>"
                        + "<br />"
                }
                $('.review-list').append(Add);
        }
    });
});
});