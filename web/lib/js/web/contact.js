var contactFn = {
    userContactFn: function () {
        var Contact = jQuery('#user-contact');
        var NguoiGui = jQuery('.NguoiGui', Contact);
        var TieuDe = jQuery('.TieuDe', Contact);
        var NoiDung = jQuery('.NoiDung', Contact);
        var Captcha = jQuery('.Captcha', Contact);
        var CaptchaImg = jQuery('.register-captcha', Contact);
        var btnSend = jQuery('.btnSend', Contact);
        var btnClear = jQuery('.btnClear', Contact);

        CaptchaImg.attr('src', '.captcha?ref=' + Math.random());
        jQuery('.global-txt', Contact).val('');
        jQuery('.global-txt-contact', Contact).val('');

        NguoiGui.keyup(function () {
            var item = jQuery(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if (jQuery('.icon-validate-ok', step1).length < 6) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
        });

        TieuDe.keyup(function () {
            var item = jQuery(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if (jQuery('.icon-validate-ok', step1).length < 6) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
        });

        NoiDung.keyup(function () {
            var item = jQuery(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if (jQuery('.icon-validate-ok', step1).length < 6) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
        });

        adm.validElValAjax(Captcha, function (_v, _t) {
            var lbl = Captcha.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            lbl.removeClass('icon-validate-load');
            var _mail = Captcha.val();
            if (_mail.length != 6) {
                lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').html(loi);
                return false;
            }
            else {
                lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').html('');
            }
            lbl.addClass('icon-validate-load');
            jQuery.ajax({
                url: adm.urlDefault,
                data: { 'subAct': 'ValidateCaptcha', 'Captcha': _v, 'act': 'loadPlug', 'rqPlug': 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien' },
                type: 'POST',
                success: function (dt) {
                    lbl.removeClass('icon-validate-load');
                    clearInterval(_t);
                    if (dt == "0") {
                        lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').html(loi);
                    }
                    else {
                        lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').html('');
                    }
                    if (jQuery('.icon-validate-ok', Contact).length < 6) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
                }
            });
        });

        btnSend.click(function () {
            jQuery.ajax({
                url: adm.urlDefault,
                type: 'POST',
                data: { 'act': 'loadPlug', 'rqPlug': 'cnn.plugin.DangKyDichVu.LienHeBanQuanTri.Class1, cnn.plugin.DangKyDichVu', 'subAct': 'userContact', NguoiGui: NguoiGui.val(), msgtitle: TieuDe.val(), NoiDungLienHe: NoiDung.val() },
                success: function (_dt) {
                    var Contact = jQuery('#user-contact');
                    var spInfo = jQuery('.admInfo', Contact);
                    if (_dt == '1') {
                        alert('Bạn đã gửi thành công!');
                        contactFn.clearText();
                    }
                   else {
                        alert.html('Có lỗi xảy ra!');
                    }
                }
            });
        });

        btnClear.click(function () {
            contactFn.clearText();
        });

        jQuery.each(jQuery('.global-txt', Contact), function (i, item) {
            var item = jQuery(item);
            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi');
            item.unbind('focus').focus(function () {
                var _error = lbl.attr('_error');
                var _val = item.val();
                if (_val == '' && _error == '0') {
                    lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint);
                }
            });
        });

        jQuery.each(jQuery('.global-txt-contact', Contact), function (i, item) {
            var item = jQuery(item);
            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi');
            item.unbind('focus').focus(function () {
                var _error = lbl.attr('_error');
                var _val = item.val();
                if (_val == '' && _error == '0') {
                    lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint);
                }
            });
        });
    },

    clearText: function () {
        var Contact = jQuery('#user-contact');
        jQuery('.NguoiGui', Contact).val('');
        jQuery('.TieuDe', Contact).val('');
        jQuery('.NoiDung', Contact).val('');
        jQuery('.Captcha', Contact).val('');
        jQuery('.admInfo', Contact).val('');
    }
}