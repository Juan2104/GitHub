angular.module('Pais.service', [])
    .factory('PaisService', [
        '$http',
        function ($http) {
            return {
                getinitMaster: function () {
                    return $http({
                        method: 'GET',
                        url: '/Pais/Get'
                    });
                },
                savePais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/SavePais',
                        data: { PaisDTO: PaisDTO }
                    });
                },
                editPais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/UpdatePais',
                        data: { PaisDTO: PaisDTO }
                    });
                },
                DeletePais: function (PaisDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Pais/DeletePais',
                        data: { IdPais: PaisDTO }
                    });
                },
                saveProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/SaveProvincia',
                        data: { ProvinciaDTO: ProvinciaDTO }
                    });
                },
                editProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/UpdateProvincia',
                        data: { ProvinciaDTO: ProvinciaDTO }
                    });
                },
                DeleteProvincia: function (ProvinciaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Provincia/DeleteProvincia',
                        data: { IdProvincia: ProvinciaDTO }
                    });
                },
            };
        }]);

