/**
 * Basket Js.
 * NetBarg Co. 2017
 */
//@todo 1. on delete every deal must call calcTotalPrice() in success and remove mirror item;
//@todo 2. on change quantity for every deal must call calcTotalPrice() in success after set value of select;
var basket = {};
basket.msg = {
    'need_address': 'لطفا یک آدرس برای ارسال سفارش خود اضافه کنید.',
    'dirtyData': 'اطلاعات وارد شده صحیح نمی باشد.',
    'giftMinErr': 'مجموع سبد خرید شما به حد نصاب کد تخفیف نرسیده است.',
    'giftCatErr': 'این کد تخفیف شامل دسته بندی های موجود در سبد شما نمی باشد.',
    'giftDealErr': 'این کد تخفیف شامل نت برگ های موجود در سبد شما نمی باشد.',
    'giftDealAndCatErr': 'این کد تخفیف شامل نت برگ های و دسته بندی های موجود در سبد شما نمی باشد.',
    'calcErr': 'مشکلی در فرایند محاسبه سبد خرید شما به وجود آمده است.',
    'unCheckBalance': 'برای استفاده از کد هدیه، تیک استفاده از موجودی را بردارید'
};

$.fn.digits = function() {
    return this.each(function() {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
    })
};

//delete donation
function delete_donation() {
    $('.t_from').text('');
    $('.t_to').text('');
    $('.t_email').text('');
    $('.t_text').text('');

    //write gift form immediately
    $('input[name="h_from"]').val('');
    $('input[name="h_to"]').val('');
    $('input[name="gift-email"]').val('');
    $('input[name="h_text"]').val('');

    //$('#donate1').val(''); //do not delete this one.
    $('#donate2').val('');
    $('#donate3').val('');
    $('#donate4').val('');

    $('#add_gift').removeClass('hidden');
    $('#donate').removeClass('hidden');
    $('#donate_form').addClass('hidden');
    $('#editable_gift').addClass('hidden');
    $('#frozen_gift').addClass('hidden');

    writeLocalStorage();
}

//close modal
function closeModal() {
    $('.nb-modal').modal('hide');
}

//final validation on payment
function finalValidate(btn) {

    var a = $('[name="user-address-id"]').val(),
        b = $('[name="use_wallet"]').val(),
        c = $('[name="gift-email"]').val(),
        d = $('[name="h_from"]').val(),
        e = $('[name="h_to"]').val();

    if (a != '' && (b == 0 || b == 1) && ((c != '' && d != '' && e != '') || (c == '' && d == '' && e == ''))) {

        if (btn.e.hasClass('p1')) {

            if ($('input[name="bank"]:checked')[0]) {
                return true;
            } else {
                dirtyData();
                return false;
            }

        } else {

            var x = $('input[name="cardNumber"]').val(),
                y = $('input[name="trackingCode"]').val();
            if (y != '' && $.isNumeric(x) && x.length == 4) {
                return true;
            } else {
                dirtyData();
                return false;
            }

        }

    } else {

        dirtyData();
        return false;

    }

}

//alert on dirty data input
function dirtyData() {
    madjax.fn.alert({
        'status': false,
        'message': basket.msg.dirtyData
    })
}

function reloadMe() {
    //something is wrong or you try to cheating.
    // location.reload();
    madjax.fn.alert({
        status: false,
        message: basket.msg.calcErr
    })
}

//write user basket data into local storage
function writeLocalStorage() {

    var lc = {
        ts: new Date().getTime(),
        address: $('input[name="user-address-id"]').val(),
        giftCode: $('input[name="h_giftCode"]').val(),
        donate: {
            from: $('input[name="h_from"]').val(),
            to: $('input[name="h_to"]').val(),
            email: $('input[name="gift-email"]').val(),
            text: $('input[name="h_text"]').val()
        }
    };

    localStorage.setItem("lc", JSON.stringify(lc));

}

//read user basket data
function readLocalStorage() {

    if (localStorage.getItem("lc")) {

        var lc = JSON.parse(localStorage.getItem("lc")),
            dateString = lc.ts,
            now = new Date().getTime(),
            dif = Math.round((now - dateString) / 60000); //keep data for 30 minutes.

        if (dif < 30) {

            //set items
            if (lc.address != '') {
                $('input[name="address"][value="' + lc.address + '"]').parents('label').click(); //address set.
            }

            if (lc.giftCode != '') {
                $('#nb_gift input').val(lc.giftCode); //gift code set.
                $('#nb_gift #submitGiftCode').click(); //gift code set.
            }

            if (lc.donate.from != '' && lc.donate.email != '' && lc.donate.to != '') {
                //donation set.
                $('.t_from').text(lc.donate.from);
                $('.t_to').text(lc.donate.to);
                $('.t_email').text(lc.donate.email);
                $('.t_text').text(lc.donate.text);

                $('#editable_gift').removeClass('hidden');
                $('#frozen_gift').removeClass('hidden');
                $('#donate').removeClass('hidden');
                $('#donate_form').addClass('hidden');
                $('#add_gift').addClass('hidden');
            }

        } else {

            localStorage.removeItem('lc');
            localStorage.removeItem('passToPayment');

        }

    }

}

