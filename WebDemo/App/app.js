var app = angular.module("app", ['ui.router', 'kendo.directives', 'ngTable', 'ui.bootstrap', ]);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/app/dashboard');
    $stateProvider
        .state('app', {
            url: '/app',
            abstract: true,
            template:"<div ui-view></div>",
            templateUrl: '/Home/Index',
        })  
        .state('app.dashboard', {
            url: '/dashboard',
            templateUrl: '/Home/Dashboard',
        })
        .state('app.allproduct', {
            url: '/allproduct',
            templateUrl: '/Product/AllProduct',   
        })
        .state('app.createproduct', {
            url: '/createproduct',
            templateUrl:'/Product/CreateProduct',
        })
        .state('app.editproduct', {
            url: '/editproduct/:Id',
            templateUrl: '/Product/EditProduct',
        })
        .state('app.listcustomer', {
            url: '/listcustomer',
            templateUrl: 'Customer/ListCustomer',
        })
        .state('app.editcustomer', {
            url: '/editcustomer/:Id',
            templateUrl:'/Customer/EditCustomer',
        })
        .state('app.createcustomer', {
            url: '/createcustomer',
            templateUrl:'/Customer/CreateCustomer',
        })
        .state('app.listorder', {
            url: '/listorder',
            templateUrl: '/Order/ListOrder',
        })
        .state('app.order', {
            url: '/order',
            templateUrl: '/Order/Order',
        })
        .state('app.orderID', {
            url: '/order/:Id',
            templateUrl: '/Order/Order',
        })
       
        //.state('app.editorder', {
        //    url: '/editorder/:Id',
        //    templateUrl:'/Order/EditOrder',
        //})
      
});

app.controller('appCtrl', ['$scope', function ($scope) {
}]);