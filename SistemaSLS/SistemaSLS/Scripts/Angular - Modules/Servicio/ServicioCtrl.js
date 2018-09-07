var app = angular.module('Servicio.list.ctrl', [])
       .controller('ServicioCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'ServicioService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, ServicioService, NgTableParams) {
               $scope.initServicio = function () {
                   $scope.getServicio();
                   $scope.getTiposServicios();
               }

               $scope.getServicio = function () {
                   $scope.isLoading = true;
                   ServicioService.getServicio().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
               $scope.getTiposServicios = function () {
                   $scope.isLoading = true;
                   ServicioService.getTiposServicios().then(function (response) {
                       $scope.TiposServicios = angular.copy(response.data);
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
               $scope.getTipoServicio = function (id) {
                   return $filter('filter')($scope.TiposServicios, { 'IdTipoServicio': id }, true)[0].Nombre;
               }
               $scope.CleanServicio = function () {
                   $scope.isSave = true;
                   $scope.Servicio = {};
               }

               $scope.getServicio = function () {
                   ServicioService.getServicio().then(function (response) {
                       $scope.ServicioTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadServicio = function (row) {
                   $scope.Servicio = angular.copy(row);
               }

               $scope.saveServicio = function () {
                   ServicioService.saveServicio($scope.Servicio).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el servicio correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editServicio = function () {
                   ServicioService.editServicio($scope.Servicio).then(function (response) {
                       $scope.message = "Se ha editado el servicio correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteServicio = function () {
                   ServicioService.DeleteServicio($scope.Servicio.IdServicio).then(function (response) {
                       $scope.message = "Se ha eliminado el servicio correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initServicio();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);