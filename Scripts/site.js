var clipboard = new Clipboard('.clipboard-trigger');

$('#badgemeup').click(generate);

function generate() {

    var domain = $('#domainInput').val().toLowerCase();
    var markup = generateMarkup(domain)
    $('#markup').val(markup);
    $('#markdown').val(generateMarkdown(domain));
    $('#image').val(generateImageUrl(domain));
    $('#imagepreview').html(markup);

}

function generateMarkup(domain) {

    return '<a href="https://securityheaders.io/?q=' + domain + '&hide=on" target="_blank"><img src="' + generateImageUrl(domain) + '"></a>';

}

function generateMarkdown(domain) {

    return '[![SecurityHeaders.io](' + generateImageUrl(domain) + ')](https://securityheaders.io/?q=' + domain + '&hide=on)';

}

function generateImageUrl(domain) {

    return window.location.protocol + '//' + window.location.host + '/create/badge?domain=' + domain;

}