var app = angular.module('Pais.list.ctrl', [])
       .controller('PaisCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'PaisService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, PaisService, NgTableParams) {
               $scope.initPais = function () {
                   $scope.getPais();
               }

               $scope.getPais = function () {
                   $scope.isLoading = true;
                   PaisService.getPais().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanPais = function () {
                   $scope.isSave = true;
                   $scope.Pais = {};
               }

               $scope.getPais = function () {
                   PaisService.getPais().then(function (response) {
                       $scope.PaisTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadPais = function (row) {
                   $scope.Pais = angular.copy(row);
               }

               $scope.savePais = function () {
                   PaisService.savePais($scope.Pais).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el pais correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initPais();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editPais = function () {
                   PaisService.editPais($scope.Pais).then(function (response) {
                       $scope.message = "Se ha editado el pais correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initPais();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeletePais = function () {
                   PaisService.DeletePais($scope.Pais.IdPais).then(function (response) {
                       $scope.message = "Se ha eliminado el pais correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initPais();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);