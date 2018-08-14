var app = angular.module('Agenda.list.ctrl', [])
       .controller('AgendaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'AgendaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, AgendaService, NgTableParams) {
               $scope.initAgenda = function () {
                   $scope.getAgenda();
               }

               $scope.getAgenda = function () {
                   $scope.isLoading = true;
                   AgendaService.getAgenda().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }

               $scope.CleanAgenda = function () {
                   $scope.isSave = true;
                   $scope.Agenda = {};
               }

               $scope.getAgenda = function () {
                   AgendaService.getAgenda().then(function (response) {
                       $scope.AgendaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadAgenda = function (row) {
                   $scope.Agenda = angular.copy(row);
               }

               $scope.saveAgenda = function () {
                   AgendaService.saveAgenda($scope.Agenda).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Agenda correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initAgenda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editAgenda = function () {
                   AgendaService.editAgenda($scope.Agenda).then(function (response) {
                       $scope.message = "Se ha editado el Agenda correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initAgenda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteAgenda = function () {
                   AgendaService.DeleteAgenda($scope.Agenda.IdAgenda).then(function (response) {
                       $scope.message = "Se ha eliminado el Agenda correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initAgenda();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);