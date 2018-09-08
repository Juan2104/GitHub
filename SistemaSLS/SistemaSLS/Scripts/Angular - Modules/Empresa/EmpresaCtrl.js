var app = angular.module('Empresa.list.ctrl', [])
       .controller('EmpresaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'EmpresaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, EmpresaService, NgTableParams) {
               $scope.initEmpresa = function () {
                   $scope.getEmpresa();
                   $scope.getPaises();
               }

               $scope.getEmpresa = function () {
                   $scope.isLoading = true;
                   EmpresaService.getEmpresa().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.getPaises = function () {
                   $scope.isLoading = true;
                   EmpresaService.getPaises().then(function (response) {
                       $scope.Paises = angular.copy(response.data);
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
               $scope.getPais = function (id) {
                   return $filter('filter')($scope.Paises, { 'IdPais': id }, true)[0].Descripcion;
               }

               $scope.CleanEmpresa = function () {
                   $scope.isSave = true;
                   $scope.Empresa = {};
               }

               $scope.getEmpresa = function () {
                   EmpresaService.getEmpresa().then(function (response) {
                       $scope.EmpresaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadEmpresa = function (row) {
                   $scope.Empresa = angular.copy(row);
               }

               $scope.saveEmpresa = function () {
                   EmpresaService.saveEmpresa($scope.Empresa).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Empresa correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initEmpresa();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editEmpresa = function () {
                   EmpresaService.editEmpresa($scope.Empresa).then(function (response) {
                       $scope.message = "Se ha editado el Empresa correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initEmpresa();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteEmpresa = function () {
                   EmpresaService.DeleteEmpresa($scope.Empresa.IdEmpresa).then(function (response) {
                       $scope.message = "Se ha eliminado el Empresa correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initEmpresa();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);