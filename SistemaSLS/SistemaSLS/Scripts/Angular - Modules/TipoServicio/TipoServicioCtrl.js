var app = angular.module('TipoServicio.list.ctrl', [])
       .controller('TipoServicioCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'TipoServicioService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, TipoServicioService, NgTableParams) {
               $scope.initTipoServicio = function () {
                   $scope.getTipoServicio();
               }

               $scope.getTipoServicio = function () {
                   $scope.isLoading = true;
                   TipoServicioService.getTipoServicio().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanTipoServicio = function () {
                   $scope.isSave = true;
                   $scope.TipoServicio = {};
               }

               $scope.getTipoServicio = function () {
                   TipoServicioService.getTipoServicio().then(function (response) {
                       $scope.TipoServicioTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadTipoServicio = function (row) {
                   $scope.TipoServicio = angular.copy(row);
               }

               $scope.saveTipoServicio = function () {
                   TipoServicioService.saveTipoServicio($scope.TipoServicio).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el tipo de servicio correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initTipoServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoServicio = function () {
                   TipoServicioService.editTipoServicio($scope.TipoServicio).then(function (response) {
                       $scope.message = "Se ha editado el tipo de servicio correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteTipoServicio = function () {
                   TipoServicioService.DeleteTipoServicio($scope.TipoServicio.IdTipoServicio).then(function (response) {
                       $scope.message = "Se ha eliminado el tipo de servicio correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);