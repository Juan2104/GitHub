var app = angular.module('TipoPersona.list.ctrl', [])
       .controller('TipoPersonaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'TipoPersonaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, TipoPersonaService, NgTableParams) {
               $scope.initTipoPersona = function () {
                   $scope.getTipoPersona();
               }

               $scope.getTipoPersona = function () {
                   $scope.isLoading = true;
                   TipoPersonaService.getTipoPersona().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;                       
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanTipoPersona = function () {
                   $scope.isSave = true;
                   $scope.TipoPersona = {};
               }

               $scope.getTipoPersona = function () {
                   TipoPersonaService.getTipoPersona().then(function (response) {
                       $scope.TipoPersonaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadTipoPersona = function (row) {
                   $scope.TipoPersona = angular.copy(row);
               }

               $scope.saveTipoPersona = function () {
                   TipoPersonaService.saveTipoPersona($scope.TipoPersona).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el tipo de persona correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initTipoPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoPersona = function () {
                   TipoPersonaService.editTipoPersona($scope.TipoPersona).then(function (response) {
                       $scope.message = "Se ha editado el tipo de persona correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteTipoPersona = function () {
                   TipoPersonaService.DeleteTipoPersona($scope.TipoPersona.IdTipoPersona).then(function (response) {
                       $scope.message = "Se ha eliminado el tipo de persona correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);