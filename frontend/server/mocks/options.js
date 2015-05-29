module.exports = function(app) {
  var express = require('express');
  var optionsRouter = express.Router();

  var options = [
    {
      id: 1,
      title: 'option 1',
      voteCount: 1,
      voting: 1
    },
    {
      id: 2,
      title: 'option 2',
      voteCount: 1,
      voting: 1
    },
    {
      id: 3,
      title: 'option 3',
      voteCount: 2,
      voting: 2
    },
    {
      id: 4,
      title: 'option 4',
      voteCount: 1,
      voting: 2
    }
  ];

  optionsRouter.get('/', function(req, res) {
    res.send({
      'options': options,
      'meta': {
        'total': options.length
      }
    });
  });

  optionsRouter.post('/', function(req, res) {
    var item = req.body.option;
    options.push(item);
    item.id = options.length;
    res.status(201).send({
      'option': item
    });
  });

  optionsRouter.get('/:id', function(req, res) {
    res.send({
      'options': options.filter(function(x){ return x.id == req.params.id })[0]
    });
  });

  optionsRouter.put('/:id', function(req, res) {
    res.send({
      'options': {
        id: req.params.id
      }
    });
  });

  optionsRouter.delete('/:id', function(req, res) {
    res.status(204).end();
  });

  optionsRouter.post('/:id/vote', function(req, res) {
    var option = options.filter(function(x){ return x.id == req.params.id })[0];
    option.voteCount += 1;
    res.status(201).end();
  });

  app.use('/api/options', optionsRouter);
};
