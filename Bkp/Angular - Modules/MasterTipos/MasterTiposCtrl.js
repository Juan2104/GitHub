var app = angular.module('MasterTipos.list.ctrl', [])
       .controller('MasterTiposCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'MasterTiposService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, MasterTiposService, NgTableParams) {
               $scope.TipoMoneda = [];
          
               $scope.InitMasterTipos = function () {
                   $scope.isLoading = true;
                   MasterTiposService.getInitMasterTipos().then(function (response) {
                       $scope.isLoading = false;
                       $scope.TipoMonedaTable = new NgTableParams({ count: 5 }, { counts: [], dataset: response.data.TipoMoneda });
                   }).catch(function (result) {                       
                   });
               }

               $scope.CleanTipoMoneda = function () {
                   $scope.isSave = true;
                   $scope.TipoMoneda = {};
               }

               $scope.InitMasterTipos = function () {
                   MasterTiposService.InitMasterTipos().then(function (response) {
                       $scope.TipoMonedaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadTipoMoneda = function (row) {
                   $scope.TipoMoneda = angular.copy(row);
               }

               $scope.saveTipoMoneda = function () {
                   MasterTiposService.saveTipoMoneda($scope.TipoMoneda).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el tipo de persona correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initMasterTipos();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoMoneda = function () {
                   MasterTiposService.editTipoMoneda($scope.TipoMoneda).then(function (response) {
                       $scope.message = "Se ha editado el tipo de persona correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initMasterTipos();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteTipoMoneda = function () {
                   MasterTiposService.DeleteTipoMoneda($scope.TipoMoneda.IdTipoMoneda).then(function (response) {
                       $scope.message = "Se ha eliminado la empresad correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initMasterTipos();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);