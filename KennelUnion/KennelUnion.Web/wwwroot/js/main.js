﻿"use strict";

$(document).ready(function () {
    var url = window.location;
    $('#navbar').find('.active').removeClass('active');
    $('#navbar ul a').each(function () {
        if (this.href == url) {
            $(this).parent().addClass('active');
        }
    });
});