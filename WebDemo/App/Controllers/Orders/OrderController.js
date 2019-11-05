app.controller("OrderController", OrderController);
OrderController.$inject = ['$http', '$stateParams','$state'];

function OrderController($http, $stateParams ,$state ) {
    var vm = this;

    vm.Product = {};
    vm.Customer = {};
    vm.item = {};

    vm.model = {
        DateCreated: new Date(),
        DateOrder: new Date(Date.now()),
        OrderDetail: [],

    }
    vm.searchProduct = searchProduct;
    vm.clickBuy = clickBuy;
    vm.saveCustomer = saveCustomer;

    vm.getCost = getCost;
    vm.clickRemove = clickRemove;
    vm.getTotal = getTotal;
    vm.Id = $stateParams.Id;
    vm.getCustomerId = getCustomerId;
    vm.editCustomer = true;
    vm.saveOrder = saveOrder;
    vm.cancel = cancel;
    vm.str = new Date();
    vm.back = back;
    vm.updateOrder = updateOrder; 

   
    function back() {
        $state.go("app.listorder");
    }
    function getCustomerId() {
        $http({
            method: 'GET',
            url: '/api/Customer/' + vm.Id,
        }).then(function successCallBack(response) {
            debugger;
            vm.Customer = response.data;
        }, function errorCallBack() {
            alert("Khong tìm được dữ liệu !");
        });
    }


    $http({
        method: 'GET',
        url: '/api/Products?search=',
    }).then(function successCallBack(response) {
        vm.Product = response.data;
    });

    $http({
        method: 'GET',
        url: 'api/Customer?search=',
    }).then(function successCallBack(response) {
       
        vm.Customer = response.data;
    }, function errorcallback(response) {
        alert("Không load được dữ liệu !");
    });

    function clickBuy(item) {
        if (!vm.model.OrderDetail) {
            vm.model.OrderDetail = [];
        }

        var found = vm.model.OrderDetail.find(x => x.ProductID == item.Id);

        if (!found) {
            vm.model.OrderDetail.push(
                {
                    ProductID: item.Id,
                    ProductName: item.Name,
                    Price: item.Price,
                    Quantity: 1,
                });
        } else {
            found.Quantity++;
        }
        vm.getTotal();
    };
    function getCost(item) {
        return item.Quantity * item.Price;
    }
    function searchProduct(search) {
        $http({
            method: 'GET',
            url: '/api/Products?search=' + search,
        }).then(function (response) {
            vm.Product = response.data;
        });
    }
    function clickRemove(item) {
        var index = vm.model.OrderDetail.indexOf(item);
        vm.model.OrderDetail.splice(index, 1);
    }
    
    function getTotal() {
       var sum = 0;
        for (var i = 0; i < vm.model.OrderDetail.length; i++) {
            sum = sum + getCost(vm.model.OrderDetail[i]);
        }

        vm.model.TotalMoney = sum;
       
    }

   
    var modelCustomer = {};
    vm.modelCustomer = modelCustomer;

    function saveCustomer() {
        $http({
            method: 'POST',
            url: '/api/Customer/',
            data: vm.item,
        }).then(function successCallBack(response) {
            vm.Customer.push(response.data);
            alert("Thêm thành công !");
        }, function errorCallBack() {
            alert("Thêm thất bại !");
        });
        vm.item = null;
    };

    
    function saveOrder() {
        if (vm.model.CustomerID == null ) {
            alert("Thiếu thông tin khách hàng !")
        }
        else {
            if (vm.Id) {
                vm.model.DateOrder = vm.str;
                $http({
                    method: 'PUT',
                    url: '/api/Order/' + vm.model.Id,
                    data : vm.model
                }).then(function successCallBack(response) {
                    alert("Bạn update thành công !");
                }, function errorCallBack() {
                        alert("Update thất bại !");
                })
            }
            else {
                vm.model.DateOrder = vm.str;
                $http({
                    method: 'POST',
                    url: '/api/Order',
                    data: vm.model,
                }).then(function successCallBack(response) {
                    alert("Save thành công!");
                })
            }
          
        }
    }
   
    vm.getOrderId = getOrderId;
    if (vm.Id) {
        
        getOrderId();
        
    }

    function getOrderId() {
        
        $http({
            method: 'GET',
            url: '/api/Order/' + vm.Id,
        }).then(function successCallBack(response) {
            vm.model = response.data;
            vm.str = vm.model.DateOrder;
        }, function errorCallBack() {
            alert("Không load được dữ liệu bảng Order");
        });
    }
    
    
    function cancel() {
        vm.model.OrderDetail = null;
        vm.model.TotalMoney = 0;
    }

    function updateOrder() {
        vm.model.DateOrder = vm.str;
        $http({
            method: 'PUT',
            url: '/api/Order/' + vm.model.Id,
            data :vm.model
        }).then(function successCallBack(response) {
            alert("Update thành công !");
        }, function errorCallBack() {
                alert("Update thất bại !");
        })
    }
     
   
};

