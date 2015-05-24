module.exports = function(app) {
  var express = require('express');
  var votingsRouter = express.Router();

  var votings = [{
    id: 1,
    title: 'Тестовое голосование для демо версии',
    active: true,
    options: [1, 2]
  },
  {
    id: 2,
    title: 'Голосование номер 2',
    active: true,
    options: [3, 4]
  }];

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

  votingsRouter.get('/', function(req, res) {
    res.send({
      'votings': votings,
      //'options': options,
      'meta': {
        total: votings.length
      }
    });
  });

  votingsRouter.post('/', function(req, res) {
    var voting = req.body.voting;
    votings.push(voting);
    voting.id = votings.length;
    res.status(201).send({
      'voting': voting
    });
  });

  votingsRouter.get('/:id', function(req, res) {
    var voting = votings.filter(function(x){ return x.id == req.params.id })[0];
    res.send({
      'voting': voting,
      //'options': options.filter(function(x){ return voting.options.indexOf(x.id) >= 0; })
    });
  });

  votingsRouter.put('/:id', function(req, res) {
    res.send({
      'votings': {
        id: req.params.id
      }
    });
  });

  votingsRouter.delete('/:id', function(req, res) {
    res.status(204).end();
  });

  app.use('/api/votings', votingsRouter);
};
