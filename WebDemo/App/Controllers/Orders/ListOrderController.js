app.controller("ListOrderController", ListOrderController);
ListOrderController.$inject = ['$http', '$state','NgTableParams'];

function ListOrderController($http, $state, NgTableParams ) {
    var vm = this;

    vm.model = {
        OrderDetail:[],
    };
    vm.deleteOrder = deleteOrder;
    vm.edit = edit;
    vm.create = create;
    function create() {
        $state.go("app.order");
    }
    function edit(item) {
        $state.go("app.orderID", { Id: item.Id })
    }
    $http({
        method: 'GET',
        url: '/api/Order?search=',
       
    }).then(function successCallBack(response) {
        vm.model = response.data;
        vm.tableParams = new NgTableParams({}, { dataset: vm.model });
    });
    function deleteOrder(item) {
        $http({
            method: 'DELETE',
            url : '/api/Order/' +item.Id,
        }).then(function successCallBack(response) {
            alert("Bạn đã xóa thành công!");
            var index = vm.orderViewModel.indexOf(item);
            vm.model.splice(index, 1);
        }, function errorCallBack() {
            alert("Xóa không thành công ! Thử lại!")
        })
    }


}