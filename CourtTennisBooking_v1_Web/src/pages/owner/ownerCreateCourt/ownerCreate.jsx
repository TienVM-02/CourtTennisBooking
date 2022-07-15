
import SidebarOwner from "../../../components/sideBarOwner/SideBarOwner";
import Topbar from "../../../components/topbar/Topbar";
import { useForm } from "react-hook-form";
import { useDispatch } from "react-redux";
import { useFormik } from "formik";
import * as yup from "yup";
import axios from "axios";
import { FormHelperText, TextField } from "@material-ui/core";

import "./createCourt.css";

const schema = yup.object().shape({
  name: yup.string().required().trim(),
  price: yup.string().required().trim(),
  address: yup.string().required().trim(),
  id: yup.string().required().trim(),
  rating: yup.string().required().trim(),
  group: yup.string().required().trim(),


});
const email = JSON.parse(localStorage.getItem("account")).username;


export default function CreateCourt() {
  const dispatch = useDispatch();
  const formik = useFormik({
    validationSchema: schema,
    validateOnMount: true,
    validateOnBlur: true,
    initialValues: {
      name: "",
      group: "",
      address: "",
      rating: "",
      id: "",
      price: ""

    },
    
    onSubmit: async (values) => {
      console.log(values);
      const data = {
        id: formik.values.id,
        name: formik.values.name,
        price: formik.values.price,
        address: formik.values.address,
        group: formik.values.group,
        rating: formik.values.rating,
        ownerId:email
      }
      const res = await axios({
        method: "POST", url: "http://www.tennisv2.somee.com/api/v1.0/TennisCourts", data,
      })
      console.log(res);


    },
  }, []);

  let form = document.getElementById('AdminFormCreateCourt');
 
  const { register, handleSummit, errors } = useForm({
    mode: "onBlur"
  })



  return (
    <>
      <Topbar />
      <div className="container">
        <SidebarOwner />
        <div className="productList">
          <div className="newProduct">
            <h1 className="addProductTitle">Create court</h1>
            <form className="addProductForm" id="AdminFormCreateCourt"
              onSubmit={formik.handleSubmit}
            >
              <div className="addProductItem">
                <label>id</label>
                <TextField
                  id="outlined-basic"
                  label="id"
                  name="id"
                  value={formik.values.id}
                  variant="outlined"
                  onChange={(e) => {
                    formik.handleChange(e)
                  }}
                  onBlur={formik.handleBlur}
                />{formik.touched.id && formik.errors.id && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.id}
                  </FormHelperText>
                )}
              </div>
              <div className="addProductItem">
                <label>Name Court</label>
                <TextField
                  id="outlined-basic"
                  label="name"
                  name="name"
                  value={formik.values.name}
                  variant="outlined"
                  onChange={(e) => {
                    formik.handleChange(e)
                  }}
                  onBlur={formik.handleBlur}
                />{formik.touched.name && formik.errors.name && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.name}
                  </FormHelperText>
                )}
              </div>
              <div className="addProductItem">
                <label>Address</label>
                <TextField
                  id="outlined-basic"
                  label="address"
                  name="address"
                  value={formik.values.address}
                  onChange={formik.handleChange}
                  variant="outlined"
                />
                {formik.touched.address && formik.errors.address && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.address}
                  </FormHelperText>
                )}
              </div>
              <div className="addProductItem">
                <label>price</label>
                <TextField
                  id="outlined-basic"
                  label="price"
                  name="price"
                  value={formik.values.price}
                  onChange={formik.handleChange}
                  variant="outlined"
                />
                {formik.touched.price && formik.errors.price && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.price}
                  </FormHelperText>
                )}
              </div>
              <div className="addProductItem">
                <label>group</label>
                <TextField
                  id="outlined-basic"
                  label="group"
                  name="group"
                  value={formik.values.group}
                  onChange={formik.handleChange}
                  variant="outlined"
                />
                {formik.touched.group && formik.errors.group && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.group}
                  </FormHelperText>
                )}
              </div>
              <div className="addProductItem">
                <label>Rating</label>
                <TextField
                  id="outlined-basic"
                  label="rating"
                  name="rating"
                  value={formik.values.rating}
                  onChange={formik.handleChange}
                  variant="outlined"
                />
                {formik.touched.rating && formik.errors.rating && (
                  <FormHelperText
                    error
                    id="standard-weight-helper-text-username-login"
                  >
                    {formik.errors.rating}
                  </FormHelperText>
                )}
              </div>
              <button className="addProductButton">Create</button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
