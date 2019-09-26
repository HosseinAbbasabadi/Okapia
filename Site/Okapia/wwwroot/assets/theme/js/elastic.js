$(document).ready(function(){
    var options = {
        url: function (phrase) {
            return "/JobView/Search";
        },
        getValue: function(element) {
            return element.short_name;
        },
        list: {
            onShowListEvent: function() {
              $(".site-search").addClass("open");
            },
            onHideListEvent: function() {
              $(".site-search").removeClass("open");
            }
        },
        ajaxSettings: {
            dataType: "json",
            method: "POST",
            data: {
                dataType: "json" 
            }
        },
        preparePostData: function(data) {
          data.phrase = $("#search-box").val();
          data.province = $("button.selected-city").attr("province-name");
            return data;
        },
        requestDelay: 800,
        template: {
            type: "custom",
            method: function (value, item) {
                return `<a href='${item.jobUrl}'><i style='background-image:url('${item.jobPictureUrl}');' /></i><span>${item.jobName}</span></a>`;
            }
        },
        minCharNumber: 3
    };
    $("#search-box").easyAutocomplete(options);

    $("form#search-form").submit(function (event) {
      const query = $("#search-box").val();
      if(query.length<3){
            event.stopPropagation();
            event.preventDefault();
        }
    });
});
