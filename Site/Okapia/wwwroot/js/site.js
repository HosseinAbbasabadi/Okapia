var count = 2;

function dynamicCard() {
  if (this.count === 11) {
    alert("حد اکثر تعداد کارت ۱۰ عدد می باشد");
    return;
  };
  const division = document.createElement("DIV");
  division.innerHTML = dynamicCardBox(this.count);
  const prevCounter = this.count - 1;
  if (document.getElementById(`removeBtn${prevCounter}`) !== null) {
    document.getElementById(`removeBtn${prevCounter}`).classList.add("hidden");
  }
  document.getElementById("bankCards").appendChild(division);
  this.count++;
}

function dynamicCardBox(count) {
  return `<div class="col-md-4">
            <div class="form-group">
              <label class="control-label">شماره کارت ${count}</label>
              <input name="Card${count}" id="Card${count}" 
                class="form-control direct-ltr" data-val-length="&#x637;&#x648;&#x644; &#x634;&#x645;&#x627;&#x631;&#x647; &#x6A9;&#x627;&#x631;&#x62A; &#x6F1;&#x6F6; &#x631;&#x642;&#x645; &#x627;&#x633;&#x62A;" data-val-length-max="16" data-val-length-min="16" data-val-regex="&#x644;&#x637;&#x641;&#x627; &#x6CC;&#x6A9; &#x634;&#x645;&#x627;&#x631;&#x647; &#x645;&#x639;&#x62A;&#x628;&#x631; &#x648;&#x627;&#x631;&#x62F; &#x6A9;&#x646;&#x6CC;&#x62F;" data-val-regex-pattern="([0-9]&#x2B;)" data-val-required="&#x627;&#x6CC;&#x646; &#x641;&#x6CC;&#x644;&#x62F; &#x646;&#x645;&#x6CC; &#x62A;&#x648;&#x627;&#x646;&#x62F; &#x62E;&#x627;&#x644;&#x6CC; &#x628;&#x627;&#x634;&#x62F;" maxlength="16"/>
              <input class="btn btn-danger btn-sm" type="button" value="حذف" onclick="removeCardBox(this)" id="removeBtn${
    count}"/>
            </div>
          </div>`;
}

function removeCardBox(div) {
  document.getElementById("bankCards").removeChild(div.parentNode.parentNode.parentNode);
  this.count--;
  if (document.getElementById(`removeBtn${this.count - 1}`) !== null) {
    document.getElementById(`removeBtn${this.count - 1}`).classList.remove("hidden");
  }
}