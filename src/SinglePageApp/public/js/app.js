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
            get: {method:'GET', params:{id:'id'}, isArray:false}
        });
    }])
    .service('GroceryService', ['GroceryItem', function(GroceryItem) {
        
        var idSequence = 1;
        
        return {
            
            groceryItems: GroceryItem.query(),
            
            _idSequence: idSequence,
            
            save: function(groceryItem) {
                
                groceryItem.dateTimeCreated = new Date();
                
                // Update existing item
                if(groceryItem.id) {
                    var existingGroceryItem = this.getItem(groceryItem.id);
                    existingGroceryItem.name = groceryItem.name;
                }
                // create new item
                else
                {
                    groceryItem.id = this._idSequence++;
                    this.groceryItems.push(groceryItem);
                }
            },
            
            // Remove the given item from the array
            removeItem: function(item) {
              var index = this.groceryItems.indexOf(item);
              
              if(index >= 0)
                this.groceryItems.splice(index, 1);  
            },
            
            getItem: function(itemId) {
                for(var index = 0; index < this.groceryItems.length; index++) {
                    var item = this.groceryItems[index];
                    if(item.id == itemId)
                        return item;
                }
                return null;
            },
            
            toggleBought: function(item) {
                item.bought = !item.bought;
            }
        };
    }])
    .controller('HomeController', ['$scope', 'GroceryService', function($scope, GroceryService) {
        $scope.groceryItems = GroceryService.groceryItems;
        
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
                $scope.groceryItem = angular.copy(GroceryService.getItem($routeParams.id));
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
