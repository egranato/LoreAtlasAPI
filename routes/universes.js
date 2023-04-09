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

router.get("/:id", async (req, res, next) => {
  const universeId = req.params.id;

  try {
    const universe = await universeQueries.getUniverse(universeId);

    if (universe) {
      return res.send(universe);
    } else {
      const error = createError.NotFound(
        `Could not find universe at id: ${universeId}`
      );
      return next(error);
    }
  } catch (e) {
    const error = createError.InternalServerError("Could not get universe");
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
