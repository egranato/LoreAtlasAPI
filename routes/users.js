const express = require("express");
const router = express.Router();
const createError = require("http-errors");
const userQueries = require("../data/queries/user");

router.get("/", (req, res, next) => {
  const userId = res.locals.user.id;

  userQueries.find(userId).then(
    (userData) => {
      res.send(userData);
    },
    (e) => {
      res.send(createError.InternalServerError("Could not get user data"));
    }
  );
});

module.exports = router;
