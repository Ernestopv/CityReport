import React, { Component } from "react";
import { Table } from "react-bootstrap";

export class Content extends Component {
  constructor(props) {
    super(props);
    this.state = {
      current: {
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
      },
    };
  }

  componentDidMount() {
    this.setState({ current: this.props.currentReport });
  }

  render() {
    const {
      weather,
      condition,
      icon,
      region,
      country,
      latitude,
      longitude,
      dateTime,
      sunrise,
      sunset,
      moonphase,
    } = this.props.currentReport ;
    return (
      <Table striped borderless hover responsive="xl" variant="dark">
        <tbody>
          <tr>
            <td className="center">Weather:</td>
            {weather !== "--" ? (
              <td className="left">
                {weather}
                {"°C"} {" (" + condition + ")"}
                <img alt="weather" src={icon} />
              </td>
            ) : (
              <td className="left">{weather}</td>
            )}
          </tr>
          <tr>
            <td className="center">Region:</td>
            <td className="left">{region}</td>
          </tr>
          <tr>
            <td className="center">Country:</td>
            <td className="left">{country}</td>
          </tr>
          <tr>
            <td className="center">Latitude:</td>
            <td className="left">{latitude}</td>
          </tr>
          <tr>
            <td className="center">Longitude:</td>
            <td className="left">{longitude}</td>
          </tr>
          <tr>
            <td className="center">Date/Time:</td>
            <td className="left">{dateTime}</td>
          </tr>
          <tr>
            <td className="center">Sunrise:</td>
            <td className="left">{sunrise}</td>
          </tr>
          <tr>
            <td className="center">Sunset:</td>
            <td className="left">{sunset}</td>
          </tr>
          <tr>
            <td className="center">Moon phase:</td>
            <td className="left">{moonphase}</td>
          </tr>
        </tbody>
      </Table>
    );
  }
}
