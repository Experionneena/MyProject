function InitialiseDataTable(mSortingString) {
    $('.dataTableBinding').dataTable({
        "aoColumnDefs": mSortingString
    });
    var $item = $(".dataTables_info").parent();
    $item.css('float', 'left');
    $('label:contains("Search")').css('color', 'transparent');
    var inputText = $('label:contains("Search")');
    inputText.children().first().css('height', '38px');
    inputText.children().first().css('width', '343px');
    inputText.children().attr("placeholder", "Search");
    $('.dataTables_filter label').contents().first()[0].textContent = '';    
    //$(".dataTables_paginate, .pagination, .previous").find('a:first').text("<<");
    //$(".dataTables_paginate, .pagination, .next").find('a:last').text(">>");

}
function InitialiseDataTableForCollpase(mSortingString) {
    $('.dataTableBinding').dataTable({
        "aoColumnDefs": mSortingString,
        searching: false
    });
    var $item = $(".dataTables_info").parent();
    $item.css('float', 'left');
    $('label:contains("Search")').css('color', 'transparent');
    var inputText = $('label:contains("Search")');
    inputText.children().first().css('height', '38px');
    inputText.children().first().css('width', '343px');
    inputText.children().attr("placeholder", "Search");
    //$('.dataTables_filter label').contents().first()[0].textContent = '';
    //$(".dataTables_paginate, .pagination, .previous").find('a:first').text("<<");
    //$(".dataTables_paginate, .pagination, .next").find('a:last').text(">>");

}