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

