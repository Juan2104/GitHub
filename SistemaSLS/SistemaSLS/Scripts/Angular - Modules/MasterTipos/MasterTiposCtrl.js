var app = angular.module('MasterTipos.list.ctrl', [])
       .controller('MasterTiposCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'MasterTiposService',
           '$window',
           '$http',
           '$timeout',
           'NgTableParams',
           'Upload',
           function ($scope, $filter, $routeParams, $location, MasterTiposService, $window, $http, $timeout, NgTableParams, Upload) {
               $scope.TipoMoneda = [];
               $scope.TipoPersona = [];
           
               $scope.initMasterTipos = function () {
                   $scope.isLoading = true;
                   MasterTiposService.getInitMasterTipos().then(function (response) {
                       $scope.isLoading = false;
                       $scope.userTable = new NgTableParams({ count: 5 }, { counts: [], dataset: response.data.TipoMoneda });
                       $scope.printerTable = new NgTableParams({ count: 5 }, { counts: [], dataset: response.data.printers });
                       $scope.TipoMoneda = response.data.TipoMoneda;
                       $scope.TipoPersona = response.data.TipoPersona;                       
                       angular.forEach(response.data.cases, function (key) {
                           var LtlWeight = "" + key.LtlWeight;
                           var LtlWidth = "" + key.LtlWidth;
                           var LtlHeight = "" + key.LtlHeight;
                           var LtlLength = "" + key.LtlLength;
                           key.LtlWeight = LtlWeight.replace(".", ",");
                           key.LtlWidth = LtlWidth.replace(".", ",");
                           key.LtlHeight = LtlHeight.replace(".", ",");
                           key.LtlLength = LtlLength.replace(".", ",");
                       });                      
                   })

                       $scope.loadTipoMoneda = function (row) {
                           $scope.TipoMoneda = angular.copy(row);
                       }

                       $scope.loadTipoPersona = function (row) {
                           $scope.TipoPersona = angular.copy(row);
                       }

             

                       $scope.saveTipoMoneda = function () {
                           if ($scope.TipoMoneda.IdTipoMoneda != undefined) {
                               MasterTiposService.editTipoMoneda($scope.TipoMoneda).then(function (response) {
                                   $scope.initMasterTipos();
                               }).catch(function (result) {
                               });
                           } else {
                               MasterTiposService.saveTipoMoneda($scope.TipoMoneda).then(function (response) {
                                   $scope.initMasterTipos();
                               }).catch(function (result) {
                               });
                           }
                       }

                       $scope.saveTipoPersona = function () {
                           if ($scope.TipoPersona.IdTipoPersona != undefined) {
                               MasterTiposService.editTipoPersona($scope.TipoPersona).then(function (response) {
                                   $scope.initMasterTipos();
                               }).catch(function (result) {
                               });
                           } else {
                               MasterTiposService.saveTipoPersona($scope.TipoPersona).then(function (response) {
                                   $scope.initMasterTipos();
                               }).catch(function (result) {
                               });
                           }
                       }

              

                       $scope.getTipoMoneda = function (IdTipoMoneda) {
                           return $filter('filter')($scope.TipoMoneda, { 'IdTipoMoneda': IdTipoMoneda }, true)[0].Name;
                       }

                       $scope.getTipoPersona = function (IdTipoPersona) {
                           return $filter('filter')($scope.TipoPersona, { 'TipoPersona': IdTipoPersona }, true)[0].Name;
                       }


                       $scope.deleteUser = function () {
                           MasterTiposService.deleteUser($scope.user.UserId).then(function (response) {
                               $scope.initMasterTipos();
                           }).catch(function (result) {
                           });
                       }

                       $scope.deleteCustomer = function () {
                           MasterTiposService.deleteCustomer($scope.customer.CustomerId).then(function (response) {
                               $scope.initMasterTipos();
                           }).catch(function (result) {
                           });   
                       }
           }]);