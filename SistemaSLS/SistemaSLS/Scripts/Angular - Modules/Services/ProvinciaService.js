angular.module('Provincia.service', [])
    .factory('ProvinciaService', [
        '$http',
        function ($http) {
            return {
                getProvincia: function () {
                    return $http({
                        method: 'GET',
                        url: '/Provincia/Get'
                    });
                },
                getPaises: function () {
                    return $http({
                        method: 'GET',
                        url: '/Pais/Get'
                    });
                },
                saveProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/Post',
                        data: { ProvinciaDTO: ProvinciaDTO }
                    });
                },
                editProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/Update',
                        data: { ProvinciaDTO: ProvinciaDTO }
                    });
                },
                DeleteProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/Delete',
                        data: { IdProvincia: ProvinciaDTO }
                    });
                },
            };
        }]);

