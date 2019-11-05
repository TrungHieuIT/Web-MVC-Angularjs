app.controller("CreateProductController", CreateProductController);

CreateProductController.$inject = ['$http','$state'];

function CreateProductController($http ,$state) {
    var vm = this;
    vm.reset = reset;
  
    vm.createProduct = createProduct;
    vm.listProduct = listProduct;
    vm.item = {};
    function createProduct () {
        $http({
            method: 'POST',
            url: '/api/Products/',
            data : vm.item,
        }).then(function successCallBack(response) {
           
            alert("Thêm thành công !");
        }, function errorCallBack() {
                alert("Thêm thất bại !");
        });
    }
    function reset () {
        vm.item = null;
       
    }
    function listProduct() {
        $state.go("app.allproduct");
    }
} 
