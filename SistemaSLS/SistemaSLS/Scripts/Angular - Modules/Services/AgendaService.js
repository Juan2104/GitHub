angular.module('Agenda.service', [])
    .factory('AgendaService', [
        '$http',
        function ($http) {
            return {
                getAgenda: function () {
                    return $http({
                        method: 'GET',
                        url: '/Agenda/Get'
                    });
                },
                saveAgenda: function (AgendaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Agenda/Post',
                        data: { AgendaDTO: AgendaDTO }
                    });
                },
                editAgenda: function (AgendaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Agenda/Update',
                        data: { AgendaDTO: AgendaDTO }
                    });
                },
                DeleteAgenda: function (AgendaDTO) {
                    return $http({
                        method: 'POST',
                        url: '/Agenda/Delete',
                        data: { IdAgenda: AgendaDTO }
                    });
                },
            };
        }]);

