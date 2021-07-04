import React, { Component } from "react";
import { Form, Container, Navbar, NavbarBrand, Spinner } from "react-bootstrap";
import { getAvailableCities } from "../Services/APIService";
import "./NavMenu.css";

export class NavMenu extends Component {
  static displayName = NavMenu.name;
  constructor(props) {
    super(props);
    this.state = {
      availableCities: [],
    };
  }

  handleAvailableCities = async () => {
    let data = await getAvailableCities();
    this.setState({ availableCities: data });
    this.props.changeCity(data[0]);
  };

  handleInput = (e) => {
    this.props.changeCity(e.target.value);
  };

  componentDidMount() {
    this.handleAvailableCities();
  }

  render() {
    const { availableCities } = this.state;
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light="true"
        >
          <Container>
            <NavbarBrand>
              <h2>City :</h2>
              <Spinner
                title="spinner"
                animation="border"
                role="status"
                hidden={this.props.show}
              >
                <span className="visually-hidden"></span>
              </Spinner>
            </NavbarBrand>
            <Form.Group controlId="selector">
              <Form.Control 
                as="select"
                defaultValue={this.props.name}
                onChange={(e) => this.handleInput(e)}
                size="lg"
                custom
              >
                {availableCities.length !== 0 ? (
                  availableCities.map((value, index) => (
                    <option value={value} key={index}>
                      {value}
                    </option>
                  ))
                ) : (
                     <option title="noCities" disabled>No Cities Available</option>
                )}
              </Form.Control>
            </Form.Group>
          </Container>
        </Navbar>
      </header>
    );
  }
}
