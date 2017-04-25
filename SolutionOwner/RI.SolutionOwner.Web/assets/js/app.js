jQuery(function($) {
    'use strict';
    var CMPLTADMIN_SETTINGS = window.CMPLTADMIN_SETTINGS || {};


    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.windowBasedLayout = function() {
        var width = window.innerWidth;
        //console.log(width);

        if ($("body").hasClass("chat-open") || $("body").hasClass("sidebar-collapse")) {

            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else if (width < 767) {

            // small window
            $(".page-topbar").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-sidebar").addClass("collapseit").removeClass("expandit");
            $("#main-content").addClass("sidebar_shift").removeClass("chat_shift");
            $(".page-right-block").removeClass("showit").addClass("hideit");
            $(".chatapi-windows").removeClass("showit").addClass("hideit");
            CMPLTADMIN_SETTINGS.mainmenuCollapsed();

        } else {

            // large window
            $(".page-topbar").removeClass("sidebar_shift chat_shift");
            $(".page-sidebar").removeClass("collapseit chat_shift");
            $("#main-content").removeClass("sidebar_shift chat_shift");
            CMPLTADMIN_SETTINGS.mainmenuScroll();
        }

    }

    /*--------------------------------
         Window Based Layout
     --------------------------------*/
    CMPLTADMIN_SETTINGS.onLoadTopBar = function() {
        
            $(".page-topbar .message-toggle-wrapper").addClass("showopacity");
            $(".page-topbar .notify-toggle-wrapper").addClass("showopacity");
            $(".page-topbar .searchform").addClass("showopacity");
            $(".page-topbar li.profile").addClass("showopacity");
    }


    /*--------------------------------
         CHAT API
     --------------------------------*/
    CMPLTADMIN_SETTINGS.chatAPI = function() {
        $('.page-topbar .toggle_chat').on('click', function() {
            var chatarea = $(".page-right-block");
            var chatwindow = $(".chatapi-windows");
            var topbar = $(".page-topbar");
            var mainarea = $("#main-content");
            var menuarea = $(".page-sidebar");

            if (chatarea.hasClass("hideit")) {
                chatarea.addClass("showit").removeClass("hideit");
                chatwindow.addClass("showit").removeClass("hideit");
                topbar.addClass("chat_shift");
                mainarea.addClass("chat_shift");
                menuarea.addClass("chat_shift");
                CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            } else {
                chatarea.addClass("hideit").removeClass("showit");
                chatwindow.addClass("hideit").removeClass("showit");
                topbar.removeClass("chat_shift");
                mainarea.removeClass("chat_shift");
                menuarea.removeClass("chat_shift");
                //CMPLTADMIN_SETTINGS.mainmenuScroll();
                CMPLTADMIN_SETTINGS.windowBasedLayout();
            }
        });

        $('.page-topbar .sidebar_toggle').on('click', function() {
            var chatarea = $(".page-right-block");
            var chatwindow = $(".chatapi-windows");
            var topbar = $(".page-topbar");
            var mainarea = $("#main-content");
            var menuarea = $(".page-sidebar");

            if (menuarea.hasClass("collapseit") || menuarea.hasClass("chat_shift")) {
                menuarea.addClass("expandit").removeClass("collapseit").removeClass("chat_shift");
                topbar.removeClass("sidebar_shift").removeClass("chat_shift");
                mainarea.removeClass("sidebar_shift").removeClass("chat_shift");
                chatarea.addClass("hideit").removeClass("showit");
                chatwindow.addClass("hideit").removeClass("showit");
                CMPLTADMIN_SETTINGS.mainmenuScroll();
            } else {
                menuarea.addClass("collapseit").removeClass("expandit").removeClass("chat_shift");
                topbar.addClass("sidebar_shift").removeClass("chat_shift");
                mainarea.addClass("sidebar_shift").removeClass("chat_shift");
                CMPLTADMIN_SETTINGS.mainmenuCollapsed();
            }
        });

    };





    /*--------------------------------
         Main Menu Scroll
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuScroll = function() {

        //console.log("expand scroll menu");

        var topbar = $(".page-topbar").height();
        var projectinfo = $(".project-info").innerHeight();

        var height = window.innerHeight - topbar - projectinfo;

        $('.fixedscroll #main-menu-wrapper').height(height).perfectScrollbar({
            suppressScrollX: true
        });
        $("#main-menu-wrapper .wraplist").height('auto');


        /*show first sub menu of open menu item only - opened after closed*/
        // > in the selector is used to select only immediate elements and not the inner nested elements.
        $("li.open > .sub-menu").attr("style", "display:block;");


    };


    /*--------------------------------
         Collapsed Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainmenuCollapsed = function() {

        if ($(".page-sidebar.chat_shift #main-menu-wrapper").length > 0 || $(".page-sidebar.collapseit #main-menu-wrapper").length > 0) {
            //console.log("collapse menu");
            var topbar = $(".page-topbar").height();
            var windowheight = window.innerHeight;
            var minheight = windowheight - topbar;
            var fullheight = $(".page-container #main-content .wrapper").height();

            var height = fullheight;

            if (fullheight < minheight) {
                height = minheight;
            }

            $('.fixedscroll #main-menu-wrapper').perfectScrollbar('destroy');

            $('.page-sidebar.chat_shift #main-menu-wrapper .wraplist, .page-sidebar.collapseit #main-menu-wrapper .wraplist').height(height);

            /*hide sub menu of open menu item*/
            $("li.open .sub-menu").attr("style", "");

        }

    };




    /*--------------------------------
         Main Menu
     --------------------------------*/
    CMPLTADMIN_SETTINGS.mainMenu = function() {
        $('#main-menu-wrapper li a').click(function(e) {

            if ($(this).next().hasClass('sub-menu') === false) {
                return;
            }

            var parent = $(this).parent().parent();
            var sub = $(this).next();

            parent.children('li.open').children('.sub-menu').slideUp(200);
            parent.children('li.open').children('a').children('.arrow').removeClass('open');
            parent.children('li').removeClass('open');

            if (sub.is(":visible")) {
                $(this).find(".arrow").removeClass("open");
                sub.slideUp(200);
            } else {
                $(this).parent().addClass("open");
                $(this).find(".arrow").addClass("open");
                sub.slideDown(200);
            }

        });

        $("body").click(function(e) {
            $(".page-sidebar.collapseit .wraplist li.open .sub-menu").attr("style","");
            $(".page-sidebar.collapseit .wraplist li.open").removeClass("open");
            $(".page-sidebar.chat_shift .wraplist li.open .sub-menu").attr("style","");
            $(".page-sidebar.chat_shift .wraplist li.open").removeClass("open");
        });

    };



    /*--------------------------------
         Top Bar
     --------------------------------*/
    CMPLTADMIN_SETTINGS.pageTopBar = function() {
        $('.page-topbar li.searchform .input-group-addon').click(function(e) {
            $(this).parent().parent().parent().toggleClass("focus");
            $(this).parent().parent().find("input").focus();
        });

        $('.page-topbar li .dropdown-menu .list').perfectScrollbar({
            suppressScrollX: true
        });

    };

    /******************************
     initialize respective scripts 
     *****************************/
    $(document).ready(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
        CMPLTADMIN_SETTINGS.mainmenuScroll();
        CMPLTADMIN_SETTINGS.mainMenu();
        CMPLTADMIN_SETTINGS.pageTopBar();
        CMPLTADMIN_SETTINGS.chatAPI();
        CMPLTADMIN_SETTINGS.chatApiScroll();
    });
    $(window).resize(function() {
        CMPLTADMIN_SETTINGS.windowBasedLayout();
    });




    // Tooltip

    $(function () {
      $('[data-toggle="tooltip"]').tooltip()
    })

    /*--------------------------------
         Contacts in add solution partner
     --------------------------------*/


            $("#add_contact_close").click(function(){
                $("#add_contact_block").slideUp("slow");
            });
            $("#contact_add").click(function(){
                $("#edit_contact_block").hide();
                $("#add_contact_block").slideDown("slow");
            });
            $("#contact_edit").click(function(){
                $("#add_contact_block").hide();
                $("#edit_contact_block").slideDown("slow");
            });
            $("#edit_contact_close").click(function(){
                $("#edit_contact_block").slideUp("slow");
            });

            /*-----------------------------------
            Solution partner invoicing
            ------------------------------------*/ 
            $("#invoice_frequency").change(function(){

                var value = $('#invoice_frequency').val();
                if(value == 'Daily'){
                    $("#weekly").css("display","none");
                    $("#txntill").css("display","block");
                    $("#txntill1").css("display","none");
                    $("#weeklyOn").css("display","none");
                    $("#monthly").css("display","none");
                    $("#daily").css("display","block");
                    $("#monthlyOn").css("display","none");
                    $("#generationWeek").css("display","none");
                    $("#periodWeek1").css("display","none");
                    $("#periodWeek2").css("display","none");
                    $("#periodMonth1").css("display","none");
                    $("#periodMonth2").css("display","none");
                    $("#generationMonth").css("display","none");
                    $("#cutoffDay").css("display","block");
                    $("#invoice_period").children().remove();
                    $("#invoice_period").append('<option value="Daily">Daily</option>');
                    $("#invoice_period").append('<option value="Weekly">Weekly</option>');
                    $("#invoice_period").append('<option value="Monthly">Monthly</option>');
                    $("#COD").css("display","none");

                }
                if(value == 'Weekly'){
                    $("#weekly").css("display","block");
                    $("#weeklyOn").css("display","block");
                    $("#monthly").css("display","none");
                    $("#daily").css("display","none");
                    $("#txntill").css("display","none");
                    $("#txntill1").css("display","block");
                    $("#cutoffDay").css("display","none");
                    $("#monthlyOn").css("display","none");
                    $("#generationWeek").css("display","block");
                    $("#periodWeek1").css("display","block");
                    $("#periodWeek2").css("display","block");
                    $("#periodMonth1").css("display","none");
                    $("#periodMonth2").css("display","none");
                    $("#generationMonth").css("display","none");
                    $("#invoice_period").children().remove();
                    $("#invoice_period").append('<option value="Weekly">Weekly</option>');
                    $("#invoice_period").append('<option value="Monthly">Monthly</option>');
                    $("#COD").css("display","block");
                    $("#tranactionCOD").children().remove();
                    $("#tranactionCOD").append('<option value="Sunday">Sunday</option>');
                    $("#tranactionCOD").append('<option value="Monday">Monday</option>');
                    $("#tranactionCOD").append('<option value="Tuesday">Tuesday</option>');
                    $("#tranactionCOD").append('<option value="Wednesday">Wednesday</option>');
                    $("#tranactionCOD").append('<option value="Thursday">Thursday</option>');
                    $("#tranactionCOD").append('<option value="Friday">Friday</option>');
                    $("#tranactionCOD").append('<option value="Saturday">Saturday</option>');
                }
                if(value == 'Monthly'){
                    $("#weekly").css("display","none");
                    $("#weeklyOn").css("display","none");
                    $("#daily").css("display","none");
                    $("#monthly").css("display","block");
                    $("#txntill").css("display","none");
                    $("#txntill1").css("display","block");
                    $("#monthlyOn").css("display","block");
                    $("#cutoffDay").css("display","none");
                    $("#periodMonth1").css("display","block");
                    $("#periodMonth2").css("display","block");
                    $("#generationMonth").css("display","block");
                    $("#periodWeek1").css("display","none");
                    $("#periodWeek2").css("display","none");
                    $("#generationWeek").css("display","none");
                    $("#invoice_period").children().remove();
                    $("#invoice_period").append('<option value="Monthly">Monthly</option>');
                    $("#COD").css("display","block");
                    $("#tranactionCOD").children().remove();
                    $("#tranactionCOD").append('<option value="1">1</option>');
                    $("#tranactionCOD").append('<option value="2">2</option>');
                    $("#tranactionCOD").append('<option value="3">3</option>');
                    $("#tranactionCOD").append('<option value="4">4</option>');
                    $("#tranactionCOD").append('<option value="5">5</option>');
                    $("#tranactionCOD").append('<option value="6">6</option>');
                    $("#tranactionCOD").append('<option value="7">7</option>');
                    $("#tranactionCOD").append('<option value="8">8</option>');
                    $("#tranactionCOD").append('<option value="9">9</option>');
                    $("#tranactionCOD").append('<option value="10">10</option>');
                    $("#tranactionCOD").append('<option value="11">11</option>');
                    $("#tranactionCOD").append('<option value="12">12</option>');
                    $("#tranactionCOD").append('<option value="13">13</option>');
                    $("#tranactionCOD").append('<option value="14">14</option>');
                    $("#tranactionCOD").append('<option value="15">15</option>');
                    $("#tranactionCOD").append('<option value="16">16</option>');
                    $("#tranactionCOD").append('<option value="17">17</option>');
                    $("#tranactionCOD").append('<option value="18">18</option>');
                    $("#tranactionCOD").append('<option value="19">19</option>');
                    $("#tranactionCOD").append('<option value="20">20</option>');
                    $("#tranactionCOD").append('<option value="21">21</option>');
                    $("#tranactionCOD").append('<option value="22">22</option>');
                    $("#tranactionCOD").append('<option value="23">23</option>');
                    $("#tranactionCOD").append('<option value="24">24</option>');
                    $("#tranactionCOD").append('<option value="25">25</option>');
                    $("#tranactionCOD").append('<option value="26">26</option>');
                    $("#tranactionCOD").append('<option value="27">27</option>');
                    $("#tranactionCOD").append('<option value="28">28</option>');
                    $("#tranactionCOD").append('<option value="29">29</option>');
                    $("#tranactionCOD").append('<option value="30">30</option>');
                    $("#tranactionCOD").append('<option value="31">31</option>');
                }
            });
            
            $("#invoice_period").change(function(){
                var value1 = $('#invoice_period').val();
                if(value1 == 'Daily')
                {
                    $("#generationMonth").css("display","none");
                    $("#generationWeek").css("display","none");
                    $("#periodWeek1").css("display","none");
                    $("#periodWeek2").css("display","none");
                    $("#periodMonth1").css("display","none");
                    $("#periodMonth2").css("display","none");
                    $("#cutoffDay").css("display","block");
                }
                if (value1 == 'Weekly') 
                {
                    $("#generationMonth").css("display","none");
                    $("#cutoffDay").css("display","none");
                    $("#generationWeek").css("display","block");
                    $("#periodWeek1").css("display","block");
                    $("#periodWeek2").css("display","block");
                    $("#periodMonth1").css("display","none");
                    $("#periodMonth2").css("display","none");
                };
                if( value1 == 'Monthly')
                {
                    $("#generationMonth").css("display","block");
                    $("#periodMonth1").css("display","block");
                    $("#periodMonth2").css("display","block");
                    $("#periodWeek1").css("display","none");
                    $("#cutoffDay").css("display","none");
                    $("#periodWeek2").css("display","none");
                    $("#generationWeek").css("display","none");
                }

            });
            // Edit invoice
            
            $("#invoice_frequencyE").change(function(){

                var value = $('#invoice_frequencyE').val();
                if(value == 'Daily'){
                    $("#weeklyE").css("display","none");
                    $("#txntillE").css("display","block");
                    $("#txntill1E").css("display","none");
                    $("#weeklyOnE").css("display","none");
                    $("#monthlyE").css("display","none");
                    $("#dailyE").css("display","block");
                    $("#monthlyOnE").css("display","none");
                    $("#generationWeekE").css("display","none");
                    $("#periodWeek1E").css("display","none");
                    $("#periodWeek2E").css("display","none");
                    $("#periodMonth1E").css("display","none");
                    $("#periodMonth2E").css("display","none");
                    $("#generationMonthE").css("display","none");
                    $("#cutoffDayE").css("display","block");
                    $("#invoice_periodE").children().remove();
                    $("#invoice_periodE").append('<option value="Daily">Daily</option>');
                    $("#invoice_periodE").append('<option value="Weekly">Weekly</option>');
                    $("#invoice_periodE").append('<option value="Monthly">Monthly</option>');
                    $("#CODE").css("display","none");

                }
                if(value == 'Weekly'){
                    $("#weeklyE").css("display","block");
                    $("#weeklyOnE").css("display","block");
                    $("#monthlyE").css("display","none");
                    $("#dailyE").css("display","none");
                    $("#txntillE").css("display","none");
                    $("#txntill1E").css("display","block");
                    $("#cutoffDayE").css("display","none");
                    $("#monthlyOnE").css("display","none");
                    $("#generationWeekE").css("display","block");
                    $("#periodWeek1E").css("display","block");
                    $("#periodWeek2E").css("display","block");
                    $("#periodMonth1E").css("display","none");
                    $("#periodMonth2E").css("display","none");
                    $("#generationMonthE").css("display","none");
                    $("#invoice_periodE").children().remove();
                    $("#invoice_periodE").append('<option value="Weekly">Weekly</option>');
                    $("#invoice_periodE").append('<option value="Monthly">Monthly</option>');
                    $("#CODE").css("display","block");
                    $("#tranactionCODE").children().remove();
                    $("#tranactionCODE").append('<option value="Sunday">Sunday</option>');
                    $("#tranactionCODE").append('<option value="Monday">Monday</option>');
                    $("#tranactionCODE").append('<option value="Tuesday">Tuesday</option>');
                    $("#tranactionCODE").append('<option value="Wednesday">Wednesday</option>');
                    $("#tranactionCODE").append('<option value="Thursday">Thursday</option>');
                    $("#tranactionCODE").append('<option value="Friday">Friday</option>');
                    $("#tranactionCODE").append('<option value="Saturday">Saturday</option>');
                }
                if(value == 'Monthly'){
                    $("#weeklyE").css("display","none");
                    $("#weeklyOnE").css("display","none");
                    $("#dailyE").css("display","none");
                    $("#monthlyE").css("display","block");
                    $("#txntillE").css("display","none");
                    $("#txntill1E").css("display","block");
                    $("#monthlyOnE").css("display","block");
                    $("#cutoffDayE").css("display","none");
                    $("#periodMonth1E").css("display","block");
                    $("#periodMonth2E").css("display","block");
                    $("#generationMonthE").css("display","block");
                    $("#periodWeek1E").css("display","none");
                    $("#periodWeek2E").css("display","none");
                    $("#generationWeekE").css("display","none");
                    $("#invoice_periodE").children().remove();
                    $("#invoice_periodE").append('<option value="Monthly">Monthly</option>');
                    $("#CODE").css("display","block");
                    $("#tranactionCODE").children().remove();
                    $("#tranactionCODE").append('<option value="1">1</option>');
                    $("#tranactionCODE").append('<option value="2">2</option>');
                    $("#tranactionCODE").append('<option value="3">3</option>');
                    $("#tranactionCODE").append('<option value="4">4</option>');
                    $("#tranactionCODE").append('<option value="5">5</option>');
                    $("#tranactionCODE").append('<option value="6">6</option>');
                    $("#tranactionCODE").append('<option value="7">7</option>');
                    $("#tranactionCODE").append('<option value="8">8</option>');
                    $("#tranactionCODE").append('<option value="9">9</option>');
                    $("#tranactionCODE").append('<option value="10">10</option>');
                    $("#tranactionCODE").append('<option value="11">11</option>');
                    $("#tranactionCODE").append('<option value="12">12</option>');
                    $("#tranactionCODE").append('<option value="13">13</option>');
                    $("#tranactionCODE").append('<option value="14">14</option>');
                    $("#tranactionCODE").append('<option value="15">15</option>');
                    $("#tranactionCODE").append('<option value="16">16</option>');
                    $("#tranactionCODE").append('<option value="17">17</option>');
                    $("#tranactionCODE").append('<option value="18">18</option>');
                    $("#tranactionCODE").append('<option value="19">19</option>');
                    $("#tranactionCODE").append('<option value="20">20</option>');
                    $("#tranactionCODE").append('<option value="21">21</option>');
                    $("#tranactionCODE").append('<option value="22">22</option>');
                    $("#tranactionCODE").append('<option value="23">23</option>');
                    $("#tranactionCODE").append('<option value="24">24</option>');
                    $("#tranactionCODE").append('<option value="25">25</option>');
                    $("#tranactionCODE").append('<option value="26">26</option>');
                    $("#tranactionCODE").append('<option value="27">27</option>');
                    $("#tranactionCODE").append('<option value="28">28</option>');
                    $("#tranactionCODE").append('<option value="29">29</option>');
                    $("#tranactionCODE").append('<option value="30">30</option>');
                    $("#tranactionCODE").append('<option value="31">31</option>');
                }
            });
            
            $("#invoice_periodE").change(function(){
                var value1 = $('#invoice_periodE').val();
                if(value1 == 'Daily')
                {
                    $("#generationMonthE").css("display","none");
                    $("#generationWeekE").css("display","none");
                    $("#periodWeek1E").css("display","none");
                    $("#periodWeek2E").css("display","none");
                    $("#periodMonth1E").css("display","none");
                    $("#periodMonth2E").css("display","none");
                    $("#cutoffDayE").css("display","block");
                }
                if (value1 == 'Weekly') 
                {
                    $("#generationMonthE").css("display","none");
                    $("#cutoffDayE").css("display","none");
                    $("#generationWeekE").css("display","block");
                    $("#periodWeek1E").css("display","block");
                    $("#periodWeek2E").css("display","block");
                    $("#periodMonth1E").css("display","none");
                    $("#periodMonth2E").css("display","none");
                };
                if( value1 == 'Monthly')
                {
                    $("#generationMonthE").css("display","block");
                    $("#periodMonth1E").css("display","block");
                    $("#periodMonth2E").css("display","block");
                    $("#periodWeek1E").css("display","none");
                    $("#cutoffDayE").css("display","none");
                    $("#periodWeek2E").css("display","none");
                    $("#generationWeekE").css("display","none");
                }

            });

              // Mode of invoice

            $("#MOI").change(function(){
                var value = $('#MOI').val();
                if(value == 'Automatic')
                {
                    $("#automaticMOI").css("display","block");
                }
                if(value == 'Manual')
                {
                    $("#automaticMOI").css("display","none");
                }
            }); 

            $("#MOIE").change(function(){
                var value = $('#MOIE').val();
                if(value == 'Automatic')
                {
                    $("#automaticMOIE").css("display","block");
                }
                if(value == 'Manual')
                {
                    $("#automaticMOIE").css("display","none");
                }
            }); 

            // Date picker
            $('.date-picker').datepicker({
            });
});

                
