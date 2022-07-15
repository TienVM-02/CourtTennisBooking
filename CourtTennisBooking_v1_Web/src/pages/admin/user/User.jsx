import {
  CalendarToday,
  LocationSearching,
  MailOutline,
  PartyMode,
  PermIdentity,
  PhoneAndroid,
  Publish,
} from "@material-ui/icons";
import { Link } from "react-router-dom";
import Sidebar from "../../../components/sidebar/Sidebar";
import Topbar from "../../../components/topbar/Topbar";
import "./user.css";
import { useParams } from "react-router-dom";
import axios from "axios";
import { useEffect, useState } from "react";
import React from "react";
import { updateUser } from "../../../module/action/action";
import { useFormik } from "formik";
import * as yup from "yup";
import { useDispatch } from 'react-redux';
import { FormHelperText, TextField } from "@material-ui/core";


const schema = yup.object().shape({
  fullName: yup.string().required().trim(),
  phone: yup.string().required().trim(),
  address: yup.string().required().trim(),
 
});

export default function User(email) {
  email = useParams();
  console.log(email);
  const [user, setUser] = React.useState({});
  useEffect(() => {
    axios.get(`http://www.tennisv2.somee.com/api/v1.0/Customers?search=${email.email}&page=1`)
      .then((res) => {
        console.log(res);
        setUser(res.data.data[0])
      })
      .catch((err) => { console.log(err); })

  }, [])


  const dispatch = useDispatch();
  const formik = useFormik({
    validationSchema: schema,
    validateOnMount: true,
    validateOnBlur: true,
    initialValues: {
      fullName: "",
      phone: "",
      address: "",
    

    },
    onSubmit: async (values) => {
      console.log(values);
      const data = {
        fullName: formik.values.fullName,
        phone: formik.values.phone,
        address: formik.values.address,
       
      }

      console.log(data);

      dispatch(updateUser(values, email.email))
    },
  }, []);


  console.log(user);
  return (
    <>
      <Topbar />
      <div className="container">
        <Sidebar />
        <div className="user">
          <div className="userTitleContainer">
            <h1 className="userTitle">Edit User</h1>
            <Link to="/admin/newUser">
              <button className="userAddButton">Create</button>
            </Link>
          </div>
          <div className="userContainer">
            <div className="userShow">
              <div className="userShowTop">
                <img
                  src="https://images.pexels.com/photos/1152994/pexels-photo-1152994.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
                  alt=""
                  className="userShowImg"
                />
                <div className="userShowTopTitle">
                  <span className="userShowUsername">{user.fullName}</span>
                  <span className="userShowUserTitle">Customer</span>
                </div>
              </div>
              <div className="userShowBottom">
                <span className="userShowTitle">Account Details</span>
                <div className="userShowInfo">
                  <PermIdentity className="userShowIcon" />
                  <span className="userShowInfoTitle">{user.fullName}</span>
                </div>
                <span className="userShowTitle">Contact Details</span>
                <div className="userShowInfo">
                  <PhoneAndroid className="userShowIcon" />
                  <span className="userShowInfoTitle">{user.phone}</span>
                </div>
                <div className="userShowInfo">
                  <MailOutline className="userShowIcon" />
                  <span className="userShowInfoTitle">
                    {user.email}
                  </span>
                </div>
                <div className="userShowInfo">
                  <LocationSearching className="userShowIcon" />
                  <span className="userShowInfoTitle">{user.address}</span>
                </div>
              </div>
            </div>
            <div className="userUpdate">
              <span className="userUpdateTitle">Edit</span>
              <form className="userUpdateForm" onSubmit={formik.handleSubmit}>
                <div className="userUpdateLeft">
                  <div className="userUpdateItem">
                    <label>Full Name</label>
                    <TextField
                      id="outlined-basic"
                      label="fullName"
                      name="fullName"
                      value={formik.values.fullName || ""}
                      variant="outlined"
                      placeholder={user.fullName}
                      onChange={(e) => {
                        formik.handleChange(e)
                      }}
                      onBlur={formik.handleBlur}
                    />{formik.touched.fullName && formik.errors.fullName && (
                      <FormHelperText
                        error
                        id="standard-weight-helper-text-username-login"
                      >
                        {formik.errors.fullName}
                      </FormHelperText>
                    )}
                  </div>
                  <div className="userUpdateItem">
                    <label>Phone</label>
                    <TextField
                      id="outlined-basic"
                      label="phone"
                      name="phone"
                      value={formik.values.phone || ""}
                      variant="outlined"
                      placeholder={user.phone}
                      onChange={(e) => {
                        formik.handleChange(e)
                      }}
                      onBlur={formik.handleBlur}
                    />{formik.touched.phone && formik.errors.phone && (
                      <FormHelperText
                        error
                        id="standard-weight-helper-text-username-login"
                      >
                        {formik.errors.phone}
                      </FormHelperText>
                    )}
                  </div>
                  <div className="userUpdateItem">
                    <label>Address</label>
                    <TextField
                      id="outlined-basic"
                      label="address"
                      name="address"
                      value={formik.values.address || ""}
                      variant="outlined"
                      placeholder={user.address}
                      onChange={(e) => {
                        formik.handleChange(e)
                      }}
                      onBlur={formik.handleBlur}
                    />{formik.touched.address && formik.errors.address && (
                      <FormHelperText
                        error
                        id="standard-weight-helper-text-username-login"
                      >
                        {formik.errors.address}
                      </FormHelperText>
                    )}
                  </div>
                </div>
                <div className="userUpdateRight">
                  <div className="userUpdateUpload">
                    <img
                      className="userUpdateImg"
                      src="https://images.pexels.com/photos/1152994/pexels-photo-1152994.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
                      alt=""
                    />
                    <label htmlFor="file">
                      <Publish className="userUpdateIcon" />
                    </label>
                    <input type="file" id="file" style={{ display: "none" }} />
                  </div>
                  <button className="userUpdateButton" >Update</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
