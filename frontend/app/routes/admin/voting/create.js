import Ember from 'ember';

export default Ember.Route.extend({
    model: function() {
        return this.store.createRecord('voting');
    },
    renderTemplate: function(controller, model) {
        this.render('admin.voting.edit', { model: model });
    },
    deactivate: function() {
        let model = this.controllerFor('admin.voting.edit').get('model');
        if (model.get('isNew')) {
            model.rollback();
        }
    }
});