// import { Link } from "react-router-dom";
import "./court.css";
import * as React from "react";
import { DataGrid } from "@material-ui/data-grid";
import { DeleteOutline } from "@material-ui/icons";
import { userRows } from "../../../dummyData";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import Topbar from "../../../components/topbar/Topbar";
import SidebarOwner from "../../../components/sideBarOwner/SideBarOwner";
import { callAPIGetCourtOwner } from "../../../module/action/action";

export default function CourtList() {
  const [data, setData] = useState(userRows);

  const dispatch = useDispatch();
  const handleDelete = (id) => {
    setData(data.filter((item) => item.id !== id));
  };

  React.useEffect(() => {
    const callAPI = async () => {
      await dispatch(callAPIGetCourtOwner());
    };
    callAPI();
  }, [dispatch]);

  const listCourt = useSelector((state) => {
    return state.userReducer.listCourtOwner;
  });
  console.log(listCourt);

  const columns = [
    {
      field: "id",
      headerName: "ID",
      width: 200,
      renderCell: (params) => {
        return <div className="productListItem">{params.row.id}</div>;
      },
    },
    {
      field: "address",
      headerName: "Address",
      width: 160,
      renderCell: (params) => {
        return <div>{params.row.address}</div>;
      },
    },
    {
      field: "name",
      headerName: "Name",
      width: 200,
      renderCell: (params) => {
        return <div className="productListItem">{params.row.name}</div>;
      },
    },
    {
      field: "price",
      headerName: "Price",
      width: 120,
      renderCell: (params) => {
        return <div>{params.row.price}</div>;
      },
    },

    {
      field: "ownerId",
      headerName: "Owner ID",
      width: 160,
      renderCell: (params) => {
        return <div>{params.row.ownerId}</div>;
      },
    },
    {
      field: "group",
      headerName: "Group",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.group}</div>;
      },
    },
    {
      field: "rating",
      headerName: "Rating",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.rating}</div>;
      },
    },
    {
      field: "image",
      headerName: "Image",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.image}</div>;
      },
    },
    // {
    //   field: "owner",
    //   headerName: "Owner",
    //   width: 160,
    // },
    // {
    //   field: "booking",
    //   headerName: "Booking",
    //   width: 160,
    // },
    {
      field: "action",
      headerName: "Action",
      width: 150,
      renderCell: (params) => {
        return (
          <>
            {/* <Link to={"/owner/court" + params.row.id}>
                <button className="userListEdit">Edit</button>
              </Link> */}
            <DeleteOutline
              className="userListDelete"
              onClick={() => handleDelete(params.row.id)}
            />
          </>
        );
      },
    },
  ];

  return (
    <>
      <Topbar />
      <div className="container">
        <SidebarOwner />
        <div className="userList">
          {listCourt && (
            <DataGrid
              rows={listCourt}
              getRowId={(rows) => rows.id}
              disableSelectionOnClick
              columns={columns}
              pageSize={8}
              checkboxSelection
            />
          )}
        </div>
      </div>
    </>
  );
}
