DangKyDichVuThanhVienFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    loadForm: function () {
        DangKyDichVuThanhVienFn.Activeform();
        DangKyDichVuThanhVienFn.popfn();
        DangKyDichVuThanhVienFn.LoadHotro();
        DangKyDichVuThanhVienFn.LoadThongTinGianHang();
        DangKyDichVuThanhVienFn.LoadThanhToanGioiThieu(function () {
            DangKyDichVuThanhVienFn.Mathtimefn();
        });
    },
    Activeform: function () {
        adm.styleButton();
        var tbBox = $('.thanhToan-box', '#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        $('.thanhToan-menu-item', tbBox).eq(0).addClass('thanhToan-menu-item-active');
        $('.thanhToan-content-box', tbBox).eq(0).addClass('thanhToan-content-box-active');
        $('.thanhToan-menu-item', tbBox).click(function () {
            var item = $(this);
            var _ref = item.attr('_ref');
            $('.thanhToan-menu-item-active', tbBox).removeClass('thanhToan-menu-item-active');
            item.addClass('thanhToan-menu-item-active');
            $('.thanhToan-content-box-active', tbBox).removeClass('thanhToan-content-box-active');
            $('.thanhToan-content-box[_ref=""' + _ref + '""]', tbBox).addClass('thanhToan-content-box-active');
        });
    },
    popfn: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var NgayBDDKVang = $('.NgayBD-DK-TV-Vang', newDlg);
        var NgayKTDKVang = $('.NgayKT-DK-TV-Vang', newDlg);
        var NgayBDDKBac = $('.NgayBD-DK-TV-Bac', newDlg);
        var NgayKTDKBac = $('.NgayKT-DK-TV-Bac', newDlg);
        var NgayBDDKDong = $('.NgayBD-DK-TV-Dong', newDlg);
        var NgayKTDKDong = $('.NgayKT-DK-TV-Dong', newDlg);
        NgayBDDKVang.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKVang.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayBDDKBac.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKBac.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayBDDKDong.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTDKDong.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    sendLienHe: function (validate, fn) {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
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
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=lienHe',
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
    LoadThongTinGianHang: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        adm.loading('Lấy dữ liệu gian hàng');
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=get',
            dataType: 'script',
            data: {},
            success: function (dt) {
                adm.loading(null);
                data = eval(dt);
                var MaDonVi = $('.MaDonVi', newDlg);
                var DiaChi = $('.DiaChi', newDlg);
                var Email = $('.Email', newDlg);
                var MaDangKy = $('.MaDangKy', newDlg);
                var Logo = $('.adm-upload-preview-img-60', newDlg);
                var ID = $('.ID', newDlg);
                MaDonVi.append(data.Ten);
                DiaChi.append(data.DiaChi);
                Email.append(data.Email);
                MaDangKy.append('DKTV' + data.ID);
                Logo.attr('src', data.Logo);
                ID.val(data.ID);

                if (eval(data.DKTV_Vang) == true || eval(data.DKTV_Bac) == true || eval(data.DKTV_Dong) == true) {
                    var btnDKBac = $('.mdl-head-DKBac', newDlg);
                    var btnDKVang = $('.mdl-head-DKVang', newDlg);
                    var btnDKDong = $('.mdl-head-DKDong', newDlg);
                    btnDKBac.hide();
                    btnDKVang.hide();
                    btnDKDong.hide();
                    //                    var __NgayHetHan = new Date(dt.NgayHetHan);
                    //                    var _NgayHetHan = __NgayHetHan.getDate() + '/' + (__NgayHetHan.getMonth() + 1) + '/' + __NgayHetHan.getFullYear();
                    //                    NgayHetHan.val(_NgayHetHan);
                    var __NgayDKTVVang = new Date(data.NgayDKTV_Vang);
                    var _NgayDKTVVang = __NgayDKTVVang.getDate() + '/' + (__NgayDKTVVang.getMonth() + 1) + '/' + __NgayDKTVVang.getFullYear();

                    var __NgayKTTVVang = new Date(data.NgayKTTV_Vang);
                    var _NgayKTTVVang = __NgayKTTVVang.getDate() + '/' + (__NgayKTTVVang.getMonth() + 1) + '/' + __NgayKTTVVang.getFullYear();

                    var __NgayDKTVBac = new Date(data.NgayDKTV_Bac);
                    var _NgayDKTVBac = __NgayDKTVBac.getDate() + '/' + (__NgayDKTVBac.getMonth() + 1) + '/' + __NgayDKTVBac.getFullYear();

                    var __NgayKTTVBac = new Date(data.NgayKTTV_Bac);
                    var _NgayKTTVBac = __NgayKTTVBac.getDate() + '/' + (__NgayKTTVBac.getMonth() + 1) + '/' + __NgayKTTVBac.getFullYear();

                    var __NgayDKTVDong = new Date(data.NgayDKTV_Dong);
                    var _NgayDKTVDong = __NgayDKTVDong.getDate() + '/' + (__NgayDKTVDong.getMonth() + 1) + '/' + __NgayDKTVDong.getFullYear();

                    var __NgayKTTVDong = new Date(data.NgayKTTV_Dong);
                    var _NgayKTTVDong = __NgayKTTVDong.getDate() + '/' + (__NgayKTTVDong.getMonth() + 1) + '/' + __NgayKTTVDong.getFullYear();

                    var DanhsachDichVuDaDK = $('.DanhsachDichVuDaDK', newDlg);

                    var btnHuyDangKy = '<a style="margin-left:200px;color:red;" class="mdl-head-HUYDKSP" href="javascript:" onclick="DangKyDichVuThanhVienFn.HuyDangKyDichVu();"">Hủy</a>';
                    if (eval(data.DKTV_Vang) == true) {
                        DanhsachDichVuDaDK.append('Dịch vụ đã đăng ký: Thành viên Vàng. Từ ngày:<span style="color:red;">' + _NgayDKTVVang + ' </span> đến <span style="color:red;">' + _NgayKTTVVang+'</span>' + btnHuyDangKy);
                    }
                    if (eval(data.DKTV_Bac) == true) {
                        DanhsachDichVuDaDK.append('Dịch vụ đã đăng ký: Thành viên Bạc. Từ ngày:<span style="color:red;">' + _NgayDKTVBac + '</span> đến <span style="color:red;">' + _NgayKTTVBac + '</span>' + btnHuyDangKy);
                    }
                    if (eval(data.DKTV_Dong) == true) {
                        DanhsachDichVuDaDK.append('Dịch vụ đã đăng ký: Thành viên Đồng. Từ ngày:<span style="color:red;">' + _NgayDKTVDong + '</span> đến <span style="color:red;">' + _NgayKTTVDong + '</span>' + btnHuyDangKy);
                    }
                }
            }
        });
    },
    clearformThongTinGianHang: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var MaDonVi = $('.MaDonVi', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var Email = $('.Email', newDlg);
        var MaDangKy = $('.MaDangKy', newDlg);
        var Logo = $('.adm-upload-preview-img-60', newDlg);
        var ID = $('.ID', newDlg);
        var DanhsachDichVuDaDK = $('.DanhsachDichVuDaDK', newDlg);

        ID.val('');
        MaDonVi.html('');
        DiaChi.html('');
        Email.html('');
        MaDangKy.html('');
        Logo.attr('src', '');
        DanhsachDichVuDaDK.html('');

    },
    clearform: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var MaDonVi = $('.MaDonVi', newDlg);
        var DiaChi = $('.DiaChi', newDlg);
        var Emai = $('.Emai', newDlg);
        var MaDangKy = $('.MaDangKy', newDlg);
        var Logo = $('.adm-upload-preview-img-60', newDlg);
        var ID = $('.ID', newDlg);

        var LienHeDM = $('.LienHe-DanhMuc', newDlg);
        var HoTroDanhMuc = $('.HoTro-DanhMuc', newDlg);

        var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc', newDlg);
        var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc', newDlg);
        var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc', newDlg);

        var GiaThanhVienVang = $('.Gia-ThanhVien-Vang', newDlg);
        var GiaThanhVienBac = $('.Gia-ThanhVien-Bac', newDlg);
        var GiaThanhVienDong = $('.Gia-ThanhVien-Dong', newDlg);

        var GioThieuThanhVienVang = $('.GioThieu-ThanhVien-Vang', newDlg);
        var GioThieuThanhVienBac = $('.GioThieu-ThanhVien-Bac', newDlg);
        var GioThieuThanhVienDong = $('.GioThieu-ThanhVien-Dong', newDlg);

        var TongTienDKVang = $('.TongTien-DKTV-Vang', newDlg);
        var TongTienDKBac = $('.TongTien-DKTV-Vang', newDlg);
        var TongTienDKDong = $('.TongTien-DKTV-Vang', newDlg);

        var NgayKTDKVang = $('.NgayKT-DK-TV-Vang', newDlg);
        var NgayBDDKVang = $('.NgayBD-DK-TV-Vang', newDlg);
        var btnDKVang = $('.mdl-head-DKVang', newDlg);
        var SoNgayDKVang = ('.SoNgay-DKTV-Vang', newDlg);

        var NgayKTDKBac = $('.NgayKT-DK-TV-Bac', newDlg);
        var NgayBDDKBac = $('.NgayBD-DK-TV-Bac', newDlg);
        var SoNgayDKBac = ('.SoNgay-DKTV-Bac', newDlg);
        var btnDKBac = $('.mdl-head-DKBac', newDlg);

        var NgayKTDKDong = $('.NgayKT-DK-TV-Dong', newDlg);
        var NgayBDDKDong = $('.NgayBD-DK-TV-Dong', newDlg);
        var SoNgayDKDong = ('.SoNgay-DKTV-Dong', newDlg);
        var btnDKDong = $('.mdl-head-DKDong', newDlg);

        var btnDKBac = $('.mdl-head-DKBac', newDlg);
        var DanhsachDichVuDaDK = $('.DanhsachDichVuDaDK', newDlg);

        ChuyenKhoanDM.html('');
        GioiThieuDanhMuc.html('');
        ThanhToanDanhMuc.html('');

        HoTroDanhMuc.html('');
        LienHeDM.html('');
        ID.val('');
        MaDonVi.html('');
        DiaChi.html('');
        Emai.html('');
        MaDangKy.html('');
        Logo.attr('src', '');
    },
    LoadHotro: function () {
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'LIENHE'
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
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
    },
    LoadThanhToanGioiThieu: function (fn) {
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'THANHTOAN'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
                var ChuyenKhoanDM = $('.ChuyenKhoan-DanhMuc', newDlg);
                var ThanhToanDanhMuc = $('.ThanhToan-DanhMuc', newDlg);

                $.each(data, function (i, item) {
                    if (item.Ma == 'TT_TAIKHOAN') {
                        ChuyenKhoanDM.append(item.Description);
                    };
                    if (item.Ma == 'TT_HINHTHUC') {
                        ThanhToanDanhMuc.append(item.Description);
                    }
                });

                //if(typeof )
                //DangKyDichVuThanhVienFn.Mathtimefn();
            }
        });
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'TV_DICHVU'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
                var GiaThanhVienVang = $('.Gia-ThanhVien-Vang', newDlg);
                var GiaThanhVienBac = $('.Gia-ThanhVien-Bac', newDlg);
                var GiaThanhVienDong = $('.Gia-ThanhVien-Dong', newDlg);
                var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc', newDlg);
                var GioThieuThanhVienVang = $('.GioThieu-ThanhVien-Vang', newDlg);
                var GioThieuThanhVienBac = $('.GioThieu-ThanhVien-Bac', newDlg);
                var GioThieuThanhVienDong = $('.GioThieu-ThanhVien-Dong', newDlg);
                //////console.log(data);
                $.each(data, function (i, item) {
                    if (item.Ma == 'TV_DICHVU_GIOITHIEU') {
                        GioiThieuDanhMuc.append(item.Description);
                        //////console.log(item.Description);
                    }
                    if (item.Ma == 'TV_DICHVU_VANG') {
                        GioThieuThanhVienVang.append(item.Description);
                        GiaThanhVienVang.append(item.GiaTri);
                        GiaThanhVienVang.attr('_gia', item.GiaTri);
                    }
                    if (item.Ma == 'TV_DICHVU_BAC') {
                        GioThieuThanhVienBac.append(item.Description);
                        GiaThanhVienBac.append(item.GiaTri);
                        GiaThanhVienBac.attr('_gia', item.GiaTri);
                    }
                    if (item.Ma == 'TV_DICHVU_DONG') {
                        GioThieuThanhVienDong.append(item.Description);
                        GiaThanhVienDong.append(item.GiaTri);
                        GiaThanhVienDong.attr('_gia', item.GiaTri);
                    }
                });
                if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    Mathtimefn: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var GiaThanhVienVang = $('.Gia-ThanhVien-Vang', newDlg);
        var GiaThanhVienBac = $('.Gia-ThanhVien-Bac', newDlg);
        var GiaThanhVienDong = $('.Gia-ThanhVien-Dong', newDlg);

        var TongTienDKVang = $('.TongTien-DKTV-Vang', newDlg);
        var TongTienDKBac = $('.TongTien-DKTV-Bac', newDlg);
        var TongTienDKDong = $('.TongTien-DKTV-Dong', newDlg);

        var NgayKTDKVang = $('.NgayKT-DK-TV-Vang', newDlg);
        var NgayBDDKVang = $('.NgayBD-DK-TV-Vang', newDlg);
        var NgayKTDKBac = $('.NgayKT-DK-TV-Bac', newDlg);
        var NgayBDDKBac = $('.NgayBD-DK-TV-Bac', newDlg);
        var NgayKTDKDong = $('.NgayKT-DK-TV-Dong', newDlg);
        var NgayBDDKDong = $('.NgayBD-DK-TV-Dong', newDlg);

        var SoNgayDKVang = $('.SoNgay-DKTV-Vang', newDlg);
        var SoNgayDKBac = $('.SoNgay-DKTV-Bac', newDlg);
        var SoNgayDKDong = $('.SoNgay-DKTV-Dong', newDlg);

        var _DateNow = new Date();
        var _Dateweek = new Date();
        _Dateweek.setDate(_Dateweek.getDate() + 7);

        var Dateweek = _Dateweek.getDate() + '/' + (_Dateweek.getMonth() + 1) + '/' + _Dateweek.getFullYear();
        var DateNow = _DateNow.getDate() + '/' + (_DateNow.getMonth() + 1) + '/' + _DateNow.getFullYear();

        NgayBDDKVang.val(DateNow);
        NgayBDDKBac.val(DateNow);
        NgayBDDKDong.val(DateNow);

        NgayKTDKVang.val(Dateweek);
        NgayKTDKDong.val(Dateweek);
        NgayKTDKBac.val(Dateweek);

        SoNgayDKVang.append('( 1 tuần )');
        SoNgayDKBac.append('( 1 tuần )');
        SoNgayDKDong.append('( 1 tuần )');
        var GiaDkVangTuan = $(GiaThanhVienVang).attr('_gia');
        TongTienDKVang.append($(GiaThanhVienVang).attr('_gia'));
        TongTienDKBac.append($(GiaThanhVienBac).attr('_gia'));
        TongTienDKDong.append($(GiaThanhVienDong).attr('_gia'));

        NgayBDDKVang.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKVang, NgayKTDKVang, SoNgayDKVang, TongTienDKVang, GiaThanhVienVang);
        });
        NgayKTDKVang.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKVang, NgayKTDKVang, SoNgayDKVang, TongTienDKVang, GiaThanhVienVang);
        });

        NgayBDDKBac.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKBac, NgayKTDKBac, SoNgayDKBac, TongTienDKBac, GiaThanhVienBac);
        });
        NgayKTDKBac.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKBac, NgayKTDKBac, SoNgayDKBac, TongTienDKBac, GiaThanhVienBac);
        });
        NgayBDDKDong.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKDong, NgayKTDKDong, SoNgayDKDong, TongTienDKDong, GiaThanhVienDong);
        });
        NgayKTDKDong.change(function () {
            DangKyDichVuThanhVienFn.InputChange(NgayBDDKDong, NgayKTDKDong, SoNgayDKDong, TongTienDKDong, GiaThanhVienDong);
        });
    },
    InputChange: function (_NgayBD, _NgayKT, _SoNgay, _TongTien, _GiaThanhVien) {
        var NgayBD = $(_NgayBD);
        var NgayKT = $(_NgayKT);
        var SoNgay = $(_SoNgay);
        var TongTien = $(_TongTien);
        var GiaThanhVien = $(_GiaThanhVien);

        SoNgay.html('');
        TongTien.html('');

        var convertNgayBD = DangKyDichVuThanhVienFn.convertDate(NgayBD.val(), '/');
        var convertNgayKT = DangKyDichVuThanhVienFn.convertDate(NgayKT.val(), '/');
        var Datecount = DangKyDichVuThanhVienFn.dateDiff('d', convertNgayBD, convertNgayKT);
        var convertweek;

        if (parseInt(Datecount) % 7 == 0) {
            convertweek = parseInt(parseInt(Datecount) / 7);
            SoNgay.append('(' + convertweek + 'tuần )');
        }
        else {
            convertweek = parseInt(parseInt(Datecount) / 7) + 1;
            var countDateDu = parseInt(Datecount) % 7;

            convertNgayKT = new Date(convertNgayKT);
            convertNgayKT.setDate(convertNgayKT.getDate() + (7 - countDateDu));
            SoNgay.append('(' + convertweek + 'tuần )');
            var convertNgayKTNew = convertNgayKT.getDate() + '/' + (convertNgayKT.getMonth() + 1) + '/' + convertNgayKT.getFullYear();
            _NgayKT.val(convertNgayKTNew);
        }
        var giatt = parseInt(GiaThanhVien.attr('_gia'));
        var tongtientt = parseInt(convertweek) * giatt;
        TongTien.append(tongtientt);
    },
    convertDate: function (d, s) {
        var cDate = d.split(s);
        return cDate[1] + s + cDate[0] + s + cDate[2];
    },
    dateDiff: function (p_Interval, p_StartDate, p_EndDate) {
        var s_dt = new Date(p_StartDate);
        var e_dt = new Date(p_EndDate);
        var i_Number;
        var i_Year = Math.abs(e_dt.getFullYear() - s_dt.getFullYear());
        var i_Month = e_dt.getMonth() - s_dt.getMonth();

        switch (p_Interval.toLowerCase()) {
            case "yyyy":
                {// year
                    i_Number = i_Year;
                    break;
                }
            case "q":
                { // quarter
                    i_Number = Math.round((i_Year * 12 + i_Month) / 3);
                    if (((i_Year * 12 + i_Month) % 3) > 0) {
                        i_Number += 1;
                    }
                    break;
                }
            case "m":
                { // month
                    i_Number = i_Year * 12 + i_Month;
                    break;
                }
            case "d": // day
                {
                    i_Number = Math.abs(Math.round((e_dt - s_dt) / (24 * 60 * 60 * 1000)));
                    break;
                }
            default:
                {
                    return "invalid interval: '" + p_Interval + "'";
                }
        }
        return i_Number;
    },
    saveDKTVVANG: function (validate, fn) {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var dkvang = 'False';

        var ID = $('.ID', newDlg);
        var NgayKTDKVang = $('.NgayKT-DK-TV-Vang', newDlg);
        var NgayBDDKVang = $('.NgayBD-DK-TV-Vang', newDlg);

        var btnDKVang = $('.mdl-head-DKVang', newDlg);
        var btnDKDong = $('.mdl-head-DKDong', newDlg);
        var btnDKBac = $('.mdl-head-DKBac', newDlg);

        var _ID = ID.val();
        var _NgayKTDKVang = NgayKTDKVang.val();
        var _NgayBDDKVang = NgayBDDKVang.val();
        var err = '';

        var convertDateNgayKTDKVang = DangKyDichVuThanhVienFn.convertDate(NgayKTDKVang.val(), '/');
        var convertDateNgayBDDKVang = DangKyDichVuThanhVienFn.convertDate(NgayBDDKVang.val(), '/');
        if (Date.parse(convertDateNgayKTDKVang) < Date.parse(convertDateNgayBDDKVang)) {
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if (_NgayBDDKVang == '') {
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if (_NgayKTDKVang == '') {
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBDDKVang != '' && _NgayKTDKVang != '' && (Date.parse(convertDateNgayKTDKVang) > Date.parse(convertDateNgayBDDKVang))) {
            dkvang = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=DKDVTHANHVIEN',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKVang': dkvang,
                'NgayKTDKVANG': _NgayKTDKVang,
                'NgayDKVANG': _NgayBDDKVang
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    btnDKVang.hide();
                    btnDKBac.hide();
                    btnDKDong.hide();
                    DangKyDichVuThanhVienFn.clearformThongTinGianHang();
                    DangKyDichVuThanhVienFn.LoadThongTinGianHang();
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveDKTVBAC: function (validate, fn) {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var dkbac = 'False';

        var ID = $('.ID', newDlg);
        var NgayKTDKBac = $('.NgayKT-DK-TV-Bac', newDlg);
        var NgayBDDKBac = $('.NgayBD-DK-TV-Bac', newDlg);

        var btnDKVang = $('.mdl-head-DKVang', newDlg);
        var btnDKDong = $('.mdl-head-DKDong', newDlg);
        var btnDKBac = $('.mdl-head-DKBac', newDlg);

        var _ID = ID.val();
        var _NgayKTDKBac = NgayKTDKBac.val();
        var _NgayBDDKBac = NgayBDDKBac.val();
        var err = '';

        var convertDateNgayKTDKBac = DangKyDichVuThanhVienFn.convertDate(NgayKTDKBac.val(), '/');
        var convertDateNgayBDDKBac = DangKyDichVuThanhVienFn.convertDate(NgayBDDKBac.val(), '/');
        if (Date.parse(convertDateNgayKTDKBac) < Date.parse(convertDateNgayBDDKBac)) {
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if (_NgayBDDKBac == '') {
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if (_NgayKTDKBac == '') {
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBDDKBac != '' && _NgayKTDKBac != '' && (Date.parse(convertDateNgayKTDKBac) > Date.parse(convertDateNgayBDDKBac))) {
            dkbac = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=DKDVTHANHVIEN',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKBac': dkbac,
                'NgayKTDKBAC': _NgayKTDKBac,
                'NgayDKBAC': _NgayBDDKBac
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    btnDKVang.hide();
                    btnDKBac.hide();
                    btnDKDong.hide();
                    DangKyDichVuThanhVienFn.clearformThongTinGianHang();
                    DangKyDichVuThanhVienFn.LoadThongTinGianHang();
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    saveDKTVDONG: function (validate, fn) {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var dkdong = 'False';

        var ID = $('.ID', newDlg);
        var NgayKTDKDong = $('.NgayKT-DK-TV-Dong', newDlg);
        var NgayBDDKDong = $('.NgayBD-DK-TV-Dong', newDlg);

        var btnDKVang = $('.mdl-head-DKVang', newDlg);
        var btnDKDong = $('.mdl-head-DKDong', newDlg);
        var btnDKBac = $('.mdl-head-DKBac', newDlg);

        var _ID = ID.val();
        var _NgayKTDKDong = NgayKTDKDong.val();
        var _NgayBDDKDong = NgayBDDKDong.val();
        var err = '';

        var convertDateNgayKTDKDong = DangKyDichVuThanhVienFn.convertDate(NgayKTDKDong.val(), '/');
        var convertDateNgayBDDKDong = DangKyDichVuThanhVienFn.convertDate(NgayBDDKDong.val(), '/');
        if (Date.parse(convertDateNgayKTDKDong) < Date.parse(convertDateNgayBDDKDong)) {
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if (_NgayBDDKDong == '') {
            err += 'Bạn phải điền ngày bắt đầu';
        }
        if (_NgayKTDKDong == '') {
            err += 'Bạn phải điền ngày hết hạn';
        }
        if (_NgayBDDKDong != '' && _NgayKTDKDong != '' && (Date.parse(convertDateNgayKTDKDong) > Date.parse(convertDateNgayBDDKDong))) {
            dkdong = 'True';
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=DKDVTHANHVIEN',
            dataType: 'script',
            type: 'POST',
            data: {
                'ID': _ID,
                'DKDong': dkdong,
                'NgayKTDKDONG': _NgayKTDKDong,
                'NgayDKDONG': _NgayBDDKDong
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    btnDKVang.hide();
                    btnDKBac.hide();
                    btnDKDong.hide();
                    DangKyDichVuThanhVienFn.clearformThongTinGianHang();
                    DangKyDichVuThanhVienFn.LoadThongTinGianHang();
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    HuyDangKyDichVu: function () {
        var newDlg = $('#DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew');
        var dkdong = 'False';
        var dkbac = 'False';
        var dkvang = 'False';
        var ID = $('.ID', newDlg);
        var btnDKVang = $('.mdl-head-DKVang', newDlg);
        var btnDKDong = $('.mdl-head-DKDong', newDlg);
        var btnDKBac = $('.mdl-head-DKBac', newDlg);
        var _ID = ID.val();
        adm.loading('Đang lưu dữ liệu');
        if (confirm('Bán có chắc chắn muốn hủy đăng ký?')) {
            $.ajax({
                url: DangKyDichVuThanhVienFn.urlDefault().toString() + '&subAct=DKDVTHANHVIEN',
                dataType: 'script',
                type: 'POST',
                data: {
                    'ID': _ID,
                    'DKDong': dkdong,
                    'DKVang':dkvang,
                    'DKBac':dkbac
                },
                success: function (dt) {
                    adm.loading(null);
                    if (dt == '1') {
                        if (typeof (fn) == 'function') {
                            fn();
                        }
                        btnDKVang.show();
                        btnDKBac.show();
                        btnDKDong.show();
                        DangKyDichVuThanhVienFn.clearformThongTinGianHang();
                        DangKyDichVuThanhVienFn.LoadThongTinGianHang();
                    }
                    else {
                        spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                    }
                }
            });
        }
    }
}


