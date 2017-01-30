angular.module('app', [])
    .service('textService', function ($sce) {
        this.splitAndTrim = function (value, delimiter) {
            return _(value.split(delimiter))
                .chain()
                .map(function (s) {
                    return s.trim();
                })
                .uniq()
                .value();
        };

        this.highlight = function (text, searchText) {
            if (!searchText) return $sce.trustAsHtml(text);

            var matchingTerms = searchText.split(' ');

            var result = text;

            _.each(matchingTerms, function (term) {
                result = result.replace(new RegExp(term, 'gi'), '<mark>$&</mark>');
            });

            return $sce.trustAsHtml(result);
        };
    })
    .service('httpService', function ($http, $q) {
        this.cancelablePost = function (url, body, success, error) {
            // Assign cancel promise
            var cancel = $q.defer();

            $http({
                method: 'POST',
                url: url,
                data: body,
                timeout: cancel.promise
            })
                .then(function (response) {
                    if (_.isFunction(success)) success(response);
                },
                    function (response) {
                        if (_.isFunction(error)) error(response);

                        if (response.status === -1) {
                            // Request cancelled
                        } else {
                            console.error('Error when making request to:', url, 'with body', body, 'parameters', arguments, 'this', this);
                        }
                    });

            return cancel;
        }
    });