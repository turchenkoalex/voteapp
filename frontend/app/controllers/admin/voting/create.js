import Ember from 'ember';

export default Ember.Controller.extend({
    actions: {
        save: function() {
            var model = this.store.createRecord('voting', {
                title: this.get('model.title'),
                active: this.get('model.active')
            });
            model.save().then(() => {
                this.transitionTo('admin');
            });
        },
        cancel: function() {
            this.transitionTo('admin');
        }
    }
});