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
        
        return {
            
            getGroceryItems: function () {
                return GroceryItem.query()
            },
            
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
                
                return result;
            },
            
            // Remove the given item from the array
            removeItem: function(item) {
              return GroceryItem.delete({id: item.id});
            },
            
            getItem: function(itemId) {
                return GroceryItem.get({id: itemId});
            },
            
            toggleBought: function(item) {
                item.bought = !item.bought;
                return GroceryItem.update(item);
            }
        };
    }])
    .controller('HomeController', ['$scope', 'GroceryService', function($scope, GroceryService) {
        $scope.groceryItems = GroceryService.getGroceryItems();
        
        $scope.removeItem = function(item) {
            item.disableButtons = true;
            var request = GroceryService.removeItem(item);
            request.$promise.then(function (resp) {
                $scope.groceryItems = GroceryService.getGroceryItems();
            });
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
                $scope.disableButtons = true;
                $scope.errors = null;
                $scope.invalidFields = null;
                var request = GroceryService.save($scope.groceryItem);
                request.$promise.then(function (resp) {
                    console.log(resp);
                    
                    if(resp.success) {
                        $location.path('/');
                    }
                    else {
                        var errors = [];
                        var invalidFields = [];
                        if(resp.errors) {
                            angular.forEach(resp.errors, function(value, key) {
                                angular.forEach(value, function(errorMessage) {
                                   errors.push(errorMessage); 
                                });
                                
                                invalidFields.push(key);
                            });
                        }
                        $scope.errors = errors;
                        $scope.invalidFields = invalidFields;
                        
                        $scope.disableButtons = false;
                    }
                });
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
