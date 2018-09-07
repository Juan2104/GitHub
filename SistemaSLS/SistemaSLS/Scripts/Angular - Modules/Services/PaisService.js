angular.module('Pais.service', [])
    .factory('PaisService', [
        '$http',
        function ($http) {
            return {
                getPais: function () {
                    return $http({
                        method: 'GET',
                        url: '/Pais/Get'
                    });
                },
                savePais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/Post',
                        data: { PaisDTO: PaisDTO }
                    });
                },
                editPais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/Update',
                        data: { PaisDTO: PaisDTO }
                    });
                },
                DeletePais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/Delete',
                        data: { IdPais: PaisDTO }
                    });
                },
            };
        }]);

