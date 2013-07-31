doanhNghiepChuaDuyetFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.chuaDuyet.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepChuaDuyetMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepChuaDuyetMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepChuaDuyetMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepChuaDuyetMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepChuaDuyetMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepChuaDuyetMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepChuaDuyetMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepChuaDuyetMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepChuaDuyetMdl-head');
        var _get_gh = 'getChuaDuyet';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepChuaDuyetMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.chuaDuyet.doanhNghiepChuaDuyet.htm")%>', function () {
                var _subMdl = $('#doanhNghiepChuaDuyetMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepChuaDuyetMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepChuaDuyetMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepChuaDuyetMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepChuaDuyetMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepChuaDuyetMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepChuaDuyetMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepChuaDuyetMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepChuaDuyetMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepChuaDuyetMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepChuaDuyetMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepChuaDuyetMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepChuaDuyetMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepChuaDuyetMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepChuaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepChuaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepChuaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepChuaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },

    xacnhan: function () {
        var _NewDlg = $('#doanhNghiepChuaDuyetMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepChuaDuyetMdl-List', _NewDlg);
        doanhNghiepFn.xacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _NewDlg = $('#doanhNghiepChuaDuyetMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepChuaDuyetMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepChuaDuyetMdl-NangCapTV-NewDlg');
        doanhNghiepFn.nangCapThanhVien(_gridMain, _DlgNangCapTV);
    }

}






 





 