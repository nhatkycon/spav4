jQuery(function () {
    var slideShowTimer;
    var slideShowInterval = 2000;
    var slideShowInt = 0;
    jQuery.each(jQuery('li', '.navi-top'), function (i, _item) {
        var item = jQuery(_item);

        var flyOut = item.find('div');
        var aItem = item.find('.navi-top-item');
        if (jQuery(flyOut).length > 0) {
            item.mouseenter(function () {
                aItem.addClass('navi-top-item-focus');
                var previousItem = item.prev();
                if ($(previousItem).length > 0) {
                    previousItem.find('.navi-top-item').addClass('navi-top-item-prev');
                }
                getEl(item, function (_t, _l, _w, _t1) {
                    flyOut.show().css({ 'left': (_l) + 'px', 'top': (_t1 - 1) + 'px' });
                    item.mouseleave(function () {
                        flyOut.hide();
                        aItem.removeClass('navi-top-item-focus');
                        if ($(previousItem).length > 0) {
                            previousItem.find('.navi-top-item').removeClass('navi-top-item-prev');
                        }
                    });
                });
            });
        }
    });

    jQuery.each(jQuery('.cate-home-li'), function (i, _item) {
        var item = jQuery(_item);
        var flyOut = item.find('.cate-flyOut');
        var aItem = item.find('.cate-item');
        var fBox = item.find('.cate-flyOut-featured-box');
        if (jQuery(flyOut).length > 0) {
            item.mouseenter(function () {
                aItem.addClass('cate-item-focus');
                var _loaded = fBox.attr('_loaded');
                var _DM_ID = fBox.attr('_DM_ID');
                if (_loaded == '0') {
                    fBox.html('nạp...');
                    jQuery.ajax({
                        url: domain + '/lib/pages/San_pham_menu_ajax.aspx?ref=' + Math.random(),
                        data: { 'DM_ID': _DM_ID },
                        success: function (dt) {
                            fBox.html(dt);
                            fBox.attr('_loaded', '1')
                        }
                    });
                }
                getEl(item, function (_t, _l, _w) {
                    //flyOut.show().css({ 'left': (_l + _w - 3) + 'px', 'top': _t + 'px' });
                    flyOut.show().css({ 'left': (_l + _w - 2) + 'px', 'top': (_t - 1) + 'px' });
                    item.mouseleave(function () {
                        flyOut.hide();
                        aItem.removeClass('cate-item-focus');
                    });
                });
            });
        }
    });

    $('.navi-top').find('.navi-top-item:last').addClass('navi-top-item-last');
    $('.tin-lienQuan-body').find('.tin-item:last').addClass('tin-item-last');


    $.fn.raty.defaults.path = '/lib/css/web/1/i/';


    $('.star-el').each(function () {
        var item = $(this);
        item.raty({ score: item.attr('data-score'), readOnly: true });
    });

    var posBox = $('.tin-view-bl-posBox');
    if ($(posBox).length > 0) {
        if ($('#star').length > 0) {
            $('#star').raty({
                cancelOff: 'cancel-off-big.png',
                cancelOn: 'cancel-on-big.png',
                size: 24,
                starHalf: 'star-half-big.png',
                starOff: 'star-off-big.png',
                starOn: 'star-on-big.png',
                scoreName: 'Star',
                width: 400
            });
        }

        var bt = posBox.find('.bl-btn');
        var Ten = posBox.find('.Ten');
        var Email = posBox.find('.Email');
        var Mobile = posBox.find('.Mobile');
        var NoiDung = posBox.find('.NoiDung');
        bt.unbind('click').click(function () {
            var Star = $('[name="Star"]');
            if ($(Star).val() == '') {
                alert('Bạn cần phải bình chọn đã nhé');
                return false;
            }
            var _PID = bt.attr('_ID');
            var _Ten = Ten.val();
            var _Email = Email.val();
            var _Mobile = Mobile.val();
            var _NoiDung = NoiDung.val();
            var _Star = Star.val();
            if (_Ten == '') { alert('Nhập tên'); Ten.focus(); return false; }
            if (_Email == '') { alert('Nhập Email'); Email.focus(); return false; }
            var _txt = bt.html();
            bt.html('Đang gửi...');
            $.ajax({
                url: domain + '/lib/aspx/comment/Default.aspx?ref=' + Math.random(),
                type: 'POST',
                data: { 'PID': _PID, 'Ten': _Ten, 'Mobile': _Mobile, 'Email': _Email, 'NoiDung': _NoiDung, 'act': 'add', 'Kieu': bt.attr('data-type'), 'Star': _Star },
                success: function (_dt) {
                    posBox.find('input,textarea').val('');
                    alert('Cám ơn bạn đã bình luận, chúng tôi sẽ sớm hồi âm cho bạn');
                    bt.html(_txt);
                }
            });

        });
    }

    jQuery.each(jQuery('.home-mdl-tin-header-item'), function (i, _item) {
        var item = jQuery(_item);
        item.click(function () {
            var _ref = item.attr('_ref');
            item.parent().find('.home-mdl-tin-header-item-active').removeClass('home-mdl-tin-header-item-active');
            item.addClass('home-mdl-tin-header-item-active');
            item.parent().next().find('.home-mdl-tin-body-active').removeClass('home-mdl-tin-body-active');
            item.parent().next().find('.home-mdl-tin-body[_ref=\'' + _ref + '\']').addClass('home-mdl-tin-body-active');
        });
    });

    $('.home-mdl-tin-content-leftBtn').click(function () {
        var item = $(this);
        var pnl = item.parent().find('.home-mdl-tin-content-box');
        $(pnl).scrollTo('-=500px', 500);
    });
    $('.home-mdl-tin-content-rightBtn').click(function () {
        var item = $(this);
        var pnl = item.parent().find('.home-mdl-tin-content-box');
        $(pnl).scrollTo('+=500px', 500);
    });
    loginFunction.init();
    var DVU = $('.search-item-txt-DVU');
    var QUAN = $('.search-item-txt-QUAN');
    var searchbtn = $('.search-btn');
    adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
        danhmuc.autoCompleteByLoai('QUAN', QUAN, function (event, ui) {
            $(QUAN).attr('_value', ui.item.id);
            document.location.href = domain + '/Danh-ba-Spa/' + ui.item.ma + '/' + ui.item.id + '/';
        });
        danhmuc.autoCompleteByLoai('DVU', DVU, function (event, ui) {
            $(DVU).attr('_value', ui.item.id);
            document.location.href = domain + '/Dich-vu-Spa/' + ui.item.ma + '/' + ui.item.id + '/';
            //console.log(ui.item);
        });
    });
    searchbtn.click(function () {
        document.location.href = domain + '/Dich-vu-Spa/';
    });

    $('.ddv-btn').each(function () {
        var item = $(this);
        item.click(function () {
            var id = item.attr('data-id');
            var type = item.attr('data-type');
            if (loggedIn) {
                adm.regType(typeof (datDichVuFn), 'plugin.spa.datDichVuMgr.Class1, plugin.spa.datDichVuMgr', function () {
                    datDichVuFn.addDangKy(id, type, function () {
                    });
                });
            }
            else {
                loginFunction.createFbUser(function () {
                    adm.regType(typeof (datDichVuFn), 'plugin.spa.datDichVuMgr.Class1, plugin.spa.datDichVuMgr', function () {
                        datDichVuFn.addDangKy(id, type, function () {
                        });
                    });
                });
            }
        });
    });

    $('.datCauHoiChungBtn').each(function (i) {
        var item = $(this);
        item.click(function () {
            if (loggedIn) {
                adm.regType(typeof (spaHoiDapMgrFn), 'plugin.spa.SpaHoiDapMgr.Class1, plugin.spa.SpaHoiDapMgr', function () {
                    spaHoiDapMgrFn.datCauHoi(function () {
                    });
                });
            }
            else {
                loginFunction.createFbUser(function () {
                    adm.regType(typeof (spaHoiDapMgrFn), 'plugin.spa.SpaHoiDapMgr.Class1, plugin.spa.SpaHoiDapMgr', function () {
                        spaHoiDapMgrFn.datCauHoi(function () {
                        });
                    });
                });
            }
        });
    });

    $('.datCauHoiDichVuBtn').each(function (i) {
        var item = $(this);
        item.click(function () {
            var id = item.attr('data-dv-id');
            if (loggedIn) {
                adm.regType(typeof (spaHoiDapMgrFn), 'plugin.spa.SpaHoiDapMgr.Class1, plugin.spa.SpaHoiDapMgr', function () {
                    spaHoiDapMgrFn.datCauHoiDichVu(id, function () {
                    });
                });
            }
            else {
                loginFunction.createFbUser(function () {
                    adm.regType(typeof (spaHoiDapMgrFn), 'plugin.spa.SpaHoiDapMgr.Class1, plugin.spa.SpaHoiDapMgr', function () {
                        spaHoiDapMgrFn.datCauHoiDichVu(id, function () {
                        });
                    });
                });
            }
        });
    });


});
function getEl(el, fn) {
    var _offset = jQuery(el).offset();
    var _t = _offset.top;
    var _l = _offset.left;
    var _w = el.width();
    var _h = el.height();
    var _pt = parseInt(el.css('padding-top').toString().toLowerCase().replace('px', ''));
    var _pb = parseInt(el.css('padding-bottom').toString().toLowerCase().replace('px', ''));
    var _mt = parseInt(el.css('margin-top').toString().toLowerCase().replace('px', ''));
    var _mb = parseInt(el.css('margin-bottom').toString().toLowerCase().replace('px', ''));
    var _bb = parseInt(el.css('border-bottom-width').toString().toLowerCase().replace('px', ''));
    var _bt = parseInt(el.css('border-top-width').toString().toLowerCase().replace('px', ''));
    var _t1 = 0;
    _t1 = _t + _h + ((_pt == NaN) ? _pt : 0) + ((_pb == NaN) ? _pb : 0) + ((_mt == NaN) ? _mt : 0) + ((_mb == NaN) ? _mb : 0) + ((_bb == NaN) ? _bb : 0) + ((_bt == NaN) ? _bt : 0);
    if (typeof (fn) == 'function') { fn(_t, _l, _w, _t1); }
}


