const express = require("express");
const router = express.Router();
const createError = require("http-errors");
const userQueries = require("../data/queries/user");

router.get("/", (req, res, next) => {
  res.render("index");
});

module.exports = router;
