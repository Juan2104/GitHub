﻿var app = angular.module('TipoPersona.list.ctrl', [])
       .controller('TipoPersonaCtrl', [
           '$scope',
           '$filter',
           '$routeParams',
           '$location',
           'TipoPersonaService',
           'NgTableParams',
           function ($scope, $filter, $routeParams, $location, TipoPersonaService, NgTableParams) {
               $scope.TipoPersona = {};

               $scope.initTipoPersona= function () {
                   $scope.getTipoPersona();
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
                       $scope.initEmpresas();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.editTipoPersona = function () {
                   TipoPersonaService.editTipoPersona($scope.TipoPersona).then(function (response) {
                       $scope.message = "Se ha editado la mesa correctamente";
                       $scope.isSuccess = true;
                       $("#ModalMessage").modal('show');
                       $scope.initTipoPersona();
                   }).catch(function (result) {
                       $scope.isSuccess = false;
                       $scope.message = result.data;
                   });
               }

               $scope.deleteTipoPersona = function () {
                   TipoPersona.deleteTipoPersona($scope.TipoPersona.id).then(function (response) {
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
