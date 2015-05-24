import Ember from 'ember';

export default Ember.Controller.extend({
    clock: Ember.inject.service(),
    reloadInterval: 30,

    chartData: function() {
        let options = this.get('model.options');

        let data = {
            labels: options.mapBy('title'),
            datasets: [
                {
                    label: "My First dataset",
                    fillColor: "rgba(151,187,205,0.5)",
                    strokeColor: "rgba(151,187,205,0.8)",
                    highlightFill: "rgba(151,187,205,0.75)",
                    highlightStroke: "rgba(151,187,205,1)",
                    data: options.mapBy('voteCount')
                }
            ]
        };

        return data;
    }.property('model.options.@each.voteCount'),

    chartOptions: {
        animation : false
    },

    sortedOptions: function() {
        let options = this.get('model.options');
        return options.sortBy('title');
    }.property('model.options.@each.title', 'model.options.@each.isMaximum'),

    recalculateMaximumVoteCount: function() {
        let options = this.get('model.options');
        if (options.get('length') > 0) {
            options.forEach((x) => x.set('isMaximum', false));
            let option = options.sortBy('voteCount').get('lastObject');
            option.set('isMaximum', true);
        }
    }.observes('model.options.@each.voteCount'),

    reloadOptions: function() {
        let time = this.get('clock.second');
        let reloadInterval = this.get('reloadInterval');
        if (time % reloadInterval === 0) {
            let options = this.get('model.options');
            options.forEach((x) => {
                x.reload();
                x.rollback();
            });
        }
    }.observes('model.options', 'clock.second'),

    actions: {
        vote: function(option) {
            Ember.$.post('/api/options/' + option.get('id') + '/vote').then(() => {
                option.incrementProperty('voteCount');
            });
        }
    }
});