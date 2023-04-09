const express = require("express");
const router = express.Router();
const createError = require("http-errors");
const universeQueries = require("../data/queries/universes");
const validation = require("../libs/validation-schema");

router.get("/", async (req, res, next) => {
  const userId = res.locals.user.id;

  try {
    const universes = await universeQueries.getUserUniverses(userId);
    return res.send(universes);
  } catch (e) {
    const error = createError.InternalServerError("Could not get universes");
    return next(error);
  }
});

router.post("/", async (req, res, next) => {
  const userId = res.locals.user.id;
  const universe = req.body;

  const valid = validation.universeValidation(universe);
  if (valid.error) {
    const error = createError.BadRequest(valid.error);
    return next(error);
  }

  universe.userId = userId;

  try {
    const newUniverses = await universeQueries.createUniverse(universe);
    return res.send(newUniverses[0]);
  } catch (e) {
    const error = createError.InternalServerError("Could not create universe");
    return next(error);
  }
});

module.exports = router;
