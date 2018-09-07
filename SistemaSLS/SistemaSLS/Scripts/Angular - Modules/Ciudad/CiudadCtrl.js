var app = angular.module('Ciudad.list.ctrl', [])
       .controller('CiudadCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'CiudadService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, CiudadService, NgTableParams) {
               $scope.initCiudad = function () {
                   $scope.getCiudad();
                   $scope.getProvincia();
               }

               $scope.getCiudad = function () {
                   $scope.isLoading = true;
                   CiudadService.getCiudad().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.getProvincia = function () {
                   $scope.isLoading = true;
                   CiudadService.getProvincia().then(function (response) {
                       $scope.Provincias = angular.copy(response.data);
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
               $scope.CleanCiudad = function () {
                   $scope.isSave = true;
                   $scope.Ciudad = {};
               }

               $scope.getCiudad = function () {
                   CiudadService.getCiudad().then(function (response) {
                       $scope.CiudadTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadCiudad = function (row) {
                   $scope.Ciudad = angular.copy(row);
               }

               $scope.saveCiudad = function () {
                   CiudadService.saveCiudad($scope.Ciudad).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Ciudad correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initCiudad();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editCiudad = function () {
                   CiudadService.editCiudad($scope.Ciudad).then(function (response) {
                       $scope.message = "Se ha editado el Ciudad correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initCiudad();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteCiudad = function () {
                   CiudadService.DeleteCiudad($scope.Ciudad.IdCiudad).then(function (response) {
                       $scope.message = "Se ha eliminado el Ciudad correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initCiudad();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);