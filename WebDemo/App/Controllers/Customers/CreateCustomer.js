app.controller("CreateCustomerController", CreateCustomerController);
CreateCustomerController.$inject('$http');

function CreateCustomerController($http) {
    var vm = this; 
    vm.createCustomer = createCustomer;
    vm.item = {};
    function createCustomer() {
        $http({
            method: 'POST',
            url: '/api/Customer',
            data : vm.item,
        }).then(function successCallBack(response) {
            alert("Thêm thành công !");
        }, function errorCallBack() {
                alert("Thêm thất bại !");
        });
    }

}