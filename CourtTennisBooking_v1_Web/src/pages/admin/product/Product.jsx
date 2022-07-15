import { Link } from "react-router-dom";
import "./product.css";
// import Chart from "../../../components/chart/Chart"
// import {productData} from "../../../dummyData"
import { Publish } from "@material-ui/icons";

export default function Product() {
  return (
    <div className="product">
      <div className="productTitleContainer">
        <h1 className="productTitle">Court Owner</h1>
        <Link to="/admin/newproduct">
          <button className="productAddButton">Create</button>
        </Link>
      </div>
      <div className="productBottom">
          <form className="productForm">
              <div className="productFormLeft">
                  <label>Email</label>
                  <input type="text" placeholder="Email ..." />
                  <label>Owner Name</label>
                  <input type="text" placeholder="Apple AirPod" />
                  <label>Phone</label>
                  <input type="text" placeholder="Apple AirPod" />
                  <label>Address</label>
                  <input type="text" placeholder="Apple AirPod" />
                  <label>Birthday</label>
                  <input type="text" placeholder="Apple AirPod" />
                  <label>Gender</label>
                  <select name="active" id="active">
                      <option value="yes">Male</option>
                      <option value="no">Female</option>
                  </select>
                  <label>Active</label>
                  <select name="active" id="active">
                      <option value="yes">Yes</option>
                      <option value="no">No</option>
                  </select>
              </div>
              <div className="productFormRight">
                  <div className="productUpload">
                      <img src="https://images.pexels.com/photos/7156886/pexels-photo-7156886.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500" alt="" className="productUploadImg" />
                      <label for="file">
                          <Publish/>
                      </label>
                      <input type="file" id="file" style={{display:"none"}} />
                  </div>
                  <button className="productButton">Update</button>
              </div>
          </form>
      </div>
    </div>
  );
}
