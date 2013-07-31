doanhNghiepTVMPFn = {
    urlDefault: function () { return adm.urlDefault + '&act=loadPlug&rqPlug=cnn.plugin.doanhNghiep.thanhVienMienPhi.Class1, cnn.plugin.doanhNghiep'; },
    setup: function () { },
    NapdoanhNghiepFn: function () {
        var _NewDlg = $('#doanhNghiepTVMPMdl-Main-NewDlg');
        var _DlgChungChi = $('#doanhNghiepTVMPMdl-ChungChi-NewDlg');
        var _DlgVideo = $('#doanhNghiepTVMPMdl-Video-NewDlg');
        var _DlgFlash = $('#doanhNghiepTVMPMdl-Flash-NewDlg');
        var _DlgHinhAnh = $('#doanhNghiepTVMPMdl-HinhAnh-NewDlg');
        var _NewDlgBody = $('#doanhNghiepTVMPMdl-Body-NewDlg', _NewDlg);

        var _filterSP = $('.mdl-head-filterNhomSP', '#doanhNghiepTVMPMdl-head');
        var _filterKV = $('.mdl-head-filterKhuVuc', '#doanhNghiepTVMPMdl-head');
        var _searchTxt = $('.mdl-head-search-doanhNghiepTVBMdl', '#doanhNghiepTVMPMdl-head');
        var _get_gh = 'getTVMP';

        adm.regType(typeof (doanhNghiepFn), 'cnn.plugin.doanhNghiep.doanhNghiep, cnn.plugin.doanhNghiep', function () {
            var _newDlgForm = $('#doanhNghiepTVMPMdl-subMdl', _NewDlg);
            doanhNghiepFn.loadMainHtml(_NewDlgBody, _newDlgForm, '<%=WebResource("cnn.plugin.doanhNghiep.thanhVienMienPhi.doanhNghiepTVMP.htm")%>', function () {
                var _subMdl = $('#doanhNghiepTVMPMdl-subMdl', _NewDlgBody);
                var _gridMain = $('#doanhNghiepTVMPMdl-List', _NewDlg);
                var _pagerMain = $('#doanhNghiepTVMPMdl-Pager', _NewDlg);
                var _gridChungChi = $('#doanhNghiepTVMPMdl-subChungChiMdl-List', _NewDlgBody);
                var _pagerChungChi = $('#doanhNghiepTVMPMdl-ChungChiPager', _NewDlgBody);
                var _gridVideo = $('#doanhNghiepTVMPMdl-subVideoMdl-List', _NewDlgBody);
                var _pagerVideo = $('#doanhNghiepTVMPMdl-VideoPager', _NewDlgBody);
                var _gridFlash = $('#doanhNghiepTVMPMdl-subFlashMdl-List', _NewDlgBody);
                var _pagerFlash = $('#doanhNghiepTVMPMdl-FlashPager', _NewDlgBody);
                var _gridHinhAnh = $('#doanhNghiepTVMPMdl-subHinhAnhMdl-List', _NewDlgBody);
                var _pagerHinhAnh = $('#doanhNghiepTVMPMdl-HinhAnhPager', _NewDlgBody);
                var _newDlgLienHe = $('#doanhNghiepTVMPMdl-subLienHeMdl', _NewDlgBody);
                var _newDlgTaiKhoan = $('#doanhNghiepTVMPMdl-subThongTinTKMdl', _NewDlgBody);
                var _newDlgThongTin = $('#doanhNghiepTVMPMdl-subThongTinMdl', _NewDlgBody);

                doanhNghiepFn.loadForm(_get_gh, _NewDlg, _subMdl, _gridMain, _pagerMain, _gridChungChi, _pagerChungChi, _gridVideo, _pagerVideo, _gridFlash, _pagerFlash, _gridHinhAnh, _pagerHinhAnh, _filterSP, _filterKV, _searchTxt, _newDlgLienHe, _newDlgTaiKhoan, _newDlgThongTin, _DlgChungChi, _DlgVideo, _DlgFlash, _DlgHinhAnh);
            });
        });

    },

    del: function () {
        var _NewDlg = $('#doanhNghiepTVMPMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVMPMdl-List', _NewDlg);
        doanhNghiepFn.del(_girdMain);

    },
    active: function () {
        var _NewDlg = $('#doanhNghiepTVMPMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVMPMdl-List', _NewDlg);
        doanhNghiepFn.Active(_girdMain);
    },

    boxacnhan: function () {
        var _NewDlg = $('#doanhNghiepTVMPMdl-Main-NewDlg');
        var _girdMain = $('#doanhNghiepTVMPMdl-List', _NewDlg);
        doanhNghiepFn.boxacnhan(_girdMain);
    },
    nangCapTV: function () {
        var _get_gh = 'getTVMP';
        var _NewDlg = $('#doanhNghiepTVMPMdl-Main-NewDlg');
        var _gridMain = $('#doanhNghiepTVMPMdl-List', _NewDlg);
        var _DlgNangCapTV = ('#doanhNghiepTVMPMdl-NangCapTV-NewDlg');       
        doanhNghiepFn.nangCapThanhVien(_get_gh,_gridMain, _DlgNangCapTV);

    }

}






 





 