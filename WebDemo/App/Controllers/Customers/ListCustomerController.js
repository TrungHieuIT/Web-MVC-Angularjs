app.controller("ListCustomerController", ListCustomerController);
ListCustomerController.$inject = ['$http', '$state','NgTableParams'];

function ListCustomerController($http, $state, NgTableParams) {
    var vm = this;
    vm.Customer = {};
    vm.createCustomer = createCustomer;
    vm.editCustomer = editCustomer;
    vm.deleteCustomer = deleteCustomer;
    vm.searchCustomer = searchCustomer;

    $http({
        method: 'GET',
        url: '/api/Customer?search=',

    }).then(function successCallBack(response) {
        vm.Customer = response.data;
        vm.tableParams = new NgTableParams({}, { dataset: response.data });
    });

    function searchCustomer(search) {
        $http({
            method: 'GET',
            url :'/api/Customer?search='+ search,
        }).then(function successCallBack(response) {
            vm.Customer = response.data;
            vm.tableParams = new NgTableParams({}, { dataset: response.data });
        })
    }
    function createCustomer() {
        $state.go("app.createcustomer");
    }
    function editCustomer(item) {
        $state.go("app.editcustomer", { Id: item.ID });
    }
    function deleteCustomer(item) {
       
        $http({
            method: 'DELETE',
            url :'/api/Customer/' + item.ID,
        }).then(function successCallBack(response) {
            alert("Bạn đã xóa thành công !");
            var index = vm.Customer.indexOf(item);
            vm.Customer.splice(index, 1);
        }, function errorCallBack() {
                alert("Xóa không thành công !");
        })
    }

}