var PFileManager = {
  urls: {
    FileManagerUrl: '/Administrator/FileManager/index',
    UploadController: '/Administrator/FileManager/Upload',
    CreateDirectory: '/Administrator/FileManager/CreateDirectory'
  },
  targetField: 'mediaModalUrl',
  Current: {
    directory: undefined,
    type: undefined
  },
  thumbnail: false,
  ReturnRoot: true, //---- return url with root ---> /Data + url
  WaterMarkerUrl: '/images/WaterMarker.png',
  haveWaterMarker: false,
  Cropp: {
    isEventAdded: false, //---- for once add event Cropper Handel
    Cropper: null,
    MainRatio: null,
  },
  CallBack: undefined
};

Window.prototype.openPFileManager = function (type, targetField, options, CallBack) {
  var w;
  if (CallBack != null && CallBack != undefined)
    PFileManager.CallBack = CallBack;
  //---- set target for PEditor if target is Null
  if (targetField == null)
    targetField = PFileManager.targetField;
  //---- check Type
  if (type != "image" && type != "video" && type != "audio" && type != "file" && type != "all") {
    alert('PFileManager Error ! \n your type not correct');
    return;
  }
  var url = PFileManager.urls.FileManagerUrl + "?type=" + type + "&Target=" + targetField;
  if (options != null) {
    var OptionKeys = Object.keys(options);
    for (var i = 0; i < OptionKeys.length; i++)
      url += '&' + OptionKeys[i] + '=' + options[OptionKeys[i]];
  }
  w = window.open(url, '_blank', 'width=800,height=600,scrollbars=1');
  // pass the targetField to the pop up window
  w.targetField = targetField;
  w.focus();
}

function returnFileUrl(fileUrl) {

  var funcNum = getQueryString('CKEditorFuncNum');
  
  window.opener.CKEDITOR.tools.callFunction(funcNum, fileUrl);
  window.close();
}

function returnYourChoice(choice) {

  if (window.targetField == null || window.targetField == undefined)
    window.targetField = getQueryString('Target');

  var isCkEditor = false;
  if (getQueryString('CKEditorFuncNum') != undefined || getQueryString('CKEditorFuncNum') != null)
    isCkEditor = true;

  if (isCkEditor) {
    returnFileUrl(choice);
  } else {

    opener.setSearchResult(targetField, choice);
    if (opener.CallBackCall != undefined && opener.CallBackCall != null)
      opener.CallBackCall(choice);
    window.close();
  }
}

function setSearchResult(targetField, returnValue) {
  document.getElementById(targetField).value = returnValue;
  window.focus();
  try {
    var a = document.createElement('a');
    var onClik = document.getElementById(targetField).getAttribute('onchange');
    onClik = onClik.split("this.value");
    onClik = onClik[0] + "'" + returnValue + "'" + onClik[1];
    a.setAttribute('onclick', onClik);
    a.href = "javascript:void(0)";
    a.click();
  } catch (e) { }
}

//---- callBack
function CallBackCall(Url) {
  if (PFileManager.CallBack != undefined && PFileManager.CallBack != null)
    PFileManager.CallBack(Url);
}

