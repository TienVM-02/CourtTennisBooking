
import React from "react";
import "./topbar.css";
import { NotificationsNone, Language, Settings } from "@material-ui/icons";
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import { Box ,Button} from "@material-ui/core";
import { Link } from 'react-router-dom';


export default function Topbar() {
  return (
    <div className="topbar">
      <div className="topbarWrapper">
        <div className="topLeft">
          <span className="logo">Tenisu Admin</span>
        </div>
        <div className="topRight">
          <div className="topbarIconContainer">
            <NotificationsNone />
            <span className="topIconBadge">2</span>
          </div>
          <div className="topbarIconContainer">
            
            <Link to={"/"}>
              <Button>
              <ExitToAppIcon />
              </Button>
            </Link>
            
          </div>

          <img src="https://scontent.fsgn2-6.fna.fbcdn.net/v/t39.30808-6/293023762_3229994973985708_6414400756070458991_n.jpg?stp=dst-jpg_p526x296&_nc_cat=100&ccb=1-7&_nc_sid=730e14&_nc_ohc=yREYBGTX_qEAX8-Jva1&_nc_ht=scontent.fsgn2-6.fna&oh=00_AT_6sJLvf3kdwvGVAfq67RDmpxPFjwLnyl24zmAR1FePKg&oe=62D5FD1F" alt="" className="topAvatar" />
        </div>
      </div>
    </div>
  );
}
