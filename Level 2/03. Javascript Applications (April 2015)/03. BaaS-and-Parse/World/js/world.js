$(document).ready(function(){
    var PARSE_APP_ID = "yecs8jNrBrCoe7BE1gjqjOFvpdWZWqWZfwxT3xSQ";
    var PARSE_REST_API_KEY = "qZ3cyrP9KfDHlr3LdeTYCDxE07jO9DfIBcJ4FYkX";
    
    getCountries();
    
    $(document).on('click', '.country', function(){
        if ( $(this).parent().children('.towns').length > 0 ) {
            $(this).parent().children('.towns').slideToggle(); 
        } else {
            getTowns($(this).parent().data('country'), $(this));
        }
    });
    
    $(document).on('click', '#country-edit-section button', function(){
        var newValue = $('#edit-country').val();
        var country = $(this).parent().parent().data('country');
        var element = $(this).parent().parent();
        
        updateCountry(newValue, country, element);
    });
    
    $(document).on('focusout', '#edit-country', function () {
        var el = $(this);
        $('#countries > li').trigger('mouseleave');
        setTimeout(function () {
            el.parent().remove();
        }, 100);
    });
    
    $(document).on('click', '.remove-country', function(){
        var el = $(this).parent().parent();
        var country = el.data('country');
        
        deleteCountry(country, el);
    });
    
    $(document).on('click', '.edit-country', function(){
        var country = $(this).parent().parent().data('country');
        var div = $('<div id="country-edit-section">');
        var input = $('<input id="edit-country">').val(country.name);
        var button = $('<button>').text('ok');
        div.append(input);
        div.append(button);
        $(this).parent().after(div);
        div.hide().slideToggle();
        input.focus().select();
    });
    
    $(document).on('mouseenter', '#countries > li', function () {
            $(this).find(".buttons").hide().fadeIn(100);
        }).on('mouseleave', '#countries > li', function () {
            $(this).find(".buttons").hide();
    });
    
    $(document).on('mouseenter', '.towns > li', function () {
            $(this).find(".town-buttons").hide().fadeIn(100);
        }).on('mouseleave', '.towns > li', function () {
            $(this).find(".town-buttons").hide();
    });
    
    $(document).on('click', '#country-add-button', function(){
        if ($(this).prev().val()) {
            addCountry($(this).prev().val());
        };
    });

    $(document).on('click', '#town-add-section button', function () {
        var country = $(this).parent().parent().data('country');
        if ($(this).prev().val()) {
            addTown($(this).prev().val(), country, $(this).parent().parent());
        };
        
    });

    $(document).on('click', '.add-town', function() {
        var div = $('<div id="town-add-section">');
        var input = $('<input id="add-town">');
        var button = $('<button>').text('ok');
        div.append(input);
        div.append(button);
        $(this).parent().after(div);
        div.hide().slideToggle();
        input.focus().select();
    });

    $(document).on('focusout', '#add-town', function () {
        var el = $(this);
        $('#countries > li').trigger('mouseleave');
        setTimeout(function () {
            el.parent().remove();
        }, 100);
    });
    
    function getCountries() {
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY 
            },
            url: 'https://api.parse.com//1/classes/Country',
            success: loadContries,
            error: error
        });
        
        function loadContries(data){
            data.results.sort(function(a, b){
                return (a.name).localeCompare(b.name);
            });
            
            $.each($(data.results), function(key, country){
                var countryItem = $('<li>').data('country', country);
                $('<span>').addClass('country').text(country.name).appendTo(countryItem);
                var div = $('<span>').addClass('buttons').append($('<button class="add-town">+</button><button class="edit-country">e</button><button            class="remove-country">x</button>'));
                div.appendTo(countryItem);
                countryItem.hide().appendTo($("#countries")).fadeIn(500);
            });
        };
    };
    
    function addCountry(name){
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY 
            },
            data: JSON.stringify({
                'name': name
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Country',
            success: addElement,
            error: error
        });
        
        function addElement(data){
            data.name = name;
            console.log(data);
            var li = $('<li>').data('country', data);
            li.append('<span class="country">' + data.name + '</span>');
            li.append('<span class="buttons"><button class="add-town">+</button><button class="edit-country">e</button><button class="remove-country">x</button></span>');
            li.append($('<ul>').addClass('towns'));			
            li.appendTo('#countries');
            $('#country-input').val('');
        };
    }
    
    function updateCountry(newName, country, el) {
        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY 
            },
            data: JSON.stringify({
                            'name': newName
                        }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Country/' + country.objectId,
            success: changeElement,
            error: error
        });
        
        function changeElement(){
            el.children('.country').text(newName);
            var data = el.data('country');
            data.name = newName;
        };
    };
    
    function deleteCountry(country, el){
        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY 
            },
            url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
            success: deleteElement,
            error: error
        });
        
        function deleteElement(){
            $(el).remove();
        }
    };
    
    
    function getTowns(country, el) {
        var path = 'https://api.parse.com//1/classes/Town?include=country&where='
        var country = {
            "country":{
                "__type":"Pointer",
                "className":"Country",
                "objectId": country.objectId
            }
        };
        
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY 
            },
            url: path + JSON.stringify(country),
            success: loadTowns,
            error: error
        });
        
        function loadTowns(data){
            $(this).empty();
            if (data.results) {
                var towns = $('<ul>').addClass('towns');
                
                $.each($(data.results), function (key, town) {
                    var townItem = $('<li>').data('town', town);
                    $('<span>').addClass('town').text(town.name).appendTo(townItem);
                    var div = $('<span>').addClass('town-buttons').append($('<button class="edit-town">e</button><button class="remove-town">x</button>'));
                    div.appendTo(townItem);
                    townItem.appendTo(towns);
                });
                
                towns.hide().appendTo(el.parent()).slideToggle();
            };
        };
    };

    function addTown(name, country, countryElement) {
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            data: JSON.stringify({
                "name": name,
                'country': {
                    "__type": "Pointer",
                    "className": "Country",
                    "objectId": country.objectId
                }
            }),
            contentType: "application/json",
            url: 'https://api.parse.com//1/classes/Town',
            success: addElement,
            error: error
        });

        function addElement(town) {
            console.log(countryElement);
            if (!countryElement.children('.towns')) {
                countryElement.append($('<ul>').addClass('towns'));
            }
            var townItem = $('<li>').data('town', town);
            $('<span>').addClass('town').text(town.name).appendTo(townItem);
            var div = $('<span>').addClass('town-buttons').append($('<button class="edit-town">e</button><button class="remove-town">x</button>'));
            div.appendTo(townItem);
            townItem.appendTo(countryElement.children('.towns'));
        };
    }
    
    function error(err){
        alert('Error: ' + err.status + ' ' + err.responseText);		
    };
});