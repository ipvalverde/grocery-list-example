(function() {
    'use strict';
    
    angular.module('groceryListApp', ['ngRoute', 'ngResource'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/groceryList.html',
                controller: 'HomeController'
            })
            .when('/itemForm', {
                templateUrl: 'views/itemForm.html',
                controller: 'GroceryItemController'
            })
            .when('/itemForm/:id', {
                templateUrl: 'views/itemForm.html',
                controller: 'GroceryItemController'
            })
            .otherwise({
                redirectTo: '/'
            });
    })
    .factory('GroceryItem', ['$resource', function ($resource) {
        return $resource('http://localhost:3001/api/GroceryItem/:id', {}, {
            get: {method:'GET', params:{id:'id'}, isArray:false},
            update: { method:'PUT' }
        });
    }])
    .service('GroceryService', ['GroceryItem', function(GroceryItem) {
        
        var idSequence = 1;
        
        return {
            
            getGroceryItems: function () {
                return GroceryItem.query()
            },
            
            _idSequence: idSequence,
            
            save: function(groceryItem) {
                
                var result;
                // Update existing item
                if(groceryItem.id) {
                    result = GroceryItem.update(groceryItem);
                }
                // create new item
                else {
                    result = GroceryItem.save(groceryItem);
                }
                
                console.log(result);
                // TODO Wait until the end of request before continue
            },
            
            // Remove the given item from the array
            removeItem: function(item) {
              throw new Error('Not implemented yet');
            },
            
            getItem: function(itemId) {
                return GroceryItem.get({id: itemId});
            },
            
            toggleBought: function(item) {
                item.bought = !item.bought;
                var response = GroceryItem.update(item);
                
                console.log(result);
                // TODO Notify if the change could not be saved.
            }
        };
    }])
    .controller('HomeController', ['$scope', 'GroceryService', function($scope, GroceryService) {
        $scope.groceryItems = GroceryService.getGroceryItems();
        
        $scope.removeItem = function(item) {
            GroceryService.removeItem(item);
        };
        
        $scope.toggleBought = function(item) {
            GroceryService.toggleBought(item);
        }
    }])
    .controller('GroceryItemController', ['$scope', '$routeParams',
        '$location', 'GroceryService',
        function($scope, $routeParams, $location, GroceryService) {
            
            if($routeParams.id) {
                $scope.groceryItem = GroceryService.getItem($routeParams.id);
            }
            
            $scope.save = function() {
                GroceryService.save($scope.groceryItem);
                $location.path('/');
            }
        }
    ])
    
    .directive('myGroceryItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'views/directives/groceryItem.html'
        };
    });
})();
