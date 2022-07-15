import { Navigate, useRoutes } from "react-router-dom";
import Home from "../pages/admin/home/Home";
import Login from "../pages/Login/login";
import NewProduct from "../pages/admin/newProduct/NewProduct";
import NewUser from "../pages/admin/newUser/NewUser";
import Product from "../pages/admin/product/Product";
import ProductList from "../pages/admin/productList/ProductList";
import User from "../pages/admin/user/User";
import UserList from "../pages/admin/userList/UserList";
import OwnerHome from "../pages/owner/ownerHome/Home";
import CreateCourt from "../pages/owner/ownerCreateCourt/ownerCreate";
import CourtList from "../pages/owner/ownerCourt/court";
import Customer from "../pages/owner/customer/customer";
import LoginCO from "../pages/Login/loginCO";
import BookingList from "../pages/owner/booking/booking";
// layouts

// ----------------------------------------------------------------------

export default function AppRouter() {
  return useRoutes([
    {
      path: "/",
        // element: <Login />,
      children: [
        { path: "login", element: <Login /> },
        { path: "loginRoleAD", element: <Login /> },
        { path: "loginRoleCO", element: <LoginCO /> },
        { path: "owner", element: <OwnerHome /> },
        { path: "owner/createCourt", element: <CreateCourt /> },
        { path: "owner/court", element: <CourtList /> },
        { path: "owner/booking", element: <BookingList /> },
        { path: "owner/customer", element: <Customer /> },
        { path: "owner/report", element: <OwnerHome /> },
        // { path: '404', element: <NotFound /> },
        { path: "*", element: <Navigate to="/404" /> },
      ],
    },
    {
      path: "/admin",
      children: [
        { path: "", element: <UserList /> },
        { path: "users", element: <UserList /> },
        { path: "user/:email", element: <User /> },
        { path: "newUser", element: <NewUser /> },
        { path: "products", element: <ProductList /> },
        { path: "product/:productId", element: <Product /> },
        { path: "newproduct", element: <NewProduct /> },
      ],
    },

    { path: "*", element: <Navigate to="/404" replace /> },
  ]);
}
