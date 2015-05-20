/**
 * This is a very simple example of an ember component to integrate
 * nnick/chart.js in an ember.js application. Basically, it is simply
 * using the components hook to create a ChartJS canvas element.
 * Additionally, it supports an update property that allows you to
 * let the chart re-rendet if your data or options change. Chart.js
 * doesn't support updating its data so this will just create a new
 * chart on the given canvas.
 * 
 * Example usage in a handlebars template:
 * {{ember-chart type=CHARTTYPE data=CHARTDATA options=CHARTOPTIONS update=CHARTUPDATE}}
 * 
 * CHARTTYPE: Can be `Line`, `Bar`, `Radar`, `PolarArea`, `Pie` or `Doughnut`.
 * CHARTDATA: The chart data array
 * CHARTOPTIONS: The chart options array, this can be skipped, the component will genereate {} if this isn't set.
 * CHARTUPDATE: Boolean indicator, the chart will re-render on data/options change if set to true. Can be undefined
 * For more information, please read the Chart.js doc at http://chartjs.org
 */

import Ember from 'ember';

export default Ember.Component.extend({
  tagName: 'canvas',
  setup: false,

  /**
   * Construction handler
   * This will create the canvas and check the given
   * input values since Chart.js can react pretty odd
   * when getting wrong and/or missing values.
   */
  didInsertElement: function(){
    let canvas  = this.get('element');
    let context = canvas.getContext('2d');

    canvas.width  = Ember.$(canvas).parent().width();
    canvas.height = Ember.$(canvas).parent().height();

    let data = this.get('data');
    let type = this.get('type').charAt(0).toUpperCase() + this.get('type').slice(1);
    
    if(!type.match(/(Line|Bar|Radar|PolarArea|Pie|Doughnut)/)) {
      type = "Line";
    }
    
    let options = (this.get('options') !== undefined) ? this.get('options') : {};

    this.setProperties({
      '_data': data,
      '_type': type,
      '_canvas':  canvas,
      '_context': context,
      '_options': options
    });
    this.chartRender();
  },

  /**
   * Render the chart to the canvas
   * This function is separated from the event hook to
   * allow data overwriting which more or less results
   * in updating the chart.
   */
  chartRender: function(){
    var chart = this.get('_chart');
    if (chart !== undefined) {
      chart.destroy();
    }

    chart = new Chart(this.get('_context'))[this.get('_type')](this.get('_data'),this.get('_options'));
    this.setProperties({
      '_chart': chart,
      'setup': true
    });
  },

  /**
   * Chart Update Handler
   * This will re-render the chart whenever its data or
   * options changes, if the 'update' property is set to true
   */
  chartUpdate : function() {
    if (this.get('update') === true && this.get('setup') === true) {
      this.setProperties({
        '_data' : this.get('data'),
        '_options' : this.get('options')
      });
      this.chartRender();
    }
  }.observes('data', 'options')
});