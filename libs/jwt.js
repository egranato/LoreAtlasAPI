const jwt = require("jsonwebtoken");
const fs = require("fs");
const path = require("path");
const sessionQueries = require("../data/queries/session");
const userQueries = require("../data/queries/user");

const privateKey = fs
  .readFileSync(path.join(__dirname, "../keys/jwtRS256.key"))
  .toString();
const publicKey = fs
  .readFileSync(path.join(__dirname, "../keys/jwtRS256.key.pub"))
  .toString();

const signJwt = (payload, options) => {
  return jwt.sign(payload, privateKey, {
    ...(options && options),
    algorithm: "RS256",
  });
};

const verifyJwt = (token) => {
  try {
    const decoded = jwt.verify(token, publicKey);
    return {
      valid: true,
      expired: false,
      decoded,
    };
  } catch (e) {
    return {
      valid: false,
      expired: e.message === "jwt expired",
      decoded: null,
    };
  }
};

const createAccessToken = (user, session) => {
  return signJwt(
    {
      id: user.id,
      roles: user.roles,
      session: session.id,
    },
    { expiresIn: process.env.ACCESS_TOKEN_TTL }
  );
};

const createRefreshToken = (user, session) => {
  return signJwt(
    {
      id: user.id,
      session: session.id,
    },
    { expiresIn: process.env.REFRESH_TOKEN_TTL }
  );
};

module.exports = {
  createTokens: (user, session) => {
    const accessToken = createAccessToken(user, session);
    const refreshToken = createRefreshToken(user, session);

    return { accessToken, refreshToken };
  },
  reIssueAccesstoken: async (refreshToken) => {
    const { decoded } = verifyJwt(refreshToken);

    if (!decoded || !decoded.id) return false;

    try {
      const session = await sessionQueries.find(decoded.session);
      if (!session.valid) return false;
      const user = await userQueries.find(session.userId);
      if (!user) return false;

      const accessToken = createAccessToken(user, session);

      return accessToken;
    } catch (e) {
      console.log(e);
      return false;
    }
  },
  verifyJwt,
};
