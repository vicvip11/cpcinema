angular.module("cpcStaffModule").controller("cpcStaffController", ['cpcStaffServices', 'multipartForm', '$scope', function (cpcStaffServices, multipartForm, $scope)
{
    $scope.addMovieInit = function () {
        $scope.genres = movieGenres;
    }

    $scope.movie = {};
    $scope.addMovieBtn = function () {
        $scope.movie.file = $('#MovieImg').prop('files')[0];
        var uploadUrl = 'staff/addMovie';
        multipartForm.post(uploadUrl, $scope.movie);
    };

    $scope.addShowInit = function () {
        $scope.show = {};

        $scope.movies = [];
        $scope.halls = [];
        $scope.show.date = new Date();

        cpcStaffServices.getMovies().then(function (response) {
            var data = response.data;
            $scope.movies = data;
        });

        cpcStaffServices.getHalls().then(function (response) {
            var data = response.data;
            $scope.halls = data;
        });
    }

    $scope.checkHallForShowsBtn = function () {
        cpcStaffServices.getShowsForHall({ hall: $scope.show.hall, date: $scope.show.date }).then(function (response) {
            var data = response.data;
            alert(data);
        });
    }

    $scope.addShowBtn = function () {
        cpcStaffServices.addShow($scope.show).then(function (response) {
            var data = response.data;
            alert(data);
        });
    };
}]);