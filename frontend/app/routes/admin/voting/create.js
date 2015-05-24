import Ember from 'ember';

export default Ember.Route.extend({
    model: function() {
        return Ember.Object.create();
    },
    renderTemplate: function(model) {
        this.render('admin.edit', { controller: 'admin.create' });
    }
});