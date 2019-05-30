// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $('.post-comment').click(function () {
        console.log('kajkjahsd');
        var comment = $('.commentBox').val();
        $('<li>').text(comment).prependTo('.comments');
        $('button').attr('disabled', 'true');
        $('.counter').text('140');
        $('.commentBox').val('');
    });

    $('.commentBox').keyup(function () {
        var commentLength = $(this).val().length;
        var charLeft = 140 - commentLength;
        $('.counter').text(charLeft);

        if (commentLength == 0) {
            $('button').attr('disabled', 'true');
        }
        else if (commentLength > 140) {
            $('button').attr('disabled', 'true');
        }
        else {
            $('button').removeAttr('disabled', 'true');
        }
    });

    $('button').attr('disabled', 'true');

});