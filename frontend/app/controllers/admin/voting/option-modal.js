import Ember from 'ember';

export default Ember.Controller.extend({
    needRollback: true,

    resetRollback: function() {
        let model = this.get('model');
        this.set('needRollback', true);
        console.log('resetted');
    }.observes('model'),

    actions: {
        save: function() {
            if (this.get('model.isNew')) {
                this.set('model.isWaiting', true);
            }
            this.set('needRollback', false);
        },
        removeModal: function() {
            if (this.get('needRollback') && !this.get('model.isWaiting')) {
                this.get('model').rollback();
            }
            return true;
        }
    }
});