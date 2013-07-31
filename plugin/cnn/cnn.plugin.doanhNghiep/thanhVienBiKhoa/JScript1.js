doanhNghiepTVBKFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.thanhVienBiKhoa.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepTVBKMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepTVBKMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepTVBKMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepTVBKMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepTVBKMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepTVBKMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepTVBKMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepTVBKMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepTVBKMdl-head');
        var _get_gh = 'getTVBK';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepTVBKMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.thanhVienBiKhoa.doanhNghiepTVBK.htm")%>', function () {
                var _subMdl = $('#doanhNghiepTVBKMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepTVBKMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepTVBKMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepTVBKMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepTVBKMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepTVBKMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepTVBKMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepTVBKMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepTVBKMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepTVBKMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepTVBKMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepTVBKMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepTVBKMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepTVBKMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepTVBKMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVBKMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    activeTVBK: function () {    
        var _NewDlg = $('#doanhNghiepTVBKMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVBKMdl-List', _NewDlg);
        doanhNghiepFn.ActiveTVBK(_girdMain);
    }

}






 





 