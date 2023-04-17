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
      next(createError.InternalServerError("Could not get user data"));
    }
  );
});

router.patch("/", (req, res, next) => {
  const userId = res.locals.user.id;
  const userData = req.body;

  userQueries
    .updateUser(userId, userData)
    .then((result) => {
      res.send(result[0]);
    })
    .catch((error) => {
      next(createError.InternalServerError("Could not update user data"));
    });
});

module.exports = router;
