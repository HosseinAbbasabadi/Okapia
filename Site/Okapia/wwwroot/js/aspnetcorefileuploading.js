// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function submitForm(formId) {
  document.getElementById(formId).submit();
}

function uploadFile(imageInputId, imagePropertyId, deleteBtnId, type) {
  const input = document.getElementById(imageInputId);
  const files = input.files;
  const formData = new FormData();
  for (let i = 0; i !== files.length; i++) {
    formData.append("files", files[i]);
  }
  $.ajax(
    {
      url: "/uploader/Upload?type=" + type,
      data: formData,
      processData: false,
      contentType: false,
      type: "POST",
      success: function(filename) {

        if (filename === 400)
          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
        if (filename === 401)
          sendNotification("error", "top-right", "خطا", "حجم عکس باید کمتر از ۳ مگابایت باشد");
        else {
          sendNotification("success", "top-right", "موفیت", "عکس با موفقیت بارگذاری شد")
          $('#' + deleteBtnId).removeClass("hidden");
          $('#' + imagePropertyId).attr("value", filename);
        }
      }
    }
  );
}

function deletePhoto(imagePropertyId, imagePreviewId, deleteBtnId, titlePhoto, altPhoto, descPhoto, type) {
  const filename = $('#' + imagePropertyId).attr("value");
  $.ajax(
    {
      url: "/Uploader/Delete/" + filename + "?type=" + type,
      processData: false,
      contentType: false,
      type: "POST",
      success: function(data) {
        if (data === 200) {
          $('#' + titlePhoto).val(null);
          $('#' + altPhoto).val(null);
          $('#' + descPhoto).val(null);
          document.getElementById(imagePropertyId).value = "";
          document.getElementById(imagePreviewId).src = "/defaultimage.png";
          $('#' + deleteBtnId).addClass("hidden");
        }
        if (data === 400)
          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
      }
    }
  );
}

//function uploadFiles(imageInputId, imagePropertyId, imagePropertyName, deleteBtnId, type) {
//  const input = document.getElementById(imageInputId);
//  const files = input.files;
//  const formData = new FormData();
//  for (let i = 0; i !== files.length; i++) {
//    formData.append("files", files[i]);
//  }
//  $.ajax(
//    {
//      url: "/uploader/Upload?type=" + type,
//      data: formData,
//      processData: false,
//      contentType: false,
//      type: "POST",
//      success: function(filename) {

//        if (filename === 400)
//          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
//        if (filename === 401)
//          sendNotification("error", "top-right", "خطا", "حجم عکس باید کمتر از ۳ مگابایت باشد");
//        else {
//          sendNotification("success", "top-right", "موفیت", "عکس با موفقیت بارگذاری شد")
//          $('#' + deleteBtnId).removeClass("hidden");
//          $('#' + imagePropertyId).attr("value", filename);
//        }
//      }
//    }
//  );
//}

//function deletePhotos(imagePropertyId, imagePropertyName, imagePreviewId, deleteBtnId, titlePhoto, altPhoto, descPhoto, type) {
//  const filename = $('#' + imagePropertyId).attr("value");
//  $.ajax(
//    {
//      url: "/Uploader/Delete/" + filename + "?type=" + type,
//      processData: false,
//      contentType: false,
//      type: "POST",
//      success: function(data) {
//        if (data === 200) {
//          $('#' + titlePhoto).val(null);
//          $('#' + altPhoto).val(null);
//          $('#' + descPhoto).val(null);
//          document.getElementById(imagePropertyId).value = "";
//          document.getElementById(imagePreviewId).src = "/defaultimage.png";
//          $('#' + deleteBtnId).addClass("hidden");
//        }
//        if (data === 400)
//          sendNotification("error", "top-right", "خطا", "فایل نامعتبر است. لطفا دوباره تلاش کنید");
//      }
//    }
//  );
//}


function PreviewImage(imagePreviewId, image) {
  var oFReader = new FileReader();
  oFReader.readAsDataURL(document.getElementById(imagePreviewId).files[0]);

  oFReader.onload = function(oFREvent) {
    document.getElementById(image).src = oFREvent.target.result;
  };
};