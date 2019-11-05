app.controller("EditCustomerController", EditCustomerController);
EditCustomerController.$inject = ['$http', '$state', '$stateParams'];

function EditCustomerController($http, $state, $stateParams) {
    var vm = this;
    vm.saveCustomer = saveCustomer;
    vm.back = back;
    vm.Customer = {};
    vm.Id = $stateParams.Id;
    vm.getCustomerById = getCustomerById;
    if (vm.Id) {
       
        getCustomerById();
    }
    function getCustomerById() {
        $http({
            method: 'GET',
            url: '/api/Customer/' + vm.Id,
        }).then(function successCallBack(response) {
           
            vm.Customer = response.data;
        }, function errorCallBack() {
            alert("Không load được ID này!");
        });
    }
    function saveCustomer() {
        $http({
            method: 'PUT',
            url: '/api/Customer/' + vm.Customer.Id,
            data: vm.Customer,
        }).then(function successCallBack(response) {
            alert("Bạn đã update thành công !");
        }, function errorCallBack() {
            alert("Update thất bại ! Thử lại !");
        });
    }
    function back() {
        $state.go("app.listcustomer");
    }
}