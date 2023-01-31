const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:65326';

module.exports = {
  "/api/*": {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
};