//--- first Func ---> if path == "" open from type
function getThis(path) {
  getPageData(path);
}
function getPageData(path) {
  //---- get data and setting
  PFileManager.Current.type = getQueryString('type');
  PFileManager.Current.directory = path;

  var type = PFileManager.Current.type;
  var ReturnRoot = getQueryString('root');
  var ratio = getQueryString('ratio');

  //--- manage Current info
  if (path == '')
    PFileManager.Current.directory = 'Data/';
  if (path == 'Data/') //---- send Empty path if is Data
    path = '';

  if (ReturnRoot != null)
    PFileManager.ReturnRoot = false; //----- return /Data or not

  if (ratio != null)
    PFileManager.Cropp.MainRatio = parseFloat(ratio); //---- image Ratio

  //--- set input to single select for image Type
  if (type == 'image') {
    document.getElementById('File').removeAttribute('multiple');
  }


  //--- Send Request
  $.ajax({
    type: 'POST',
    url: '/Administrator/FileManager/getFile',
    data: { path: path, type: type },
    dataType: 'json',
    cache: false,
    success: function (result) {
      fetchPage(result);
      hideLoader();
    },
    beforeSend: function () {
      showLoader();
    }
  });

}
//--- fill Page
function fetchPage(result) {
  var DirectoryTag = '';
  var FilesTag = '';
  var Choice;
  var DirectoryName, DirectoryPath;
  //---- add Directories list to side
  if (result.Directories != null) {
    for (var i = 0; i < result.Directories.length; i++) {
      DirectoryName = result.Directories[i].split('/');
      DirectoryName = DirectoryName[DirectoryName.length - 1];
      //----- remove Data
      if (PFileManager.Current.type == 'all')
        DirectoryPath = result.Directories[i].split('Data/')[1];
      else
        DirectoryPath = result.Directories[i].split(PFileManager.Current.type + '/')[1];

      DirectoryTag += '<li><a href="javascript:void(0)" onclick="getThis(\'' + DirectoryPath + '\')" >' + DirectoryName + '</a></li>';
    }
  }
  document.getElementById('Dir').innerHTML = DirectoryTag;
  for (var i = 0; i < result.files.length; i++) {
    result.files[i] = result.files[i].replace('\\', '/');
    //--- not Return /Data if have Thumbnail
    Choice = result.files[i];
    if (PFileManager.thumbnail || !PFileManager.ReturnRoot)
      Choice = result.files[i].split('/Data')[1];

    FilesTag += ' <div class="col-12 col-sm-6 col-md-4 col-lg-3">' +
      '<i class="fa fa-fw fa-trash" onclick="DeleteFile(\'' + Choice + '\', this)"></i>' +
      '<div class="item" onclick="returnYourChoice(\'' + Choice + '\')">' +
      '<div class="imgDivider">' +
      returnFiles(result.files[i]) +
      '</div>' +
      '<p class="text-center">' + getFileName(result.files[i]) + '</p>' +
      '</div>' +
      '</div>';
  }
  document.getElementById('FilesRow').innerHTML = FilesTag;
}
function BackDir() {
  if (PFileManager.Current.directory != 'Data/') {
    var path = '/';
    var Directories = PFileManager.Current.directory.split('/');

    var BackDirLength = Directories.length - 2;
    if (PFileManager.Current.type == "all")
      BackDirLength = Directories.length - 1;

    for (var i = 0; i < BackDirLength; i++) {
      if (Directories[i] != '') {
        path += Directories[i];
        if (i != BackDirLength - 1)
          path += '/';
      }
    }
    getPageData(path);
  }
}
function showLoader() {
  document.getElementById('Loader').style.display = 'block';
}
function hideLoader() {
  setTimeout(function () {
    document.getElementById('Loader').style.display = 'none';
  }, 500)
}
function Upload() {
  $('#ModalFile').modal('hide');
  var Form_data = new FormData();
  //--- GetFiles    
  var files = document.getElementById('File').files;
  //-- generate Directory and Remove Base Directory
  var Directory = GetDirectoryForUpload();
  //--- append ToForm
  Form_data.append('pathFile', Directory);
  //--- if is Image
  if (PFileManager.Current.type == 'image') {
    //-- crop and water marker and compress and create thumbnail
    if (!document.getElementById('withOutCompress').checked) {
      GetImageCrope();
      return;
    }
  }
  //---- if Not Image
  for (var i = 0; i < files.length; i++) {
    Form_data.append('files[]', files[i]);
  }
  uploadRequest(Form_data);

}
function CheckType(FileName) {
  var type = getType(FileName);
  if (type == "jpg" || type == "png" || type == "gif" || type == "bmp" || type == "jpeg")
    type = 'image';
  return type;
}
function GetDirectoryForUpload() {
  var Directory = PFileManager.Current.directory.split('/');
  var FinalDir = '';
  for (var i = 0; i < Directory.length; i++) {
    if (Directory[i].toLowerCase() != 'data') {
      FinalDir += Directory[i];
      if (i != Directory.length - 1)
        FinalDir += '/';
    }

  }
  return FinalDir;
}
function uploadRequest(Form_data) {
  var url = PFileManager.urls.UploadController;

  $.ajax({
    type: "POST",
    async: true,
    data: Form_data,
    cache: false,
    dataType: "JSON",
    contentType: false,
    processData: false,
    url: url,
    success: function (result) {
      getPageData(PFileManager.Current.directory)
      hideLoader();
    },
    beforeSend: function () {
      showLoader();
    },
    error: function (xhr) {
      hideLoader();
    }
  });

  $('#File')[0].value = "";
}
function getType(file) {
  var type = file.split('/');
  type = type[type.length - 1];
  type = type.split('.');
  type = type[type.length - 1];
  type = type.toLowerCase();
  return type;
}
function getFileName(src) {
  var name = src.split('/');
  name = name[name.length - 1];
  //-- remove time Number in Name
  name = name.slice(7, name.length);
  //-- remove type
  name = name.split('.')[0];
  if (name.length > 15)
    name = name.slice(0, 12) + '...';
  return name;
}
function returnFiles(fileSrc) {
  var type = getType(fileSrc);
  var tag = '';
  if (type == 'jpg' || type == 'png' || type == 'gif' || type == 'bmp' || type == 'jpeg') {
    tag = '<img src="' + fileSrc + '" />'
  } else {
    tag = returnIcon(fileSrc, false);
  }
  return tag;
}
function returnIcon(file, isImageIcon) {
  var type = getType(file);
  var tag;
  if (type == 'jpg' || type == 'png' || type == 'gif' || type == 'bmp' || type == 'jpeg') {
    if (isImageIcon) {
      tag = '<span class="fa fa-file-image-o"></span>'
    }
  } else if (type == 'mp4')
    tag = '<span class="fa fa-file-video-o"></span>';
  else if (type == 'pdf')
    tag = '<span class="fa  fa-file-pdf-o"></span>';
  else if (type == 'mp3' || type == 'wav')
    tag = '<span class="fa  fa-file-audio-o"></span>';
  else
    tag = '<span class="fa fa-file"></span>';

  return tag;
}
function imageCrope(elem) {
  //--- Get Modal Body
  var ModalBody = document.getElementById('body');
  var $modal = $('#ModalFile');
  //--- Get File Type 
  var type = CheckType(elem.files[0].name);
  if (type != 'image') {
    ModalBody.innerHTML = '<h2 class="danger-text">خطا ... فرمت فایل نادرست است ... لطفا فقط فایل تصویری آپلود کنید</h2>';
    $('#buttonSave').removeAttr('onclick');
    $modal.modal('show');
    return;
  }
  ModalBody.innerHTML = '<label style="font-size:20px"><input type="checkbox" id="withOutCompress" checked="true"/>آپلود تصویر بدون برش و فشرده سازی</label>';
  if (PFileManager.Cropp.MainRatio != undefined)
    ModalBody.innerHTML += '<h5>توجه داشته باشید که نسبت عرض به طول تصویر باید ' + PFileManager.Cropp.MainRatio + ' باشد</h5>';
  ModalBody.innerHTML += '<div class="img-container"><img id="image" src=""></div>';

  var files = elem.files;
  //---- Cropper Settings
  var done = function (url) {
    document.getElementById('image').src = url;
    $modal.modal({
      backdrop: 'static',
      keyboard: false
    });
  };

  var reader;
  var file;
  var url;

  if (files && files.length > 0) {
    file = files[0];

    if (URL) {
      done(URL.createObjectURL(file));
    } else if (FileReader) {
      reader = new FileReader();
      reader.onload = function (e) {
        done(reader.result);
      };
      reader.readAsDataURL(file);
    }
  }

  if (!PFileManager.Cropp.isEventAdded) {
    $modal.on('shown.bs.modal', function () {
      //--- set Cropper    
      PFileManager.Cropp.Cropper = new Cropper(image, {
        aspectRatio: PFileManager.Cropp.MainRatio,
      });
    }).on('hidden.bs.modal', function () {
      PFileManager.Cropp.Cropper.destroy();
      PFileManager.Cropp.Cropper = null;
    });
    PFileManager.Cropp.isEventAdded = true;
  }
}
function overView(elem) {
  //--- send image for Crop  
  if (PFileManager.Current.type == 'image') {
    imageCrope(elem)
    return;
  }
  var tag = "<h3>فایل های انتخاب شده</h3>";
  var files = elem.files;
  if (files.length == 0)
    return;
  for (var i = 0; i < files.length; i++) {
    tag += '<h6>' + returnIcon(files[i].name, true) + files[i].name + '</h6>';
  }
  document.getElementById('body').innerHTML = tag;
  $('#ModalFile').modal('show');
}

