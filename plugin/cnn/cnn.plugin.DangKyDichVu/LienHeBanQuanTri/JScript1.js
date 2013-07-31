LienHeBanQuanTriFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.DangKyDichVu.LienHeBanQuanTri.Class1, cnn.plugin.DangKyDichVu'; },
    setup: function () { },
    LoadForm: function () {
        adm.styleButton();
        var LienHeBanQuantriFnMain = $('#LienHeBanQuantriFn-Main');
        LienHeBanQuanTriFn.LoadFormhtml(LienHeBanQuantriFnMain, function () {
            LienHeBanQuanTriFn.ProcessMain();
            adm.styleButton();
        });
    },
    LoadFormhtml: function (_obj, fn) {
        var obj = $(_obj);
        var newDlg = $('.LienHeBanQuanTri-Newdlg');
        ////console.log('1');
        if ($(newDlg, obj).length < 1) {
            adm.loading('Load form');
            $(obj).load('<%=WebResource("cnn.plugin.DangKyDichVu.LienHeBanQuanTri.htm.htm")%>', function () {
                ////console.log(newDlg);
                ////console.log('2');
                adm.loading(null);
                if (typeof (fn) == 'function') { fn(); }
            });
        }
    },
    ProcessMain: function () {
        var newDlg = $('#LienHeBanQuantriFn-Main');
        var txtTieuDe = $('.txtTieuDe', newDlg);
        var txtNoiDung = $('.txtNoiDung', newDlg);
        LienHeBanQuanTriFn.LoadHotro();
    },
//    LoadThongTinDoanhNghiep: function () {
//        var newDlg = $('#LienHeBanQuantriFn-Main');
//        var TenDoanhNghiep = $('.TenDoanhNghiep', newDlg);
//        var DiaChi = $('.DiaChi', newDlg);
//        var LTV = $('.LTV', newDlg);
//        var NgayDK = $('.NgayDK', newDlg);
//        var NguoiDaiDien = $('.NguoiDaiDien', newDlg);
//        var DienThoai = $('.DienThoai', newDlg);
//        var Website = $('.Website', newDlg);
//        $.ajax({
//            url: LienHeBanQuanTriFn.urlDefault().toString() + '&subAct=get',
//            dataType: 'script',
//            data: {
//        },
//        success: function (dt) {
//            var data = eval(dt);
//            TenDoanhNghiep.append(data.Ten);
//            DiaChi.append(data.DiaChi);
//            NgayDK.append(data.NgayTao);
//            NguoiDaiDien.append(data.NguoiDaiDien);
//            DienThoai.append(data.DienThoai);
//            Website.append(data.Website);
//        }
//    });
//},
sendLienHe: function (validate, fn) {
    var newDlg = $('#LienHeBanQuantriFn-Main');
    var txtNoiDung = $('.txtNoiDungLienHe', newDlg);
    var txtTieuDeLienHe = $('.txtTieuDeLienHe', newDlg)

    var tieude = $(txtTieuDeLienHe).val();
    var noidung = $(txtNoiDung).val();
    if (tieude == '') { alert('bạn phải điền tiêu đề'); return false; }
    if (noidung == '') { alert('bạn phải điền nội dung'); return false; }
    if (validate) { if (typeof (fn) == 'function') { fn(); } return false; }
    adm.loading('Đang gửi liên hệ');
    $.ajax({
        url: LienHeBanQuanTriFn.urlDefault().toString() + '&subAct=lienHe',
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
        url: LienHeBanQuanTriFn.urlDefault().toString() + '&subAct=LoadHoTroDKDV',
        dataType: 'script',
        data: {
            'MaDanhMuc': 'LIENHE'
        },
        success: function (dt) {
            adm.loading(null);
            var data = eval(dt);
            var newDlg = $('#LienHeBanQuantriFn-Main');
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
}

}


