angular.module('Empresa.service', [])
    .factory('EmpresaService', [
        '$http',
        function ($http) {
            return {
                getEmpresa: function () {
                    return $http({
                        method: 'GET',
                        url: '/Empresa/Get'
                    });
                },
                getPaises: function () {
                    return $http({
                        method: 'GET',
                        url: '/Pais/Get'
                    });
                },
                saveEmpresa: function (EmpresaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Empresa/Post',
                        data: { EmpresaDTO: EmpresaDTO }
                    });
                },
                editEmpresa: function (EmpresaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Empresa/Update',
                        data: { EmpresaDTO: EmpresaDTO }
                    });
                },
                DeleteEmpresa: function (EmpresaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Empresa/Delete',
                        data: { IdEmpresa: EmpresaDTO }
                    });
                },
            };
        }]);

