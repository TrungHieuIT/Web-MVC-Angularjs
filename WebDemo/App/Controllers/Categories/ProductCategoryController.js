app.controller("ProductCategoryController", ['$scope', '$http', function ($scope, $http) {
    $scope.submit = true;
    $scope.update = false;
    $scope.cancel = false;

    //GET: api/ProductCategories

    $http({
        method: 'GET',
        url: 'api/ProductCategories',
    }).then(function successCallBack(response) {
        $scope.ProductCategory = response.data;
    }, function errorcallback(response) {
        alert("Không load được dữ liệu bảng Product Category !");
    });

    //POST: api/ProductCategories
    $scope.createProductCategory = function () {
        $http({
            method: 'POST',
            url: 'api/ProductCategories',
            data: $scope.item,
        }).then(function successCallBack(response) {

            $scope.ProductCategory.push(response.data);
            alert("Thêm thành công !!");
        }, function errorCallBack(response) {
            alert("Không thêm được dữ liệu !");
        });
    };

    // PUT: api/ProductCategories/5
    $scope.updateProductCategory = function () {
        $http({
            method: 'PUT',
            url: 'api/ProductCategories/' + $scope.item.ID,
            data: $scope.item,
        }).then(function successCallBack(response) {
            alert("Bạn đã update thành công !");
        }, function errorCallBack(response) {
            alert("Update thất Bại");
        });
    };

    //DELETE: api/ProductCategories/5

    $scope.deleteProductCategory = function (item) {
        $http({
            method: 'DELETE',
            url: 'api/ProductCategories/' + item.ID
        }).then(function successCallBack(response) {
            alert("Bạn đã xóa thành công !");
            var index = $scope.ProductCategory.indexOf(item);
            $scope.ProductCategory.splice(index, 1);
        }, function errorCallBack(response) {
            alert("Không xóa được !");
        });
    };

    $scope.editProductCategory = function (item) {
        $scope.item = item;
        $scope.submit = false;
        $scope.update = true;
        $scope.cancel = true;
    };
    $scope.cancelUpdate = function () {
        $scope.productCategory = null;
        $scope.submit = true;
        $scope.update = false;
        $scope.cancel = false;
    };
}]);