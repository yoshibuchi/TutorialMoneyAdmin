// カレンダーの読み込み
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById("calendar");
    var calendar = new FullCalendar.Calendar(calendarEl, {
        // カレンダーに表示する文字の言語選択
        locale: "ja",
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