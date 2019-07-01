// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function submitForm(formId) {
  document.getElementById(formId).submit();
}

function showDeleteBtn(elementName, filename) {
  elementName = '#delete' + elementName;
  $(elementName).removeClass("hidden");
  $(elementName).attr("filename", filename);
}

function hideDeleteBtn(name) {
  $('#delete' + name).addClass("hidden");
}

function setHiddenInputPhotoName(inputId, data) {
  $('#name' + inputId).val(data);
}

function uploadFiles(inputId) {
  const input = document.getElementById(inputId);
  const files = input.files;
  const formData = new FormData();
  for (let i = 0; i !== files.length; i++) {
    formData.append("files", files[i]);
  }
  $.ajax(
    {
      url: "/uploader/Upload",
      data: formData,
      processData: false,
      contentType: false,
      type: "POST",
      success: function(data) {

        if (data === 400)
          alert("فایل نامعتبر است. لطفا دوباره تلاش کنید");
        if (data === 401)
          alert("حجم عکس باید کمتر از ۳ مگابایت باشد");
        else {
          alert("عکس با موفقیت بارگذاری شد");
          showDeleteBtn(inputId, data);
          setHiddenInputPhotoName(inputId, data);
        }
      }
    }
  );
}

function deletePhoto(elementName) {
  const filename = $('#delete' + elementName).attr("filename");
  $.ajax(
    {
      url: "/Uploader/Delete/"+filename,
      //data: { "filename" : "fdfsdfsd"},
      processData: false,
      contentType: false,
      type: "POST",
      success: function(data) {
        if (data === 200) {
          document.getElementById(elementName).value = "";
          document.getElementById('prev' + elementName).src = "/defaultimage.png";
          hideDeleteBtn(elementName);
        }
        if (data === 400)
          alert("خطایی رخ داده است لطفا دوباره تلاش کنید");
      }
    }
  );
}