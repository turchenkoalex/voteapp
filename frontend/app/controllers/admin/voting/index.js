import Ember from 'ember';

export default Ember.ArrayController.extend({
    sortProperties: ['id'],
    actions: {
        delete: function(item) {
            item.destroyRecord();
        }
    }
});