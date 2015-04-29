var app = app || {};

app.controller = (function () {
    function Controller(model) {
        this._model = model;
    }

    Controller.prototype.loadHeader = function(headerSelector){
        var _this = this;
        if(this._model.users.isLogged()){

            return  this._model.users.getCurrentUserData()
                .then(function(userData){
                    _this._model.users.getById(userData.userId)
                        .then(function(data){
                            console.log(data);
                            app.views.headerView.load(headerSelector, data);
                        });
                });
        }
        else {
            return app.views.clearView.load(headerSelector);
        }
    };

    Controller.prototype.loadPostBox = function(selector){
        return app.views.postBoxView.load(selector);
    };

    Controller.prototype.loadHome = function(selector){

        if(this._model.users.isLogged()){
            app.views.postsView.load(selector);
        } else {
            app.views.defaultView.load(selector);
        }
    };

    Controller.prototype.loadLogin = function(selector){
        if(!this._model.users.isLogged()){
            app.views.loginView.load(selector);
        } else {
            window.location.replace('#/');
            Noty.success('Already logged in!');
        }

    };

    Controller.prototype.loadRegister = function(selector){
        if(!this._model.users.isLogged()){
            app.views.registerView.load(selector);
        } else {
            this.redirectTo('#/');
            Noty.success('Can\'t register while logged in!');
        }
    };


    Controller.prototype.loadProfile = function(selector){
        var _this = this;

        if(this._model.users.isLogged()){
            this._model.users.getCurrentUserData()
                .then(function(userData){
                    _this._model.users.getById(userData.userId)
                        .then(function(data){
                            app.views.profileView.load(selector, data)
                                .then(function(){

                                }, function(){
                                    Noty.error('Error loading profile page.!');
                                });
                        }, function(){
                            Noty.error('Error loading profile page.!');
                        });
                });
        } else {
            this.redirectTo('#/');
            Noty.error('Please log-in to view this page.!');
        }
    };

    Controller.prototype.logout = function(){
        var _this = this;

        if(this._model.users.isLogged()){
            this._model.users.logout()
                .then(function(){
                    _this.redirectTo('#/')
                    Noty.success('Successfully logged out.');
                });
        } else {
            Noty.error('Already logged out.');
            this.redirectTo('#/')
        }
    };

    Controller.prototype.redirectTo = function(url) {
        window.location = url;
    };


    Controller.prototype.attachEventHandlers = function(){
        var selector = '#main',
            headerSelector = '#header';

        attachLoginHandler.call(this, selector);
        attachRegisterHandler.call(this, selector);
//        attachHoverHandler.call(this, selector);
//        attachShowPostHandler.call(this, headerSelector);
//        attachSubmitPostHandler.call(this, selector);
//        attachPictureUploadHandler.call(this, selector);
//        attachEditProfileHandler.call(this, selector);
    };

    var attachLoginHandler = (function(selector){
        var _this = this;

        $(selector).on('click', '#login-btn', function(event){
            var userData = {
                username : $('#login-username').val(),
                password : $('#login-password').val()
            };

            _this._model.users.login(userData.username, userData.password)
                .then(function(){
                    Noty.success('Successfully logged in.');
                    _this.redirectTo('#/');
                }, function(error){
                    Noty.error('Your login has encountered an error.');
                    _this.redirectTo('#/');
                });
        });
    });

    var attachRegisterHandler = (function(selector){
        var _this = this;
        $(selector).on('click', '#reg-btn', function(event){
            var userData = {
                username: $('#reg-username').val(),
                password: $('#reg-password').val(),
                name: $('#reg-name').val(),
                about: $('#reg-about').val(),
                gender: $('input[type=radio]:checked').val(),
                picture: $('#picture').attr('data-picture-data')
            };

            _this._model.users.register(userData)
                .then(function(){

                    Noty.success('Your registration was successful.');
                    _this.redirectTo('#/');
                }, function(error){
                    Noty.error('Your registration has encountered an error.');
                    _this.redirectTo('#/');
                });
      });
    });


    return {
        get: function (model) {
            return new Controller(model);
        }
    }
}());