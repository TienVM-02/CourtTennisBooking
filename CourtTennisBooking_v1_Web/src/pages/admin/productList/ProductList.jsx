import "./productList.css";
import { DataGrid } from "@material-ui/data-grid";
import { DeleteOutline } from "@material-ui/icons";
import * as React from "react";
import Topbar from "../../../components/topbar/Topbar";
import Sidebar from "../../../components/sidebar/Sidebar";
import { GetListCour } from "../../../module/action/action";
import { useDispatch, useSelector } from "react-redux";
import { Switch } from "@material-ui/core";



export default function ProductList() {
  const label = { inputProps: { 'aria-label': 'Switch demo' } };
  const dispatch = useDispatch();

  React.useEffect(() => {
    const callAPI = async () => {
      await dispatch(GetListCour());
    };
    callAPI();
  }, []);

  const courtowners = useSelector((state) => {
    return state.userReducer.listCO;
  });
  console.log(courtowners);

  const columns = [
    {
      field: "email",
      headerName: "fullName",
      width: 200,
      renderCell: (params) => {
        return (
          <div className="productListItem">
            {params.row.fullName}
          </div>
        );
      },
    },
  
    {
      field: "phone",
      headerName: "Phone",
      width: 120,
    },
    {
      field: "address",
      headerName: "Address",
      width: 160,
    },
    {
      field: "dob",
      headerName: "Birthday",
      width: 160,
    },
    {
      field: "gender",
      headerName: "Gender",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.gender === true ? "male" : "famale"}</div>;
      },
    },
    {
      field: "action",
      headerName: "Action",
      width: 150,
      renderCell: (params) => {
        return (
          <>
            <Switch className="productListDelete" {...label} />
          </>
        );
      },
    },
  ];

  return (
    <>
      <Topbar />
      <div className="container">
        <Sidebar />
        <div className="productList">
          {courtowners &&<DataGrid
            rows={courtowners}
            getRowId= {(rows) => rows.email}
            disableSelectionOnClick
            columns={columns}
            pageSize={8}
            checkboxSelection
            onCellDoubleClick={(params, event) => {
              if (!event.ctrlKey) {
                event.isDefaultMuiPrevented = true;
              }
            }}
          />}
        </div>
      </div>
    </>
  );
}
