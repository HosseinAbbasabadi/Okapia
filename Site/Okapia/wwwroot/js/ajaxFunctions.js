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
    success: function (result) {
      $(distDropdown).html("");
      $(distDropdown).append($('<option></option>').val(0).html('انتخاب کنید'));
      $.each(result,
        function (i, item) {
          $(distDropdown).append($('<option></option>').val(item.id).html(item.name));
        });
    },
    error: function () {
      alert("خطا در ارتباط با سرور لطفا با مدیر سیتم تماس بگیرید.");
    }
  });
}

function getCityList(url) {
  this.getList('#provinceDropDown', url, '#cityDropDown');
}

function getDistrictList(url) {
  this.getList('#cityDropDown', url, '#districtDropDown');
}

function getNeighborhoodList(url) {
  this.getList('#districtDropDown', url, '#neighborhoodDropDown');
}
function string_to_slug(str) {
  document.getElementById("JobSlug").value = str;
}
