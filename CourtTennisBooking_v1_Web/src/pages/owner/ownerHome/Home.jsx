import Chart from "../../../components/chart/Chart";
import FeaturedInfo from "../../../components/featuredInfo/FeaturedInfo";
import "./home.css";
import { userData } from "../../../dummyData";
import WidgetSm from "../../../components/widgetSm/WidgetSm";
import WidgetLg from "../../../components/widgetLg/WidgetLg";
import Topbar from "../../../components/topbar/Topbar";
import SidebarOwner from "../../../components/sideBarOwner/SideBarOwner";

export default function OwnerHome() {
  return (
    <>
      <Topbar />
      <div className="container">
        <SidebarOwner />
        <div className="home">
          <FeaturedInfo />
          <Chart
            data={userData}
            title="User Analytics"
            grid
            dataKey="Active User"
          />
          <div className="homeWidgets">
            <WidgetSm />
            <WidgetLg />
          </div>
        </div>
      </div>
    </>
  );
}
