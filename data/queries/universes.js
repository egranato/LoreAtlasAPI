const db = require("../database-connection");

module.exports = {
  getUserUniverses: (userId) => {
    return db("universe").where("userId", userId);
  },
  createUniverse: (universe) => {
    return db("universe").insert(universe).returning("*");
  },
};
