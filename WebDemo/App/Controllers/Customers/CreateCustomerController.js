app.controller("CreateCustomerController", CreateCustomerController);
CreateCustomerController.$inject = ['$http' , '$state'];

function CreateCustomerController($http , $state) {
    var vm = this;
   
    vm.item = {};
    vm.addCustomer = addCustomer;
    vm.back = back;
    vm.searchCustomer = searchCustomer;
    function back() {
        $state.go("app.listcustomer");
    }
    function addCustomer() {
        $http({
            method: 'POST',
            url: '/api/Customer/',
            data : vm.item,
        }).then(function successCallBack(response) {
            alert("Thêm thành công !");
        }, function errorCallBack() {
                alert("Thêm thất bại !");
        })
        vm.item = null;
    }
    function searchCustomer() {
        $http({
            method: 'GET',
            url: '/api/Customer?search=' + search,
        }).then(function successCallBack(response) {
            vm.item = response.data;   
        }, function errorCallBack() {
            alert("Thêm thất bại !");
        })

    }
  
}