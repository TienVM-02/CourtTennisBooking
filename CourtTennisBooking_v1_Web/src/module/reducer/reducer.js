import * as ActionType from "../constants/constants";
const initialState = {
  user: {},
  listUser: [],
  listCO: [],
  listCourtOwner: [],
  listCourtBooking: [],
};

// Use the initialState as a default value
export default function userReducer(state = initialState, { type, payload }) {
  switch (type) {
    case ActionType.GET_LIST_USER:
      state.listUser = payload;
      break;
    case ActionType.UPDATE_USER:
      break;
    case ActionType.GET_LIST_CO:
      state.listCO = payload;
      break;
    case ActionType.GET_COURT_OWNER:
      state.listCourtOwner = payload;
      break;
    case ActionType.GET_COURT_BOOKING:
      state.listCourtBooking = payload;
      break;
    default:
      break;
  }
  return { ...state };
}
