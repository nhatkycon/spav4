thongTinDonViFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.thongTinDonVi.thongTinChung.Class1, cnn.plugin.thongTinDonVi'; },
    setup: function () { },
    loadForm: function () {
        thongTinDonViFn.LoadHtml(function () {
            thongTinDonViFn.MainFunction();
        });
    },
    MainFunction: function () {
        thongTinDonViFn.Activeform();
        thongTinDonViFn.popfn();
        thongTinDonViFn.edit();
        thongTinDonViFn.LoadHotro();
    },
    Activeform: function () {
        adm.styleButton();
        var tbBox = $('.thongTinChungDoanhNghiep-box', '#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        $('.thongTinChungDoanhNghiep-menu-item', tbBox).eq(0).addClass('thongTinChungDoanhNghiep-menu-item-active');
        $('.thongTinChungDoanhNghiep-content-box', tbBox).eq(0).addClass('thongTinChungDoanhNghiep-content-box-active');
        $('.thongTinChungDoanhNghiep-menu-item', tbBox).click(function () {
            var item = $(this);
            var _ref = item.attr('_ref');
            $('.thongTinChungDoanhNghiep-menu-item-active', tbBox).removeClass('thongTinChungDoanhNghiep-menu-item-active');
            item.addClass('thongTinChungDoanhNghiep-menu-item-active');
            $('.thongTinChungDoanhNghiep-content-box-active', tbBox).removeClass('thongTinChungDoanhNghiep-content-box-active');
            $('.thongTinChungDoanhNghiep-content-box[_ref=""' + _ref + '""]', tbBox).addClass('thongTinChungDoanhNghiep-content-box-active');
        });
    },
    popfn: function () {
        var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        var tinh = $('.TenTinh', newDlg);
         
        var solaodong = $('.SoLaoDong', newDlg);
        var vonphapdinh = $('.VonPhapDinh', newDlg);
        var doanhthu = $('.DoanhThuHangNam', newDlg);
        var xuatkhau = $('.TyLeXuatKhau', newDlg);
        var quymonhamay = $('.QuyMoNhaMay', newDlg);
        var socanbo = $('.SoCanBo', newDlg);
        var chitietDN = $('.ChiTietCongTy', newDlg);
        var thitruong = $('#ListThiTruongChinh', newDlg);
        var chatluong = $('#ListChungNhanChatLuong', newDlg);
        var loaiDN = $('#ListLoaiDN', newDlg)
        var spdv = $('#SPDV', newDlg);

        adm.createFck(chitietDN);
        var ulpFn = function () {
            var uploadBtn = $('#btnLogo', newDlg);
            var uploadView = $('#logo-img', newDlg);
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.upload(uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
        var ulpFn1 = function () {
            var uploadBtn1 = $('#btnImgLienHe', newDlg);
            var uploadView1 = $('#ImgLienHe', newDlg);
            var _params1 = { 'oldFile': $(uploadBtn1).attr('ref') };
            adm.upload(uploadBtn1, 'anh', _params1, function (rs) {
                $(uploadBtn1).attr('ref', rs)
                $(uploadView1).attr('src', '../up/i/' + rs + '?ref=' + Math.random());
                ulpFn1();
            }, function (f) {
            });
        }
        ulpFn1();

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'KV_TINH', tinh, function (event, ui) {
                $(tinh).attr('_value', ui.item.id);
            });
            $(tinh).unbind('click').click(function () { $(tinh).autocomplete('search', ''); });

        });
        adm.watermark(tinh, 'Chọn khu vực', function () {
        });
        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_LD', solaodong, function (event, ui) {
                $(solaodong).attr('_value', ui.item.id);
            });
            $(solaodong).unbind('click').click(function () { $(solaodong).autocomplete('search', ''); });

        });
        adm.watermark(solaodong, 'Chọn số lao động', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_VON', vonphapdinh, function (event, ui) {
                $(vonphapdinh).attr('_value', ui.item.id);
            });
            $(vonphapdinh).unbind('click').click(function () { $(vonphapdinh).autocomplete('search', ''); });

        });
        adm.watermark(vonphapdinh, 'Chọn vốn pháp định', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_DTHU', doanhthu, function (event, ui) {
                $(doanhthu).attr('_value', ui.item.id);
            });
            $(doanhthu).unbind('click').click(function () { $(doanhthu).autocomplete('search', ''); });

        });
        adm.watermark(doanhthu, 'Chọn doanh thu', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_XK', xuatkhau, function (event, ui) {
                $(xuatkhau).attr('_value', ui.item.id);
            });
            $(xuatkhau).unbind('click').click(function () { $(xuatkhau).autocomplete('search', ''); });

        });
        adm.watermark(xuatkhau, 'Chọn tỷ lệ xuất khẩu', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_QUYMONM', quymonhamay, function (event, ui) {
                $(quymonhamay).attr('_value', ui.item.id);
            });
            $(quymonhamay).unbind('click').click(function () { $(quymonhamay).autocomplete('search', ''); });

        });
        adm.watermark(quymonhamay, 'Chọn quy mô nhà máy', function () {
        });

        adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
            danhmuc.autoCompleteLangBased('', 'TV_R&D', socanbo, function (event, ui) {
                $(socanbo).attr('_value', ui.item.id);
            });
            $(socanbo).unbind('click').click(function () { $(socanbo).autocomplete('search', ''); });

        });
        adm.watermark(socanbo, 'Chọn số cán bộ', function () {
        });
        var nam = $('.NamThanhLap', newDlg);
        var year = [];
        //        for (var i = 1900; i <= 2011; i++) {
        //            year[111 + i - 2011] = "" + i + "";
        //        }
        for (var i = 2012; i >= 1900; i--) {
            year[2012 - i] = "" + i + "";
        }
        adm.watermark(nam, 'Chọn năm', function () {
        });
        $(nam).autocomplete({ source: year, minLength: 0, delay: 0, selectFirst: true });
        $(nam).unbind('click').click(function () {
            $(nam).autocomplete({
                source: year,
                minLength: 0,
                delay: 0,
                selectFirst: true
            });
        });
        thongTinDonViFn.EmailMember();
        //        thongTinDonViFn.ListCheckbox("SP_NHOM", spdv, function () { });
        //        thongTinDonViFn.ListCheckbox("TV_TTRUONG", thitruong, function () { });
        //        thongTinDonViFn.ListCheckbox("TV_ISO", chatluong, function () { });
        //        thongTinDonViFn.ListCheckbox("DN_LOAI", loaiDN, function () { });
    },
    edit: function () {
        var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        var imgLogo = $('#logo-img', newDlg);
        var lblAnhDN = $('#btnLogo', newDlg);
        var txtchitietDN = $('.ChiTietCongTy', newDlg);
        var txtwebDN = $('.Web', newDlg);
        var txttenDN = $('.TenDN', newDlg);
        var txtDiaChiDN = $('.DiaChiDN', newDlg);
        var txtDienThoaiDN = $('.DienThoaiDN', newDlg);
        var txtFaxDN = $('.FaxDN', newDlg);
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlg);
        var txtChiNhanh = $('.ChiNhanhDN', newDlg);
        var txtDiaChiNhaMay = $('.DiaChiNhaMay', newDlg);
        var txtNamThanhLap = $('.NamThanhLap', newDlg);
        //combobox get to danh muc        
        var txtthitruong = $('#ListThiTruongChinh', newDlg);
        var txtchatluong = $('#ListChungNhanChatLuong', newDlg);
        var txtloaiDN = $('#ListLoaiDN', newDlg);
        var txttinh = $('.TenTinh', newDlg);
        var txtsolaodong = $('.SoLaoDong', newDlg);
        var txtvonphapdinh = $('.VonPhapDinh', newDlg);
        var txtdoanhthu = $('.DoanhThuHangNam', newDlg);
        var txtxuatkhau = $('.TyLeXuatKhau', newDlg);
        var txtquymonhamay = $('.QuyMoNhaMay', newDlg);
        var txtsocanbo = $('.SoCanBo', newDlg);
        var txtspdv = $('#SPDV', newDlg);
        var txtnam = $('.NamThanhLap', newDlg);
        //lien he
        var txtTenLienHe = $('.TenNguoiLienHe', newDlg);
        var rdoNam = $('.Nam', newDlg);
        var rdoNu = $('.Nu', newDlg);
        var txtEmailLienHe = $('.EmailLienHe', newDlg);
        var txtDienThoaiLienHe = $('.DienThoai', newDlg);
        var txtDiDongLienHe = $('.DiDong', newDlg);
        var txtChucDanhLienHe = $('.ChucDanh', newDlg);
        var txtYahooLienHe = $('.Yahoo', newDlg);
        var txtDiaChiNguoiLienHe = $('.DiaChiNguoiLienHe', newDlg);
        var imgLienHe = $('#ImgLienHe', newDlg);
        var lblImgLienHe = $('#btnImgLienHe', newDlg);
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=LoadThongTin',
            dataType: 'script',
            data: {},
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                if (data != '') {
                    var item_gh = data[0];
                    $(lblAnhDN).attr('ref', item_gh.Anh);
                    if (item_gh.Anh != '') {
                        $(imgLogo).attr('src', '../up/i/' + item_gh.Anh + '?ref=' + Math.random());
                    }
                    $(txtchitietDN).val(item_gh.MoTa);
                    $(txtwebDN).val(item_gh.Website);
                    $(txttenDN).val(item_gh.Ten);
                    $(txtDiaChiDN).val(item_gh.DiaChi);
                    $(txtDienThoaiDN).val(item_gh.DienThoai);
                    $(txtFaxDN).val(item_gh.Fax);
                    $(txtNguoiDaiDien).val(item_gh.NguoiDaiDien);
                    $(txtChiNhanh).val(item_gh.TomTat);
                    $(txtDiaChiNhaMay).val(item_gh.GioiThieu);
                    $(txtNamThanhLap).val(item_gh.NamThanhLap);
                    $(txtTenLienHe).val(item_gh.LH_Ten);
                    $(txtEmailLienHe).val(item_gh.LH_Email);
                    $(txtDienThoaiLienHe).val(item_gh.LH_Phone);
                    $(txtDiDongLienHe).val(item_gh.LH_Mobile);
                    $(txtChucDanhLienHe).val(item_gh.LH_ChucDanh);
                    $(txtYahooLienHe).val(item_gh.LH_Ym);
                    if (item_gh.LH_GioiTinh == true) {
                        $(rdoNam).attr('checked', 'checked');
                    }
                    else { $(rdoNu).attr('checked', 'checked'); }
                    $(txtDiaChiNguoiLienHe).val(item_gh.LH_DiaChi);
                    $(lblImgLienHe).attr('ref', item_gh.LH_Anh);
                    if (item_gh.LH_Anh != '') {
                        $(imgLienHe).attr('src', '../up/i/' + item_gh.LH_Anh + '?ref=' + Math.random());
                    }
                }
                $.each(data, function (i, item_Dm) {
                    if (item_Dm.ldm_Ma == 'KV_TINH') {
                        txttinh.val(item_Dm.dm_Ten);
                        txttinh.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_LD') {
                        txtsolaodong.val(item_Dm.dm_Ten);
                        txtsolaodong.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_VON') {
                        txtvonphapdinh.val(item_Dm.dm_Ten);
                        txtvonphapdinh.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_DTHU') {
                        txtdoanhthu.val(item_Dm.dm_Ten);
                        txtdoanhthu.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_XK') {
                        txtxuatkhau.val(item_Dm.dm_Ten);
                        txtxuatkhau.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_QUYMONM') {
                        txtquymonhamay.val(item_Dm.dm_Ten);
                        txtquymonhamay.attr('_value', item_Dm.dm_Id);
                    }
                    if (item_Dm.ldm_Ma == 'TV_R&D') {
                        txtsocanbo.val(item_Dm.dm_Ten);
                        txtsocanbo.attr('_value', item_Dm.dm_Id);
                    }
                })
                txtspdv.html('');
                thongTinDonViFn.ListCheckbox("SP_NHOM", txtspdv, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'SP_NHOM') {
                            var arrcheck = eval($(txtspdv).find('.item-checkbox')); //$('.item-checkbox', newDlg);                           
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtthitruong.html('');
                thongTinDonViFn.ListCheckbox("TV_TTRUONG", txtthitruong, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'TV_TTRUONG') {
                            var arrcheck = eval($(txtthitruong).find('.item-checkbox')); //$('.item-checkbox', newDlg);                           
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    //$(item1).is(':checked') = true;
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtchatluong.html('');
                thongTinDonViFn.ListCheckbox("TV_ISO", txtchatluong, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'TV_ISO') {
                            var arrcheck = eval($(txtchatluong).find('.item-checkbox')); //$('.item-checkbox', newDlg);                      -                            
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });
                txtloaiDN.html('');
                thongTinDonViFn.ListCheckbox("DN_LOAI", txtloaiDN, function () {
                    $.each(data, function (i, item) {
                        if (item.ldm_Ma == 'DN_LOAI') {
                            var arrcheck = eval($(txtloaiDN).find('.item-checkbox')); //$('.item-checkbox', newDlg);                      
                            $.each(arrcheck, function (i, item1) {
                                if (eval($(item1).attr('value')) == item.dm_Id) {
                                    $(item1).attr('checked', 'checked');
                                }
                            });
                        }

                    });
                });

            }
        });
    },

    infoSave: function () {
        var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        var newDlg2 = $('#dialog-dlgNew');
        var dialog = $('#dialog', newDlg2);
        //gioi thieu chung, thong tin co ban
        var lblLogo = $('.AnhLogo', newDlg);
        var logo = $(lblLogo).attr('ref');
        var txtchitietDN = $('.ChiTietCongTy', newDlg);
        var mota = $(txtchitietDN).val();
        var txtwebDN = $('.Web', newDlg);
        var web = $(txtwebDN).val();
        var txttenDN = $('.TenDN', newDlg);
        var tenDN = $(txttenDN).val();
        var txtDiaChiDN = $('.DiaChiDN', newDlg);
        var diachiDN = $(txtDiaChiDN).val();
        var txtDienThoaiDN = $('.DienThoaiDN', newDlg);
        var dienthoaiDN = $(txtDienThoaiDN).val();
        var txtFaxDN = $('.FaxDN', newDlg);
        var faxDN = $(txtFaxDN).val();
        var txtNguoiDaiDien = $('.NguoiDaiDien', newDlg);
        var nguoiDaiDien = $(txtNguoiDaiDien).val();
        var txtChiNhanh = $('.ChiNhanhDN', newDlg);
        var chinhanh = $(txtChiNhanh).val();
        var txtDiaChiNhaMay = $('.DiaChiNhaMay', newDlg);
        var diaChiNhaMay = $(txtDiaChiNhaMay).val();
        //Nguoi lien he
        var txtTenLienHe = $('.TenNguoiLienHe', newDlg);
        var tenLienHe = $(txtTenLienHe).val();
        var rdoNam = $('.Nam', newDlg);
        var rdoNu = $('.Nu', newDlg);
        var Nam = $(rdoNam).is(':checked');
        var Nu = $(rdoNu).is(':checked');
        var gioiTinh = '';
        if (Nam == true) { gioiTinh = 'Nam'; }
        else { gioiTinh = 'Nữ'; }
        var txtEmailLienHe = $('.EmailLienHe', newDlg);
        var emailLienHe = $(txtEmailLienHe).val();
        var txtDienThoai = $('.DienThoai', newDlg);
        var dienThoai = $(txtDienThoai).val();
        var txtDiDong = $('.DiDong', newDlg);
        var diDong = $(txtDiDong).val();
        var txtChucDanh = $('.ChucDanh', newDlg);
        var chucDanh = $(txtChucDanh).val();
        var txtYahoo = $('.Yahoo', newDlg);
        var yahoo = $(txtYahoo).val();
        var txtDiaChiNguoiLienHe = $('.DiaChiNguoiLienHe', newDlg);
        var diaChiLH = $(txtDiaChiNguoiLienHe).val();
        var lblImg = $('#btnImgLienHe', newDlg);
        var imgLH = $(lblImg).attr('ref');
        //combobox, checkbox.(DanhMuc)
        var txtNamThanhLap = $('.NamThanhLap', newDlg);
        var namThanhLap = $(txtNamThanhLap).val();
        if (namThanhLap == 'Chọn năm') {
            namThanhLap = 0;
        }
        var txttinh = $('.TenTinh', newDlg);
        var tinh = $(txttinh).attr('_value');
        var txtvonphapdinh = $('.VonPhapDinh', newDlg);
        var vonphapdinh = $(txtvonphapdinh).attr('_value');
        var txtsolaodong = $('.SoLaoDong', newDlg);
        var solaodong = $(txtsolaodong).attr('_value');
        var txtdoanhthu = $('.DoanhThuHangNam', newDlg);
        var doanhthu = $(txtdoanhthu).attr('_value');
        var txtxuatkhau = $('.TyLeXuatKhau', newDlg);
        var xuatkhau = $(txtxuatkhau).attr('_value');
        var txtquymonhamay = $('.QuyMoNhaMay', newDlg);
        var quymonhamay = $(txtquymonhamay).attr('_value');
        var txtsocanbo = $('.SoCanBo', newDlg);
        var socanbo = $(txtsocanbo).attr('_value');
        var txtthitruong = $('#ListThiTruongChinh', newDlg);
        var txtchatluong = $('#ListChungNhanChatLuong', newDlg);
        var txtloaiDN = $('#ListLoaiDN', newDlg);
        var txtsanpham = $('#SPDV', newDlg);
        var resanpham = thongTinDonViFn.Duyetcheckbox(txtsanpham);
        var rethitruong = thongTinDonViFn.Duyetcheckbox(txtthitruong);
        var rechatluong = thongTinDonViFn.Duyetcheckbox(txtchatluong);
        var reloaiDN = thongTinDonViFn.Duyetcheckbox(txtloaiDN);
        var thitruong = rethitruong.substring(0, rethitruong.length - 1);
        var chatluong = rechatluong.substring(0, rechatluong.length - 1);
        var loaiDN = reloaiDN.substring(0, reloaiDN.length - 1);
        var spdv = resanpham.substring(0, resanpham.length - 1);
         

        var err = '';
        if (tenDN == '') {
            err += '* Nhập tên công ty. <br/>';
        }
        if (diachiDN == '') {
            err += '* Nhập địa chỉ công ty. <br/>';
        }
        if (dienthoaiDN == '') {
            err += '* Nhập điện thoại công ty.<br/> ';
        }
        if (thongTinDonViFn.valiNumberPhone(dienthoaiDN) == false || thongTinDonViFn.valiNumberPhone(dienThoai) == false || thongTinDonViFn.valiNumberPhone(diDong) == false) {
            err += '* Điện thoại chỉ nhập sô.<br/>';
        }
        if (thongTinDonViFn.valiEmail(emailLienHe) == false & emailLienHe != '') {
            err += '* Nhập sai định dạng email.<br/>';
        }
        if (tinh == 'Chọn khu vực' || tinh == '') {
            err += '* Chọn Tỉnh/Thành phố.<br/> ';
        }
        if (loaiDN == '') {
            err += '* Chọn loại hình công ty.<br/> '
        }
        if (spdv == '') {
            err += '* Chọn sản phẩm/Dịch vụ.<br/>';
        }
        if (tenLienHe == '') {
            err += '* Nhập tên người liên hệ.<br/>';
        }
        if (dienThoai == '') {
            err += '* Nhập điện thoại của người liên hệ.<br/>';
        }

        if (err != '') {
            $(dialog).html(err);
            var newDlg = $('#dialog-dlgNew');
            $(newDlg).dialog({
                title: 'Lỗi nhập dữ liệu',
                width: 230,
                buttons: {
                    'OK': function () {
                        $(newDlg).dialog('close');
                    }
                }
            });
            return false;
        }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=infoSave',
            dataType: 'script',
            type: 'POST',
            data: {
                'SoCanBo': socanbo,
                'QuyMoNhaMay': quymonhamay,
                'TyLeXuatKhau': xuatkhau,
                'DoanhThuHangNam': doanhthu,
                'SoLaoDong': solaodong,
                'VonPhapDinh': vonphapdinh,
                'TenTinh': tinh,
                'NamThanhLap': namThanhLap,
                'ImageLienHe': imgLH,
                'DiaChiNguoiLienHe': diaChiLH,
                'Yahoo': yahoo,
                'ChucDanh': chucDanh,
                'DiDong': diDong,
                'DienThoai': dienThoai,
                'EmailLienHe': emailLienHe,
                'GioiTinh': gioiTinh,
                'TenNguoiLienHe': tenLienHe,
                'DiaChiNhaMay': diaChiNhaMay,
                'ChiNhanhDN': chinhanh,
                'NguoiDaiDien': nguoiDaiDien,
                'DiaChiDN': diachiDN,
                'TenDN': tenDN,
                'DienThoaiDN': dienthoaiDN,
                'FaxDN': faxDN,
                'Web': web,
                'ChiTietCongTy': mota,
                'AnhLogo': logo,
                'SPDV': spdv,
                'ThiTruong': thitruong,
                'ChatLuong': chatluong,
                'LoaiDN': loaiDN
            },
            success: function (dt) {
                adm.loading(null);
                alert('Thông tin doanh nghiệp đã được lưu');
            }
        });
    },
    EmailMember: function () {
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=EmailMember',
            dataType: 'script',
            success: function (dt) {
                adm.loading(null);
                var data = eval('(' + dt + ')');
                var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
                var txtEmail = $('.Email', newDlg);
                $(txtEmail).html(data.Email);
            }
        });
    },
    //List Checkbox
    ListCheckbox: function (ldm_ma, el, fn) {
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=loadDM',
            dataType: 'script',
            data: {
                'LDM_Ma': ldm_ma
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);

                $.each(data, function (i, item) {
                    el.append('<li><input class="item-checkbox" type="checkbox" name="' + item.ID + '" value="' + item.ID + '"/><label  style="width:25%" for="mainMarketsItem1">' + item.Ten + '</label></li>');
                });

                if (typeof (fn) == 'function') { fn(); }
            }

        });
    },
    Duyetcheckbox: function (_newDlg) {
        var newDlg = $(_newDlg);
        var arrcheck = eval($(newDlg).find('.item-checkbox')); //$('.item-checkbox', newDlg);                            
        var arrdm_id = '';
        $.each(arrcheck, function (i, item) {
            if (eval($(item).is(':checked')) == true) {
                arrdm_id = arrdm_id + $(item).attr('value') + ',';
            }
        });
        return arrdm_id;
    },
    sendLienHe: function (validate, fn) {
        var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        var spbMsg = $('.admMsg', newDlg);
        var txtNoiDung = $('.txtNoiDungLienHe', newDlg);
        var txtID = $('.ID', newDlg);
        var txtTieuDeLienHe = $('.txtTieuDeLienHe', newDlg)

        var tieude = $(txtTieuDeLienHe).val();
        var noidung = $(txtNoiDung).val();
        var ID = txtID.val();

        if (noidung == '') { alert('bạn phải điền nội dung'); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=lienHe',
            dataType: 'script',
            data: {
                'ID': ID,
                'NoiDungLienHe': noidung,
                'msgtitle': tieude
            },
            success: function (dt) {
                adm.loading(null);
                txtNoiDung.val('');
                txtTieuDeLienHe.val('');
                alert('Bạn đã gửi liên hệ thành công');
            }
        });
    },
    //validate
    valiNumberPhone: function (number) {
        var status = false;
        var numberPRegEx = /(^[\d]*[-]*$)|(^[-]*[0-9]*$)|(^[0-9]*[-]*[0-9]*$)/;
        if (number.search(numberPRegEx) == -1) {
            status = false;
        }
        else {
            status = true;
        }
        return status;
    },
    valiEmail: function (email) {
        var status = false;
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (emailRegEx.test(email))
            status = true;
        return status;
    },
    //end Validate
    LoadHtml: function (fn) {
        var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
        if ($(newDlg).length < 1) {
            adm.loading('Load dữ liệu');
            $('#form-mdl').load('<%=WebResource("cnn.plugin.thongTinDonVi.thongTinChung.htm.htm")%>', function () {
                adm.loading(null);
                if (typeof (fn) == 'function') { fn(); }
            });
        }
    },
    LoadHotro: function () {
        $.ajax({
            url: thongTinDonViFn.urlDefault().toString() + '&subAct=loadDM',
            dataType: 'script',
            data: {
                'LDM_Ma': 'LIENHE'
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#thongTinDonViMdl-thongTinChungDoanhNghiepMdl-dlgNew');
                var LienHeDM = $('.LienHe-DanhMuc', newDlg);
                var HoTroDanhMuc = $('.HoTro-DanhMuc', newDlg);
                HoTroDanhMuc.append('<b>Hỗ trợ</b> <br/>');
                $.each(data, function (i, item) {
                    if (item.Ma == 'LH_CHUNG') {
                        LienHeDM.append(item.Description);
                    };
                    if (item.Ma == 'LH_HOTRO') {
                        var src = 'http://opi.yahoo.com/online?u=' + item.GiaTri + '&amp;m=g&amp;t=1';
                        HoTroDanhMuc.append('<b>' + item.Ten + '</b>' + ': <br/>' + '<a href="ymsgr:sendIM?' + item.GiaTri + '"><img border="0" src="' + src + '" alt="Hỗ trợ trực tuyến"></a><br />' + 'Mobile: ' + item.KyHieu + '<br/>');
                    };
                });
            }
        });
    }
}