var app = angular.module('Pais.list.ctrl', [])
       .controller('PaisCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'PaisService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, PaisService, NgTableParams) {
               $scope.Pais = [];
               $scope.Provincia = [];
               

 

               $scope.initMaster = function () {
                   $scope.isLoading = true;
                   PaisService.getinitMaster().then(function (response) {
                       $scope.isLoading = false;
                       $scope.PaisTable = new NgTableParams({ count: 5 }, { counts: [], dataset: response.data.Pais });
                       $scope.ProvinciaTable = new NgTableParams({ count: 5 }, { counts: [], dataset: response.data.Provincia });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }







     

               $scope.CleanPais = function () {
                   $scope.isSave = true;
                   $scope.Pais = {};
               }

               $scope.getinitMaster = function () {
                   PaisService.getinitMaster().then(function (response) {
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
                       $scope.initMaster();
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
                       $scope.initMaster();
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
                       $scope.initMaster();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.Provincia = function () {
                   $scope.Provincia = Provincia.Descripcion
               }

               $scope.CleanProvincia = function () {
                   $scope.isSave = true;
                   $scope.Provincia = {};
               }

               $scope.getProvincia = function () {
                   PaisService.getProvincia().then(function (response) {
                       $scope.ProvinciaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadProvincia = function (row) {
                   $scope.Provincia = angular.copy(row);
               }

               $scope.saveProvincia = function () {
                   PaisService.saveProvincia($scope.Provincia).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Provincia correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initMaster();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editProvincia = function () {
                   PaisService.editProvincia($scope.Provincia).then(function (response) {
                       $scope.message = "Se ha editado el Provincia correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initMaster();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeleteProvincia = function () {
                   PaisService.DeleteProvincia($scope.Provincia.IdProvincia).then(function (response) {
                       $scope.message = "Se ha eliminado el Provincia correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initMaster();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);