function DeleteFile(url, elem) {
  var conf = confirm("حذف شود ؟!؟");
  if (conf == true) {
    $.post("/Administrator/FileManager/Delete", { url: url }, function (data) {
      if (data.res == true)
        $(elem).parent().remove();
    })
  }

}

//---- New Directory
function CreateNewFolder() {
  var DirectoryName = $('#DirName').val().toLowerCase().trim();
  if (DirectoryName != "image" && DirectoryName != "video" && DirectoryName != "audio" && DirectoryName != "file" && DirectoryName != "data") {
    var CurrentDir = PFileManager.Current.directory;
    if (CurrentDir.indexOf('Data/') > -1) {
      CurrentDir = CurrentDir.split('Data/')[1];
    }
    var path = CurrentDir + '/' + DirectoryName;
    $.post(PFileManager.urls.CreateDirectory, { path: path, type: PFileManager.Current.type }, function (data) {
      if (data.Success == true) {
        $('#DirModal').modal('hide');
        getPageData(PFileManager.Current.directory);
      }
      else
        $('#DirModal .modal-body')[0].innerHTML += '<h6 style="direction: rtl;">' + data.Message + '</h6>';
    })
  } else {
    $('#DirModal .modal-body')[0].innerHTML += '<h6 style="direction: rtl;">نام های image , data , file , audio , video , image غیر مجاز هستند</h6>';
  }
}
$('#DirModal').on('shown.bs.modal', function () {
  $('#DirName').focus();
})
//----- menu Context
function RenderMenuContext() {
  var RightClick = document.getElementsByClassName('rightClick');
  for (var i = 0; i < RightClick.length; i++) {
    RightClick[i].addEventListener('contextmenu', function (e) {
      e.preventDefault();
      toogleContext(e);
    });
  }
}
function CreateMenuContext(MenuItem, id) {
  //----- create Context
  var div = document.createElement('div');
  div.setAttribute('onclick', 'closeMenu()');
  div.setAttribute('class', 'MenuContextDiv');
  div.setAttribute('id', id + 'Div');
  var ContextDiv = document.createElement('div');
  ContextDiv.setAttribute('class', 'MenuContext');
  ContextDiv.setAttribute('id', id);
  ContextDiv.setAttribute('data-show', 'false');

  var divItem;
  for (var i = 0; i < MenuItem.length; i++) {
    divItem = document.createElement('div');
    divItem.setAttribute('onclick', MenuItem[i].clickFunc);
    divItem.innerHTML = MenuItem[i].name;
    ContextDiv.appendChild(divItem);
  }
  div.appendChild(ContextDiv);
  document.body.appendChild(div);
}
function toogleContext(id, e) {
  var MenuContext = document.getElementById(id);

  MenuContext.parentElement.classList.add('active');
  MenuContext.style.top = e.clientY + 'px';
  MenuContext.style.left = e.clientX + 'px';
}
function closeMenu(id) {
  var MenuContext = document.getElementById(id + 'Div');
  MenuContext.classList.remove('active');
}
function getQueryString(name, url) {
  if (!url) {
    url = window.location.href;
  }
  name = name.replace(/[\[\]]/g, "\\$&");
  var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
    results = regex.exec(url);
  if (!results) return null;
  if (!results[2]) return '';
  return decodeURIComponent(results[2].replace(/\+/g, " "));
}


