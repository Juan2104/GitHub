angular.module('TipoMoneda.service', [])
    .factory('TipoMonedaService', [
        '$http',
        function ($http) {
            return {
                getTipoMoneda: function () {
                    return $http({
                        method: 'GET',
                        url: '/TipoMoneda/Get'
                    });
                },
                saveTipoMoneda: function (TipoMonedaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoMoneda/Post',
                        data: { TipoMonedaDTO: TipoMonedaDTO }
                    });
                },
                editTipoMoneda: function (TipoMonedaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoMoneda/Update',
                        data: { TipoMonedaDTO: TipoMonedaDTO }
                    });
                },
                DeleteTipoMoneda: function (TipoMonedaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoMoneda/Delete',
                        data: { IdTipoMoneda: TipoMonedaDTO }
                    });
                },
            };
        }]);

