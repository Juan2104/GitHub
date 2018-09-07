angular.module('Servicio.service', [])
    .factory('ServicioService', [
        '$http',
        function ($http) {
            return {
                getServicio: function () {
                    return $http({
                        method: 'GET',
                        url: '/Servicio/Get'
                    });
                },
                getTiposServicios: function () {
                    return $http({
                        method: 'GET',
                        url: '/TipoServicio/Get'
                    });
                },
                saveServicio: function (ServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Servicio/Post',
                        data: { ServicioDTO: ServicioDTO }
                    });
                },
                editServicio: function (ServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Servicio/Update',
                        data: { ServicioDTO: ServicioDTO }
                    });
                },
                DeleteServicio: function (ServicioDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Servicio/Delete',
                        data: { IdServicio: ServicioDTO }
                    });
                },
            };
        }]);

