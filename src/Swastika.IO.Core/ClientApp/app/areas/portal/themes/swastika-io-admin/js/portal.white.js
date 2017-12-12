
    $(document).ready(function () {
        $('#sidebarCollapse').on('click', function () {
          $('#sidebar').toggleClass('active');
        });
  
        $(".sortable").sortable({
          revert: true
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

        $(window).on("scroll",function(){
            var wn = $(window).scrollTop();
          if(wn > 120){
              $("header").css("background","rgba(0, 0, 0, 0.88)");
          }
          else{
              $("header").css("background","rgba(0, 0, 0, 0.5)");
          }
        });

      });