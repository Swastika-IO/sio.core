$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    $(".sortable").sortable({
        revert: true,
        update: function (event, ui) {
            //create the array that hold the positions...
            var order = [];
            //loop trought each li...
            $('.sortable .sortable-item').each(function (e) {
                //add each li position to the array...
                // the +1 is for make it start from 1 instead of 0
                //order.push($(this).attr('id') + '=' + ($(this).index() + 1));
                $(this).find('.item-priority').val($(this).index() + 1);
                //alert($(this).attr('module-priority'));
            });
            // join the array as single variable...
            var positions = order.join(';')
            //use the variable as you need!
            //alert(positions);
            // $.cookie( LI_POSITION , positions , { expires: 10 });
        }
    });
    $(".draggable").draggable({
        cursor: "move",
        cursorAt: { top: 56, left: 56 },
        connectToSortable: ".sortable",
        helper: "clone",
        revert: "invalid"
    });
    $(".draggable-header").draggable({
        cursor: "move",
        cursorAt: { top: 56, left: 56 },
        connectToSortable: ".sortable",
        handle: ".card-header",
        helper: "clone",
        revert: "invalid"
    });
    $("ul, li").disableSelection();

    // $(window).on("scroll",function(){
    //     var wn = $(window).scrollTop();
    //   if(wn > 120){
    //       $("header").css("background","rgba(0, 0, 0, 0.88)");
    //   }
    //   else{
    //       $("header").css("background","rgba(0, 0, 0, 0.5)");
    //   }
    // });
});