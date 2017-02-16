/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


var app = angular.module('userApp', ['angularUtils.directives.dirPagination']);
app.controller('userCtrl', userCtrl);

//function nhom hang
app.controller('nhanvienCtrl', nhanvienCtrl);
function nhanvienCtrl($scope, $http) {


    //-------------------------------------------------------------

    $scope.get_nhanvien = function (id) {
        $http.get("/api/Api_NhanvienTAHCM/"+id).then(function (response) {
            $scope.nhanvien = response.data;
        });
    }
}

//function hang hoa
function userCtrl($scope, $http) {

    $scope.get_user = function () {
        $http.get("/api/Api_NguoidungTAHCM")
                .then(function (response) {
                    $scope.danhsachuser = response.data;
                    
                });

    }
    $scope.get_user();
    //-------------------------------------------------------------
    $scope.get_user = function (username) {
        $http.get("/api/Api_NguoidungTAHCM")
                .then(function (response) {
                    $scope.danhsachuser = response.data;

                });

    }


    //Insert data

    $scope.add = function () {
        
        var data_add = {
            USERNAME: $scope.username,
            PASSWORD: $scope.password,
            HO_VA_TEN: $scope.hovaten,
            SDT: $scope.sdt,
            EMAIL: $scope.email,
            IS_ADMIN: $scope.admin,
            ALLOWED: $scope.allowed,
            MA_CONG_TY: "TAHCM"
        }
        $http.post("/api/Api_NguoidungTAHCM", data_add).then(function (response) {
            $scope.get_user();
            var nhanvien_add = {
                USERNAME: $scope.username,
                GIOI_TINH: $scope.gioitinh,
                NGAY_SINH: $scope.ngaysinh,
                QUE_QUAN: $scope.quequan,
                TRINH_DO_HOC_VAN: $scope.trinhdohocvan,
                MA_PHONG_BAN: $scope.maphongban
            }
            $http.post("/api/Api_NhanvienTAHCM", nhanvien_add).then(function (response) {
                $scope.get_user();
            });
        });

        

       
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (user) {
        var data_update = {
            ID : user,
            USERNAME: $scope.item.USERNAME,
            PASSWORD: $scope.item.PASSWORD,
            HO_VA_TEN: $scope.item.HO_VA_TEN,
            SDT: $scope.item.SDT,
            EMAIL: $scope.item.EMAIL,
            IS_ADMIN: $scope.item.IS_ADMIN,
            ALLOWED: $scope.item.ALLOWED,
            MA_CONG_TY: "TAHCM",
        }
        $http.put("/api/Api_NguoidungTAHCM/" + user, data_update).then(function (response) {
            $scope.get_user();

        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (user) {

        var data_delete = {
            ID: user,
        }


        $http.delete("/api/Api_NguoidungTAHCM/" + user, data_delete)
            .then(function (response) {
                $scope.get_user();
            });
    }

}