var IsFacebookAppInit = false;
var FacebookAppIdKey = 364176790369842;
var loginFunction = {
    init: function () {
        var createBtn = $('.item-icon-dangky');
        createBtn.click(function () {
            loginFunction.createFbUser();
        });
        loginFunction.FacebookAppInit();
        var dangNhap = $('.item-icon-dangNhap');
        dangNhap.click(function () {
            //            adm.regType(typeof (preload), 'docsoft.hethong.preload.Class1, docsoft.hethong.preload', function () {
            //                preload.login(function () {
            //                    document.location.reload();
            //                    return false;
            //                });
            //            });
            loginFunction.createFbUser();
        });

        var logOut = $('.item-icon-thoat');
        logOut.click(function () {
            adm.regType(typeof (preload), 'docsoft.hethong.preload.Class1, docsoft.hethong.preload', function () {
                preload.logout();
            });
        });

        var joinBtn = $('.sk-item-header-join');
        joinBtn.click(function () {
            var _id = joinBtn.attr('_id');
            if ($(dangNhap).length > 0) {
                adm.regType(typeof (preload), 'docsoft.hethong.preload.Class1, docsoft.hethong.preload', function () {
                    preload.login(function () {
                        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                            thanhvien.dangKySk(_id, function (dt) {

                            });
                        });
                        return false;
                    });
                });
            } else {
                adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
                    thanhvien.dangKySk(_id, function (dt) {

                    });
                });
            }
        });

        loginFunction.myProfileFn();
        loginFunction.binhLuanFn();
    },
    createFbUser: function (fn, fn1) {
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            thanhvien.createUser(function (dt) {
                if(typeof(fn) == "function") {
                    fn();
                }else {
                    document.location.reload();

                }
            }, function () {
                if (typeof (fn) == "function") {
                    fn();
                } else {
                    document.location.reload();
                }
            });
        });
    },
    myProfileFn: function (fn) {
        var bd = $('#user-myProfileInfo');
        if ($(bd).length < 1) {
            return false;
        }
        var btnSaveInfo = bd.find('.item-icon-saveInfo');
        adm.regType(typeof (thanhvien), 'docsoft.plugin.hethong.thanhvien.Class1, docsoft.plugin.hethong.thanhvien', function () {
            $.ajax({
                url: thanhvien.urlDefault,
                data: { subAct: 'editUsr' },
                dataType: 'script',
                success: function (_dt) {
                    if (_dt == '') {
                        document.location.href = domain;
                        return false;
                    }
                    var dt = eval(_dt);
                    var Truong = bd.find('.Truong');
                    var Mobile = bd.find('.Mobile');
                    var Lop = bd.find('.Lop');
                    var Que = bd.find('.Que');
                    var Ten = bd.find('.Ten');
                    var Email = bd.find('.Email');
                    var Anh = bd.find('.Anh');
                    var uploadView = bd.find('.adm-preview-img');

                    var ulpFn = function () {
                        var _params = { 'oldFile': Anh.attr('ref') };
                        adm.upload(Anh, 'anh', _params, function (rs) {
                            Anh.attr('ref', rs)
                            $(uploadView).attr('src', domain + '/lib/up/i/' + rs + '?ref=' + Math.random());
                            Anh.attr('loai', 'up');
                            ulpFn();
                        }, function (f) {
                        });
                    }
                    ulpFn();

                    Truong.val(dt.Truong_Ten);
                    Que.val(dt.Que_Ten);
                    Lop.val(dt.Lop);
                    Mobile.val(dt.Mobile);
                    Ten.html(dt.Ten);
                    Email.html(dt.Email);
                    adm.styleButton();

                    adm.regType(typeof (danhmuc), 'docsoft.plugin.danhmuc.Class1, docsoft.plugin.danhmuc', function () {
                        danhmuc.autoCompleteLangBased('', 'Truong', Truong, function (event, ui) {
                            Truong.attr('_value', ui.item.id);
                        });
                        danhmuc.autoCompleteLangBased('', 'Tinh', Que, function (event, ui) {
                            Que.attr('_value', ui.item.id);
                        });
                    });

                    btnSaveInfo.click(function () {
                        var Truong = bd.find('.Truong');
                        var Mobile = bd.find('.Mobile');
                        var Lop = bd.find('.Lop');
                        var Que = bd.find('.Que');
                        var Ten = bd.find('.Ten');
                        var Email = bd.find('.Email');
                        var Anh = bd.find('.Anh');

                        var _Truong = Truong.attr('_value');
                        var _Mobile = Mobile.val();
                        var _Lop = Lop.val();
                        var _Que = Que.attr('_value');
                        var _Anh = Anh.attr('ref');
                        var _Ten = Ten.val();

                        var err = '';
                        if (_Ten == '') {
                            err += 'Chọn tên <br/>';
                        }
                        if (_Truong == '') {
                            err += 'Chọn trường <br/>';
                        }
                        if (_Mobile == '') {
                            err += 'Nhập mobile <br/>';
                        }
                        if (_Lop == '') {
                            err += 'Nhập lớp <br/>';
                        }
                        if (_Que == '') {
                            err += 'Chọn hội đồng hương đi bạn <br/>';
                        }
                        if (err != '') {
                            common.fbMsg('Lỗi này bạn ơi', '<h1>Bạn cần chỉnh ngay nhé:</h1>' + err, 200, 'msg-portal-pop', function () {
                                setTimeout(function () {
                                    $(document).trigger('close.facebox', 'msg-portal-pop');
                                }, 5000);
                            });
                            return false;
                        }
                        $.ajax({
                            url: thanhvien.urlDefault,
                            data: { Truong: _Truong, Mobile: _Mobile, Lop: _Lop, Que: _Que, Anh: _Anh, subAct: 'saveInfo' },
                            success: function (_dt) {
                                if (_dt == '1') {
                                    common.fbMsg('Xong rồi này', '<h1>Bạn đã lưu thành công</h1>:"> Quá giỏi lun', 200, 'msg-portal-pop', function () {
                                        setTimeout(function () {
                                            $(document).trigger('close.facebox', 'msg-portal-pop');
                                            document.location.reload();
                                        }, 5000);
                                    });
                                } else {
                                    common.fbMsg('Dính lỗi rồi :(( ặc ặc', '<h1>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h1>' + _dt + '<br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net', 200, 'msg-portal-pop', function () {
                                        setTimeout(function () {
                                            $(document).trigger('close.facebox', 'msg-portal-pop');
                                        }, 5000);
                                    });
                                }
                            }
                        });
                    });
                }
            })
        });
    },
    binhLuanFn: function () {
        var blPost = $('.bl-post');
        if ($(blPost).length < 1) {
            return false;
        }
        blPost.click(function () {
            var thoat = $('.item-icon-thoat');
            if ($(thoat).length < 1) {
                adm.regType(typeof (preload), 'docsoft.hethong.preload.Class1, docsoft.hethong.preload', function () {
                    preload.login(function () {
                        loginFunction.binhLuanPostFn(blPost.parent(), function () {
                            document.location.reload();
                        });
                        return false;
                    });
                });
            } else {
                loginFunction.binhLuanPostFn(blPost.parent(), function () {
                });
            }
        });
    },
    binhLuanPostFn: function (blPost, fn) {
        common.fbJquery('Bình luận', blPost, 690, 'bl-post', function (bd) {
            var btn = bd.find('.item-icon-post');
            btn.click(function () {
                var Ten = bd.find('.Ten');
                var NoiDung = bd.find('.NoiDung');
                var _Ten = Ten.val();
                var _NoiDung = NoiDung.val();
                var err = '';
                if (_Ten == '') {
                    err += 'Nhập tiêu đề<br/>';
                }
                if (_NoiDung == '') {
                    err += 'Nhập nội dung<br/>';
                }
                if (err != '') {
                    common.fbMsg('Lỗi này bạn ơi', '<h1>Bạn cần chỉnh ngay nhé:</h1>' + err, 400, 'msg-portal-pop', function () {
                        setTimeout(function () {
                            $(document).trigger('close.facebox', 'msg-portal-pop');
                        }, 5000);
                    });
                    return false;
                }

                var ID = btn.attr('_id');
                var Url = document.location.href;
                adm.regType(typeof (binhLuanMgrFn), 'cangtin.plugins.binhLuanMgr.Admin.Class1, cangtin.plugins.binhLuanMgr', function () {
                    $.ajax({
                        url: binhLuanMgrFn.urlDefault,
                        data: { Ten: _Ten, NoiDung: _NoiDung, P_RowId: ID, Url: Url, subAct: 'save' },
                        type: 'POST',
                        success: function (_dt) {
                            if (_dt == '1') {
                                $(document).trigger('close.facebox', 'bl-post');
                                common.fbMsg('Còn phải chờ duyệt nữa', '<h1>Chờ nhóm mình duyệt đã nhé</h1>cám ơn bạn đã góp ý nhé', 400, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                        if (typeof (fn) == "function") {
                                            fn();
                                        }
                                    }, 5000);
                                });
                            } else {
                                common.fbMsg('Dính lỗi rồi :(( ặc ặc', '<h1>Có lỗi, chán quá vì mình sửa mãi mà nó vẫn bị</h1>' + _dt + '<br/>Copy lỗi trên rùi gửi cho mình nhé: linh_net', 400, 'msg-portal-pop', function () {
                                    setTimeout(function () {
                                        $(document).trigger('close.facebox', 'msg-portal-pop');
                                    }, 5000);
                                });
                            }
                        }
                    });
                });
            });
        });

    },
    FacebookAppInit: function () {
        if (!IsFacebookAppInit) {
            if (typeof (FB) == 'undefined') {
                return false;
            }
            FB.init({
                appId: FacebookAppIdKey, // App ID
                channelUrl: '//' + window.location.hostname + '/Channel.aspx', // Path to your Channel File
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true,  // parse XFBML
                oauth: true // supports oauth token
            });
            IsFacebookAppInit = true;
        }
    }
};


