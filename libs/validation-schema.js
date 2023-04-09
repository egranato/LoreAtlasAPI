const Joi = require("joi");

module.exports = {
  universeValidation: (universe) => {
    const schema = Joi.object({
      title: Joi.string().alphanum().max(255).required().label("Title"),
      description: Joi.string().min(0).label("Description"),
    });
    return schema.validate(universe);
  },
  signUpBodyValidation: (body) => {
    const schema = Joi.object({
      name: Joi.string().required().label("Name"),
      email: Joi.string().email().required().label("Email"),
    });
    return schema.validate(body);
  },
  loginBodyValidation: (body) => {
    const schema = Joi.object({
      email: Joi.string().email().required().label("Email"),
      password: Joi.string().required().label("Password"),
    });
    return schema.validate(body);
  },
  refreshTokenBodyValidation: (body) => {
    const schema = Joi.object({
      refreshtoken: Joi.string().required().label("Refresh Token"),
    });
    return schema.validate(body);
  },
};
