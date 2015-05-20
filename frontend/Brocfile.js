/* global require, module */

var EmberApp = require('ember-cli/lib/broccoli/ember-app');

var app = new EmberApp();

// Use `app.import` to add additional libraries to the generated
// output files.
//
// If you need to use different assets in different
// environments, specify an object as the first parameter. That
// object's keys should be the environment name and the values
// should be the asset to use in that environment.
//
// If the library that you are including contains AMD or ES6
// modules that you would like to import into your application
// please specify an object with the list of modules as keys
// along with the exports of each module as its value.

// Bootstrap 3
app.import('bower_components/bootstrap/dist/js/bootstrap.js');
app.import('bower_components/bootstrap/dist/css/bootstrap.css');
app.import('bower_components/bootstrap/dist/css/bootstrap.css.map', { destDir: 'assets' });
['eot', 'ttf', 'svg', 'woff', 'woff2'].forEach(function (ext) {
   app.import('bower_components/bootstrap/dist/fonts/glyphicons-halflings-regular.' + ext , { destDir: 'fonts' });
});

// MomentJS
app.import('bower_components/moment/min/moment-with-locales.js');

// ChartJS
app.import('bower_components/Chart.js/Chart.js');

module.exports = app.toTree();
