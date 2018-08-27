angular.module('TipoDictado.service', [])
    .factory('TipoDictadoService', [
        '$http',
        function ($http) {
            return {
                getTipoDictado: function () {
                    return $http({
                        method: 'GET',
                        url: '/TipoDictado/Get'
                    });
                },
                saveTipoDictado: function (TipoDictadoDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoDictado/Post',
                        data: { TipoDictadoDTO: TipoDictadoDTO }
                    });
                },
                editTipoDictado: function (TipoDictadoDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoDictado/Update',
                        data: { TipoDictadoDTO: TipoDictadoDTO }
                    });
                },
                DeleteTipoDictado: function (TipoDictadoDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoDictado/Delete',
                        data: { IdTipoDictado: TipoDictadoDTO }
                    });
                },
            };
        }]);

