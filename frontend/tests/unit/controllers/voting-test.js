import Ember from 'ember';
import { moduleFor,  test } from 'ember-qunit';

moduleFor('controller:voting', {
});

test('settings model', function(assert) {
  assert.expect(1);

  // grab an instance of `CommentsController` and `PostController`
  var ctrl = this.subject();

  // wrap the test in the run loop because we are dealing with async functions
  Ember.run(function() {

    // set a generic model on the post controller
    ctrl.set('model', Ember.Object.create({ options: [ Ember.Object.create({}) ] }));

    // assert that the controllers title has changed
    let sortedOptionsLength = ctrl.get('sortedOptions.length');
    assert.equal(sortedOptionsLength, 1);
  });
});