angular.module('app')
.controller('ContactsController', ['httpService', 'textService', '$scope', '$http', '$q', '$sce', function (httpService, textService, $scope, $http, $q, $sce) {
    // Spinner
    var opts = {
        lines: 13, length: 28, width: 14, radius: 42, scale: 0.3, corners: 1, color: '#000', opacity: 0.25,
        rotate: 0, direction: 1, speed: 1, trail: 60, fps: 20, zIndex: 2e9, className: 'spinner', top: '50%',
        left: '50%', shadow: false, hwaccel: false, position: 'absolute'
    };

    var spinner = new Spinner(opts).spin($('#loading')[0]);

    var cancel = $q.defer();

    $scope.loading = false;

    $scope.getAge = function (dt) {
        return moment().diff(dt, 'years');
    }

    $scope.getInterests = function (interests) {
        return textService.splitAndTrim(interests, ', ');
    }

    $scope.highlight = textService.highlight;

    $scope.searchText = '';
    $scope.search = function (text) {
        if (text && text.length > 1) {
            var randomDelay = _.random(0, 3000);
            $scope.loading = true;

            // Cancel last search request if applicable
            if (cancel && cancel.resolve) {
                cancel.resolve();
                cancel = null;
            }

            _.delay(function () {
                $scope.findMatchingContacts(text);
            }, randomDelay);
        }
    }
    $scope.contacts = [];

    $scope.findMatchingContacts = _.debounce(function (text) {
        var always = function () {
            cancel = null; // Clear cancel promise
            $scope.loading = false; // Stop loading animation
        }

        cancel = httpService.cancelablePost('/Contacts/Search', { Text: text }, function (response) {
            always();
            $scope.contacts = response.data;
        }, function (response) {
            always();
        });
    }, 100);
}]);