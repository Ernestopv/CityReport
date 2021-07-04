import React from "react";
import { render } from "@testing-library/react";
import { Content } from "../Content";

test("Check  all variables required from Document to be displayed on table ", () => {
  const current = {
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
  const component = render(<Content currentReport={current} />);

  expect(component.container).toHaveTextContent("Weather:");
  expect(component.container).toHaveTextContent("Region:");
  expect(component.container).toHaveTextContent("Country:");
  expect(component.container).toHaveTextContent("Latitude:");
  expect(component.container).toHaveTextContent("Longitude:");
  expect(component.container).toHaveTextContent("Date/Time:");
  expect(component.container).toHaveTextContent("Sunrise:");
  expect(component.container).toHaveTextContent("Sunset:");
  expect(component.container).toHaveTextContent("Moon phase:");
});
