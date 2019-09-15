/**
 * netbarg map page.
 * show all deals based on location, categories & search result
 */
function defaultImg(e) {
    var src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHUAAABKCAIAAAAKSoyTAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTExIDc5LjE1ODMyNSwgMjAxNS8wOS8xMC0wMToxMDoyMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKFdpbmRvd3MpIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjA5QjFEMzYzQkUwODExRTc5NTI4ODMzNEQ0NDlENEQwIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjA5QjFEMzY0QkUwODExRTc5NTI4ODMzNEQ0NDlENEQwIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6MDlCMUQzNjFCRTA4MTFFNzk1Mjg4MzM0RDQ0OUQ0RDAiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6MDlCMUQzNjJCRTA4MTFFNzk1Mjg4MzM0RDQ0OUQ0RDAiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7LVpPUAAAC+0lEQVR42uybCW+yQBiEFfE+SDwg8f//No2BqCCKt9/UbdftBhBNTZZ8M0mNXKZ9eJ2dd5dWZ7NZhfqYbPw4jkMQn1AYhhYpfFTkS77kS5Ev+ZIvRb7kS74U+ZIvRb7kS74U+ZIv+VLkS77kS5FvWWQb/vtdr9fdbrff78/nM95jT61WazQazWaz3W5Xq1XyfV9RFG02m9vtphE/nU7b7dayrF6vNxgMyPdlgWkQBIfDIb+0cQNQ3aPRqF6v039fgLtYLPLhSsE3ip/M+v0SKhfU1D1w21arJYoUh0AzSRL1BN/3Pc8zsIqN4wvDVYsRI9hwOMRQpp4D2z0ej+v1Gq8q4ul0Sn94khbCMFT3uK6rwRVChNAO4VoQJ98nxatuonLzv/IY2Wz78RWM4/hyuZBvpgBIvgfZTqfz9BLcg5w7RL4PoYlQo26/3y9yVeMuuYlcTL6ZfNVNBIaCF2K4U7Od9jnk+y10ZVoKLnghOuac+8R89ugU1M3lcglv1djJM6HTj7QLyTezbVM3kYLn8zk6CyQEpGAcRQJDPJATPZlfScsi3+d8JeXU3hd1DY7aq5Ca2Mj3V91lpVcgQ0hAYrPvEkArZZBBfEFN4wuI3W4XTZqawMolg/gCopxPgOGKud03ZtAxvhXPdv9RPlOhwAocx3kD7mq1CoKA+Tedr0xjWhYuDlesa5BvuuRiD7LES5NhMG6UrWiOjTJrs+Z/MZrFcSyKF29QiU+X10AWWNVlutT5TPL91mQyQVshYEVRlCQJoMsuQ5yD/gJdBgZDRGNtVggOg/PJNy8Fu67r+75o0lDLwihEByGsAzWbNTsxHo/N+nMMzIwID57noWbVnWJZXsw2pMLFDUDtm7YEZ+j6PEoVsGCs0o5zBN+AJ8CpDWzqjH6+pHuXMFlQhi2gikXxCruAKYulZWPbZdOfj6rcF+c1ryiR+Hwf+ZIvRb7kS74U+ZIv+VLkS74U+ZIv+VLkS77kS5Ev+ZIvRb5l0df6sfYvqdQf6p8AAwD1N3/T0N0q1QAAAABJRU5ErkJggg==';
    $(e).attr('src',src);
}

window.setMapHeight = function (){
    var h = $('header').height();
    $('.container-fluid.fit').css('height', 'calc(100% - '+h+'px)');
}

