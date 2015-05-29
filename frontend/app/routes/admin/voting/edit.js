import Ember from 'ember';

export default Ember.Route.extend({
    model: function(params) {
        return this.store.find('voting', params.id);
    },
    deactivate: function() {
        let model = this.controllerFor('admin.voting.edit').get('model');
        if (model.get('isDirty') || !model.get('isSaving')) {
            model.rollback();
        }
    }
});