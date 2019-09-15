var PhoneVerificationFlow = function (phoneNumber, page, options) {
    options = options || {};
    var self = this;
    // default values
    self.phoneNumber = '';
    if (/^(0{0,2}|\+*)(98)*9\d{9}$/.test(phoneNumber)) {
        self.phoneNumber = phoneNumber;
    }

    self.page = page;
    // modal selectors
    self.getNumberModalSelector = '#edit-mobile';
    self.enterOtpModalSelector = '#verifymobile';
    /**
     * Methods
     */
    self.hideModal = function (selector) {
        $(selector).modal('hide');
        return self;
    };
    self.showModal = function (selector) {
        $(selector).modal('show');
        // clear validation errors every time
        $(selector).find('.hint').empty();
        $(selector).find('input.red').removeClass('red');
        return self;
    };
    self.setFormUrl = function ($jqFormOjb) {
        var target = $jqFormOjb.attr('mj-target');
        if (typeof target != 'undefined' && target.indexOf('?page') === -1) {
            // to run only once
            $jqFormOjb.attr('mj-target', $jqFormOjb.attr('mj-target') + '?page=' + self.page);
        }
        return self;
    };
    // start new verification flow
    self.startVerification = function () {
        var $form = $(self.getNumberModalSelector).find('form');
        self.setFormUrl($form);
        self.showModal(self.getNumberModalSelector);
        $form.find('input[name="phone"]').val(self.phoneNumber);
        if (self.phoneNumber.trim() !== '') {
            $form.find('input[name="phone"]').prev().addClass('hascontent');
        }
    };
    // shows enter password modal
    self.showCodeForm = function () {
        self.hideModal(self.getNumberModalSelector).showModal(self.enterOtpModalSelector);
        $(self.getNumberModalSelector).find('input').val('');
        $(self.enterOtpModalSelector).find('.otp-code-verify-button').removeClass('nb-btn-success')
            .addClass('nb-btn-disabled').attr('disabled', 'disabled');
        setTimeout(function () {
            $(self.enterOtpModalSelector).find('.multi-part-input-auto-next input').first().focus();
        }, 500);
        grecaptcha.reset($(self.enterOtpModalSelector).find('[data-recaptcha-id]').attr('data-recaptcha-id'));
        $(document).trigger('otp-countdown-start');
    };
    /**
     * Event Listeners
     */
    $(document).off('otp-verification-step-one-success.' + self.page);
    $(document).on('otp-verification-step-one-success.' + self.page, function (event, data) {
        if (data.page === self.page) {
            self.showCodeForm();
        }
    });
    // overwrite options
    for (var key in options) {
        if (self.hasOwnProperty(key)) {
            self[key] = options[key];
        }
    }
};
