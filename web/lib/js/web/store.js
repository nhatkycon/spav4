jQuery(function () {

    //lien he
    var lienHeBox = jQuery('.store-lienHeBox');
    if (jQuery(lienHeBox).length > 0) {
        var NguoiGui = lienHeBox.find('.NguoiGui');
        var TieuDe = lienHeBox.find('.TieuDe');
        var NoiDung = lienHeBox.find('.NoiDung');
        var CaptchaImg = lienHeBox.find('.register-captcha');
        var CaptchaTxt = lienHeBox.find('.global-txt Captcha');
        var btnSend = lienHeBox.find('.btnSend');
        var btnClear = lienHeBox.find('.btnClear');
        var admInfo = lienHeBox.find('.admInfo');
        CaptchaImg.attr('src', 'linh.captcha?ref=' + Math.random());
        btnSend.click(function () {
            var _NguoiGui = NguoiGui.val();
            var _TieuDe = TieuDe.val();
            var _NoiDung = NoiDung.val();
            var _CaptchaTxt = CaptchaTxt.val();
            var _err = '';
            if (_NguoiGui == '') { _err += 'Nhập tên người gửi<br/>'; }
            if (_TieuDe == '') { _err += 'Nhập tiêu đề<br/>'; }
            if (_NoiDung == '') { _err += 'Nhập nội dung<br/>'; }
            if (_err != '') { admInfo.html('Lỗi<br/>' + _err); return false; }
            btnSend.html('Đang gửi...');
            jQuery.ajax({
                url: domain + '/lib/pages/Lien_he_ajax.aspx?ref=' + Math.random(),
                data: {
                    'NguoiGui': -NguoiGui,
                    'TieuDe': _TieuDe,
                    'NoiDung': _NoiDung,
                    'CaptchaTxt': _CaptchaTxt
                },
                success: function (_dt) {
                    btnSend.html('Gửi');
                }
            });
        });
    }
});