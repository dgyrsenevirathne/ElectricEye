// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// site.js

$(document).ready(function () {
    // Example: Toggle visibility of a section when a button is clicked
    $('#toggleButton').click(function () {
        $('#toggleSection').toggle();
    });

    // Example: Smooth scroll to sections
    $('a[href*="#"]').on('click', function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $($(this).attr('href')).offset().top
        }, 500);
    });
});
