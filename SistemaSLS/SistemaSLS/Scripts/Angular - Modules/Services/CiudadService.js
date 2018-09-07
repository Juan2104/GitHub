angular.module('Ciudad.service', [])
    .factory('CiudadService', [
        '$http',
        function ($http) {
            return {
                getCiudad: function () {
                    return $http({
                        method: 'GET',
                        url: '/Ciudad/Get'
                    });
                },
                getProvincia: function () {
                    return $http({
                        method: 'GET',
                        url: '/Provincia/Get'
                    });
                },
                saveCiudad: function (CiudadDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Ciudad/Post',
                        data: { CiudadDTO: CiudadDTO }
                    });
                },
                editCiudad: function (CiudadDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Ciudad/Update',
                        data: { CiudadDTO: CiudadDTO }
                    });
                },
                DeleteCiudad: function (CiudadDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Ciudad/Delete',
                        data: { IdCiudad: CiudadDTO }
                    });
                },
            };
        }]);

