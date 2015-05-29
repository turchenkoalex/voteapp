import Ember from 'ember';

export default Ember.Controller.extend({
    actions: {
        save: function() {
            this.get('model.options').forEach(x => x.save());
            this.get('model').save().then(() => {
                this.transitionToRoute('admin.voting');
            });
        },
        cancel: function() {
            this.get('model.options').forEach(x => x.rollback());
            this.get('model').rollback();
            this.transitionToRoute('admin.voting');
        },
        createOption: function() {
            let voting = this.get('model');
            let item = this.store.createRecord('option', { voting: voting });
            this.send('showModal', 'admin.voting.option-modal', item);
        },
        delete: function(item) {
            item.destroyRecord();
        }
    }
});