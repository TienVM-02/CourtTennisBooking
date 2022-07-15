import Sidebar from "../../../components/sidebar/Sidebar";
import Topbar from "../../../components/topbar/Topbar";


import "./newProduct.css";

export default function NewProduct() {
  return (
    <>
      <Topbar />
      <div className="container">
        <Sidebar />
        <div className="productList">
          <div className="newProduct">
            <h1 className="addProductTitle">Create court</h1>
            <form className="addProductForm">
              <div className="addProductItem">
                <label>Image</label>
                <input type="file" id="file" />
              </div>
              <div className="addProductItem">
                <label>Name Court</label>
                <input type="text" placeholder="Enter court name..." />
              </div>
              <div className="addProductItem">
                <label>Address</label>
                <input type="text" placeholder="Enter court address..." />
              </div>
              <div className="addProductItem">
                <label>Price</label>
                <input type="text" placeholder="Price..." />
              </div>
              <div className="addProductItem">
                <label>Group</label>
                <input type="text" placeholder="Group..." />
              </div>
              <div className="addProductItem">
                <label>Rating</label>
                <input type="text" placeholder="Rating..." />
              </div>
              <button className="addProductButton">Create</button>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
