const uglify = require("uglifyjs-webpack-plugin");
const config = require("./webpack.config");

config.mode = "production";
config.optimization = {
    minimizer: [new uglify()]
};
delete config.devtool;
module.exports = config;