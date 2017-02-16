


var app = angular.module('nguoidungApp', ['angularUtils.directives.dirPagination']);
app.controller('nguoidungCtrl', nguoidungCtrl);
//function người dùng

//function người dùng
function nguoidungCtrl($scope, $http)
{
    // lấy dữ liệu từ server(nhóm hàng)
    $scope.get_nguoidung = function () {
        $http.get("/api/Api_NguoidungDN/")
                .then(function (response) {
                    $scope.nguoidung = response.data;
                });

    }
    $scope.get_nguoidung();
    //-------------------------------------------------------------

    // lấy dữ liệu từ server(nhân viên)
    $scope.get_nhanvien = function () {
        $http.get("/api/Api_NhanvienDN/")
                .then(function (response) {
                    $scope.nhanvien = response.data;
                });

    }

    // init dữ liệu
    $scope.get_nhanvien();
    //-------------------------------------------------------------



    //Insert data

    $scope.add = function () {
        var data_add = {
            ID: $scope.id,
            USERNAME: $scope.username,
            PASSWORD: $scope.password,
            HO_VA_TEN: $scope.hovaten,
            SDT: $scope.sdt,
            EMAIL: $scope.email,
            AVATAR: $scope.avatar,
            IS_ADMIN: $scope.isadmin,
            ALLOWED: $scope.allowed,
            MA_CONG_TY: $scope.macongty
        }
        $http.post("/api/Api_NguoidungDN/", data_add).then(function (response) {
            $scope.get_nguoidung();

        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (id) {
        var data_update = {
            ID: $scope.item.ID,
            USERNAME: $scope.item.USERNAME,
            PASSWORD: $scope.item.PASSWORD,
            HO_VA_TEN: $scope.item.HO_VA_TEN,
            SDT: $scope.item.SDT,
            EMAIL: $scope.item.EMAIL,
            AVATAR: $scope.item.AVATAR,
            IS_ADMIN: $scope.item.IS_ADMIN,
            ALLOWED: $scope.item.ALLOWED,
            MA_CONG_TY: $scope.item.MA_CONG_TY

        }
        $http.put("/api/Api_NguoidungDN/" + id, data_update).then(function (response) {
            $scope.get_nguoidung();
            
        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (id) {

        var data_delete = {
            ID: id
        }


        $http.delete("/api/Api_NguoidungDN/" + id, data_delete)
            .then(function (response) {
                $scope.get_nguoidung();
            });
    }

}

