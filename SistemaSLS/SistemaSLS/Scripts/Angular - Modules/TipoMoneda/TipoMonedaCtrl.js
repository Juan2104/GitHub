var app = angular.module('TipoMoneda.list.ctrl', [])
       .controller('TipoMonedaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'TipoMonedaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, TipoMonedaService, NgTableParams) {
               $scope.initTipoMoneda = function () {
                   $scope.getTipoMoneda();
               }

               $scope.getTipoMoneda = function () {
                   $scope.isLoading = true;
                   TipoMonedaService.getTipoMoneda().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanTipoMoneda = function () {
                   $scope.isSave = true;
                   $scope.TipoMoneda = {};
               }

               $scope.getTipoMoneda = function () {
                   TipoMonedaService.getTipoMoneda().then(function (response) {
                       $scope.TipoMonedaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadTipoMoneda = function (row) {
                   $scope.TipoMoneda = angular.copy(row);
               }

               $scope.saveTipoMoneda = function () {
                   TipoMonedaService.saveTipoMoneda($scope.TipoMoneda).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el tipo de moneda correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initTipoMoneda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoMoneda = function () {
                   TipoMonedaService.editTipoMoneda($scope.TipoMoneda).then(function (response) {
                       $scope.message = "Se ha editado el tipo de moneda correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoMoneda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteTipoMoneda = function () {
                   TipoMonedaService.DeleteTipoMoneda($scope.TipoMoneda.IdTipoMoneda).then(function (response) {
                       $scope.message = "Se ha eliminado el tipo de moneda correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoMoneda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);