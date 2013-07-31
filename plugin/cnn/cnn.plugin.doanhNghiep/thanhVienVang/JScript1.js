doanhNghiepTVVFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.thanhVienVang.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepTVVMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepTVVMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepTVVMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepTVVMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepTVVMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepTVVMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepTVVMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepTVVMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepTVVMdl-head');
        var _get_gh = 'getTVV';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepTVVMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.thanhVienVang.doanhNghiepTVV.htm")%>', function () {
                var _subMdl = $('#doanhNghiepTVVMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepTVVMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepTVVMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepTVVMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepTVVMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepTVVMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepTVVMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepTVVMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepTVVMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepTVVMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepTVVMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepTVVMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepTVVMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepTVVMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepTVVMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVVMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepTVVMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVVMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },

    boxacnhan: function () {
        var _NewDlg = $('#doanhNghiepTVVMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVVMdl-List', _NewDlg);
        doanhNghiepFn.boxacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _get_gh = 'getTVV';
        var _NewDlg = $('#doanhNghiepTVVMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepTVVMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepTVVMdl-NangCapTV-NewDlg');
        doanhNghiepFn.nangCapThanhVien(_get_gh,_gridMain, _DlgNangCapTV);
    }

}






 





 