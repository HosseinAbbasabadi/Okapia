function getList(sourceDropdown, action, distDropdown) {
  var id = $(sourceDropdown).val();
  $.ajax({
    url: action + '/' + id,
    type: 'Get',
    //datatype: 'application/json',
    contentType: 'application/json',
    //data: JSON.stringify({
    //  stateId: +stateId
    //}),
    success: function(result) {
      $(distDropdown).html("");
      $(distDropdown).append($('<option></option>').val(0).html('انتخاب کنید'));
      debugger;
      $.each(result,
        function(i, item) {
          $(distDropdown).append($('<option></option>').val(item.id).html(item.name));
        });
    },
    error: function() {
      alert("خطا در ارتباط با سرور لطفا با مدیر سیتم تماس بگیرید.");
    }
  });
}

//function getCityList(url) {
//  this.getList("#provinceDropDown", url, '#cityDropDown');
//}

function getCityList(province, url, city) {
  this.getList("#" + province, url, '#' + city);
}

//function getDistrictList(url) {
//  this.getList('#cityDropDown', url, '#districtDropDown');
//}

function getDistrictList(city, url, district) {
  this.getList('#' + city, url, '#' + district);
}

//function getNeighborhoodList(url) {
//  this.getList('#districtDropDown', url, '#neighborhoodDropDown');
//}

function getNeighborhoodList(district, url, neighborhood) {
  this.getList('#' + district, url, '#' + neighborhood);
}

function string_to_slug(str) {
  document.getElementById("JobSlug").value = str;
}

function openModalWithData(url, containerName, modalName) {
  $.ajax({
    url: url,
    type: "Get",
    success: function(response) {
      //$("#createCityDiv").html(response);
      //$('#createCityModal').modal('toggle');
      const container = document.getElementById(containerName);
      container.insertAdjacentHTML("beforeend", response);
      const forms = container.getElementsByTagName("form");
      const newForm = forms[forms.length - 1];
      $.validator.unobtrusive.parse(newForm);
      $('#' + modalName).modal('toggle');
    }
  });
}