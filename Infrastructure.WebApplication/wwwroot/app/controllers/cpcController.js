angular.module("cpcModule").controller("cpcController", ['cpcServices', '$scope', function (cpcServices, $scope) {

    $scope.movies = [];
    $scope.thisMovie = null;

    cpcServices.getMovies(0).then(function (response)
    {
        var data = response.data;
        $scope.movies = data;
       
    });

    $scope.selectMovie = function (movie) {
        movie.genre = movieGenres[movie.genre - 1].name;
        $scope.thisMovie = movie;        
    }

    $scope.back = function () {
        $scope.thisMovie = null;
    }
}]);