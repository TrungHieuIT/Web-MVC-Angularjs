app.controller("EditProductController", EditProductController);
EditProductController.$inject = ['$http', '$stateParams','$state'];

function EditProductController($http, $stateParams ,$state) {
    var vm = this;
    vm.Id = $stateParams.Id;
    vm.getProdutId = getProductId;
    vm.updateProduct = updateProduct;
    vm.product = {}
    vm.listProduct = listProduct;
    vm.createProduct = createProduct;

    if (vm.Id) {
        getProductId();
    }
    function getProductId () {
        $http({
            method: 'GET',
            url :'/api/Products/' + vm.Id,
        }).then(function successCallBack(response) {
            vm.product = response.data;
        }, function errorCallBack() {
            alert("Không tìm được dữ liệu bảng Product  !");
        });
    }

    function updateProduct() {
        $http({
            method: 'PUT',
            url: '/api/Products/' + vm.product.Id,
            data: vm.product,
        }).then(function successCallBack(response) {
            alert("Bạn đã update thành công !");
        }, function errorCallBack() {
                alert("Update thất bại !");
        });
    }
    function listProduct() {
        $state.go("app.allproduct");
    }
    function createProduct() {
        $state.go("app.createproduct");
    }
  
}