const fs = require("fs");
const path = require("path");

const secretKey = fs.readFileSync(
  path.join(__dirname, "..", "jwtRS256.key"),
  "utf-8"
);
const publicKey = fs.readFileSync(
  path.join(__dirname, "..", "jwtRS256.key.pub"),
  "utf-8"
);

let newSecretKey = '"';
secretKey.split(/\r?\n/).forEach((line) => {
  newSecretKey += `${line}\\n`;
});
newSecretKey = newSecretKey.slice(0, newSecretKey.length - 2) + '"';

let newPublicKey = '"';
publicKey.split(/\r?\n/).forEach((line) => {
  newPublicKey += `${line}\\n`;
});
newPublicKey = newPublicKey.slice(0, newPublicKey.length - 2) + '"';

fs.writeFileSync(path.join(__dirname, "..", "jwtRS256.env.key"), newSecretKey);
fs.writeFileSync(
  path.join(__dirname, "..", "jwtRS256.env.key.pub"),
  newPublicKey
);

const used = process.memoryUsage().heapUsed / 1024 / 1024;
console.log(`The script uses approximately ${Math.round(used * 100) / 100} MB`);
