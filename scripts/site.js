$(window).bind("load resize",function(){var n=$("header nav"),t=$("body");window.innerWidth<768?(n.addClass("navbar-fixed-top"),t.addClass("navbarFixedTop")):(n.removeClass("navbar-fixed-top"),t.removeClass("navbarFixedTop"))});$("h2,h3").each(function(){var n=$(this).attr("id"),t;n&&($(this).before('<a name="'+n+'"><\/a>'),t=$('<a href="#'+n+'">'+$(this).text()+"<\/a>"),$(this).html(t))});$("#sidebar").affix({offset:{top:function(){return this.top=$(".bs-docs-sidebar").position().top}}});$("#buyBtn").click(function(){var n=$("#appName").val(),t;if(n===""){alert("Please enter the name of your app and then click 'Buy'.");return}t="https://secure.shareit.com/shareit/checkout.html?PRODUCT[300652529]=1&DELIVERY[300652529]=EML&backlink=http%3A%2F%2Fwww.mrgestures.com%2F#Buy&pc=90aex&HADD[300652529][ADDITIONAL1]="+encodeURIComponent(n);window.open(t,"_blank")});$(window).load(function(){$(".compatibility td").each(function(){if(this.title){for(var r=this.parentNode,t=r.children,i=$(t[0]).text(),n=1;n<t.length&&t[n]!==this;)n++;i+=n<t.length?" on "+["iOS","Android","UWP","WPF","MacOS"][n-1]:"";this.setAttribute("data-content",this.title);this.setAttribute("data-title",i);this.title=i;this.setAttribute("data-container","body");this.setAttribute("data-toggle","popover");this.setAttribute("data-placement","bottom");this.setAttribute("data-trigger","click hover")}});$(function(){$('[data-toggle="popover"]').popover()})})