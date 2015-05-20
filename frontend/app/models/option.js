import DS from 'ember-data';

export default DS.Model.extend({
    title: DS.attr('string'),
    voteCount: DS.attr('number'),
    voting: DS.belongsTo('voting')
});