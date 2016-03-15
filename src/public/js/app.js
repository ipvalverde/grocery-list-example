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
                { id: idSequence++, bought: true, itemName: 'Milk', date: '2016-03-09' },
                { id: idSequence++, bought: true, itemName: 'Meat', date: '2016-03-09' },
                { id: idSequence++, bought: true, itemName: 'Banana', date: '2016-03-09' },
                { id: idSequence++, bought: true, itemName: 'Chocolates', date: '2016-03-01' },
                { id: idSequence++, bought: true, itemName: 'Chicken wings (buffalo wings)', date: '2016-03-01' },
                { id: idSequence++, bought: true, itemName: 'Apple', date: '2016-03-01' },  
                { id: idSequence++, bought: true, itemName: 'Bread loaf', date: '2016-03-10' },  
                { id: idSequence++, bought: true, itemName: 'Coca-cola', date: '2016-03-10' }
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


