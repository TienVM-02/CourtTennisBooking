import { combineReducers } from "redux";
import userReducer from "../module/reducer/reducer";

const rootReducer = combineReducers({
  userReducer,
});

export default rootReducer;
