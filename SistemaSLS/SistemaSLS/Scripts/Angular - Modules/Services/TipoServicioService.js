angular.module('TipoServicio.service', [])
    .factory('TipoServicioService', [
        '$http',
        function ($http) {
            return {
                getTipoServicio: function () {
                    return $http({
                        method: 'GET',
                        url: '/TipoServicio/Get'
                    });
                },
                saveTipoServicio: function (TipoServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoServicio/Post',
                        data: { TipoServicioDTO: TipoServicioDTO }
                    });
                },
                editTipoServicio: function (TipoServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoServicio/Update',
                        data: { TipoServicioDTO: TipoServicioDTO }
                    });
                },
                DeleteTipoServicio: function (TipoServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/TipoServicio/Delete',
                        data: { IdTipoServicio: TipoServicioDTO }
                    });
                },
            };
        }]);

