"use strict";

var path = require("path");

module.exports = {
  entry: "./app/boot.ts",
  output: {
    publicPath: '/public/',
    path: path.join(__dirname, '/public'),
    filename: "bundle.js"
  },
  resolve: {
    extensions: ["", ".js", ".ts"]
  },
  devtool: 'source-map',
  module: {
    loaders: [
      {
        test: /\.ts/,
        loaders: ["ts-loader"],
        exclude: /node_modules/
      },
      {
        test: /\.scss$/,
        loaders: ["style?sourceMap", "css?sourceMap", "sass?sourceMap"]
      }
    ]
  }
}
