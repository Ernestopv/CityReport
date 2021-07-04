import React, { Component } from "react";
import { BrowserRouter, Route, Redirect, Switch } from "react-router-dom";
import { Container } from "react-bootstrap";
import { NavMenu } from "./NavMenu.jsx";
import { Content } from "./Content.jsx";
import NotFound from "./common/Not-Found";

import {
  getAstronomyBy,
  getCurrentWeatherBy,
  getTimeZoneBy,
} from "../Services/APIService";

export class Layout extends Component {
  static displayName = Layout.name;
  constructor(props) {
    super(props);
    this.state = {
      weather: "--",
      condition: "--",
      icon: "--",
      region: "--",
      country: "--",
      latitude: "--",
      longitude: "--",
      dateTime: "--",
      sunrise: "--",
      sunset: "--",
      moonphase: "--",
      show: true,
    };
  }

  handleCity = async (city) => {
    this.setState({ show: false });
    await this.handleTimeZoneBy(city);
    await this.handleCurrentWeatherBy(city);
    await this.handleAstronomyBy(city);
    setTimeout(async () => {
      this.setState({ show: true });
    }, 800);
  };

  handleTimeZoneBy = async (city) => {
    const data = await getTimeZoneBy(city);

    this.setState({
      region: data.location.region,
      country: data.location.country,
      latitude: data.location.latitude,
      longitude: data.location.longitude,
      dateTime: data.location.localTime,
    });
  };

  handleCurrentWeatherBy = async (city) => {
    const data = await getCurrentWeatherBy(city);

    this.setState({
      weather: data.current.temp_c,
      condition: data.current.condition.text,
      icon: data.current.condition.icon,
    });
  };

  handleAstronomyBy = async (city) => {
    const data = await getAstronomyBy(city);

    this.setState({
      sunrise: data.astronomy.astro.sunrise,
      sunset: data.astronomy.astro.sunset,
      moonphase: data.astronomy.astro.moon_phase,
    });
  };

  render() {
    return (
      <div>
        <Container>
          <BrowserRouter>
            <Switch>
              <Route exact path="/cityReport">
                <NavMenu
                  title="navMenu"
                  changeCity={this.handleCity}
                  show={this.state.show}
                />
                {this.state.show ? (
                  <Content currentReport={this.state} title="content" />
                ) : (
                  ""
                )}
              </Route>
              <Route path="/not-found" component={NotFound} />
              <Redirect from="/" exact to="/cityReport" />
              <Redirect to="/not-found" />
            </Switch>
          </BrowserRouter>
        </Container>
      </div>
    );
  }
}
