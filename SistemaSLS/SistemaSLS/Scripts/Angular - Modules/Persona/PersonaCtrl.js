var app = angular.module('Persona.list.ctrl', [])
       .controller('PersonaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'PersonaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, PersonaService, NgTableParams) {
               $scope.initPersona = function () {
                   $scope.getPersona();
                   $scope.getPaises();
                   $scope.getTiposPersonas();
                   $scope.getEmpresas();
               }

               $scope.getPersona = function () {
                   $scope.isLoading = true;
                   PersonaService.getPersona().then(function (response) {
                       $scope.dataToFilter = angular.copy(response.data);
                       $scope.Tipo = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                       $scope.isLoading = false;
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
               $scope.getPaises = function () {
                   $scope.isLoading = true;
                   PersonaService.getPaises().then(function (response) {
                       $scope.Paises = angular.copy(response.data);
                   }).catch(function (result) {
                       $scope.isLoading = false;
                   });
               }
                 $scope.getPais = function (id) {
                   return $filter('filter')($scope.Paises, { 'IdPais': id }, true)[0].Descripcion;
                 }

                 $scope.getTiposPersonas = function () {
                     $scope.isLoading = true;
                     PersonaService.getTiposPersonas().then(function (response) {
                         $scope.TiposPersonas = angular.copy(response.data);
                     }).catch(function (result) {
                         $scope.isLoading = false;
                     });
                 }

                 $scope.getTipoPersona = function (id) {
                     return $filter('filter')($scope.TiposPersonas, { 'IdTipoPersona': id }, true)[0].descripcion;
                 }
                 $scope.getEmpresas = function () {
                     $scope.isLoading = true;
                     PersonaService.getEmpresas().then(function (response) {
                         $scope.Empresas = angular.copy(response.data);
                     }).catch(function (result) {
                         $scope.isLoading = false;
                     });
                 }
                 $scope.getEmpresa = function (id) {
                     return $filter('filter')($scope.Empresas, { 'IdEmpresa': id }, true)[0].Descripcion;
                 }
               $scope.CleanPersona = function () {
                   $scope.isSave = true;
                   $scope.Persona = {};
               }

               $scope.getPersona = function () {
                   PersonaService.getPersona().then(function (response) {
                       $scope.PersonaTable = new NgTableParams({ count: 20 }, { counts: [], dataset: response.data });
                   }).catch(function (result) {
                   });
               }

               $scope.loadPersona = function (row) {
                   $scope.Persona = angular.copy(row);
               }

               $scope.savePersona = function () {
                   PersonaService.savePersona($scope.Persona).then(function (response) {
                       $scope.isSuccess = true;
                       $scope.message = "Se ha agregado el Persona correctamente";
                       $("#ModalMessage").modal('show');
                       $scope.initPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editPersona = function () {
                   PersonaService.editPersona($scope.Persona).then(function (response) {
                       $scope.message = "Se ha editado el Persona correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.DeletePersona = function () {
                   PersonaService.DeletePersona($scope.Persona.IdPersona).then(function (response) {
                       $scope.message = "Se ha eliminado el Persona correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

           }]);