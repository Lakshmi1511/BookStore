var BookStoreApp = angular.module('BookStoreApp', ['ngRoute']); //Initialize the app

BookStoreApp.config(function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
    .when('/Home', {
        templateUrl: 'templates/MainPage.htm',
        controller: 'homeController'
    })

    .when('/MyCart', {
        templateUrl: 'templates/MyCart.htm',
        controller: 'CartlController'
    })

    .otherwise({ redirectTo: '/Home' });
});

//Controller for index.cshtml
BookStoreApp.controller('indexController', function ($scope, $rootScope, BookStoreAppService) {
    $scope.items = [];
    $scope.Heading = "Home";

    $scope.setHeading = function (newHeading) {

        $scope.Heading = newHeading;

    };


    var ReturnData = BookStoreAppService.getAllPageInfo();

    ReturnData.then(function (pl) {
        $scope.MenuList = pl.data
    }, function (errorPl) {//this is an error call back });

    });



    //This method will add the Items to the cart
    $scope.cartCount = 0;
    $scope.addItemstoCart = function (item, index) {
        var urSet = BookStoreAppService.addItemToCart(item.Id);
        if (item.InStock > 0)
            { $scope.cartCount += 1;}
      
        urSet.then(function (pl) {
            $scope.MenuList = pl.data
            
        }, function (errorPl) {//this is an error call back });


        });


    };



    //This method is to remove the Item from the cart.Each Item inside the Cart can be removed.
    $rootScope.$on('cartRemoved', function (event, data) {
        data.id=$scope.cartCount -= 1;
        var cc = BookStoreAppService.getAllPageInfo();

        cc.then(function (pl) {
            $scope.MenuList = pl.data
        }, function (errorPl) {//this is an error call back });

        });
    });


});



//Controller for About.html 
BookStoreApp.controller('homeController', function ($scope, $rootScope) {
    $scope.Heading = "Home";
});

BookStoreApp.controller('CartlController', function ($scope, $rootScope, BookStoreAppService) {
    $scope.TotalAmount = 0;
    var cartData = BookStoreAppService.getCartData();

    cartData.then(function (pl) {

        $scope.CartList = pl.data
        angular.forEach($scope.CartList, function (value, key) {
            $scope.TotalAmount = parseFloat($scope.TotalAmount) +parseFloat(value.TotalAmount);
        });


    }, function (errorPl) {//this is an error call back });

    });


    $scope.removeFromCart = function (id) {
        $scope.TotalAmount = 0;
        var crtRemove = BookStoreAppService.removeFromCart(id);
        crtRemove.then(function (pl) {
            $scope.CartList = pl.data
            angular.forEach($scope.CartList, function (value, key) {
                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(value.TotalAmount);
            });


            $rootScope.$broadcast('cartRemoved', [id]);

        }, function (errorPl) {//this is an error call back });

        });

    }




});




//Services for methods
BookStoreApp.service("BookStoreAppService", function ($http) {

    this.getAllPageInfo = function () {

        return $http.get("http://localhost:59567/BookstoreApi/Get");
    };

    this.addItemToCart = function (id) {
        return $http.get("http://localhost:59567/BookstoreApi/AddCart/" + id);
    };

    this.getCartData = function (id) {
        return $http.get("http://localhost:59567/BookstoreApi/GetCart");
    };

    this.removeFromCart = function (id) {
        return $http.get("http://localhost:59567/BookstoreApi/RemoveFromCart/" + id);
    };



});