//move to step 2 (payment)
function toggleToPayment() {

    var passToPayment = true;
    localStorage.setItem("passToPayment", JSON.stringify(passToPayment));

    $('.nb-alert').remove();
    $('.main-levels li').removeClass('active').removeClass('active-st'); //basket-levels
    $('li[nb-toggle="confirm-part"]').addClass('active-st'); //basket-levels
    $('li[nb-toggle="payment-part"]').addClass('active'); //basket-levels
    $('.part').addClass('hidden'); //toggle part
    $('.payment-part').removeClass('hidden'); //toggle part

    pay_jump();

    $('html, body').animate({
        scrollTop: 0
    }, 'fast');

    //disable card to card
    if ($('[nb-gift-code]').attr('nb-gift-code').length >= 1) {
        $('#menu2 .bank-checker').addClass('hidden');
        $('#menu2 .doNotUseGift').removeClass('hidden');
    } else {
        $('#menu2 .bank-checker').removeClass('hidden');
        $('#menu2 .doNotUseGift').addClass('hidden');
    }

    //show my-address
    var checked_address = $('input[name="address"]:checked');
    var myAddress = $('#my-address');
    if (checked_address.length > 0) {
        myAddress.removeClass('hidden');
        myAddress.find('.gs-myadress span').text(checked_address.parents('.radio-wrapper').find('.text-addr').text());
    } else {
        myAddress.addClass('hidden');
        myAddress.find('.gs-myadress span').text('');
    }

    writeLocalStorage();
}

//step 1
//calculate deal total price.
function calcTotalPrice() {

    var t = $('.basket-item');

    $.each(t, function() {

        var num = $(this).find('[nb-num]'),
            numV = num.attr('nb-num'),
            qt = $(this).find('select').val(),
            total = $(this).find('[nb-total]'),
            deal_id = $(this).attr('nb-deal-id'),
            mirror = $('.mirror[nb-deal-id="' + deal_id + '"]');

        if (qt < 1 || numV < 0) {
            reloadMe();
        }

        if (qt < 1 ) {
            $(this).find('.list-items').css('border-color', 'red');
        }

        num.text(numV).digits(); //put number into field.
        total.attr('nb-total', numV * qt);
        total.text(numV * qt).digits(); //put number into field.

        // change mirror value
        mirror.find('select').val(qt);
        mirror.find('select').attr('disabled', true).removeAttr('mj-target').removeAttr('mj-type'); //@todo must handle in back-end also.
        mirror.find('[nb-num-mirror]').text(numV).digits();
        mirror.find('[nb-total-mirror]').text(numV * qt).digits();

    });

    calcTotalBasket();

}

//step 2
//calculate basket total
var totalAmountForCalc = 0;
function calcTotalBasket() {

    var t = $('.basket-item').find('[nb-total]');
    var total = 0;
    var totalAmountCorpDeal = 0;
    var totalPackageItemExtraGift = 0;
    var packageTotalGift = {};
    $.each(t, function() {

        var v = $(this).attr('nb-total');
        total = total + parseInt(v);
        if($(this)[0].hasAttribute('is_corporation')){
            var z = $(this).attr('nb-total');
            totalAmountCorpDeal += parseInt(z);
        }

        if($(this)[0].hasAttribute('data-deal-extra-gift') && ($('span[data-deal-extra-gift]').length > 1)){
            pClass = $(this).attr('class').split('-');
            pClass = pClass[1];
            totalPackageItemExtraGift += parseInt($(this).attr('data-deal-extra-gift')) * $(this).parent('span').siblings('select[name="quantity"]').val();
            if(!isNaN(parseInt($('#data-package-extra-gift-'+pClass+'-'+($('.'+$(this).attr('class')).length - 1)).val()))){
                packageTotalGift[pClass] = parseInt($('#data-package-extra-gift-'+pClass+'-'+($('.'+$(this).attr('class')).length - 1)).val());
            }
        }

        
    });
    
    if(packageTotalGift.length != 0){
        $.each(packageTotalGift, function(key,value) {
            totalPackageItemExtraGift += value;
        });
        totalPackageItemExtraGift = Math.round(totalPackageItemExtraGift / 10)
        $('.package-discount-percenatge').text(totalPackageItemExtraGift).digits();
    }else if(totalPackageItemExtraGift == 0){
        $('.package-discount').remove();
    }

    totalAmountForCalc = total;
    if(totalPackageItemExtraGift != 0){
        totalAmountForCalc = total - totalPackageItemExtraGift;
    }
    var nb_corporation_percentage = 0;
    nb_corporation_percentage = $('[nb-final-price]').attr('nb-corporation-percentage');
    if(nb_corporation_percentage > 0){
        totalAmountForCalc = Math.round(totalAmountForCalc - (nb_corporation_percentage * ((totalAmountForCalc - totalAmountCorpDeal)/100)));
    }

    if (total < 0) {
        reloadMe();
    }

    $('[nb-totalBasket]').attr('nb-totalBasket', total);
    $('[nb-totalBasket]').text(total).digits(); //put number into field.
    $('[nb-totalBasket-mirror]').text(total).digits(); //put mirror value.

    calcGift();
    calcFinal();
    //pay_jump();

}

