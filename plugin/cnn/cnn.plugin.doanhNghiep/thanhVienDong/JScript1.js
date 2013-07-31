doanhNghiepTVDFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.thanhVienDong.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepTVDMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepTVDMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepTVDMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepTVDMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepTVDMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepTVDMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepTVDMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepTVDMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepTVDMdl-head');
        var _get_gh = 'getTVD';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepTVDMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.thanhVienDong.doanhNghiepTVD.htm")%>', function () {
                var _subMdl = $('#doanhNghiepTVDMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepTVDMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepTVDMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepTVDMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepTVDMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepTVDMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepTVDMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepTVDMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepTVDMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepTVDMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepTVDMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepTVDMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepTVDMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepTVDMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepTVDMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVDMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepTVDMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVDMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },

    boxacnhan: function () {
        var _NewDlg = $('#doanhNghiepTVDMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVDMdl-List', _NewDlg);
        doanhNghiepFn.boxacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _get_gh = 'getTVD';
        var _NewDlg = $('#doanhNghiepTVDMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepTVDMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepTVDMdl-NangCapTV-NewDlg');
        doanhNghiepFn.nangCapThanhVien(_get_gh,_gridMain, _DlgNangCapTV);
    }

}






 





 