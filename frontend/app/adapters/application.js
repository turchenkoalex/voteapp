import DS from 'ember-data';

let Adapter = DS.RESTAdapter.extend({
    namespace: 'api'
});

export default Adapter;