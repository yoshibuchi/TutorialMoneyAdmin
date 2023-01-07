// カレンダーの読み込み
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById("calendar");
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            // ヘッダーのボタン
            left: "prev,next today",
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay,listMonth"
        }
    });
    // カレンダーの描画
    calendar.render();
});