import Switch from "@material-ui/core/Switch";
import { Button } from "@material-ui/core";
import Box from "@material-ui/core/Box";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as yup from "yup";
import { useNavigate, Link } from "react-router-dom";
import "./login.css";
import API from "../../Axios/API";

const signInUserSchema = yup.object().shape({
  // email: yup
  //   .string()
  //   .required("* Email is required")
  //   .email("* Email is invalid"),
  username: yup.string().required("* Username is required"),
  password: yup.string().required("* Password is required"),
});
const label = { inputProps: { "aria-label": "Switch demo" } };
export default function Login() {
  const navigate = useNavigate();
  const handleLogInCO = async (values, { resetForm }) => {
    try {
      const res = await API(
        "POST",
        "http://www.tennisv2.somee.com/api/v1.0/User/LoginUser",
        values,
        null
      );
      localStorage.setItem("account", JSON.stringify(values));
      // console.log(res.data.data[0].roleId);
      if (res.data.data[0].roleId === "AD") {
        navigate("/admin");
      } else if (res.data.data[0].roleId === "OC") {
        navigate("/owner");
      }


    } catch (err) {
      console.log({ ...err });
      // notifiError("Login Fail!");
    }
    resetForm({ values: "" });
  };
  return (

    <div className="loginstyle container">
      <div className="d-flex justify-content-center h-100">
        <div className="card">
          <div className="card-header">
            <p className="name">Tenisu</p>
            <h3>Wellcome back!</h3>
          </div>
          <div className="card-body">
            <Formik
              initialValues={{
                username: "",
                password: "",
              }}
              validationSchema={signInUserSchema}
              onSubmit={handleLogInCO}
              render={(formilProps) => (
                <Form>
                  <div className="input-group form-group">
                    <div className="input-group-prepend">
                      <span className="input-group-text">
                        <i className="fas fa-user" />
                      </span>
                    </div>
                    <Field
                      name="username"
                      type="text"
                      className="input"
                      onChange={formilProps.handleChange}
                    />
                  </div>
                  <ErrorMessage name="username">
                    {(msg) => <div style={{ color: "red" }}>{msg}</div>}
                  </ErrorMessage>
                  <div className="input-group form-group">
                    <div className="input-group-prepend">
                      <span className="input-group-text">
                        <i className="fas fa-key" />
                      </span>
                    </div>
                    <Field
                      name="password"
                      type="password"
                      className="input"
                      data-type="password"
                      onChange={formilProps.handleChange}
                    />
                  </div>
                  <ErrorMessage name="password">
                    {(msg) => <div style={{ color: "red" }}>{msg}</div>}
                  </ErrorMessage>

                  <div className="switch">
                    <Switch {...label} defaultChecked />
                    <p>Stay Signed in </p>
                  </div>

                  <Box sx={{ display: "flex", flexDirection: "column" }}>
                    <Button
                      variant="contained"
                      sx={{ mb: "10px" }}
                      type="submit"
                    // onClick={()=>{
                    //   LoginAcc(formilProps.values.username,formilProps.values.password,navigate)
                    // }}
                    >
                      Login
                    </Button>
                    {/* <Link to={"/loginRoleAD"}>
                      <Button
                        sx={{
                          backgroundColor: "white",
                          color: "black",
                          mb: "10px",
                        }}
                      >
                        owner login
                      </Button>
                    </Link> */}
                  </Box>
                </Form>
              )}
            />
          </div>
        </div>
      </div>
    </div>


  );
}
