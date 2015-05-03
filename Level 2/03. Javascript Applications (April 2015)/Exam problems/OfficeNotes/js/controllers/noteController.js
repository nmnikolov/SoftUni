var app = app || {};

app.noteController = (function () {
    function NoteController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    NoteController.prototype.loadAddNoteView = function(selector) {
        this.viewBag.addNote.addNoteView(selector);
    };

    NoteController.prototype.loadNoteView = function(selector, urlParams, action) {
        var data = urlParams.split('&');
        var outData = {
            id : decodeURI(data[0].split('id=')[1]),
            title: decodeURI(data[1].split('title=')[1]),
            text: decodeURI(data[2].split('text=')[1]),
            deadline: decodeURI(data[3].split('deadline=')[1])
        };

        if(action === 'delete') {
            this.viewBag.deleteNote.deleteNoteView(selector, outData);
        } else {

            this.viewBag.editNote.editNoteView(selector, outData);
        }
    };

    NoteController.prototype.listAllNotes = function (selector, page) {
        var _this = this;

        return _this.model.listAllNotes(page)
                    .then(function (data) {
                        _this.viewBag.listNotes.loadNotesView(selector, page,  data);
                    }, function () {
                        Noty.error('Error retrieving notes. Please try again.');
                    });
    };

    NoteController.prototype.listMyNotes = function (selector, page) {
        var _this = this;

        return _this.model.listMyNotes(page)
                    .then(function (data) {
                        _this.viewBag.listMyNotes.loadMyNotesView(selector, page, data);
                    }, function () {
                        Noty.error('Error retrieving notes. Please try again.');
                    });
    };

    NoteController.prototype.addNote = function (title, text, deadline) {
        return this.model.addNote(title, text, deadline)
            .then(function() {
                Noty.success('Note successfully added.');
                window.location.replace('#/myNotes/1');
            }, function() {
                Noty.error('Error adding note. Please try again.');
            })
    };

    NoteController.prototype.editNote = function (noteId, title, text, deadLine) {
        return this.model.editNote(noteId, title, text, deadLine)
            .then(function() {
                Noty.success('Note successfully edited.');
                window.location.replace('#/myNotes/1');
            }, function() {
                Noty.error('Error editing note. Please try again.');
            })
    };

    NoteController.prototype.deleteNote = function (noteId) {
        return this.model.deleteNote(noteId)
            .then(function() {
                Noty.success('Note successfully deleted.');
                window.location.replace('#/myNotes/1');
            }, function() {
                Noty.error('Error deleting note. Please try again.');
            })
    };

    return {
        load: function (model, views) {
            return new NoteController(model, views);
        }
    }
}());