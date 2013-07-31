DangKyDVQuangCaoFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.DangKyDVQuangCao.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    LoadForm: function () {
        adm.styleButton();
        var DangKyDVQuangCaoFnMain = $('#DangKyDVQuangCaoFn-Main');
        DangKyDVQuangCaoFn.LoadFormhtml(DangKyDVQuangCaoFnMain, function () {
            DangKyDVQuangCaoFn.ProcessMain();
            DangKyDVQuangCaoFn.popfn();
            adm.styleButton();
        });
        if (typeof (Ajax_upload) == 'undefined') { $.getScript('../js/ajaxupload.js', function () { }); }
    },
    ProcessMain: function () {
        DangKyDVQuangCaoFn.Activeform();
        DangKyDVQuangCaoFn.LoadHotro();
        DangKyDVQuangCaoFn.LoadThanhToanGioiThieu();
        DangKyDVQuangCaoFn.LoadThongTinDangKyDichVuDonVi();
    },
    sendLienHe: function (validate, fn) {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var txtNoiDung = $('.txtNoiDungLienHe', newDlg);
        var txtTieuDeLienHe = $('.txtTieuDeLienHe', newDlg)

        var tieude = $(txtTieuDeLienHe).val();
        var noidung = $(txtNoiDung).val();
        if (tieude == '') { alert('bạn phải điền tiêu đề'); return false; }
        if (noidung == '') { alert('bạn phải điền nội dung'); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
        adm.loading('Đang gửi liên hệ');
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=lienHe',
            dataType: 'script',
            data: {
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
    LoadHotro: function () {
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'LIENHE'
            },
            success: function (dt) {
                adm.loading(null);
                var data = eval(dt);
                var newDlg = $('#DangKyDVQuangCaoFn-Main');
                var LienHeDM = $('.LienHe-DanhMuc', newDlg);
                var HoTroDanhMuc = $('.HoTro-DanhMuc', newDlg);
                HoTroDanhMuc.append('<b>HỖ TRỢ</b><br/>');
                $.each(data, function (i, item) {
                    if (item.Ma == 'LH_CHUNG') {
                        LienHeDM.append(item.Description);
                    };
                    if (item.Ma == 'LH_HOTRO') {
                        var src = 'http://opi.yahoo.com/online?u=' + item.GiaTri + '&amp;m=g&amp;t=1';
                        HoTroDanhMuc.append('<br/><b>' + item.Ten + '</b>' + '<br/>' + '<a href="ymsgr:sendIM?' + item.GiaTri + '"><img border="0" src="' + src + '" alt="Hỗ trợ trực tuyến"></a><br />' + 'Mobile:<span style="color:red;"> ' + item.KyHieu + '</span><br/>');
                    };
                });
            }
        });
    },

    Activeform: function () {
        adm.styleButton();
        var tbBox = $('.thanhToan-box', '#DangKyDVQuangCaoFn-Main');
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
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var DangKyDichVuQCBuoc2 = $('.DangKyDichVuQC-Buoc-2', newDlg);
        var DangKyDichVuQCBuoc1 = $('.DangKyDichVuQC-Buoc-1', newDlg);
        DangKyDichVuQCBuoc2.hide();
    },
    LoadThanhToanGioiThieu: function (fn) {
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'THANHTOAN'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKyDVQuangCaoFn-Main');
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
                //DangKyDVQuangCaoFn.Mathtimefn();
            }
        });
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
            dataType: 'script',
            data: {
                'MaDanhMuc': 'QC_DICHVU'
            },
            success: function (dt) {
                var data = eval(dt);
                var newDlg = $('#DangKyDVQuangCaoFn-Main');
                var GioiThieuDanhMuc = $('.GioiThieu-DanhMuc', newDlg);
                $.each(data, function (i, item) {
                    if (item.Ma == 'QC_DV_GIOITHIEU') {
                        GioiThieuDanhMuc.append(item.Description);
                    }
                });
                //if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    uploadAnhQC: function (height, width) {
        //console.log(height + ' v1');
        //console.log(width +' v1');
        var ulpFn = function () {
            var newDlg = $('#DangKyDVQuangCaoFn-Main');
            var uploadBtn = $('.adm-upload-btn', newDlg);
            var uploadView = $('.adm-upload-preview-img-dkdvqc', newDlg);
            //console.log(height + ' v2');
            //console.log(width + ' v2');
            var _params = { 'oldFile': $(uploadBtn).attr('ref') };
            adm.uploadQuangCao(height, width, uploadBtn, 'anh', _params, function (rs) {
                $(uploadBtn).attr('ref', rs)
                $(uploadView).attr('src', '../up/quangcao/' + rs + '?ref=' + Math.random());
                ulpFn();
            }, function (f) {
            });
        }
        ulpFn();
    },
    Mathtimefn: function () {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var GiaQC = $('.GiaQC', newDlg);
        var NgayDKQC = $('.NgayDKQC', newDlg);
        var NgayKTQC = $('.NgayKTQC', newDlg);
        var SoNgayDKQC = $('.SoNgayDKQC', newDlg);
        var TongGiaQC = $('.TongGiaQC', newDlg);
        var _DateNow = new Date();
        var _Dateweek = new Date();
        _Dateweek.setDate(_Dateweek.getDate() + 7);

        var Dateweek = _Dateweek.getDate() + '/' + (_Dateweek.getMonth() + 1) + '/' + _Dateweek.getFullYear();
        var DateNow = _DateNow.getDate() + '/' + (_DateNow.getMonth() + 1) + '/' + _DateNow.getFullYear();

        NgayDKQC.val(DateNow);
        NgayKTQC.val(Dateweek);

        SoNgayDKQC.append('( 1 tuần )');
        var GiaQCTuan = $(GiaQC).attr('_gia');
        TongGiaQC.append(GiaQCTuan);
        TongGiaQC.attr('_Tonggia', GiaQCTuan)
        NgayDKQC.change(function () {
            DangKyDVQuangCaoFn.InputChange(NgayDKQC, NgayKTQC, SoNgayDKQC, TongGiaQC, GiaQC);
        });
        NgayKTQC.change(function () {
            DangKyDVQuangCaoFn.InputChange(NgayDKQC, NgayKTQC, SoNgayDKQC, TongGiaQC, GiaQC);
        });
    },
    QuayLai: function () {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var DangKyDichVuQCBuoc2 = $('.DangKyDichVuQC-Buoc-2', newDlg);
        var DangKyDichVuQCBuoc1 = $('.DangKyDichVuQC-Buoc-1', newDlg);
        DangKyDichVuQCBuoc2.hide();
        DangKyDichVuQCBuoc1.show();
    },
    SaveDKDVQC: function (validate, fn) {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var TenDV = $('.TenDV', newDlg);
        var DiaChiDV = $('.DiaChiDV', newDlg);
        var NguoiLienHe = $('.NguoiLienHe', newDlg);
        var Email = $('.Email', newDlg);
        var DienThoai = $('.DienThoai', newDlg);

        var _TenDV = TenDV.val();
        var _DiaChiDV = DiaChiDV.val();
        var _NguoiLienHe = NguoiLienHe.val();
        var _Email = Email.val();
        var _DienThoai = DienThoai.val();

        var TenQC = $('.TenQC', newDlg);
        var TrangQC = $('.TrangQC', newDlg);
        var ViTriQC = $('.ViTriQC', newDlg);
        var LinkUrl = $('.LinkUrl', newDlg);
        var NgayDKQC = $('.NgayDKQC', newDlg);
        var NgayKTQC = $('.NgayKTQC', newDlg);

        var _TenQC = TenQC.val();
        var _TrangQC = TrangQC.val();
        var _TrangQCID = TrangQC.attr('_value');
        var _ViTriQC = ViTriQC.val();
        var _ViTriQCID = ViTriQC.attr('_value');
        var _LinkUrl = LinkUrl.val();
        var _NgayDKQC = NgayDKQC.val();
        var _NgayKTQC = NgayKTQC.val();

        var lblAnh = $('.Anh', newDlg);
        var _Anh = lblAnh.attr('ref');

        var TongGiaQC = $('.TongGiaQC', newDlg);
        var _TongGiaQC = TongGiaQC.attr('_Tonggia');

        var err = '';

        if (_TenDV == '') {
            err = 'Bạn chưa điền tên đơn vị đăng ký dịch vụ'
        }
        if (_DiaChiDV == '') {
            err = 'Bạn chưa điền địa chỉ'
        }
        if (_NguoiLienHe == '') {
            err = 'Bạn cần điền tên người liên hệ'
        }
        if (_Email == '') {
            err = 'Bạn cần điền địa chỉ Email'
        }
        if (_DienThoai == '') {
            err = 'Bạn cần điền số điện thoại'
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }

        adm.loading('Đang lưu dữ liệu');
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString(),
            dataType: 'script',
            type: 'POST',
            data: {
                'subAct': 'SaveDKDVQC',
                'Ten': _TenQC,
                'Anh': _Anh,
                'Url': _LinkUrl,
                'ViTri': _ViTriQCID,
                'ViTri_Ten': _ViTriQC,
                'TrangQuangCao': _TrangQCID,
                'TrangQuangCao_Ten': _TrangQC,
                'NgayHetHan': _NgayKTQC,
                'NgayDangKy': _NgayDKQC,
                'TenDonVi': _TenDV,
                'DiaChiDonVi': _DiaChiDV,
                'NguoiLienHe': _NguoiLienHe,
                'Email': _Email,
                'DienThoai': _DienThoai,
                'SoTienThanhToan': _TongGiaQC
            },
            success: function (dt) {
                adm.loading(null);
                if (dt == '1') {
                    if (typeof (fn) == 'function') {
                        fn();
                    }
                    alert('Bạn đã đăng ký thành công dịch vụ quảng cáo.');
                }
                else {
                    spbMsg.html('Lỗi máy chủ, chưa thể lưu được dữ liệu');
                }
            }
        });
    },
    Buoc1: function (validate, fn) {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var TenQC = $('.TenQC', newDlg);
        var TrangQC = $('.TrangQC', newDlg);
        var ViTriQC = $('.ViTriQC', newDlg);
        var LinkUrl = $('.LinkUrl', newDlg);
        var NgayDKQC = $('.NgayDKQC', newDlg);
        var NgayKTQC = $('.NgayKTQC', newDlg);

        var _TenQC = TenQC.val();
        var _TrangQC = TrangQC.val();
        var _ViTriQC = ViTriQC.val();
        var _LinkUrl = LinkUrl.val();
        var _NgayDKQC = NgayDKQC.val();
        var _NgayKTQC = NgayKTQC.val();

        var err = '';

        if (_TenQC == '') {
            err = 'Bạn Chưa điền tên Quảng cáo'
        }
        if (_TrangQC == '' || _ViTriQC == '') {
            err = err + 'Bạn chưa chọn trang hoặc vị trí quảng cáo'
        }
        if (_LinkUrl == '') {
            err = err + 'Bạn chưa chọn liên kết cho Quảng cáo'
        }
        var convertDateNgayDKQC = DangKyDVQuangCaoFn.convertDate(NgayDKQC.val(), '/');
        var convertDateNgayKTQC = DangKyDVQuangCaoFn.convertDate(NgayKTQC.val(), '/');
        if (Date.parse(convertDateNgayKTQC) < Date.parse(convertDateNgayDKQC)) {
            err += 'ngày kết thúc phải lớn hơn ngày đăng ký';
        }
        if (_NgayDKQC == '') {
            err = err + 'Bạn chưa chọn ngày bắt đầu'
        }
        if (_NgayKTQC == '') {
            err = err + 'Bạn chưa chọn ngày kết thúc'
        }
        if (err != '') { alert(err); return false; }
        if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }

        var DangKyDichVuQCBuoc2 = $('.DangKyDichVuQC-Buoc-2', newDlg);
        var DangKyDichVuQCBuoc1 = $('.DangKyDichVuQC-Buoc-1', newDlg);
        DangKyDichVuQCBuoc2.show();
        DangKyDichVuQCBuoc1.hide();
    },
    InputChange: function (_NgayBD, _NgayKT, _SoNgay, _TongTien, _GiaThanhVien) {
        var NgayBD = $(_NgayBD);
        var NgayKT = $(_NgayKT);
        var SoNgay = $(_SoNgay);
        var TongTien = $(_TongTien);
        var GiaThanhVien = $(_GiaThanhVien);

        SoNgay.html('');
        TongTien.html('');

        var convertNgayBD = DangKyDVQuangCaoFn.convertDate(NgayBD.val(), '/');
        var convertNgayKT = DangKyDVQuangCaoFn.convertDate(NgayKT.val(), '/');
        var Datecount = DangKyDVQuangCaoFn.dateDiff('d', convertNgayBD, convertNgayKT);
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
        //console.log(giatt);
        var tongtientt = parseInt(convertweek) * giatt;
        TongTien.append(tongtientt);
        TongTien.attr('_Tonggia', tongtientt);
    },
    LoadInputChange: function (_id, fn) {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var ViTriQC = $('.ViTriQC', newDlg);
        ////console.log(idvtqc);
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=edit',
            dataType: 'script',
            data: {
                'ID': _id
            },
            success: function (dt) {
                var data = eval(dt);
                var GiaQC = $('.GiaQC', newDlg);
                GiaQC.append(data.GiaTri);
                GiaQC.attr('_gia', data.GiaTri);
                var KichThuoc = data.KyHieu;
                var ckickthuoc = KichThuoc.match(/[\d\.]+/g);
                var VitriQuangCaotext = $('.VitriQuangCaotext', newDlg);
                var ImgInfo = $('.Img-Info', newDlg);
                var Chieurong = ckickthuoc[0];
                var chieudai = ckickthuoc[1];
                $(ImgInfo).append('Kích thước : ' + Chieurong + ' x ' + chieudai + ' px');
                $(VitriQuangCaotext).append('<div class="adm-upload-preview-auto-size" style="width:' + Chieurong + 'px;height:' + chieudai + 'px"><img class="adm-upload-preview-img-dkdvqc" style="width:' + Chieurong + 'px;height:' + chieudai + 'px;" alt="" /></div><a style="vertical-align: top;margin-left:5px;" href="javascript:;" class="adm-upload-btn Anh" ref="">Chọn ảnh</a>');
                DangKyDVQuangCaoFn.uploadAnhQC(chieudai, Chieurong);
                if (typeof (fn) == 'function') { fn(); }
            }
        });
    },
    Samplesplit: function () {
        var str = '   120 x X * 150     ';
        //console.log(str + '1');
        var strv1 = $.trim(str);
        //console.log(strv1 + '2');
        var strv2 = strv1.split(' ').join('');
        //console.log(strv2 + '3');
        var cstr = strv2
    },
    clearformmath: function () {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var GiaQC = $('.GiaQC', newDlg);
        var VitriQuangCaotext = $('.VitriQuangCaotext', newDlg);
        var ImgInfo = $('.Img-Info', newDlg);
        var SoNgayDKQC = $('.SoNgayDKQC', newDlg);
        var TongGiaQC = $('.TongGiaQC', newDlg);

        SoNgayDKQC.html('');
        TongGiaQC.html('');
        GiaQC.html('');
        VitriQuangCaotext.html('');
        ImgInfo.html('');

    },
    popfn: function () {
        var newDlg = $('#DangKyDVQuangCaoFn-Main');
        var TrangQC = $('.TrangQC', newDlg);
        var ViTriQC = $('.ViTriQC', newDlg);
        var NgayDKQC = $('.NgayDKQC', newDlg);
        var NgayKTQC = $('.NgayKTQC', newDlg);

        DangKyDVQuangCaoFn.autoCompleteLangBased('', 'QC_DANHMUC', TrangQC, function (event, ui) {
            $(TrangQC).attr('_value', ui.item.id);
            ViTriQC.val('');
            ViTriQC.attr('_value', '');
            DangKyDVQuangCaoFn.clearformmath();
            DangKyDVQuangCaoFn.autoCompleteLangBasedByDanhMucId($(TrangQC).attr('_value'), ViTriQC, function (event, ui) {
                $(ViTriQC).attr('_value', ui.item.id);
                DangKyDVQuangCaoFn.clearformmath();
                DangKyDVQuangCaoFn.LoadInputChange($(ViTriQC).attr('_value'), function () {
                    DangKyDVQuangCaoFn.Mathtimefn();

                });
            });
            $(ViTriQC).unbind('click').click(function () { $(ViTriQC).autocomplete('search', ''); });
        });
        $(TrangQC).unbind('click').click(function () { $(TrangQC).autocomplete('search', ''); });
        NgayDKQC.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
        NgayKTQC.datepicker({ defaultDate: +7, dateFormat: 'dd/mm/yy', showButtonPanel: true });
    },
    LoadThongTinDangKyDichVuDonVi: function () {
        $.ajax({
            url: DangKyDVQuangCaoFn.urlDefault().toString() + '&subAct=get',
            dataType: 'script',
            data: {
        },
        success: function (dt) {
            var data = eval(dt);
            var newDlg = $('#DangKyDVQuangCaoFn-Main');
            var TenDV = $('.TenDV', newDlg);
            var DiaChiDV = $('.DiaChiDV', newDlg);
            var NguoiLienHe = $('.NguoiLienHe', newDlg);
            var Email = $('.Email', newDlg);
            var DienThoai = $('.DienThoai', newDlg);

            TenDV.val(data.Ten);
            DiaChiDV.val(data.DiaChi);
            NguoiLienHe.val(data.NguoiDaiDien);
            Email.val(data.Email);
            DienThoai.val(data.DienThoai);

        }
    });
},
LoadFormhtml: function (_obj, fn) {
    var obj = $(_obj);
    var newDlg = $('.DangKyDVQuangCao-Newdlg');
    if ($(newDlg, obj).length < 1) {
        adm.loading('Load form');
        $(obj).load('<%=WebResource("cnn.plugin.DangKyDichVu.DangKyDVQuangCao.htm.htm")%>', function () {
            adm.loading(null);
            if (typeof (fn) == 'function') { fn(); }
        });
    }
},
autoCompleteLangBased: function (id, ldm_ma, el, fn) {
    $(el).autocomplete({
        source: function (request, response) {
            var term = 'danhMuc-autoCompleteLangBased' + id + ldm_ma;
            adm.loading('Nạp danh sách');
            _lastXhr = $.ajax({
                url: DangKyDVQuangCaoFn.urlDefault().toString(),
                dataType: 'script',
                data: { 'subAct': 'autoCompleteLangBased', 'LDM_Ma': ldm_ma, 'ID': id },
                success: function (dt, status, xhr) {
                    adm.loading(null);
                    var data = eval(dt);
                    _cache[term] = data;
                    if (xhr === _lastXhr) {
                        var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                        response($.map(data, function (item) {
                            if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                return {
                                    label: item.Ten,
                                    value: item.Ten,
                                    id: item.ID,
                                    rowid: item.RowId,
                                    ma: item.Ma,
                                    kyhieu: item.KyHieu,
                                    giatri: item.GiaTri,
                                    level: item.Level
                                }
                            }
                        }))
                    }
                }
            });
        },
        minLength: 0,
        select: function (event, ui) {
            fn(event, ui);
        },
        change: function (event, ui) {
            if (!ui.item) {
                if ($(this).val() == '') {
                    $(this).attr('_value', '');
                }
            }
        },
        delay: 0,
        selectFirst: true
    }).data("autocomplete")._renderItem = function (ul, item) {
        return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
    };
},
autoCompleteLangBasedByDanhMucId: function (id, el, fn) {
    ////console.log(id);
    $(el).autocomplete({
        source: function (request, response) {
            var term = 'danhMuc-autoCompleteLangBasedByDanhMucId' + id;
            adm.loading('Nạp danh sách');
            _lastXhr = $.ajax({
                url: DangKyDVQuangCaoFn.urlDefault().toString(),
                dataType: 'script',
                data: { 'subAct': 'autoCompleteLangBasedByDanhMucId', 'ID': id },
                success: function (dt, status, xhr) {
                    adm.loading(null);
                    var data = eval(dt);
                    _cache[term] = data;
                    if (xhr === _lastXhr) {
                        var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                        response($.map(data, function (item) {
                            if (matcher.test(item.Ten.toLowerCase()) || matcher.test(adm.normalizeStr(item.Ten.toLowerCase()))) {
                                return {
                                    label: item.Ten,
                                    value: item.Ten,
                                    id: item.ID,
                                    rowid: item.RowId,
                                    ma: item.Ma,
                                    kyhieu: item.KyHieu,
                                    giatri: item.GiaTri,
                                    level: item.Level
                                }
                            }
                        }))
                    }
                }
            });
        },
        minLength: 0,
        select: function (event, ui) {
            fn(event, ui);
        },
        change: function (event, ui) {
            if (!ui.item) {
                if ($(this).val() == '') {
                    $(this).attr('_value', '');
                }
            }
        },
        delay: 0,
        selectFirst: true
    }).data("autocomplete")._renderItem = function (ul, item) {
        return $("<li></li>")
				            .data("item.autocomplete", item)
				            .append("<a style=\"margin-left:" + (parseInt(item.level) * 10) + "px;\">" + item.label + "</a>")
				            .appendTo(ul);
    };
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
}
}