//step 3
//calculate final
function calcFinal() {

    //@todo user is not login.
    if (!$('.basket-confirm')[0]) {
        return;
    }

    var total_basket = parseInt(totalAmountForCalc),
        gift = parseInt($('[nb-gift-price]').attr('nb-gift-price')),
        TotalAccountBalance = Math.round($('[nb-balance]').attr('nb-balance')),
        balance = TotalAccountBalance;

    //mablaghe takhfif + mojodi bishtar az jame kole sabad nabashad.
    if ($('#balance1').prop('checked') && $('#nb_gift').attr('nb-gift-price') > 0) {
        // if ((TotalAccountBalance + gift) > total_basket) {
        //     var g = $('#nb_gift');
        //     g.attr('nb-min', '')
        //         .attr('nb-max', '')
        //         .attr('nb-for-deal', '')
        //         .attr('nb-for-cat', '')
        //         .attr('nb-percent', '')
        //         .attr('nb-gift-code', '')
        //         .attr('nb-gift-price', '0');
        //     $('.basket-confirm .hint').text(basket.msg.unCheckBalance);
        //     $('#gift_text').text('0');
        //     g.removeClass('active');
        //     gift = parseInt($('[nb-gift-price]').attr('nb-gift-price'));
        // }
    }

    // if balance is checked
    if ($('#balance1').prop('checked')) {

        if ((total_basket - gift) < balance) {

            //my balance is over my bill
            $('[nb-balance]').text(total_basket - gift).digits();
            $('[for="balance1"]').children('span').text('(' + (balance - (total_basket - gift)) + ' تومان)').digits(); //rest of your balance
            
            balance = total_basket - gift; // if balance is more than total

        } else {

            //my balance is less than my bill
            $('[nb-balance]').text(TotalAccountBalance).digits();
            $('[for="balance1"]').children('span').text('(0 تومان)'); //rest of your balance

        }

    } else {

        console.log(TotalAccountBalance)
        $('[for="balance1"]').children('span').text('(' + TotalAccountBalance + ' تومان)').digits(); //rest of your balance
        balance = 0;

    }
    

    var f = total_basket - (gift + balance);

    if (f < 0) {
        reloadMe();
    }

    $('[nb-final-price]').html(f).digits();
    $('[nb-final-price]').attr('nb-final-price', f);

    if (f == 0) {
        //there is no need to show payment method, so we hide that.
        $('.basket-confirm .nav').addClass('hidden');
        $('#menu1,#menu2').addClass('hidden');
        $('#menu3').addClass('in active').removeClass('hidden');
    } else {
        $('.basket-confirm .nav').removeClass('hidden');
        $('#menu1,#menu2').removeClass('hidden');
        $('#menu3').removeClass('in active').addClass('hidden');
    }

    $('[nb-gift-price-mirror]').text($('[nb-gift-price]').attr('nb-gift-price')).digits(); //set mirror value of gift
    $('[nb-balance-mirror]').text($('[nb-balance]').text()); //set mirror value of USED balance!
    $('[nb-final-price-mirror]').text($('[nb-final-price]').text()); //set mirror value of payable amount.

    //fix height
    if ($('.page-basket .balance').height() > 70) {
        $('.page-basket .balance p').css({
            width: '100%',
            'text-align': 'center'
        })
    }

}

