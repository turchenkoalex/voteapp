import Ember from 'ember';

export default Ember.Controller.extend({
    actions: {
        save: function() {
            this.get('model.options').forEach((x) => x.save());
            this.model.save().then(() => {
                this.transitionTo('admin');
            });
        },
        cancel: function() {
            this.model.rollback();
            this.transitionTo('admin');
        }
    }
});