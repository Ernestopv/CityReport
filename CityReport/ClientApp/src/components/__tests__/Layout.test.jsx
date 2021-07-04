import React from "react";
import { render } from "@testing-library/react";
import { Layout } from "../Layout";

it("Check if Table(content) is hidden when there is no data from API", () => {
  const component = render(<Layout />);

  expect(component.queryByTitle("content")).toBeNull();
});

it("Check if NavMenu component is defined", () => {
  const component = render(<Layout />);

  expect(component.queryByTitle("navMenu")).toBeDefined();
});