//floating action button for mobile device
function pay_jump() {

    var word = 'تایید سفارش',
        _class = 'hidden';
    if ($('li[nb-toggle="payment-part"]').hasClass('active')) {
        word = 'پرداخت';
        _class = '';
    }

    if ($('.basket-proccess .panel-heading')[0]) {
        var jumper = 'pay-jump';
        var jumOfp = $('.payment-part .panel-heading');
        var jumOfc = $('.confirm-part .panel-heading');

        $('.fixed-fab').remove();
        if ($('.confirm-part').hasClass('hidden')) {
            // console.log('pay-jump-pay');
            jumper = 'pay-jump-pay';
            $('div.package-row').addClass('hidden');
            $('.payment-part .panel-heading').attr('id', jumper);
            jumOfc = jumOfc;
        } else {
            //    console.log('pay-jump');
            jumper = 'pay-jump';
            $('div.package-row').removeClass('hidden');
            $('.confirm-part .panel-heading').attr('id', jumper);
            jumOfc = jumOfp;
        }

        var tMBfix = "<div class='fixed-fab smooth-scroll clearfix visible-sm visible-xs'>" +
            "<span class='hidden-xs pay-conf-text'>قابل پرداخت: </span><span class='" + _class + "'>" +
            "<i>" + $('[nb-final-price]').text() + "</i><span class='pay-toman'>(تومان)</span>" +
            "</span><span data-href='#" + jumper + "'" + "class='nb-btn pull-left'>" + word + "</span></div>";

        $(tMBfix).appendTo(".page-basket");
        // $(tMBfixConfirm).appendTo( ".bc-scroll" );
        var pF = $('.page-basket .fixed-fab');
        var pFHeight = $('.page-basket .fixed-fab').height();
        pFHeight = pFHeight + 100;
        pF.find('.nb-btn').click('on', function() {
            $('html, body').stop().animate({
                scrollTop: $($(this).attr('data-href')).offset().top
            }, 500);
        });

        $(window).scroll(function() {
            if ($('.confirm-part').hasClass('hidden')) {
                jumOfc = $('.payment-part .panel-heading');
            } else {
                jumOfc = $('.confirm-part .panel-heading');
            }
            var offTop = $(window).scrollTop();
            var offTopB = jumOfc.offset();

            if ($(window).height() > 800) {
                if (offTop >= offTopB.top - 750) {
                    pF.css({
                        'bottom': -pFHeight
                    })
                } else {
                    pF.css({
                        'bottom': 0
                    });
                }
            } else {
                if (offTop >= offTopB.top - 500) {
                    pF.css({
                        'bottom': -pFHeight
                    })
                } else {
                    pF.css({
                        'bottom': 0
                    });
                }
            }
        });
    }
}

