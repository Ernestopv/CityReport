import React from "react";
import { render } from "@testing-library/react";
import { NavMenu } from "../NavMenu";


 
it("Rendering condtions from DropDown and Spinner in component", () => {
        
    const component = render(<NavMenu />);   
    expect(component).toBeDefined();
    //if there is not data from API noCities is going to be Disabled and spinner is going to be Visible
    expect(component.queryByTitle("noCities")).toBeDisabled();
    expect(component.queryByTitle("spinner")).toBeVisible();
  });
;
