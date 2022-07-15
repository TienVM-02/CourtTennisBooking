import "./sidebar.css";
import {
  PermIdentity,
  Storefront,
} from "@material-ui/icons";
import { Link } from "react-router-dom";

export default function SidebarOwner() {
  return (
    <div className="sidebar">
      <div className="sidebarWrapper">
        <div className="sidebarMenu">
          <h3 className="sidebarTitle">Owner task</h3>
          <ul className="sidebarList">
            <Link to="/owner/createCourt" className="link">
              <li className="sidebarListItem">
                <PermIdentity className="sidebarIcon" />
                Create court
              </li>
            </Link>
            <Link to="/owner/court" className="link">
              <li className="sidebarListItem">
                <Storefront className="sidebarIcon" />
                Court manager
              </li>
            </Link>
            <Link to="/owner/booking" className="link">
              <li className="sidebarListItem">
                <Storefront className="sidebarIcon" />
                Booking
              </li>
            </Link>
            <Link to="/owner/customer" className="link">
              <li className="sidebarListItem">
                <Storefront className="sidebarIcon" />
                Customer
              </li>
            </Link>
            <Link to="/owner/report" className="link">
              <li className="sidebarListItem">
                <Storefront className="sidebarIcon" />
                Report
              </li>
            </Link>
          </ul>
        </div>
      </div>
    </div>
  );
}