function GetImageCrope() {
  var initialAvatarURL;
  var canvas;
  if (PFileManager.Cropp.Cropper) {
    canvas = PFileManager.Cropp.Cropper.getCroppedCanvas({});
    var CroppedImageUrl = canvas.toDataURL('image/jpeg');
    //---- WaterMarker Creator
    if (PFileManager.haveWaterMarker)
      SetWatterMarkerWidth(CroppedImageUrl, 16);
    else {
      var Blob = canvas.toBlob(function (blob) {
        CompressImageResult(blob);
      })
    }
  }
}

function SetWatterMarkerWidth(Src, percent) {
  //-- get width of image and set water Marke to 10 percent of image width
  var img = new Image();
  img.onload = function () {
    var width = img.width;
    var marker = new Image();
    marker.onload = function () {
      var MarkerRatio = marker.width / marker.height;
      var MarkerWidth = (width * percent) / 100;
      marker.width = MarkerWidth;
      var canvas = document.createElement('canvas');
      canvas.width = MarkerWidth;
      canvas.height = MarkerWidth / MarkerRatio;
      var ctx = canvas.getContext('2d');
      ctx.drawImage(marker, 0, 0, MarkerWidth, (MarkerWidth / MarkerRatio));
      canvas.toBlob(function (blob) {
        //--- Generate watter Marker 
        CreateWatterMarker(Src, blob);
      })
    }
    marker.src = PFileManager.WaterMarkerUrl;
  }
  img.src = Src;
}

function CreateWatterMarker(MainImage, WaterMarekr) {
  //---- waterMarke
  watermark([MainImage, WaterMarekr])
    .blob(watermark.image.lowerLeft())
    .then(function (Newblob) {
      //--- CompressImage
      CompressImageResult(Newblob);
    });

}

function CompressImageResult(Newblob) {
  var Form_data = new FormData();
  var path = GetDirectoryForUpload();
  Form_data.append('pathFile', path);
  var files = document.getElementById('File').files;
  var imageName = files[0].name


  var ErrorMessage = 'مشکل در آپلود .... لطفا دوباره امتحان بفرمایید';
  if (Newblob.size > 300000) {
    new ImageCompressor(Newblob, { //---- compress Image
      quality: 0.7,
      maxWidth: 1080,
      minWidth: 450,
      success: function (FileResult) {
        if (FileResult.size > 800000) {
          new ImageCompressor(Newblob, { //---- compress Image again
            quality: 0.7,
            maxWidth: 600,
            success: function (FileResult) {
              Form_data.append('files[]', FileResult, imageName);
              uploadRequest(Form_data);


            },
            error: function (e) {
              FileCounter--;
              ErrorFlag = true;
              alert(ErrorMessage);

            },
          });
        } else {
          Form_data.append('files[]', FileResult, imageName);
          uploadRequest(Form_data);
        }
      },
      error: function (e) {
        console.log(e);
      },
    });
  } else {
    Form_data.append('files[]', Newblob, imageName);
    uploadRequest(Form_data);
  }

}