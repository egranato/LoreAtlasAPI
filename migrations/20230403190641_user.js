/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = (knex) => {
  return knex.schema.createTable("user", (t) => {
    t.increments("id");
    t.string("email").unique().notNullable();
    t.string("name").notNullable();
    t.enum("roles", ["user", "admin", "super_admin"])
      .notNullable()
      .defaultTo("user");
    t.timestamps(true, true);
  });
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = (knex) => {
  return knex.schema.dropTable("user");
};
