function statistics() {
    $('#statistics-button').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        $.get('https://localhost:7087/api/statistics', function (data) {
            $('#total_workouts').text(data.totalWorkouts + " Workouts");
            $('#total_users').text(data.totalUsers + " Users");
            $('#statistics').removeClass('d-nome');
            $('#statistics-button').hide();
        });
    });
};