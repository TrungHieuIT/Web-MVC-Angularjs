app.controller("ProductController", ProductController);
ProductController.$inject = ['$http', 'NgTableParams','$state' ];

function ProductController($http, NgTableParams, $state ) {
    
    var vm = this;
    vm.deleteProduct = deleteProduct;
    vm.searchProduct = searchProduct; 
    vm.ProductViewModel = [{}];
    vm.createProduct = createProduct;
    vm.editProduct = editProduct;
   
    
   
    $http({
        method: 'GET',
        url: '/api/Products?search=',
    }).then(function successCallBack(response) {
        vm.ProductViewModel = response.data;
        vm.tableParams = new NgTableParams({}, { dataset: vm.ProductViewModel });
    });

   

    function searchProduct (search) {
        $http({
            method: 'GET',
            url: '/api/Products?search=' + search,
        }).then(function (response) {
            vm.ProductViewModel = response.data;
            vm.tableParams = new NgTableParams({}, { dataset: vm.ProductViewModel });
        });
        
    }
  

    function createProduct() {
       
        $state.go("app.createproduct");
    }
    function editProduct(item) {
        $state.go("app.editproduct", { Id: item.Id });
    }
    function deleteProduct(item) {
        $http({
            method: 'DELETE',
            url : '/api/Products/' + item.Id, 
        }).then(function successCallBack(response) {
            
            alert("Bạn đã xóa thành công !");
            var index = vm.ProductViewModel.indexOf(item);
            vm.ProductViewModel.splice(index, 1);
        }, function errorCallBack() {
            alert("Xoá không thành công !")
        })
    }

  
}

    