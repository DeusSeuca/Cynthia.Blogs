const path = require("path");
const glob = require("glob");

var babelOptions = {
    "presets": ["@babel/typescript"],
};

module.exports = {
    mode: "development",
    entry: {
        bundle: ["@babel/polyfill", ...glob.sync(path.resolve(__dirname, '../../src/*/ClientApp/**/*.entry.@(t|j)s?(x)'))],
    },
    output: {
        path: path.resolve(__dirname, '../../src/Cynthia.Blogs.Server/obj/webpack'),
        filename: "scripts/[name].js",
        chunkFilename: "scripts/[chunkhash].js"
    },
    module: {
        rules: [{
            test: /\.(ts|js)x?$/i,
            exclude: /node_modules/,
            use: [{
                loader: "babel-loader",
                options: babelOptions
            }]
        }, {
            test: /\.css$/,
            use: ['style-loader', 'css-loader'],
        }, {
            test: /.(png|jpg|gif|bmp)$/i,
            use: [{
                loader: "url-loader",
                options: {
                    limit: 8192,
                    name: "assets/[hash].[ext]"
                }
            }]
        }],
    },
    plugins: [],
    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx"]
    },
    devtool: 'source-map'
};