//calculate gift affected value.
function calcGift() {

    //@todo user is not login.
    if (!$('.basket-confirm')[0]) {
        return;
    }
    // run all calculation and put last value into nb-gift-price.
    var g = $('#nb_gift'),
        min = g.attr('nb-min'),
        max = g.attr('nb-max'),
        fordeal = g.attr('nb-for-deal'),
        forcat = g.attr('nb-for-cat'),
        forcity = g.attr('nb-for-city'),
        percent = g.attr('nb-percent'),
        code = g.attr('nb-gift-code');

    min = parseInt(min);
    max = parseInt(max);
    percent = parseInt((percent == '' ? 0 : percent));

    g.attr('nb-gift-price', 0); //reset values
    $('.basket-confirm .hint').text('');

    var totalbasket = totalAmountForCalc;


    var foundByCat = [],
        foundByDeal = [],
        enoughForCityAndCat = false,
        catAndDealTotall = 0; //sum cat and deal match found.

    //search for matched by cat id.

    if (forcity != '' && forcat != '') {
        enoughForCityAndCat = true;
        var cities = forcity.split(','),
        totalOfCat = 0;
        for (var x in cities) {
            var _match = $('[nb-city-id="' + cities[x] + '"]').not('.mirror');
            //ignore duplicate item. we check if this item is not same as before in foundByCat loop.
            $.each(_match, function () {
                
                var cats = forcat.split(',');
                totalOfCat = 0;
                for (var j in cats) {
                    var match = $('[nb-cat-id="' + cats[j] + '"]').not('.mirror');
                    foundByCat.push(match.attr('nb-deal-id'));
                    $.each(match, function () {
                        totalOfCat = totalOfCat + parseInt($(this).find('[nb-total]').attr('nb-total'));
                    });
                }
            });
            
        }

        catAndDealTotall += totalOfCat;

    }
    if (forcat != '' && !enoughForCityAndCat) {

        var cats = forcat.split(','),
            totalOfCat = 0;
        for (var x in cats) {
            var match = $('[nb-cat-id="' + cats[x] + '"]').not('.mirror');
            foundByCat.push(match.attr('nb-deal-id'));
            $.each(match, function() {
                totalOfCat = totalOfCat + parseInt($(this).find('[nb-total]').attr('nb-total'));
            });
        }
        
        console.log('total of cat id : ', totalOfCat);
        
        catAndDealTotall += totalOfCat;
        
    }
    
    //search for matched by deal id (except found by cat in past loop.)
    if (fordeal != '') {
        
        var deals = fordeal.split(','),
        totalOfDeal = 0;
        for (var x in deals) {
            var _match = $('[nb-deal-id="' + deals[x] + '"]').not('.mirror');
            //ignore duplicate item. we check if this item is not same as before in foundByCat loop.
            if ($.inArray(deals[x], foundByCat) < 0) {
                foundByDeal.push(_match.attr('nb-city-id'));
                $.each(_match, function() {
                    totalOfDeal = totalOfDeal + parseInt($(this).find('[nb-total]').attr('nb-total'));
                });
            }

        }
        console.log('total of deal id : ', totalOfDeal);
        catAndDealTotall += totalOfDeal;

    }


    if (forcity != '' && !enoughForCityAndCat) {

        var cities = forcity.split(','),
            totalOfCity = 0;
        for (var x in cities) {
            var _match = $('[nb-city-id="' + cities[x] + '"]').not('.mirror');
            //ignore duplicate item. we check if this item is not same as before in foundByCat loop.
            if ($.inArray(cities[x], foundByDeal) < 0) {
                $.each(_match, function() {
                    totalOfCity = totalOfCity + parseInt($(this).find('[nb-total]').attr('nb-total'));
                });
            }

        }
        console.log('total of city id : ', totalOfCity);
        catAndDealTotall += totalOfCity;

    }

    if (catAndDealTotall > 0) {
        totalbasket = catAndDealTotall; //if gift code is for specific cats or deals, so we consider it's total value.
    }


    if (min == '' && max == '') {
        g.attr('nb-gift-price', 0);
        console.warn('gift code return no result.');
    }; //No gift code.

    if ((min != '' || min >= 0) && (percent == '' || isNaN(percent) || percent == 0)) {

        console.warn('gift code contain min and value. (no percentage)');
        if (totalbasket >= min) {
            var v = (max > totalbasket ? totalbasket : max);
            g.attr('nb-gift-price', v);

            isForProperCategory = false;
            isForProperDeal = false;
            isForProperCity = false;
            enoughForProperCityAndCat = false;
            if (forcat != '' && forcity != '') {
                enoughForProperCityAndCat = true;
                if (fordeal.indexOf(',') > -1) {
                    var cityArrays = forcity.split(',');
                } else {
                    var cityArrays = [forcity];
                }
                var _matchOnes = $('[nb-city-id]');
                $.each(_matchOnes, function (key, value) {
                    var cityId = $(this).attr('nb-city-id');
                    if ($.inArray(cityId, cityArrays) != -1) {
                        if (forcat.indexOf(',') > -1) {
                            var catArrays = forcat.split(',');
                        } else {
                            var catArrays = [forcat];
                        }
                        var _matchOnes = $('[nb-cat-id]');
                        $.each(_matchOnes, function (key, value) {
                            var catId = $(this).attr('nb-cat-id');
                            if ($.inArray(catId, catArrays) != -1) {
                                isForProperCategory = true;
                            }
                        });
                    }
                });
            }
            if (forcat != '' && !enoughForProperCityAndCat) {
                if(forcat.indexOf(',') > -1){
                    var catArrays = forcat.split(',');
                }else{
                    var catArrays= [forcat];
                }
                var _matchOnes = $('[nb-cat-id]');
                $.each(_matchOnes, function(key, value) {
                    var catId = $(this).attr('nb-cat-id');
                    if($.inArray(catId, catArrays) != -1){
                        isForProperCategory = true;
                    }
                });
            }
            if (fordeal != '') {
                if(fordeal.indexOf(',') > -1){
                    var dealArrays = fordeal.split(',');
                }else{
                    var dealArrays = [fordeal];
                }


                var _matchOnes = $('[nb-deal-id]');

                $.each(_matchOnes, function(key, value) {
                    var dealId = $(this).attr('nb-deal-id');
                    if($.inArray(dealId , dealArrays ) != -1){
                        isForProperDeal= true;
                    }
                });
            }
            if (forcity != '' && !enoughForProperCityAndCat) {
                if(fordeal.indexOf(',') > -1){
                    var cityArrays = forcity.split(',');
                }else{
                    var cityArrays = [forcity];
                }


                var _matchOnes = $('[nb-city-id]');

                $.each(_matchOnes, function(key, value) {
                    var cityId = $(this).attr('nb-city-id');
                    if($.inArray(cityId , cityArrays ) != -1){
                        isForProperCity= true;
                    }
                });
            }

            if (fordeal != '' || forcat != '' || forcity != ''){
                if (!isForProperDeal && !isForProperCategory && !isForProperCity) {
                    $('.basket-confirm .hint').text(basket.msg.giftDealAndCatErr); // for deal error
                    g.attr('nb-gift-price', 0);
                }
            }

        } else if (forcat != '') {
            if (totalbasket == 0) {
                $('.basket-confirm .hint').text(basket.msg.giftCatErr); // for cat error
            } else if (totalbasket < min) {
                $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
            }
        } else if (fordeal != '') {
            if (totalbasket == 0) {
                $('.basket-confirm .hint').text(basket.msg.giftDealErr); // for deal error
            } else if (totalbasket < min) {
                $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
            }
        } else if (forcity != '') {
            if (totalbasket == 0) {
                $('.basket-confirm .hint').text(basket.msg.giftCityErr); // for deal error
            } else if (totalbasket < min) {
                $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
            }
        }else if (!isNaN(min)) {
            //hint: isNaN check to be sure that this is not on delete gift code.
            $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
        }

    } //

    if (percent != '' && !isNaN(percent)) {

        console.warn('gift code contain percentage');
        if (totalbasket >= min) {

            var xx = (totalbasket * percent) / 100;
            var v = (xx > max ? max : xx);
            v = Math.ceil(v); //Round upward
            g.attr('nb-gift-price', v);
            isForProperCategory = false;
            isForProperDeal = false;
            isForProperCity = false;
            enoughForProperCityAndCat = false;
            if (forcat != '' && forcity != '') {
                enoughForProperCityAndCat = true;
                if (fordeal.indexOf(',') > -1) {
                    var cityArrays = forcity.split(',');
                } else {
                    var cityArrays = [forcity];
                }
                var _matchOnes = $('[nb-city-id]');
                $.each(_matchOnes, function (key, value) {
                    var cityId = $(this).attr('nb-city-id');
                    if ($.inArray(cityId, cityArrays) != -1) {
                        if (forcat.indexOf(',') > -1) {
                            var catArrays = forcat.split(',');
                        } else {
                            var catArrays = [forcat];
                        }
                        var _matchOnes = $('[nb-cat-id]');
                        $.each(_matchOnes, function (key, value) {
                            var catId = $(this).attr('nb-cat-id');
                            if ($.inArray(catId, catArrays) != -1) {
                                isForProperCategory = true;
                            }
                        });
                    }
                });
            }
            if (forcat != '' && !enoughForProperCityAndCat) {
                if(forcat.indexOf(',') > -1){
                    var catArrays = forcat.split(',');
                }else{
                    var catArrays = [forcat];
                }
                var _matchOnes = $('[nb-cat-id]');
                $.each(_matchOnes, function(key, value) {
                    var catId = $(this).attr('nb-cat-id');
                    if($.inArray(catId, catArrays) != -1){
                        isForProperCategory = true;
                    }
                });

            }
            if (fordeal != '') {
                if(fordeal.indexOf(',') > -1){
                    var dealArrays = fordeal.split(',');
                }else{
                    var dealArrays = [fordeal];
                }
                var _matchOnes = $('[nb-deal-id]');
                $.each(_matchOnes, function(key, value) {
                    var dealId = $(this).attr('nb-deal-id');
                    if($.inArray(dealId , dealArrays ) != -1){
                        isForProperDeal= true;
                    }
                });
            }
            if (forcity != '' && !enoughForProperCityAndCat) {
                if(fordeal.indexOf(',') > -1){
                    var cityArrays = forcity.split(',');
                }else{
                    var cityArrays = [forcity];
                }
                var _matchOnes = $('[nb-city-id]');
                $.each(_matchOnes, function(key, value) {
                    var cityId = $(this).attr('nb-city-id');
                    if($.inArray(cityId , cityArrays ) != -1){
                        isForProperCity= true;
                    }
                });
            }
            if (fordeal != '' || forcat != '' || forcity != ''){
                if (!isForProperDeal && !isForProperCategory && !isForProperCity) {
                    $('.basket-confirm .hint').text(basket.msg.giftDealAndCatErr); // for deal error
                    g.attr('nb-gift-price', 0);
                }
            }


        } else if (forcat != '') {
            if (totalbasket == 0) {
                $('.basket-confirm .hint').text(basket.msg.giftCatErr); // for cat error
            } else if (totalbasket < min) {
                $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
            }
        } else if (fordeal != '') {

            if (totalbasket == 0) {
                $('.basket-confirm .hint').text(basket.msg.giftDealErr); // for deal error
            } else if (totalbasket < min) {
                $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
            }
        } else if (!isNaN(min)) {
            //hint: isNaN check to be sure that this is not on delete gift code.
            $('.basket-confirm .hint').text(basket.msg.giftMinErr); // min error
        }

    }

    $('#gift_text').text(g.attr('nb-gift-price')).digits();

    calcFinal();
    //pay_jump();
}

