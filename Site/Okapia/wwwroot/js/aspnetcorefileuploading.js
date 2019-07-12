// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function submitForm(formId) {
  document.getElementById(formId).submit();
}

function showDeleteBtn(inputId, filename, fileid) {
  const deleteBtnName = '#delete' + inputId; 
  $(deleteBtnName).removeClass("hidden");
  const elementName = '#name' + inputId;
  $(elementName).attr("filename", filename);
  $(elementName).attr("fileid", fileid);
  $(elementName).attr("value", filename);
}

function hideDeleteBtn(name) {
  $('#delete' + name).addClass("hidden");
}

function uploadFiles(inputId, fileid, type) {
  const input = document.getElementById(inputId);
  const files = input.files;
  const formData = new FormData();
  for (let i = 0; i !== files.length; i++) {
    formData.append("files", files[i]);
  }
  $.ajax(
    {
      url: "/uploader/Upload?type="+type,
      data: formData,
      processData: false,
      contentType: false,
      type: "POST",
      success: function(data) {

        if (data === 400)
          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
        if (data === 401)
          sendNotification("error", "top-right", "خطا", "حجم عکس باید کمتر از ۳ مگابایت باشد");
        else {
          sendNotification("success", "top-right", "موفیت","عکس با موفقیت بارگذاری شد")
          showDeleteBtn(inputId, data, fileid);
        }
      }
    }
  );
}

function deletePhoto(inputId, type, titlePhoto, altPhoto, descPhoto) {
  const filename = $('#name' + inputId).attr("filename");
  $('#name' + inputId).attr('filename', null);
  $('#name' + inputId).attr('fileid', null);
  $('#' + titlePhoto).val(null);
  $('#' + altPhoto).val(null);
  $('#' + descPhoto).val(null);
  $.ajax(
    {
      url: "/Uploader/Delete/"+filename+"?type="+type,
      //data: { "filename" : "fdfsdfsd"},
      processData: false,
      contentType: false,
      type: "POST",
      success: function(data) {
        if (data === 200) {
          document.getElementById(inputId).value = "";  
          document.getElementById('prev' + inputId).src = "/defaultimage.png";
          hideDeleteBtn(inputId);
          $('#name' + inputId).attr('value', '');
        }
        if (data === 400)
          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
      }
    }
  );
}


function PreviewImage(input, img) {
  var oFReader = new FileReader();
  oFReader.readAsDataURL(document.getElementById(input).files[0]);

  oFReader.onload = function (oFREvent) {
    document.getElementById(img).src = oFREvent.target.result;
  };
};