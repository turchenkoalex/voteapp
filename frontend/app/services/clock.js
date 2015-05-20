import Ember from 'ember';

export default Ember.Object.extend({
    second: null,
    minute: null,
    hour:   null,

    init: function() {
        this.tick();
    },

    tick: function() {
        let now = new Date();

        this.setProperties({
            second: now.getSeconds(),
            minute: now.getMinutes(),
            hour:   now.getHours()
        });

        Ember.run.later(this.tick.bind(this), 1000);
    }
});