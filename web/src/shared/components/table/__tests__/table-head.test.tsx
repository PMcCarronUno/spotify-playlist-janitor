import {
  fireEvent,
  getByTestId,
  getByText,
  render,
} from "@testing-library/react";
import { tableColumns } from "shared/mock-data/table-data";

import { TableHead } from "../table-head";

describe("<TableHead />", () => {
  let container: HTMLElement;
  let props: any;
  let mockHandleSort = jest.fn();

  beforeEach(() => {
    props = {
      columns: tableColumns,
      handleSorting: mockHandleSort,
    };

    ({ container } = render(
      <table>
        <TableHead {...props} />
      </table>
    ));
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should render TableHead component", () => {
    expect(container.firstChild).toMatchSnapshot();
  });

  it("should execute handleSort when sortable header clicked", () => {
    const colunHead = getByTestId(container, "table-head-cell-title");
    fireEvent.click(colunHead);

    expect(mockHandleSort).toHaveBeenCalledWith("title", "asc");
  });

  it("should execute handleSort when sortable header clicked with opposite sort order", () => {
    const colunHead = getByTestId(container, "table-head-cell-title");
    fireEvent.click(colunHead);
    fireEvent.click(colunHead);

    expect(mockHandleSort).toHaveBeenNthCalledWith(1, "title", "asc");
    expect(mockHandleSort).toHaveBeenLastCalledWith("title", "desc");
  });

  it("should not execute handleSort when non-sortable header clicked", () => {
    const colunHead = getByTestId(container, "table-head-cell-image");
    fireEvent.click(colunHead);

    expect(mockHandleSort).not.toHaveBeenCalled();
  });
});
