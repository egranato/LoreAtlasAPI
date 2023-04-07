/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = function (knex) {
  return knex.schema.createTable("universe", (t) => {
    t.increments("id");
    t.string("title").notNullable();
    t.integer("userId").notNullable();
    t.timestamps(true, true);

    t.foreign("userId").references("id").inTable("user");
  });
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = function (knex) {
  return knex.schema.dropTable("universe");
};
