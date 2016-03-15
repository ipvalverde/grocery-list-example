(function() {
    'use strict';
    
    angular.module('groceryListApp', ['ngRoute'])
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
    
    .service('GroceryService', function() {
        
        var idSequence = 1;
        
        return {
            
            groceryItems: [
                { id: idSequence++, bought: true, itemName: 'Milk', date: new Date('March 9, 2016 12:00:00') },
                { id: idSequence++, bought: true, itemName: 'Meat', date: new Date('March 9, 2016 12:00:00') },
                { id: idSequence++, bought: true, itemName: 'Banana', date: new Date('March 9, 2016 12:00:00') },
                { id: idSequence++, bought: true, itemName: 'Chocolates', date: new Date('March 1, 2016 12:00:00') },
                { id: idSequence++, bought: true, itemName: 'Chicken wings (buffalo wings)', date: new Date('March 1, 2016 12:00:00') },
                { id: idSequence++, bought: true, itemName: 'Apple', date: new Date('March 1, 2016 12:00:00') },  
                { id: idSequence++, bought: true, itemName: 'Bread loaf', date: new Date('March 10, 2016 12:00:00') },  
                { id: idSequence++, bought: true, itemName: 'Coca-cola', date: new Date('March 10, 2016 12:00:00') }
            ],
            
            _idSequence: idSequence,
            
            save: function(groceryItem) {
                
                groceryItem.date = new Date();
                
                // Update existing item
                if(groceryItem.id) {
                    var existingGroceryItem = this.getItem(groceryItem.id);
                    existingGroceryItem.itemName = groceryItem.itemName;
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
            }
        };
    })
    .controller('HomeController', ['$scope', 'GroceryService', function($scope, GroceryService) {
        $scope.groceryItems = GroceryService.groceryItems;
        
        $scope.removeItem = function(item) {
            GroceryService.removeItem(item);
        };
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
    ]);
})();


