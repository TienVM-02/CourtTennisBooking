import "./userList.css";
import { DataGrid } from "@material-ui/data-grid";
import { DeleteOutline } from "@material-ui/icons";
import { Link } from "react-router-dom";
import Topbar from "../../../components/topbar/Topbar";
import Sidebar from "../../../components/sidebar/Sidebar";
import * as React from "react";
import { useDispatch, useSelector } from "react-redux";
import { callAPIGetListUser } from "../../../module/action/action";


export default function UserList(props) {
  // const [open, setOpen] = React.useState(false);
     
  const dispatch = useDispatch();

  React.useEffect(() => {
    const callAPI = async () => {
      await dispatch(callAPIGetListUser());
    };
    callAPI();
  }, []);

  const customer = useSelector((state) => {
    return state.userReducer.listUser;
  });
  console.log(customer);
  const {email}= props;
 

  const handleDelete = (email) => {};

  const columns = [
    
    {
      field: "fulname",
      headerName: "Full name",
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
      field: "email",
      headerName: "email",
      width: 200,
      renderCell: (params) => {
        return (
          <div className="productListItem">
            {params.row.email}
          
          </div>
        );
      },
    },
    {
      field: "phone",
      headerName: "Phone",
      width: 120,
      renderCell: (params) => {
        return <div className="userListUser">{params.row.phone}</div>;
      },
    },
    {
      field: "address",
      headerName: "Address",
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
            <Link to={"/admin/user/" + params.row.email}>
              <button className="userListEdit">Edit</button>
            </Link>
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
        <Sidebar />
        <div className="userList">
          {customer && 
            <DataGrid
              rows={customer}
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
            />
          }
        </div>
      </div>
    </>
  );
}
