﻿function submitQuery() {
    var queryTxt = document.getElementById('query').value;
    if (queryTxt != '') {
        console.log('Starting query...');
        window.location = 'https://www.google.it/search?as_sitesearch=' + window.location.hostname + '&q=' + queryTxt;
    }
}