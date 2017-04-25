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
        ////CMPLTADMIN_SETTINGS.chatApiScroll();
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
       
});
