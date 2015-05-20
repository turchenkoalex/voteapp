import DS from 'ember-data';

let Voting = DS.Model.extend({
    title: DS.attr('string'),
    active: DS.attr('boolean', { defaultValue: true }),
    options: DS.hasMany('option', { async: true })
});

export default Voting;