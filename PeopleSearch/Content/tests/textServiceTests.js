angular.module('app')
.controller('testController', ['textService', '$scope', function (textService, $scope) {
    // Dead simple unit tests for angular service
    //  so that reviewers can simply visit /Home/Test and see the results
    //  without needing to setup/download a headless browser or run
    //  custom tasks inside visual studio
    $scope.results = [];

    var values = textService.splitAndTrim('a, b, c', ', ');
    $scope.results.push(['textService.splitAndTrim', 'returns correct number of values', values.length === 3]);
    $scope.results.push(['textService.splitAndTrim', 'trims values', values[1].length === 1]);

    var value = textService.highlight('abcd', 'b');
    $scope.results.push(['textService.highlight','highlights search text', value.toString() === 'a<mark>b</mark>cd']);

    value = textService.highlight('abcd', 'b c');
    $scope.results.push(['textService.highlight', 'highlights multiple search texts', value.toString() === 'a<mark>b</mark><mark>c</mark>d']);
}])