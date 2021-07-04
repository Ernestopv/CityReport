import React, { Component } from "react";
import { Layout } from "./components/Layout.jsx";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return <Layout />;
  }
}
