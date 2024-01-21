
const INCOME = 1;
const SPEND = 2;
// カレンダーの読み込み
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById("calendar");
    var calendar = new FullCalendar.Calendar(calendarEl, {
        // カレンダーに表示する文字の言語選択
        locale: "ja",
        editable: true,
        slotEventOverlap: true,
        selectable: true,
        selectMinDistance: 1,
        events: function (start, end, timezone, callback) {
            // 前回実装したカレンダーデータ取得部分
            //setCalendarList(start.format('YYYY-MM-DD'), end.format('YYYY-MM-DD'), callback);
        },
        eventClick: function (calEvent, jsEvent, view) {
            // ***** 今回はここにクリックイベントを追加 *****
            $('#modalTitle').html(calEvent.title); // モーダルのタイトルをセット
            $('#modalBody').html(calEvent.description); // モーダルの本文をセット
            $('#calendarModal').modal(); // モーダル着火
        },
        dateClick: function (date, jsEvent, view) {
            // カレンダー空白部分クリック時のイベント
            date = date.dateStr;
            mode = 1;
            axios.post('/Calender/ShowCalenderModal', {
                date: date,
                mode: mode,
            })
            .then(function (res) {
                data = res.data;
                $('#modal_base').html(data);
                // モーダル表示
                $('#modal_base').find('.modal').modal('show');
            })
            .catch(function (error) {
                console.log(error);
            });
        },
        //select: function (start, end) {
        //    // カレンダー空白部分をドラッグして範囲指定した時のイベント
        //    date = "";
        //},
        //eventDrop: function (event, delta, revertFunc, jsEvent, ui, view) {
        //    // イベントをドラッグして別日に移動させた時のイベント
        //},
        headerToolbar: {
            // ヘッダーのボタン
            left: "prev,next today",
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay,listMonth"
        },
        // 土日の色付け
        businessHours: true
    });
        // カレンダーの描画
        calendar.render();
});
// 収入画面、支出画面の切り替え
function setCalenderModalInfo(val) {
    //モーダル画面再描画時に多重にならないようにする（黒くならないようにする。）
    $('.modal-backdrop').remove();
    let detailDate = $('#IncomeOrSpendDate').val();;
    let incomeOrSpendMode = val;
    axios.post('/Calender/ShowCalenderModal', {
        date: detailDate,
        mode: incomeOrSpendMode,
    })
    .then(function (res) {
        data = res.data;
        $('#modal_base').html(data);
        // モーダル表示
        $('#modal_base').find('.modal').modal('show');
    })
    .catch(function (error) {
        console.log(error);
    });
}

$('body').on('change', '#btnOpenMenu', function () {
    var selectCategory = $('#SelectLargeCategory').val();
    var incomeOrSpendMode = $('#IncomeOrSpendMode').val();
    let categoryNum = '';
    ReloadMiddleCategory(selectCategory, incomeOrSpendMode, categoryNum);
})
// 収入画面、支出画面の切り替え
function ReloadMiddleCategory(selectCategory, incomeOrSpendMode, categoryNum) {
    axios.post('/Calender/ReloadMiddleCategory', {
        selectCategory: selectCategory,
        mode: incomeOrSpendMode,
    })
    .then(function (res) {
        registCategoryDataSet(res, categoryNum, incomeOrSpendMode)
    })
    .catch(function (error) {
        console.log(error);
    });
}
// 大カテゴリーにあった中カテゴリーを設定する
function registCategoryDataSet(res, categoryNum, incomeOrSpendMode) {
    let $cmb = $('#SelectMiddleCategory' + categoryNum);
    let mode = parseInt(incomeOrSpendMode);
    $cmb.empty();
    $.each(res.data, function (index, item) {
        let option = '';
        if (mode == INCOME) {
            option = '<option value="' + item.IncomeMiddleCategoryId + '" ' + '>' + item.IncomeMiddleCategoryName + '</option>';
            $cmb.append(option);
        } else {
            option = '<option value="' + item.SpendMiddleCategoryId + '" ' + '>' + item.SpendMiddleCategoryName + '</option>';
            $cmb.append(option);
        }
    })
}

$('body').on('mouseover', '.dropdown-item', function () {
    var incomeOrSpendCategoryName = $(this).text();
    var incomeOrSpendCategoryId = parseInt($(this).data('value'));
    var incomeOrSpendMode = parseInt($('#IncomeOrSpendMode').val());
    let $cmb = $('#dropdown-menu-sub' + incomeOrSpendCategoryId);
    axios.post('/Calender/ReloadMiddleCategory', {
        selectCategory: incomeOrSpendCategoryId,
        mode: incomeOrSpendMode
    })
    .then(function (res) {
        $cmb.empty();
        $.each(res.data, function (index, item) {
            let option = '';
            if (incomeOrSpendMode == INCOME) {
                option = '<li class="drop-hover dropright"><a class="dropdown-item item-middle-category" data-value="' + item.IncomeMiddleCategoryId + '" >' + item.IncomeMiddleCategoryName + '</a></li>';
                $cmb.append(option);
            } else {
                option = '<li class="drop-hover dropright"><a class="dropdown-item item-middle-category" data-value="' + item.SpendMiddleCategoryId + '" >' + item.SpendMiddleCategoryName + '</a></li>';
                $cmb.append(option);
            }
        })
    })
    .catch(function (error) {
        console.log(error);
    });
});

$('body').on('click', '.dropdown-item', function () {
    if (this.className === "dropdown-item item-middle-category") {
        var itemMiddleId = parseInt(this.dataset.value);
        var middleCategoryName = this.innerText;
        var incomeOrSpendMode = parseInt($('#IncomeOrSpendMode').val());
        axios.post('/Calender/SelectMiddleCategory', {
            selectMiddleCategoryId: itemMiddleId,
            mode: incomeOrSpendMode
        })
        .then(function (res) {
            var data = res.data;
            var mainDropDown = document.getElementById("btnOpenMenu");
            var subDropdown = document.getElementById("dropdownMenuButton");
            mainDropDown.innerText = data[0].IncomeLargeCategoryName;
            subDropdown.innerText = middleCategoryName;
        })
        .catch(function (error) {
            console.log(error);
        });
    } else {
        var visibleItem = $('.dropdown-toggle', $(this).closest('.dropdown'));
        visibleItem[0].innerText = this.innerText;
    }
    // カテゴリーId取得できる
    //$(this).attr('value')
});


