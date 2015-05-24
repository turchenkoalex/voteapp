import Ember from 'ember';
import config from './config/environment';

var Router = Ember.Router.extend({
    location: config.locationType
});

Router.map(function() {
    this.route('voting', { path: '/voting/:id' });
    this.route('admin', function() {
        this.route('voting', function() {            
            this.route('edit', { path: '/:id' });
            this.route('create', { path: '/new' });
        });
    });
});

export default Router;
