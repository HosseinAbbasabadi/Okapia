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
      $("#" + containerName).empty();
      const container = document.getElementById(containerName);
      container.insertAdjacentHTML("beforeend", response);
      const forms = container.getElementsByTagName("form");
      const newForm = forms[forms.length - 1];
      $.validator.unobtrusive.parse(newForm);
      $('#' + modalName).modal('toggle');
    }
  });
}

function createEntity(url, formId) {
  if ($("#" + formId).valid() === true) {
    const sendingData = $(`#${formId}`).serialize();
    $.post(url,
      sendingData,
      function(operationResult) {
        if (operationResult.success) {
          sendNotification('success', 'top right', "موفقیت", operationResult.message);
          $(`#${formId}`).trigger("reset");
        } else {
          sendNotification('error', 'top right', "خطا", operationResult.message);
        }
      });
  }
}

function createEntityThenFeedList(url, formId, listUrl, listDivId) {
  if ($("#" + formId).valid() === true) {
    const sendingData = $(`#${formId}`).serialize();
    $.post(url,
      sendingData,
      function(operationResult) {
        if (operationResult.success) {
          sendNotification('success', 'top right', "موفقیت", operationResult.message);
          $(`#${formId}`).trigger("reset");
          $.ajax({
            url: listUrl,
            type: "Get",
            success: function(response) {
              const container = document.getElementById(listDivId);
              $("#" + listDivId).empty();
              container.insertAdjacentHTML("beforeend", response);
            }
          });
        } else {
          sendNotification('error', 'top right', "خطا", operationResult.message);
        }
      });
  }
}

function createEntityThenReferesh(url, formId) {
  if ($("#" + formId).valid() === true) {
    for (instance in CKEDITOR.instances) {
      CKEDITOR.instances[instance].updateElement();
    }
    const sendingData = $(`#${formId}`).serialize();
      $.post(url,
        sendingData,
        function(operationResult) {
          if (operationResult.success) {
            sendNotification('success', 'top right', "موفقیت", operationResult.message);
            location.reload();
          } else {
            sendNotification('error', 'top right', "خطا", operationResult.message);
          }
        });
    }
  }

  function createUser(url, formId, redirectUrl) {
    if ($("#" + formId).valid() === true) {
      const sendingData = $(`#${formId}`).serialize();
      $.post(url,
        sendingData,
        function(operationResult) {
          if (operationResult.success) {
            sendNotification('success', 'top right', "موفقیت", operationResult.message);
            location.replace(redirectUrl);
          } else {
            sendNotification('error', 'top right', "خطا", operationResult.message);
          }
        });
    }
  }

  function updateEntity(url, formId) {
    const sendingData = $(`#${formId}`).serialize();
    if ($("#" + formId).valid() === true) {
      $.post(url,
        sendingData,
        function(operationResult) {
          if (operationResult.success) {
            sendNotification('success', 'top right', "موفقیت", operationResult.message);
            location.reload();
          } else {
            sendNotification('error', 'top right', "خطا", operationResult.message);
          }
        });
    }
  }

function updateEntityPage(url, formId, redirectUrl) {
  for (instance in CKEDITOR.instances) {
    CKEDITOR.instances[instance].updateElement();
  }
    const sendingData = $(`#${formId}`).serialize();
    if ($("#" + formId).valid() === true) {
      $.post(url,
        sendingData,
        function(operationResult) {
          if (operationResult.success) {
            sendNotification('success', 'top right', "موفقیت", operationResult.message);
            location.replace(redirectUrl);
          } else {
            sendNotification('error', 'top right', "خطا", operationResult.message);
          }
        });
    }
  }

  function sendNotification(status, place, title, body) {
    $.Notification.autoHideNotify(status, place, title, body);
}

function checkSlugDuplication(url, dist) {
  const id = document.getElementById(dist).value;
  $.get({
    url: url + '/' + id,
    success: function (operationResult) {
      if (!operationResult.success){
        sendNotification('error', 'top right', "خطا", operationResult.message);
      }
    }
  });
}

var slug = function (str) {
  var $slug = '';
  const trimmed = $.trim(str);
  $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
  return $slug.toLowerCase();
}

function makeSlug(source, dist, url) {
  const takedata = $('#'+source).val();
  $('#'+dist).val(slug(takedata));
  checkSlugDuplication(url, dist);
};