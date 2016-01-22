var homeController = function($scope, $http, blogService) {
    console.log('ciao');

    blogService.latest().then(function (articles) {
        $scope.blogs = articles;
    });
};