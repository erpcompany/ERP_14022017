
var hanghoa = angular.module("hanghoaApp", ['angularUtils.directives.dirPagination']);

hanghoa.controller("hanghoaCtrl", function ($scope, $http) {


    $scope.get_hanghoa = function () {
        $http.get("/api/Api_HanghoaTAHCM/").then(function (response) {
            $scope.hanghoa = response.data;
        });
    };
    $scope.get_hanghoa();

    $scope.add = function () {
        var data_add = {
            MA_HANG_HT: $scope.ma_hang_ht,
            MA_HANG_NHAP: $scope.ma_hang_nhap,
            TEN_HANG: $scope.ten_hang,
            MA_NHOM_HANG: $scope.ma_nhom_hang,
            SERI: $scope.seri,
            DON_VI_TINH: $scope.don_vi_tinh,
            MODEL_DAC_BIET: $scope.model_dac_biet,
            HINH_ANH: $scope.hinh_anh,
            DAC_TINH: $scope.dac_tinh,
            GHI_CHU: $scope.ghi_chu,
            TK_HACH_TOAN_KHO: $scope.tk_hach_toan_kho,
            TK_DOANH_THU: $scope.tk_doanh_thu,
            TK_CHI_PHI: $scope.tk_chi_phi
        }
        $http.post("/api/Api_HanghoaTAHCM/", data_add).then(function (response) {
            $scope.get_hanghoa();
            $scope.ma_hang_ht = "";
            $scope.ma_hang_nhap = "";
            $scope.ten_hang = "";
            $scope.ma_nhom_hang = "";
            $scope.seri = "";
            $scope.don_vi_tinh = "";
            $scope.model_dac_biet = "";
            $scope.hinh_anh = "";
            $scope.dac_tinh = "";
            $scope.ghi_chu = "";
            $scope.tk_hach_toan_kho = "";
            $scope.tk_doanh_thu = "";
            $scope.tk_chi_phi = "";
        });
    };

    $scope.edit = function (item) {
        $scope.item = item;
    };

    $scope.save = function (mahanght) {
        var data_update = {
            MA_HANG_HT: $scope.item.MA_HANG_HT,
            MA_HANG_NHAP: $scope.item.MA_HANG_NHAP,
            TEN_HANG: $scope.item.TEN_HANG,
            MA_NHOM_HANG: $scope.item.MA_NHOM_HANG,
            SERI: $scope.item.SERI,
            DON_VI_TINH: $scope.item.DON_VI_TINH,
            MODEL_DAC_BIET: $scope.item.MODEL_DAC_BIET,
            HINH_ANH: $scope.item.HINH_ANH,
            DAC_TINH: $scope.item.DAC_TINH,
            GHI_CHU: $scope.item.GHI_CHU,
            TK_HACH_TOAN_KHO: $scope.item.TK_HACH_TOAN_KHO,
            TK_DOANH_THU: $scope.item.TK_DOANH_THU,
            TK_CHI_PHI: $scope.item.TK_CHI_PHI
        }
        $http.put("/api/Api_HanghoaTAHCM/" +mahanght, data_update).then(function (response) {
            $scope.get_hanghoa();
            $scope.MA_HANG_NHAP = "";
            $scope.TEN_HANG = "";
            $scope.MA_NHOM_HANG = "";
            $scope.SERI = "";
            $scope.DON_VI_TINH = "";
            $scope.MODEL_DAC_BIET = "";
            $scope.HINH_ANH = "";
            $scope.DAC_TINH = "";
            $scope.GHI_CHU = "";
            $scope.TK_HACH_TOAN_KHO = "";
            $scope.TK_DOANH_THU = "";
            $scope.TK_CHI_PHI = "";
            
        });
    };

    $scope.delete = function (mahang) {
        var data_delete = {
            MA_HANG_HT: mahang
        };
        $http.delete("/api/Api_HanghoaTAHCM/" + mahang, data_delete).then(function (response) {
            $scope.get_hanghoa();
        });
    };
});