//run this on new gift code on madjax success callback.
function newGift(min, max, percent, fordeal, forcat ,forcity, code) {
    var g = $('#nb_gift');
    g.addClass('active');

    //set attribute
    g.attr('nb-min', min)
        .attr('nb-max', max)
        .attr('nb-for-deal', fordeal)
        .attr('nb-for-cat', forcat)
        .attr('nb-for-city', forcity)
        .attr('nb-percent', percent)
        .attr('nb-gift-code', code)
        .attr('nb-gift-price', '0');

    $('.basket-confirm .hint').text('');

    g.find('input').val(code);

    calcGift();
}

//edit donation form
function edit_donation() {
    $('#add_gift').removeClass('hidden');
    $('#donate').addClass('hidden');
    $('#donate_form').removeClass('hidden');
    $('#editable_gift').addClass('hidden');

    $('#donate1').val($('#editable_gift .t_from').text()).next().addClass('hascontent');
    $('#donate2').val($('#editable_gift .t_to').text()).next().addClass('hascontent');
    $('#donate3').val($('#editable_gift .t_email').text()).next().addClass('hascontent');
    $('#donate4').val($('#editable_gift .t_text').text()).next().addClass('hascontent');

    netbarg.fn.labelAnimate();
}

$(function() {

    "use strict";

    //open new address form if there is no address
    if ($('[nb-postal]').length >= 1 && $('.text-addr').length < 1) {
        $('.add-address').click();
    }

    //move to confirm part
    $(document).on('click', '[nb-toggle="confirm-part"]', function() {
        $('.main-levels li').removeClass('active').removeClass('active-st'); //basket-levels
        $('[nb-toggle="confirm-part"]').addClass('active-st'); //basket-levels
        $('.part').addClass('hidden'); //toggle part
        $('.confirm-part').removeClass('hidden'); //toggle part
        pay_jump();
    });

    //move to payment part
    $(document).on('click', '[nb-toggle="payment-part"]', function() {

        var un = $('.avatar-info .name').text();
        if (un == '' || un == ' ' || un == '  ' || un == '   ' || un == '    ' || un == '     ') {
            $('#complete-info').modal('show');
            return;
        }

        if ($(this).is('li')) {
            if (!localStorage.getItem("passToPayment")) {
                return;
            }
        }
        //fill hidden values
        $('input[name="use_wallet"]').val(($('#balance1').prop('checked') ? 1 : 0));
        $('input[name="user-address-id"]').val($('input[name="address"]:checked').val());
        $('input[name="h_giftCode"]').val($('#nb_gift').attr('nb-gift-code'));
        $('input[name="h_from"]').val($('#frozen_gift .t_from').text());
        $('input[name="h_to"]').val($('#frozen_gift .t_to').text());
        $('input[name="gift-email"]').val($('#frozen_gift .t_email').text());
        $('input[name="h_text"]').val($('#frozen_gift .t_text').text());

        //check pre-requisites
        if ($('[nb-postal]').length >= 1) {
            console.info('you have at least an item that require address for delivery');
            //we have at least an item with postal delivery method. So, do u have any delivery address already?
            if ($('input[name="address"]:checked').length == 1) {
                toggleToPayment();
                pay_jump();
            } else {
                console.warn('you don\'t add or select any address!');
                madjax.fn.alert({
                    'status': false,
                    'message': basket.msg.need_address
                })
            }
        } else {
            toggleToPayment();
            pay_jump();
        }
        

    });

    pay_jump();

    function guest_basket(){
        if ($('.basket-quest-login')[0]){
            var tMBfix2 = "<div class='fixed-fab smooth-scroll clearfix visible-sm visible-xs'><span class='nb-btn pull-left'>نهایی کردن خرید </span></div>";
            $(tMBfix2).appendTo(".page-basket");

            var pF = $('.page-basket .fixed-fab');
            var pFHeight = $('.page-basket .fixed-fab').height();
            pFHeight = pFHeight + 100;
            pF.find('.nb-btn').click('on', function () {
                $('html, body').stop().animate({
                    scrollTop: $('.page-basket .login-box').offset().top + 50
                }, 500);
            });

            $(window).scroll(function () {
                var x = $('.basket-quest-login .panel-heading');
                var offTop = $(window).scrollTop();
                var offTopB = x.offset();
                if ($(window).height() > 800) {
                    if (offTop >= offTopB.top - 750) {
                        pF.css({
                            'bottom': -pFHeight
                        })
                    } else {
                        pF.css({
                            'bottom': 0
                        });
                    }
                } else {
                    if (offTop >= offTopB.top - 350) {
                        pF.css({
                            'bottom': -pFHeight
                        })
                    } else {
                        pF.css({
                            'bottom': 0
                        });
                    }
                }
            });
        }
    }

    if ($('.basket-quest-login').length > 0) {
        guest_basket();
    }

    //delete gift code
    $(document).on('click', '#deleteGiftCode', function() {

        var g = $('#nb_gift');

        g.attr('nb-min', '')
            .attr('nb-max', '')
            .attr('nb-for-deal', '')
            .attr('nb-for-cat', '')
            .attr('nb-for-city', '')
            .attr('nb-percent', '')
            .attr('nb-gift-code', '')
            .attr('nb-gift-price', '0');

        $('.basket-confirm .hint').text('');

        g.removeClass('active');

        //g.find('input').val('');

        calcGift();

    });

    //read local storage for first time.
    readLocalStorage();

    //run script for first time.
    calcTotalPrice();

    //quantity change.
    $(document).on('change', '.qt', function() {
        calcTotalPrice();
        pay_jump();
    });

    //balance change.
    $(document).on('change', '#balance1', function() {
        $('[nb-balance]').text('0');
        $('[nb-balance-mirror]').text('0');
        calcFinal();
        //pay_jump();
    });

    ///Donation
    //user try to donate
    $(document).on('click', '.add-gift', function() {
        $('#donate').toggleClass('hidden');
        $('#donate_form').toggleClass('hidden');
    });

    //close donation form
    $(document).on('click', '#donate_form .bt-cancel', function() {

        if ($('#editable_gift .t_from').text() == '') {
            $('#donate').removeClass('hidden');
            $('#add_gift').removeClass('hidden');
        } else {
            $('#editable_gift').removeClass('hidden');
            $('#donate').addClass('hidden');
            $('#add_gift').addClass('hidden');
        }

        $('#donate_form').addClass('hidden');
    });

    //submit donation form
    $(document).on('click', '#donate_form .nb-btn-success', function(e) {

        if ($('#donate1').hasClass('red') || $('#donate2').hasClass('red') || $('#donate3').hasClass('red') || $('#donate4').hasClass('red')) {
            return;
        }

        var a = $('#donate1').val(),
            b = $('#donate2').val(),
            c = $('#donate3').val(),
            d = $('#donate4').val();

        $('.t_from').text(a);
        $('.t_to').text(b);
        $('.t_email').text(c);
        $('.t_text').text(d);

        $('#editable_gift').removeClass('hidden');
        $('#frozen_gift').removeClass('hidden');
        $('#donate').removeClass('hidden');
        $('#donate_form').addClass('hidden');
        $('#add_gift').addClass('hidden');

        //write gift form immediately
        $('input[name="h_from"]').val($('#frozen_gift .t_from').text());
        $('input[name="h_to"]').val($('#frozen_gift .t_to').text());
        $('input[name="gift-email"]').val($('#frozen_gift .t_email').text());
        $('input[name="h_text"]').val($('#frozen_gift .t_text').text());
        writeLocalStorage();

        e.preventDefault();

    });

    //delete donation details with confirm
    $(document).on('click', '#delete_donation', function() {

        var body = '<p>آیا از حذف سبد هدیه خود اطمینان دارید؟</p>',
            footer = '<button type="button" class="nb-btn nb-btn-sm nb-btn-border" onclick="delete_donation();closeModal();" >بلـه</button>' +
                '<button type="button" data-dismiss="modal" aria-label="Close" class="nb-btn nb-btn-sm nb-btn-border">خیـر</button>';
        netbarg.fn.mainModal([false, true, true], 'conf-modal', '', body, footer);

    });

    //edit donation detail
    $(document).on('click', '#edit_donation', function() {
        edit_donation();
    });

    //test script
    //newGift (2000000,1000000,10,'deal_1','','NETBARG2');//@TODO DELETE/COMMENT THIS ON PRODUCTION.
});