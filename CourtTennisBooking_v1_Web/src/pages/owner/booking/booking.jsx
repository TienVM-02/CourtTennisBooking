// import { Link } from "react-router-dom";
import "./booking.css";
import * as React from "react";
import { DataGrid } from "@material-ui/data-grid";
import { DeleteOutline } from "@material-ui/icons";
import { userRows } from "../../../dummyData";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import Topbar from "../../../components/topbar/Topbar";
import SidebarOwner from "../../../components/sideBarOwner/SideBarOwner";
import { apiGetBooking } from "../../../module/action/action";

export default function BookingList() {
  const [data, setData] = useState(userRows);

  const dispatch = useDispatch();
  const handleDelete = (id) => {
    setData(data.filter((item) => item.id !== id));
  };

  React.useEffect(() => {
    const callAPI = async () => {
      await dispatch(apiGetBooking());
    };
    callAPI();
  }, [dispatch]);

  const listBooking = useSelector((state) => {
    return state.userReducer.listCourtBooking;
  });
  console.log(listBooking);

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
      field: "cusId",
      headerName: "Cus Id",
      width: 160,
      renderCell: (params) => {
        return <div>{params.row.cusId}</div>;
      },
    },
    {
      field: "cusName",
      headerName: "Cus Name",
      width: 200,
      renderCell: (params) => {
        return <div className="productListItem">{params.row.cusName}</div>;
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
      field: "bookingDate",
      headerName: "Booking Date",
      width: 160,
      renderCell: (params) => {
        return <div>{params.row.bookingDate}</div>;
      },
    },
    {
      field: "courtId",
      headerName: "Court Id",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.courtId}</div>;
      },
    },
    {
      field: "status",
      headerName: "status",
      width: 160,
      renderCell: (params) => {
        return (
          <div className="userListUser">
            {params.row.status === true ? "Acitve" : "InActive"}
          </div>
        );
      },
    },
    {
      field: "createDate",
      headerName: "createDate",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.createDate}</div>;
      },
    },
    {
      field: "timeStart",
      headerName: "timeStart",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.timeStart}</div>;
      },
    },
    {
      field: "timeEnd",
      headerName: "timeEnd",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.timeEnd}</div>;
      },
    },
    {
      field: "ownerId",
      headerName: "ownerId",
      width: 160,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.ownerId}</div>;
      },
    },
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
          {listBooking && (
            <DataGrid
              rows={listBooking}
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
