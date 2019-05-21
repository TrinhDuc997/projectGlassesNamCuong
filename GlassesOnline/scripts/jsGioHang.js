$(document).ready(function () {
    DatHang = function (MaSP) {
        var SoLuongSanPham = $('#SoLuongSPGioHang').val();
        if(isNaN(SoLuongSanPham))
        {
            SoLuongSanPham = 1;
        }
        $.ajax({
            url: "/GioHang/ThemGioHang",
            data: { _MaSP: MaSP, SL: SoLuongSanPham },
            type: "POST",
            success: function (result) {
                alert("Đặt Hàng Thành Công!");
            }
        });
    }
});