$( function (){

    'use strict';

    $(window).load(function(){
        setMapHeight();
    });

    $(window).resize(function(){
        setMapHeight();
    })

    window.netbarg = {};
    window.netbarg.fn = {};
    window.netbarg.city = '';
    window.nbSelectedCat = [];
    window.netbarg.isMobile = ($(window).width() <= 991);
    window.netbarg.lastDraw = [];

    var howMuchDistance = 1;//@todo
    var mapCanvas = document.getElementById("dealMap");
    var myCenter = new google.maps.LatLng(35.700428,51.374980);
    var mapOptions = {center: myCenter, zoom: 14,disableDefaultUI: true};
    var map = new google.maps.Map(mapCanvas,mapOptions);

    $('body').addClass(bowser.name);//browser name

    $(".madJaxWait").removeClass('hidden');

    //add an event listener on drag to show new result based on new area.
    google.maps.event.addListener(map, 'dragend', function() {
        if (window.netbarg.isMobile) {
            $('#dragend').removeProp('disabled').removeClass('hidden');
        } else {
            clearMarkers ();
            draw(window.netbarg.lastDraw[0],window.netbarg.lastDraw[1]);
        }
    });

    //get Distance From Latitude and Longitude In Km
    function getDistanceFromLatLonInKm(lat1,lon1,lat2,lon2) {
        var R = 6371; // Radius of the earth in km
        var dLat = deg2rad(lat2-lat1);  // deg2rad below
        var dLon = deg2rad(lon2-lon1);
        var a =
                Math.sin(dLat/2) * Math.sin(dLat/2) +
                Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
                Math.sin(dLon/2) * Math.sin(dLon/2)
            ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        var d = R * c; // Distance in km
        return d;
    }

    //degree to radius
    function deg2rad(deg) {
        return deg * (Math.PI/180)
    }

    //get url params
    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    //draw markers
    function draw (cat,search,center) {
        center = center || '';

        //keep in mind my move
        window.netbarg.lastDraw = [cat,search];

        var resultCount = 0;

        $('.wr').html('').css('margin-top','0px' );

        var lat = (center ? center[0] : map.getCenter().lat());
        var lng = (center ? center[1] : map.getCenter().lng());


        //@todo sort data based on distance and get some useful data.
        var all_distance = [],
            inNameCount = 0,
            all_deals_count = 0;
        $.each(dealMap, function(k,v){
            var inCat = false,//is it category deals or not.
                inName = false;//is it search result or not.
            if (cat !== '') {
                if ( nbSelectedCat.indexOf(v.DealCategories.categoryId + '') !== -1 ){
                    inCat = true;// this deal contain selected cat.
                }
            } else {
                if (search !== '') {
                    if ( v.short_name.indexOf(search) >= 0 ) {
                        inName = true;// this deal contain search character.
                    }
                } else {
                    inCat = true;
                }
            }

            if ( inCat || inName ) {
                $.each(v.company.company_addresses, function (k, v) {
                    all_deals_count++;
                    var latitude = v.latitude;
                    var longitude = v.longitude;
                    var distanceInKm = getDistanceFromLatLonInKm(lat, lng, latitude, longitude);
                    all_distance.push(parseFloat(distanceInKm));
                    if (inName) {
                        inNameCount++;
                    }
                });
            };

        });

        console.info('all_deals_count ', all_deals_count);

        var first40item = all_distance.sort(function(a, b){return a-b}).slice(0, 40);//get 40 item sort by distance from center
        var max_area = first40item[first40item.length - 1];// maximum distance in km from center that 40 item (or less) contain in it.

        //'30' is maximum radius in km that user can see search result.
        //'10' is maximum radius in km that user can see deals.
        howMuchDistance = ( max_area ? (inNameCount > 0 ? (max_area > 30 ? 30 : max_area) : (max_area > 10 ? 10 : max_area)) : 1 );// recalculate radius.

        howMuchDistance = (all_deals_count < 40 ? false : howMuchDistance);//if all is less than 40, show all.

        howMuchDistance = (howMuchDistance < 0.3 && howMuchDistance > 0.0001 ? 0.5 : howMuchDistance);//in case of more than 40 pin in one position.

        var empty = true;
        for (var o in first40item) {
            if (first40item[o] < howMuchDistance ) {
                empty = false;
            }
        }
        if ( empty &&  howMuchDistance < 10) {
            howMuchDistance = howMuchDistance * 1.02;
        }

        if(window.nbBackDoor){
            console.warn('Caution. Your browser may slow down.');
            howMuchDistance = window.nbBackDoor;
        }

        //draw blue polygon
        var _center = new google.maps.LatLng(lat,lng);
        if (!howMuchDistance) {
            howMuchDistance = 10000;
        } else {
            window.blueCircle = new google.maps.Circle({
                center: _center,
                radius: howMuchDistance * 1000,
                strokeColor: "#5f9be7",
                strokeOpacity: 0.1,
                strokeWeight: 2,
                fillColor: "#0000FF",
                fillOpacity: 0.1
            });
            blueCircle.setMap(map);
        }

        //End of area calculation

        $.each(dealMap, function(k,v){
            var myDeal = v;
            var inCat = false,
                inName = false;

            if (cat !== '') {

                if ( nbSelectedCat.indexOf(v.DealCategories.categoryId + '') !== -1 ){
                    inCat = true;// this deal contain selected cat.
                }

            } else {

                if (search !== '') {

                    if ( v.short_name.indexOf(search) >= 0 ) {
                        inName = true;// this deal contain search character.
                    }

                } else {
                    inCat = true;
                }

            }

            var short_name = v.short_name;
            var company_name = v.company.name;
            var original_price = v.original_price.toLocaleString();
            var discounted_price = v.discounted_price.toLocaleString();
            if(v.is_show_sum_deal_user == 1){
                var deal_user_count = v.deal_user_count + v.sum_deal_user_count;
            }else{
                var deal_user_count = v.deal_user_count;
            }
            var DealCategories = v.DealCategories.id;
            var DealCities = v.DealCities.id;
            var photo = v.attachments[0].dir;
            var commission_percentage = v.commission_percentage;
            var catId = v.category_slug;
            var uid = v.id;

            if ( inCat || inName ) {

                $.each(v.company.company_addresses, function (k,v){

                    var latitude = v.latitude;
                    var longitude = v.longitude;
                    var address = v.address;
                    var distanceInKm =  getDistanceFromLatLonInKm(lat,lng,latitude,longitude);

                    if ( distanceInKm < howMuchDistance ) {

                        resultCount = resultCount + 1;
                        var url = "/"+ window.nbCity +"/d/c:"+myDeal.category_slug+"/"+myDeal.id+"/"+myDeal.deal_slug+"/";
                        var template = '<div class="card" data-uid="'+uid+'"><div class="w-top clearfix"><img src="'+photo+'" onerror="defaultImg(this)" style="height:74px;width:117px;">'+
                            '<p>'+short_name+'</p><span>'+company_name+'</span></div>'+
                            '<div class="w-bottom clearfix">'+
                            '<div class="count"><span class="icon icon-shopping-cart_main"></span><span class="num">'+deal_user_count+'</span></div>'+
                            '<div class="span badge">'+commission_percentage+' %</div>'+
                            '<a href="' + url + '" target="_blank" class="span badge green-link">مشاهده و خرید</a>'+
                            '<div class="spacer"></div><ins class="new-price">'+discounted_price+' تومان</ins>'+
                            '<del class="old-price">'+original_price+'</del></div></div>';

                        var marker = new google.maps.Marker({
                            position: new google.maps.LatLng(latitude,longitude),
                            icon:'/assets/site/img/pin-' + catId + '.png',
                            animation: google.maps.Animation.DROP,
                            _uid: uid,
                            optimized: false
                        });

                        $('.wr').append(template);

                        nbMarkers[uid] = marker;

                        marker.addListener('click', function (){
                            var card = $('#cards').find('div[data-uid="' + marker._uid + '"]'),
                                index = card.index(),
                                height = card.outerHeight(),
                                m = (index * height) + (index * 4),
                                cardLength = $('.card').length,
                                cardWidth = card.outerWidth() + 5,
                                wWidth = $(window).width(),
                                gap = wWidth - cardWidth;

                            var cardHeight = $('#cards .card:first').outerHeight() + 4;
                            var cardsLength = $('#cards .card').length;
                            var cardsWrapperHeight = $('#dealMap').height();
                            var cardsHeight = cardHeight * cardsLength;

                            $('.card').removeClass('hey');
                            card.addClass('hey');

                            if (netbarg.isMobile) {
                                if (bowser.ios && bowser.name == 'Chrome') {
                                    $("#cards").animate({ scrollLeft: (index * cardWidth) * -1 }, 600);//chrome ios
                                } else {
                                    if (bowser.name == 'Firefox' || bowser.name == 'Safari') {
                                        $("#cards").animate({ scrollLeft: index * cardWidth }, 600);//firefox or iphone safari
                                    } else {
                                        $("#cards").animate({ scrollLeft: ((cardLength * cardWidth) - ((index + 1) * cardWidth)) - gap }, 600);//chrome android
                                    }
                                }
                            } else {

                                if ( Math.abs(m) > (cardsHeight - cardsWrapperHeight) ) {
                                    m = (cardsHeight - cardsWrapperHeight);
                                    m = (m < 0 ? 0 : m);
                                };//do not let free space appear.

                                $('.wr').animate({ 'marginTop': "-" + m + "px" }, 300);
                            }
                        });
                        marker.setMap(map);

                        if (marker.getAnimation() !== null) {
                            marker.setAnimation(null);
                        } else {
                            marker.setAnimation(google.maps.Animation.BOUNCE);
                        }

                    }

                });

            }

        });

        //move to center after draw all markers.
        if (center != ''){
            var lat = parseFloat(center[0]),
                lon = parseFloat(center[1]);
            var latLng = new google.maps.LatLng(lat,lon); //Makes a latlng
            map.panTo(latLng);
        }

        console.info('result count: ',resultCount);

        if (resultCount == 0) {
            var noResult = '<div class="noResult"><i class="icon icon-close-circular-button-symbol"></i><p>در این محدوده موردی یافت نشد</p></div>';
            $('#cards .wr').html(noResult);
        }

        //@todo move
        $('.card').on('click', function(){

            var attr = $(this).attr('data-uid');
            map.panTo(nbMarkers[attr].getPosition());

            nbMarkers[attr].setAnimation(google.maps.Animation.BOUNCE);
            setTimeout(function(){ nbMarkers[attr].setAnimation(null); }, 1470);

        });

    }

    //print all the categories
    function list (data) {
        $('#cats ul').html('');
        $('#check_all_lg').prop('checked',true);

        $.each(data, function (k,v){

            var name = v.name;
            var id = v.id;
            var alias = v.slug;

            var template = '<li data-alias="' + alias + '" data-catId="' + id + '"><i></i><span>' + name + '</span><div class="checkbox">'
                +'<input id="check_' + alias + '" type="checkbox" name="cats" value="' + id + '" checked class="styled">'
                +'<label class="select-cat" for="check_' + alias + '"></label></div></li>';

            $('#cats ul').append(template);

        });

    }

    //build map
    function initMap(city,range,center) {
        $(".madJaxWait").addClass('hidden');

        if ( bowser.mobile ) {
            //$('body').css('padding-top','2px'); //resize bug
        }

        //city = city || 'tehran';
        window.netbarg.city = city;
        range = range || '';
        center = center || '';

        //@TODO change it based on city
        // var url = (city == 'esfahan' ? '/assets/js/alldeals2.json' : '/assets/js/alldeals.json');
        // $.get(url, function (data){

        $.get('/deals/dealMap.json' + (city ? '?city_slug=' + city : ''), function (data){

            window.dealMap = data.deals;
            window.nbMarkers = {};
            window.nbSelectedCat = [];
            window.nbCity = data.city;

            center = [data.center.lat,data.center.lng];

            if (center != ''){
                draw ('','',center);
            } else {
                draw ('','');
            }

            $(".madJaxWait").addClass('hidden');
            window.dealCat = data.categories;
            list (data.categories);
        });

    }

    //remove all markers
    function clearMarkers (){

        blueCircle.setMap(null);

        for (var x in nbMarkers){
            nbMarkers[x].setMap(null);
        }

    }

    //set window height
    function heightFix (){
        if (!netbarg.isMobile) {
            var h = $(window).height();
            $('#cards .wr').css('min-height', h + 'px').css('padding-bottom', h + 'px');
        }
    }

    //check for minimized window and force to maximize window
    function minimized () {

        if ( $(window).width() <= 991 && !bowser.mobile ) {
            $('body').addClass('minimized');
        } else {
            $('body').removeClass('minimized');
        }

    }

    heightFix();
    minimized();

    // toggle search box in small devices.
    $('.toggle-search-js').on('click', function () {
        $('.toggle-hidden').toggleClass('active');
    });

    // mobile search close button
    $('.search-close').on('click', function () {
        $('.toggle-hidden').toggleClass('active');
    });

    // toggle burger menu.
    $('.burger-icon').on('click', function () {
        var icon = $(this);
        var b = $('.burger-menu-right');
        var fix = b.find('.fix');
        var wr = b.find('.wrapper');

        b.removeClass('out');
        $('body').addClass('overflow-hidden');
        fix.stop().css('opacity', '0').animate({
            'opacity': '1'
        }, 300);
        wr.stop().css('right', '-270px').animate({
            'right': '0'
        }, 300);
        $('.burger-menu-right .wrapper').scrollTop(0);

    });

    $('.burger-menu-right .fix').on('click', function () {
        var fix = $(this);
        var b = $('.burger-menu-right');
        var wr = b.find('.wrapper');

        fix.stop().animate({
            'opacity': '0'
        }, 300);
        wr.stop().animate({
            'right': '-270'
        }, 300, function () {
            b.addClass('out');
            $('body').removeClass('overflow-hidden');
            fix.css('opacity', '1');
            wr.css('right', '0')
        });
    });

    //close alert
    $(document).on('click','.nb-alert i.icon-close', function () {
        $(this).parent().remove();
    });

    //mouse-wheel on deal card wrapper
    $('.wr').mousewheel(function(event) {

        if (!netbarg.isMobile) {
            event.preventDefault();
            var card = $('.card');
            var q = card.length;
            var h = card.eq(0).height();
            h = h + 20;//@todo 20 is padding. must calculate by dynamic
            h = h * q;
            h = h + (q * 4);

            var that = $(this);
            var scrollTop = that.css('margin-top');
            scrollTop = parseInt(scrollTop.replace('px',''));

            var sc = (scrollTop + (event.deltaY * event.deltaFactor) );
            sc = ( sc <= 0 ? sc : 0 );
            sc = ( (sc * -1) > (h - 300) ? ((h - 300) * -1) : sc );
            sc = (sc > 0 ? 0 : sc);

            var cardHeight = $('#cards .card:first').outerHeight() + 4;
            var cardsLength = $('#cards .card').length;
            var cardsWrapperHeight = $('#dealMap').height();
            var cardsHeight = cardHeight * cardsLength;

            if ( Math.abs(sc) > (cardsHeight - cardsWrapperHeight) ) {
                sc = (cardsHeight - cardsWrapperHeight) * -1;
                sc = (sc > 0 ? 0 : sc);
            };//do not let free space appear.

            that.css('margin-top', sc + 'px' );
        }

    });

    //on change categories
    $(document).on('change', 'input[name="cats"]', function (e){

        $('input[name="mapSearch"]').val('');

        if ( !netbarg.isMobile ) {
            var x = $('input[name="cats"]:checked');

            var z = [];

            x.each(function(k,v){
                z.push($(v).val());
            });

            if (z == '') {
                $('#check_all_lg').prop('checked',false)
            }

            if ( z.length == $('input[name="cats"]').length ) {
                $('#check_all_lg').prop('checked',true)
            } else {
                $('#check_all_lg').prop('checked',false)
            }

            window.nbSelectedCat = z;

            clearMarkers ();

            draw (nbSelectedCat,'');
        }

    });

    $('#catModalbtn').on('click', function (e) {
        e.preventDefault();
        var x = $('input[name="cats"]:checked');

        var z = [];

        x.each(function(k,v){
            z.push($(v).val());
        });

        window.nbSelectedCat = z;

        clearMarkers ();

        draw (nbSelectedCat,'');

        $('#catModal, #cats ul').css('display','none');
    });

    $('input[name="all_cat"]').on('click', function (e) {
        //$('input[name="cats"]').prop('checked',$(this).prop("checked"));
        if($(this).is(':checked')){
            $('input[name="cats"]:not(:checked)').trigger('click');
        } else {
            $('input[name="cats"]:checked').trigger('click');
        }

    });

    $('form.search').on('submit', function (e){

        e.preventDefault();

        clearMarkers();

        var n = $('input[name="mapSearch"]').val();

        if (n != '') {
            $('input[name="cats"],input[name="all_cat"]').removeProp('checked');
        } else {
            $('input[name="cats"],input[name="all_cat"]').prop('checked', true);
        }

        draw('',n);

    });

    $('#dragend').on('click', function () {
        clearMarkers ();
        draw(window.netbarg.lastDraw[0],window.netbarg.lastDraw[1]);
        $(this).prop('disabled',true).addClass('hidden');
    });

    //initialize map on load
    $(window).load(function() {
        var qs = getParameterByName('city_slug');
        initMap(qs);//@todo get city from url or use a default value.
    });

    $(window).on('resize', function (){
        window.netbarg.isMobile = ($(window).width() <= 991);
        heightFix();
        minimized();
    });

    $(document).on('click', '.card', function (){
        $('.card').removeClass('hey');
        $(this).addClass('hey');
    });

    //close search result
    $(document).on('click','#closeSearchResult', function () {
        $(this).addClass('hidden');
        $('input[name="mapSearch"]').val('');
        clearMarkers ();
        $('input[name="all_cat"],input[name="cats"]').prop('checked','checked');
        draw('','');
    });

    //get back to last page
    $('.getBack').on('click', function(){
        window.history.back();
    });

    //choose city
    $('[data-city_slug]').on('click', function (e){
        e.preventDefault();

        var city = $(this).data('city_slug'),
            title = $(this).data('title'),
            centerLat = $(this).data('centerlat'),
            centerLon = $(this).data('centerlon');
        clearMarkers();
        $('#chooseCity span.name').text(title);
        initMap(city,'',[centerLat,centerLon]);

    });

    //fab behavior
    $('#fab').on('click', function () {
        $('#catModal, #cats ul').css('display','block');
    });

    //close cat modal
    $('#closeCatModal').on('click', function () {
        $('#catModal, #cats ul').css('display','none');
    });

    //show cross icon in search
    $('.header form.search input').on('keyup', function () {
        var c = $('#closeSearchResult');
        if ( $(this).val().length >= 1 ) {
            c.removeClass('hidden');
        } else {
            c.addClass('hidden');
        }
    });

    function heightFixer (){
        var w = $(window);
        if (w.height() < 400){
            $('#dragend').addClass('hidden');
            $('#fab').addClass('hidden');
            $('#cards').addClass('hidden');
        } else {

            if (!$('#dragend').attr('disabled')) {
                $('#dragend').removeClass('hidden');
            }

            $('#fab').removeClass('hidden');
            $('#cards').removeClass('hidden');
        }
    }

    $(window).resize(function() {
        heightFixer();
    });
    heightFixer();

    $('#dragend').prop('disabled', true);$('#dragend').addClass('hidden');

});
