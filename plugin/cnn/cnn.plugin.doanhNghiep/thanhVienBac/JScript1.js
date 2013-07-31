doanhNghiepTVBFn= {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.thanhVienBac.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepTVBMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepTVBMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepTVBMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepTVBMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepTVBMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepTVBMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepTVBMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepTVBMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepTVBMdl-head');
        var _get_gh = 'getTVB';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepTVBMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm,'<%=WebResource("cnn.plugin.doanhNghiep.thanhVienBac.doanhNghiepTVB.htm")%>', function () {
                var _subMdl = $('#doanhNghiepTVBMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepTVBMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepTVBMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepTVBMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepTVBMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepTVBMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepTVBMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepTVBMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepTVBMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepTVBMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepTVBMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepTVBMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepTVBMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepTVBMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepTVBMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVBMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepTVBMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVBMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },

    boxacnhan: function () {
        var _NewDlg = $('#doanhNghiepTVBMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVBMdl-List', _NewDlg);
        doanhNghiepFn.boxacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _get_gh = 'getTVB';
        var _NewDlg = $('#doanhNghiepTVBMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepTVBMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepTVBMdl-NangCapTV-NewDlg');
        doanhNghiepFn.nangCapThanhVien(_get_gh,_gridMain, _DlgNangCapTV);
    }

}






 





 