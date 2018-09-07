var app = angular.module('Provincia.list.ctrl', [])
       .controller('ProvinciaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'ProvinciaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, ProvinciaService, NgTableParams) {
               $scope.initProvincia = function () {
                   $scope.getProvincia();
                   $scope.getPaises();
               }

               $scope.getProvincia = function () {
                   $scope.isLoading = true;
                   ProvinciaService.getProvincia().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.getPaises = function () {
                   $scope.isLoading = true;
                   ProvinciaService.getPaises().then(function (response) {
                       $scope.Paises = angular.copy(response.data);
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

     
               $scope.CleanProvincia = function () {
                   $scope.isSave = true;
                   $scope.Provincia = {};
               }

               $scope.getProvincia = function () {
                   ProvinciaService.getProvincia().then(function (response) {
                       $scope.ProvinciaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadProvincia = function (row) {
                   $scope.Provincia = angular.copy(row);
               }

               $scope.saveProvincia = function () {
                   ProvinciaService.saveProvincia($scope.Provincia).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Provincia correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initProvincia();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editProvincia = function () {
                   ProvinciaService.editProvincia($scope.Provincia).then(function (response) {
                       $scope.message = "Se ha editado el Provincia correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initProvincia();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteProvincia = function () {
                   ProvinciaService.DeleteProvincia($scope.Provincia.IdProvincia).then(function (response) {
                       $scope.message = "Se ha eliminado el Provincia correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initProvincia();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);