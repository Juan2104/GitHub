var app = angular.module('TipoDictado.list.ctrl', [])
       .controller('TipoDictadoCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'TipoDictadoService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, TipoDictadoService, NgTableParams) {
               $scope.initTipoDictado = function () {
                   $scope.getTipoDictado();
               }

               $scope.getTipoDictado = function () {
                   $scope.isLoading = true;
                   TipoDictadoService.getTipoDictado().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanTipoDictado = function () {
                   $scope.isSave = true;
                   $scope.TipoDictado = {};
               }

               $scope.getTipoDictado = function () {
                   TipoDictadoService.getTipoDictado().then(function (response) {
                       $scope.TipoDictadoTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadTipoDictado = function (row) {
                   $scope.TipoDictado = angular.copy(row);
               }

               $scope.saveTipoDictado = function () {
                   TipoDictadoService.saveTipoDictado($scope.TipoDictado).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el tipo de dictado correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initTipoDictado();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoDictado = function () {
                   TipoDictadoService.editTipoDictado($scope.TipoDictado).then(function (response) {
                       $scope.message = "Se ha editado el tipo de dictado correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoDictado();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteTipoDictado = function () {
                   TipoDictadoService.DeleteTipoDictado($scope.TipoDictado.IdTipoDictado).then(function (response) {
                       $scope.message = "Se ha eliminado el tipo de dictado correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoDictado();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);