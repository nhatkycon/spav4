Lienhefn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.LienHeChung.Class1, cnn.plugin.LienHeChung'; },
    setup: function () { },
    loadHtml: function (fn) {

        var dlg = $('#LienHeDenThanhVien');
        if ($(dlg).length < 1) {
            adm.loading('Dựng from');
            $.ajax({
                url: '<%=WebResource("cnn.plugin.LienHeChung.htm.htm")%>',
                success: function (dt) {
                    adm.loading(null);
                    $('body').append(dt);
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                }
            });
        }
        else {
            if (typeof (fn) == 'function') { fn(); }
        }
    },
    sendLienHeDN: function (email) {

        var newdlg = $('#LienHeDenThanhVien');
        var txtTieude = $('.TieuDe', newdlg);
        var tieude = $(txtTieude).val();
        var txtTenKhachHang = $('.HotenKhachHang', newdlg)
        var TenKH = $(txtTenKhachHang).val();
        var txtEmail = $('.EmailKhachHang', newdlg)
        var emailKhachHang = $(txtEmail).val();
        var txtNoiDung = $('.NoiDungLienHeDN', newdlg)
        var noidung = $(txtNoiDung).val();
        var txtID = $('.GH_ID', newdlg)
        var id = $(txtID).val();
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: Lienhefn.urlDefault().toString() + '&subAct=lienHeDN',
            dataType: 'script',
            data: {
                'ID': id,
                'EmailKH': emailKhachHang,
                'Email': email,
                'NoiDungLienHeDN': noidung,
                'TieuDe': tieude,
                'TenKH': TenKH
            },
            success: function (dt) {
                adm.loading(null);
                alert('Gửi thành công!');
            }

        })

    },
    valiEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (emailRegEx.test(email))
            status = true;
        return status;
    },
    LienHe: function (id, ghTen, ghDiaChi, lhTen, lhDienthoai, lhEMail, memEmail, title, validate, fn) { 
        if (memEmail == '' && lhEMail == '') {
            alert('Hiện tại không có email liên hệ!');
            return false;
        }
        Lienhefn.loadHtml(function () {
            var newDlg = $('#LienHeDenThanhVien');
            $(newDlg).dialog({
                title: title,
                width: 960,
                height: 560,
                modal: true,
                buttons: {

                    'Đóng': function () {
                        var newDlg = $('#LienHeDenThanhVien');
                        var btnSend = $('.btnSend', newDlg);
                        btnSend.addClass('contact-send-btn-ok');
                        $(newDlg).dialog('close');

                    }
                },
                beforeClose: function () {
                },
                open: function () {
                    Lienhefn.thongTinQT();
                    Lienhefn.popfn(id, ghTen, ghDiaChi, lhTen, lhDienthoai, lhEMail, memEmail, title);
                    if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }

                }
            });
        });
    },
    thongTinQT: function () {
        $.ajax({
            url: Lienhefn.urlDefault().toString() + '&subAct=thongTinQT',
            dataType: 'script',
            data: {},
            success: function (dt) {
                adm.loading(null);
                var newDlg = $('#LienHeDenThanhVien');
                var el = $('#lienHe-QT');
                el.html('');
                var data = eval(dt);
                $.each(data, function (i, item) {
                    el.append('<span>' + item.Ten + '</span><br/>');
                    el.append('<span>' + item.KyHieu + '</span><br/>');
                    el.append('<span>Email: ' + item.GiaTri + '</span><br/>');
                });
            }
        })
    },
    valiEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (emailRegEx.test(email))
            status = true;
        return status;
    },
    popfn: function (id, ghTen, ghDiaChi, lhTen, lhDienthoai, lhEMail, memEmail, title) {

        var newDlg = $('#LienHeDenThanhVien');
        var titleLienHe = $('.lienHe-form-body-right-title-LHDN', newDlg);
        titleLienHe.html('');
        titleLienHe.append('<span>' + title + '</span>');
        var txtTen = $('.tenDoanhNghiep', newDlg);
        $(txtTen).html(ghTen);
        var txtDiaChiDN = $('.diaChiDoanhNghiep', newDlg);
        $(txtDiaChiDN).html(ghDiaChi);
        var txtTenLH = $('.tenLienHe', newDlg);
        $(txtTenLH).html(lhTen);
        var txtDienThoaiLH = $('.dienThoaiLienHe', newDlg);
        $(txtDienThoaiLH).html(lhDienthoai);
        var txtEmailLH = $('.emailLienHe', newDlg);
        if (Lienhefn.valiEmail(memEmail) == true) {
            $(txtEmailLH).html(memEmail);
        }
        else {
            $(txtEmailLH).html(lhEMail);
        }
        var txtID = $('.GH_ID', newDlg);
        $(txtID).val(id);
        var txtTieude = $('.TieuDe', newDlg);
        lblTieuDe = $(txtTieude).next();
        lblTieuDe.removeClass('icon-validate-ok');
        lblTieuDe.hide();
        var txtTenKhachHang = $('.HotenKhachHang', newDlg);
        lblTenKH = $(txtTenKhachHang).next();
        lblTenKH.removeClass('icon-validate-ok');
        lblTenKH.hide();
        var txtEmail = $('.EmailKhachHang', newDlg);
        lblEmail = $(txtEmail).next();
        lblEmail.removeClass('icon-validate-ok');
        lblEmail.hide();
        var txtNoiDung = $('.NoiDungLienHeDN', newDlg);
        lblNoiDung = $(txtNoiDung).next();
        lblNoiDung.removeClass('icon-validate-ok');
        lblNoiDung.hide();

        var Captcha = $('.Captcha', newDlg);
        lblCaptcha = $(Captcha).next();
        lblCaptcha.removeClass('icon-validate-ok');
        lblCaptcha.hide();

        var btnSend = $('.btnSend', newDlg);
        var btnClear = $('.btnClear', newDlg);
        Lienhefn.clearFrom();
        //        CaptchaImg.attr('src', '.captcha?ref=' + Math.random());
        //        $('.global-txt', newDlg).val('');
        //        $('.global-txt-contact', newDlg).val('');
        //        
        txtTenKhachHang.keyup(function () {
            var item = jQuery(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if ($('.icon-validate-ok', newDlg).length >= 5) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); } //
        });

        txtEmail.keyup(function () {

            var item = $(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if ($('.icon-validate-ok', newDlg).length >= 5) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); } //
        });

        txtTieude.keyup(function () {
            var item = $(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }
            if ($('.icon-validate-ok', newDlg).length >= 5) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
        });

        txtNoiDung.keyup(function () {
            var item = $(this); var _val = item.val();
            if (_val.length < 4) { item.next().attr('_error', '1'); }
            else { item.next().attr('_error', '0'); }

            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            if (_error == '0') {
                if (_val != '') { lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').show().html(''); }
                else { lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint); }
            }
            else { lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').show().html(loi); }

            if ($('.icon-validate-ok', newDlg).length >= 5) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); }
        });

        adm.validElValAjax(Captcha, function (_v, _t) {
            var lbl = Captcha.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi'); var _error = lbl.attr('_error');
            lbl.removeClass('icon-validate-load');
            var _mail = Captcha.val();
            if (_mail.length != 6) {
                lbl.removeClass('icon-validate-ok').addClass('icon-validate-false').html(loi);
                btnSend.addClass('contact-send-btn-ok');
                return false;
            }
            else {
                lbl.removeClass('icon-validate-false').addClass('icon-validate-ok').html('');
                //btnSend.removeClass('contact-send-btn-ok');
            }
            lbl.addClass('icon-validate-load');
            $.ajax({
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
                    if ($('.icon-validate-ok', newDlg).length >= 5) { btnSend.removeClass('contact-send-btn-ok'); } else { btnSend.addClass('contact-send-btn-ok'); } //
                }
            });
        });

        btnSend.unbind('click').click(function () {
            if (btnSend.hasClass('contact-send-btn-ok')) { return false; }
            else {
                if (Lienhefn.valiEmail(memEmail) == true) {
                    Lienhefn.sendLienHeDN(memEmail);
                }
                else {
                    Lienhefn.sendLienHeDN(lhEMail);
                }

            }
        });

        btnClear.unbind('click').click(function () {

            Lienhefn.clearFrom();
        });

        $.each($('.global-txt', newDlg), function (i, item) {
            var item = $(item);
            var lbl = item.next(); var hint = lbl.attr('_hint'); var loi = lbl.attr('_loi');
            item.unbind('focus').focus(function () {
                var _error = lbl.attr('_error');
                var _val = item.val();
                if (_val == '' && _error == '0') {
                    lbl.removeClass('icon-validate-false').removeClass('icon-validate-ok').show().html(hint);
                }
            });
        });

        $.each($('.global-txt-contact', newDlg), function (i, item) {
            var item = $(item);
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

    clearFrom: function () {
        var newDlg = $('#LienHeDenThanhVien');
        var btnSend = $('.btnSend', newDlg);
        btnSend.addClass('contact-send-btn-ok');
        var tieude = $('.TieuDe', newDlg);
        tieude.val('');
        var tenKhachHang = $('.HotenKhachHang', newDlg);
        tenKhachHang.val('');
        var email = $('.EmailKhachHang', newDlg);
        email.val('');
        var noiDung = $('.NoiDungLienHeDN', newDlg);
        noiDung.val('');
        var captcha = $('.Captcha', newDlg);
        captcha.val('');

        var tieude = $('.TieuDe', newDlg);
        lblTieuDe = $(tieude).next();
        lblTieuDe.removeClass('icon-validate-ok');
        lblTieuDe.hide();
        var tenKhachHang = $('.HotenKhachHang', newDlg);
        lblTenKH = $(tenKhachHang).next();
        lblTenKH.removeClass('icon-validate-ok');
        lblTenKH.hide();
        var email = $('.EmailKhachHang', newDlg);
        lblEmail = $(email).next();
        lblEmail.removeClass('icon-validate-ok');
        lblEmail.hide();
        var noiDung = $('.NoiDungLienHeDN', newDlg);
        lblNoiDung = $(noiDung).next();
        lblNoiDung.removeClass('icon-validate-ok');
        lblNoiDung.hide();

        var captcha = $('.Captcha', newDlg);
        lblCaptcha = $(captcha).next();
        lblCaptcha.removeClass('icon-validate-ok');
        lblCaptcha.hide();

    }
}



