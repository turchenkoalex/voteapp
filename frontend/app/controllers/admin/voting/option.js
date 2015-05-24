import Ember from 'ember';

export default Ember.Controller.extend({
    actions: {
        save: function() {
            this.transitionTo('admin.edit', this.get('model.voting'));
        },
        cancel: function() {
            this.model.rollback();
            this.transitionTo('admin.edit', this.get('model.voting'));
        }
    }
});