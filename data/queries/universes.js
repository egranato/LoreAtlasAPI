const db = require("../database-connection");

module.exports = {
  getUserUniverses: (userId) => {
    return db("universe").where("userId", userId);
  },
  getUniverse: (id) => {
    return db("universe").where("id", id).first();
  },
  createUniverse: (universe) => {
    return db("universe").insert(universe).returning("*");
  },
};
