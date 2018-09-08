angular.module('Persona.service', [])
    .factory('PersonaService', [
        '$http',
        function ($http) {
            return {
                getPersona: function () {
                    return $http({
                        method: 'GET',
                        url: '/Persona/Get'
                    });
                },
                getPaises: function () {
                    return $http({
                        method: 'GET',
                        url: '/Pais/Get'
                    });
                },
                getEmpresas: function () {
                    return $http({
                        method: 'GET',
                        url: '/Empresa/Get'
                    });
                },
                getTiposPersonas: function () {
                    return $http({
                        method: 'GET',
                        url: '/TipoPersona/Get'
                    });
                },
                savePersona: function (PersonaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Persona/Post',
                        data: { PersonaDTO: PersonaDTO }
                    });
                },
                editPersona: function (PersonaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Persona/Update',
                        data: { PersonaDTO: PersonaDTO }
                    });
                },
                DeletePersona: function (PersonaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Persona/Delete',
                        data: { IdPersona: PersonaDTO }
                    });
                },
            };
        }]);

