$(function () {
    'use strict';
    var filter = {
        pageIndex: 0,
        pageSize: 10,
        keyword: ''
    };
    var headers = [
        { key: 'id', display: 'Id' },
        { key: 'name', display: 'Name' },
        { key: 'description', display: 'Description' },
        { key: 'slug', display: 'Slug' },
        { key: 'createdUtc', display: 'Created Date' }
    ];
    var req = {
        method: 'POST',
        url: '/api/Blog',
        data: JSON.stringify(filter)

    };

    SW.Common.getApiResult(req).then(response => {        

        var table = SW.Common.getPagingTable(response.data, 'Header Title', headers);
        $('#container').append(table);

    });



});
